open Methods
open System

let getFun index =
    match index with
    | 1 -> maxEasyDivider
    | 2 -> multValues
    | _ -> method3

[<EntryPoint>]
let main argv =
    let input = (Console.ReadLine() |> int,Console.ReadLine() |> int)
    
    //каррирование
    fst <| input |> getFun <| (snd <| input) |> printfn "%d"

    //композиция
    printfn "%d" ((Console.ReadLine >> int >> (fun x -> Console.ReadLine >> int >> getFun x))()())

    //композиция, но ввод в переменной
    let input2 = (Console.ReadLine >> int,Console.ReadLine >> int)

    let index = fst input2
    let value = snd input2
    
    printfn "%d" ((index >> (fun x -> value >> getFun x))()())
    0