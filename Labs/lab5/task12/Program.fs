open Functions

[<EntryPoint>]
let main argv =
    let answer =
        function
        | "F#" -> "Подлиза"
        | "Php" | "Python" -> "Кринж"
        | "Swift" -> "Сразу видно - хороший человек"
        | other -> $"Впервые слышу о {other}"
    printfn "Какой твой любимый язык программирования?"
    
    System.Console.ReadLine() |> answer |> printfn "%s"
    (System.Console.ReadLine >> answer >> printfn "%s")()
    0