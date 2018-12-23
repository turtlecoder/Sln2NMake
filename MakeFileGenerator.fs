module MakeFileGenerator

open System
open System.Collections.Generic
open Ast
open System.Text


let MakeProjectDependencyList projectDependencyList = 
  projectDependencyList 
    |> List.map (fun dependency -> match dependency with | Ast.ProjectDependency(guid) -> guid)

let MakeProjectLookUpTable ast =
  match ast with 
  | Ast.SolutionFile((Ast.Version(_), projectList, _)) ->
      projectList 
      |> List.toSeq 
      |> Seq.map (fun project -> 
                    match project with
                    | Ast.Project(Ast.ProjectInfo(_,Ast.ProjectName(name),Ast.ProjectPath(path), Ast.ProjectGuid(guid)), projectDependencyList) ->
                       (guid, (name, path, (MakeProjectDependencyList projectDependencyList))))
      |> Map.ofSeq 

let AllProjectTargets (projectLookupTable:seq<KeyValuePair<Guid,String*String*Guid list>>) =
  Seq.fold (fun (accum:StringBuilder) (kvp:KeyValuePair<Guid,String*String*Guid list>) -> 
              accum.Append(" ").Append(kvp.Value |> (fun (name, _ , _) -> name)))
           (new StringBuilder()) 
           projectLookupTable


let rec VisitSolutionConfigurationGlobalSection globalSectionList = 
  match globalSectionList with
  | SolutionConfigurationPlatforms(theSolutionConfigs)::_ ->
      Some(theSolutionConfigs)
  | _::tail -> VisitSolutionConfigurationGlobalSection tail
  | [] -> None


let MakeSolutionConfigPlatforms ast = 
  match ast with
  | Ast.SolutionFile((_, _,globalSectionList)) ->
      (VisitSolutionConfigurationGlobalSection globalSectionList).Value
    