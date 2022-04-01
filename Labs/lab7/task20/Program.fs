open Functions
open System

let alphabet = ['а'..'я']

let charFequences string =
    stringFold (fun state char ->
        List.map (fun feq ->
            (fst feq, snd feq + if fst feq == char then 1.0 else 0.0)
        ) state
    ) (List.map (fun x -> (x, 0.0)) alphabet) string

let maxFequence (list: (char * float) list) =
    (List.sortBy (fun x -> -(snd x)) list).Head

let solution1 strings = 
    let text = concatinate ' ' strings
    let allFequences = charFequences text
    List.sortBy (fun string -> 
        let maxFeq = maxFequence (charFequences string)
        let stringFeq =  (snd maxFeq) / (string.Length |> float)
        let textFeq = (List.fold ( fun state value ->
            match value with
            | a when fst a == (fst maxFeq) -> snd maxFeq
            | _ -> state
        ) 0.0 allFequences) / (text.Length |> float)
        abs (stringFeq - textFeq)
    ) strings

[<EntryPoint>]
let main argv = 
    //let index = argv[0] |> int
    let n = Console.ReadLine() |> int

    let strings = readStrings n

    printfn "%A"(solution1 strings)
    0