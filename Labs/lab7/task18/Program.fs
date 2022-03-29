open Functions

[<EntryPoint>]
let main argv =
    let n1 = argv[0] |> int
    let n2 = argv[1] |> int
    let array1 = readArray n1
    let array2 = readArray n2
    
    printfn "%A"(Array.concat [|array1; array2|])
    0