open System
open Functions

let makeRange (list: int list) = 
    let mid = ((List.fold (fun state value -> state + value) 0 list) / list.Length) |> int
    List.filter (fun x -> x > mid) list
    
[<EntryPoint>]
let main argv =
    let n = argv[0] |> int

    let list = readList n
    
    printfn "%A"(makeRange list)
    0