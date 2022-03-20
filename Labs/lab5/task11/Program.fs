open Functions

let answer lang =
    match lang with
    | "F#" -> "Подлиза"
    | "Php" | "Python" -> "Кринж"
    | "Swift" -> "Сразу видно - хороший человек"
    | other -> $"Впервые слышу о {other}"

[<EntryPoint>]
let main argv =
    let lang = argv[0]
    printfn "%s"(answer lang)
    0