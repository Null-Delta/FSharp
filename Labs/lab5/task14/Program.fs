open Functions

let processDividers x (action: int -> int -> int) = 
    let rec _getDividers init result =
        match init with
        | value when value = x -> action value result
        | _ -> 
            let nextInit = init + 1
            let nextResult = if x % init = 0 then action result init else result
            _getDividers nextInit nextResult
    _getDividers 1 0

[<EntryPoint>]
let main argv =
    let input = argv[0] |> int
    printfn "%d"(processDividers input (fun x y -> x + y))
    0