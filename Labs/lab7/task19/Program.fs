open Functions
open System

let solution8 value =
    stringFold (fun state char -> 
        match char with
        | ' ' -> 
            if (snd state) % 2 == 0 then ((fst state) + 1, 0) else (fst state, 0)
        | _ -> (fst state, (snd state) + 1)
    ) (0, 0) value |> fst

let solution16 list =
    List.sortBy (fun value ->
        match value with
        | "белый" -> 1
        | "синий" -> 2
        | _ -> 3
    ) list

let solution3 value = 
    value |>
    splitString ' ' |>
    List.sortBy (fun x -> 
        (new System.Random()).Next(1, 1000)
    ) |>
    concatinate ' ' 


[<EntryPoint>]
let main argv =

    let n = argv[0] |> int

    match n with
    | 1 -> 
        let list = Console.ReadLine()
        printfn "%A"(solution3 list)
    | 2 ->
        let list = Console.ReadLine()
        printfn "%A"(solution8 list)
    | _ -> 
        let list = [Console.ReadLine();Console.ReadLine();Console.ReadLine()]
        printfn "%A"(solution16 list)
    0