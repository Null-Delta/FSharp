open System
open Functions

let isMax (list: int list) index = 
    let max = List.fold (fun state value -> max value state) list.Head list.Tail
    List.findIndex (fun x -> x == max) list == index
    
[<EntryPoint>]
let main argv =
    let n = argv[0] |> int

    let list = readList n
    printfn "%A"(isMax list 5)
    0