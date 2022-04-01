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

let ascii char = int char - int '0'


let asciiWeight string = (stringFold (fun sum v -> sum + float (ascii v)) 0.0 string) / (float string.Length)

let solution2 (strings: string list) =
    let first = strings.Head
    let firstWeight = asciiWeight first
    List.sortBy (fun x -> pown ((asciiWeight x) - firstWeight) 2) strings

[<EntryPoint>]
let main argv = 
    let index = argv[0] |> int
    match index with
    | 1 -> 
        let n = Console.ReadLine() |> int
        let strings = readStrings n
        printfn "%A" (solution1 strings)
    |2 ->
        let n = Console.ReadLine() |> int
        let strings = readStrings n
        printfn "%A" (solution2 strings)
    0