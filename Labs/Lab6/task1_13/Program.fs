open Functions

let rec moveBack list =
    let min = listMinIndex list
    
    let rec _moveBack index list =
        match list with
        | h::t when h == min -> list
        | _ ->
            let newList = list.Tail@[list.Head]
            _moveBack min newList

    _moveBack min list

[<EntryPoint>]
let main argv =
    let n = argv[0] |> int
    let list = readList n
    printfn "%A"(moveBack list)
    0