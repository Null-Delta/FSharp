open Functions

let rec makeMove (list: int list) = list.Tail@[list.Head]

[<EntryPoint>]
let main argv =
    let n = argv[0] |> int
    let list = readList n
    printfn "%A"(makeMove list)
    0