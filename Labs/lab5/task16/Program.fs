open Functions
    
let Eiler n =
    convolution (fun v -> NOD v n == 1) (fun v1 v2 -> v1 + 1) 1 n 0

[<EntryPoint>]
let main argv =
    let n = argv[0] |> int
    let m = argv[1] |> int

    printfn "%d"(NOD n m)
    printfn "%d"(Eiler n)
    0