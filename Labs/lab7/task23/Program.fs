open Functions
open System

let find2Min (list: int list) = 
    List.fold (fun (state: int * int) (value: int) -> 
        match value with
        | _ when fst state > value || snd state > value -> (value, min (fst state) (snd state))
        | _ -> state
    ) (list.Head, list.Tail.Head) list.Tail.Tail

[<EntryPoint>]
let main argv =
    let n = argv[0] |> int

    let list = readList n
    
    printfn "%A"(find2Min list)
    0