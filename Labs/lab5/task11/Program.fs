open Functions

let answer =
    function
    | "F#" -> "Подлиза"
    | "Php" | "Python" -> "Кринж"
    | "Swift" -> "Сразу видно - хороший человек"
    | other -> $"Впервые слышу о {other}"

[<EntryPoint>]
let main argv =
    printfn "Какой твой любимый язык программирования?"
    let lang = System.Console.ReadLine()
    printfn "%s"(answer lang)
    0