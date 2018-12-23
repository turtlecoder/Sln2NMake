(* Fix paths for release *)
#r @"bin\Debug\MessageFilterImpl.dll"
#r @"bin\Debug\Sln2NMake.VisualStudioAutomation.Interfaces.dll"
#r @"System.ComponentModel.Composition.dll"
#r @"bin\Debug\ImpromptuInterface.dll"
#r @"bin\Debug\ImpromptuInterface.FSharp.dll"


//namespace Sln2NMake

open MessageFilterImpl;
open System.ComponentModel.Composition
open System.ComponentModel.Composition.Hosting
open System.Collections.Generic
open Sln2NMake.VisualStudioAutomation.Interfaces
open System.Diagnostics;
open System.Reflection;
open ImpromptuInterface
open ImpromptuInterface.FSharp

(* Creating a new type to import the plugins for Visual Studio *)

type AutomationPlugins() = 
  class 
    (* The container that will hold all the composed parts *)
    [<DefaultValue(true)>]
    val mutable private _container:CompositionContainer

    (* Change the metadata to access more strongly type metadata *)
    let mutable _DTEFactories:IEnumerable<System.Lazy<IDTEFactory, IDictionary<string,System.Object> > > = null

    [<ImportMany>]
    member public this.DTEFactories
      with get() = _DTEFactories
      and set(value) = _DTEFactories <- value
    
    member public this.Compose() = 
      (* Check if directory exists *)
      let mutable catalog = new AggregateCatalog()
      
      Assembly.Load(@"bin\Debug\Sln2NMake.VisualStudio2010Automation") 
        |> fun assembly -> new AssemblyCatalog(assembly) 
        |>  catalog.Catalogs.Add
      this._container <- new CompositionContainer(catalog)
      this._container.ComposeParts(this)
  end

(* Register the Message Filter *)

module AutomationTests = 
  MessageFilter.Register()
  let automationPlugins = new AutomationPlugins()
  automationPlugins.Compose()
  let dteFactory = automationPlugins.DTEFactories |> Seq.head |> fun lv -> lv.Value
  let dte = dteFactory.CreateDTE()

  let solution = dte.Solution
  solution.Open(@"c:\views\isiteclient\trunk\isiteclient\products\src\isiteclient.sln")
  let solutionProjects = solution.Projects
  let uiLibraryProjectItems = solutionProjects 
                                |> Seq.toList
                                |> fun pl -> pl.[3].ProjectItems 
                                |> Seq.toList
  let vcppProject3 = uiLibraryProjectItems.[0].SubProject :?> IVCppProject
  printf "%s %s" vcppProject3.Name  vcppProject3.Kind
  printf "Using Dynamic Look up for Project 3 %s" vcppProject3.Object?Name
  let vcppProject3Configs = vcppProject3.Files |> Seq.nth 10 |> fun f -> f.FileConfigurations
  
  (*
vcppProject3.Files |> Seq.nth 10|> fun f -> f.FileConfigurations |> Seq.nth 0 |> (fun cfg -> cfg.CustomBuildRule);;
   *)