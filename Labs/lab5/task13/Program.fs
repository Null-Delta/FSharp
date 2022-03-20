open Functions

let rec multSum =
    function
    | 0 -> 1
    | value -> (value % 10) * multSum (value / 10)

let rec minNumber =
    function
    | a when a < 10 -> a
    | value -> min (value % 10) (minNumber (value / 10))

let rec maxNumber =
    function
    | a when a < 10 -> a
    | value -> max (value % 10) (maxNumber (value / 10))

let tailMultSum value =
    let rec _tailMultSum value result =
        match value with
        | 0 -> result
        | _ -> 
            let newValue = value / 10
            let newResult = result * (value % 10)
            _tailMultSum newValue newResult
    _tailMultSum value 1

let tailMinNumber value = 
    let rec _tailMinNumber value minimum =
        match value with
        | 0 -> minimum
        | _ -> 
            let newValue = value / 10
            let newMin = min minimum (value % 10)
            _tailMinNumber newValue newMin
    _tailMinNumber value 9

let tailMaxNumber value = 
    let rec _tailMaxNumber value maximum =
        match value with
        | 0 -> maximum
        | _ -> 
            let newValue = value / 10
            let newMax = max maximum (value % 10)
            _tailMaxNumber newValue newMax
    _tailMaxNumber value 0

[<EntryPoint>]
let main argv =
    let number = argv[0] |> int

    printfn "произведение чисел (рекурсия вверх):"
    number |> multSum |> printfn "%d"
    printfn "произведение чисел (хвостовая рекурсия):"
    number |> tailMultSum |> printfn "%d"

    printfn "минимальная цифра (рекурсия вверх):"
    number |> minNumber |> printfn "%d"
    printfn "минимальная цифра (хвостовая рекурсия):"
    number |> tailMinNumber |> printfn "%d"

    printfn "максимальная цифра (рекурсия вверх):"
    number |> maxNumber |> printfn "%d"
    printfn "максимальная цифра (хвостовая рекурсия):"
    number |> tailMaxNumber |> printfn "%d"
    0