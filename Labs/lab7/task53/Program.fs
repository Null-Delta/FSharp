open System
open Functions

let makeRange (list: int list) = 
    let mid = ((List.fold (fun state value -> state + value) 0 list) / list.Length) |> int
    let max = List.fold (fun state value -> max value state) list.Head list.Tail

    List.filter (fun x -> x > mid && x < max) list
    
[<EntryPoint>]
let main argv =
    let n = argv[0] |> int

    let list = readList n
    
    printfn "%A"(makeRange list)
    0