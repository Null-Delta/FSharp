open Functions
open System

let minCount (list: int list) = 
    snd (List.fold (fun (state: int * int) (value: int) -> 
        match value with
        | _ when fst state = value -> (fst state, snd state + 1)
        | _ when fst state > value -> (value, 1)
        | _ -> state
    ) (list.Head, 1) list.Tail)

[<EntryPoint>]
let main argv =
    let n = argv[0] |> int

    let list = readList n
    
    printfn "%A"(minCount list)
    0