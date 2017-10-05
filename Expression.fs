module Expression

  open Codegen

  type CodegenBuilder() =

    member __.Return _ = Codegen.init()

    member __.Bind(c,f) = Codegen.bind c f

    [<CustomOperation ("newLine", MaintainsVariableSpaceUsingBind = true)>]
    member __.NewLine(c) = Codegen.newLine c

    [<CustomOperation ("useIndent", MaintainsVariableSpaceUsingBind = true)>]
    member __.UseIndent(c,f) = Codegen.useIndent c f

    [<CustomOperation ("append", MaintainsVariableSpaceUsingBind = true)>]
    member __.Append(c,s) = Codegen.append c s

    [<CustomOperation ("appendLine", MaintainsVariableSpaceUsingBind = true)>]
    member __.AppendLine(c,s) = Codegen.appendLine c s

  let codegen = CodegenBuilder()