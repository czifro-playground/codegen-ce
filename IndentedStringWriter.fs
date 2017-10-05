module StringWriter

  open System
  open System.IO

  type IndentedStringWriter() =
    inherit StringWriter() with

      let indentSize = 4
      let mutable indentLevel = 0
      let mutable indentPending = false

      let getIndent() =
        if indentPending && indentLevel > 0 then
          indentPending <- false
          ("",[| for i in 1..(indentSize * indentLevel) -> " " |])
          |> String.Join
        else ""

      override __.Write(v:string) =
        let indent = getIndent()
        base.Write (indent + v)

      override __.WriteLine() =
        indentPending <- true
        base.WriteLine()

      member __.IncrementIndent() =
        indentLevel <- indentLevel + 1

      member __.DecrementIndent() =
        indentLevel <- indentLevel - 1

      member this.Indent() = new Indenter(this)

  and Indenter(isw:IndentedStringWriter) =
    do
      isw.IncrementIndent()

    interface IDisposable with

      override __.Dispose() = isw.DecrementIndent()