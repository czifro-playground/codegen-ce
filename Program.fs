// Learn more about F# at http://fsharp.org

open System
open Codegen
open Expression

let innerCodegen =
  codegen {
    append "printfn \"Hello World!\""
  }

let simpleCodegen =
  codegen {
    appendLine "let test ="
    useIndent innerCodegen
  }

[<EntryPoint>]
let main argv =
  printfn "%s" (Codegen.result simpleCodegen)
  0 // return an integer exit code
