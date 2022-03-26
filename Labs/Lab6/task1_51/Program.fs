open Functions

let rec unrepeatableValues list =
    match list with
    | h::t ->
        let newList = listFilter (fun x -> x <> h) list
        h::(unrepeatableValues newList)
    | [] -> []

let countList sourceList firstList =
    listMap 
        (fun x -> (listFilter (fun y -> y == x) sourceList).Length)
        firstList

[<EntryPoint>]
let main argv =
    let n = argv[0] |> int
    let list = readList n

    let values = unrepeatableValues list
    let counts = countList list values
    printfn "%A"(values)
    printfn "%A"(counts)
    0