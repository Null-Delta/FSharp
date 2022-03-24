open Functions

let maxEasyDivider value =
    convolution (fun x -> value % x = 0 && isEasy x) (fun x y -> y) 2 (value - 1) 1

let rec multValues fromValue init =
    match fromValue with
    | 0 -> init
    | _ -> 
        let newInit = if fromValue % 5 = 0 then init else init * (fromValue % 10)
        let newValue = fromValue / 10
        multValues newValue newInit

[<EntryPoint>]
let main argv =
    let n = argv[0] |> int
    //printfn "%d"(maxEasyDivider n)
    printfn "%d"(multValues n 1)
    0