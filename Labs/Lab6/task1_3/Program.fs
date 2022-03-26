open Functions

let checkMax list index = 
    let checkValue = listValueAtIndex index list
    (listFilter (fun x -> x > checkValue) list).Length == 0

[<EntryPoint>]
let main argv =
    let n = argv[0] |> int
    let index = argv[1] |> int
    let list = readList n
    printfn "%b"(checkMax list index)
    0