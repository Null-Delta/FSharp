open Functions
open System

let isToToTo (list: int list) = 
    fst (List.fold (fun (state: bool * int) (value: int) -> 
        match value with
        | _ when fst state = false -> state
        | _ -> ( snd state % 2 <> value % 2, value)
    ) (true, list.Head) list.Tail)

[<EntryPoint>]
let main argv =
    let n = argv[0] |> int

    let list = readList n
    
    printfn "%A"(isToToTo list)
    0