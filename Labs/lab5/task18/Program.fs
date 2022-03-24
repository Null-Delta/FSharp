module Methods
open Functions

let maxEasyDivider value =
    convolution (fun x -> value % x = 0 && isEasy x) (fun x y -> y) 2 (value - 1) 1

let multValues fromValue =
    let rec _multValues from init =
        match from with
        | 0 -> init
        | _ -> 
            let newInit = if from % 5 = 0 then init else init * (from % 10)
            let newValue = from / 10
            _multValues newValue newInit
    _multValues fromValue 1

let method3 value =
    let mult = multValues value
    let maxUndivider = convolution (fun x -> value % x = 0 && not (isEasy x) && x % 2 = 1) (fun x y -> y) 2 (value - 1) 1
    NOD mult maxUndivider

[<EntryPoint>]
let main argv =
    let n = argv[0] |> int
    printfn "%d"(method3 n)
    0