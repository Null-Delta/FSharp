open System
open Functions

let isMax (list: int list) index = 
    let min = List.fold (fun state value -> min value state) list.Head list.Tail
    
    let front = 
        List.fold (fun (state: bool * int list) (value: int) ->
            match state with
            | (s, v) when s && value != min -> (true, value::v)
            | (_, v) when value = min -> (false, v) 
            | (s,v) -> (false, v)
        ) (true, []) list |> snd

    let back = 
        List.fold (fun (state: bool * int list) (value: int) ->
            match state with
            | (s, v) when s -> (true, v@[value])
            | (s, v) when not s && value = min -> (true, v@[value]) 
            | (s,v) -> (false, v)
        ) (false, []) list |> snd

    back@front
    
[<EntryPoint>]
let main argv =
    let n = argv[0] |> int
    let index = argv[1] |> int

    let list = readList n
    printfn "%A"(isMax list index)
    0