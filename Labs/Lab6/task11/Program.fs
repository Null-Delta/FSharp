open Functions

let rec convert list (func: int -> int -> int -> int) =
    match list with 
    | a::b::c::t -> (func a b c) :: (convert t func)
    | a::b::[] -> (func a b 1) :: (convert [] func)
    | a::[] -> (func a 1 1) :: (convert [] func)
    | [] -> []
[<EntryPoint>]
let main argv =
    let n = argv[0] |> int
    let list = readList n

    printfn "%A"(convert list (fun x y z -> x + y + z))
    0