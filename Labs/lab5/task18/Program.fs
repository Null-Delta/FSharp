open Functions

let maxEasyDivider value =
    convolution (fun x -> value % x = 0 && isEasy x) (fun x y -> y) 2 (value - 1) 1

[<EntryPoint>]
let main argv =
    let n = argv[0] |> int
    printfn "%d"(maxEasyDivider n)
    0