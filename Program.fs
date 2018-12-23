// Learn more about F# at http://fsharp.net


// Opening and closing the solution
//> let dtetype = Type.GetTypeFromProgID("VisualStudio.DTE.9.0");;
//
//val dtetype : Type = System.__ComObject
//
//> let dte = Activator.CreateInstance(dtetype) :?> EnvDTE.DTE;;
//
//val dte : EnvDTE.DTE
//
//> dte.Solution;;
//val it : EnvDTE.Solution = seq []
//> dte.Solution.Open("C:/Views/iSiteClient/branches/Hilo/iSiteClient/Products/Src/iSiteClient.sln");;
//val it : unit = ()
//> dte.Solution.Count
//- ;;
//val it : int = 70
//> dte.Solution.Close();;
//val it : unit = ()
//> dte.Quit();;
//val it : unit = ()
//>

module Sln2NMakeProgram

open System
open System.IO
open CommandLine
open Sln2NMake
open System.Text
open System.Text.RegularExpressions
open Sln2NMakeLexer
open Sln2NMakeParser
open Microsoft.FSharp.Text.Lexing;
open Ast


    




[<EntryPoint>]
let main args = 
  assert(false)
  let programOptions = args |> UsingProgramOptions.Create |> UsingProgramOptions.Check
  let (inputStreamOption, outputStreamOption) = (programOptions.Value.InputStream(), programOptions.Value.OutputStream())
  let FileStreams() = 
    { 
      new IDisposable with
        member this.Dispose() = 
          do
            inputStreamOption.Value.Dispose()
            outputStreamOption.Value.Dispose()
    }
  use fileStreams = FileStreams()
  let streamReader = new StreamReader(inputStreamOption.Value, Encoding.ASCII)
  //let linesSeq = streamReader |> Seq.unfold ( fun sr -> if sr.Peek() >= 0 then Some(sr.ReadLine(), sr) else None)
  let lexBuff = LexBuffer<char>.FromTextReader(streamReader)

  try 
(*
    let ast = Sln2NMakeParser.START Sln2NMakeLexer.Tokenize lexBuff
    let _ = PrettyPrint.SolutionFile ast 1
    let projectLookupTable = MakeFileGenerator.MakeProjectLookUpTable ast
    let allTargets = String.Format("all: {0}\n", MakeFileGenerator.AllProjectTargets projectLookupTable)
    let targetList = MakeFileGenerator.ProjectTargetList projectLookupTable
    let solutionConfigList = MakeFileGenerator.MakeSolutionConfigPlatforms ast
    let makefileInfo = new FileInfo(".\\makefile")
    let makefileStream = makefileInfo.OpenWrite()
    let makeFileStreamWriter = new StreamWriter(makefileStream)
    in 
    makeFileStreamWriter.WriteLine("CONFIG=Debug");
    makeFileStreamWriter.WriteLine("PLATFORM=Win32");
    makeFileStreamWriter.WriteLine();
    makeFileStreamWriter.WriteLine(allTargets.ToString());
    makeFileStreamWriter.WriteLine();
    makeFileStreamWriter.Close();
*)
    0
  with
  | ex -> raise(System.Exception(System.String.Format("Parse Failed at line {0}, column {1}({2})",
                                                      lexBuff.StartPos.Line, lexBuff.StartPos.Column, 
                                                      new System.String(lexBuff.Lexeme))))
                                               
