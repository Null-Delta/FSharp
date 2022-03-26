open Functions

let rec localMax list index =
    match list with
    | a::b::c::t when index == 1 -> b > a && b > c
    | a::b::[] when index == 1 -> b > a
    | a::b::t when index == 0 -> a > b
    | _ -> 
        let newIndex = index - 1
        let newList = list.Tail
        localMax newList newIndex

[<EntryPoint>]
let main argv =
    let n = argv[0] |> int
    let index = argv[1] |> int

    let list = readList n

    printfn "%b"(localMax list index)
    0