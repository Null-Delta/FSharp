open Functions

let rec getRangeSum a b list =
    let rec _getRangeSum iter init list = 
        match list with
        | [] -> init
        | h::t -> 
            let newInit = 
                if h >= a && h <= b then init + h
                else init
            let newIter = iter + 1
            
            _getRangeSum newIter newInit t

    _getRangeSum 0 0 list

[<EntryPoint>]
let main argv =
    let n = argv[0] |> int
    let a = argv[1] |> int
    let b = argv[2] |> int
    
    let list = readList n

    printfn "%d"(getRangeSum a b list)
    0