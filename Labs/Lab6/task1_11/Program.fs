open Functions

let rec findIndividual list =
    match list with
    | a::b::c::t -> 
        match a,b,c with
        | (x,y,z) | (y,x,z) | (y,z,x) when x <> y && y = z -> Some(x)
        | _ -> findIndividual (b::c::t)
    | _ -> None
         
[<EntryPoint>]
let main argv =
    let n = argv[0] |> int
    
    let list = readList n
    let result = findIndividual list

    printfn "%s"(if result.IsNone then "значений не найдено" else result.Value |> string)
    0