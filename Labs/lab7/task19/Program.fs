open Functions
open System

let solution8 value =
    stringFold (fun state char -> 
        match char with
        | ' ' -> 
            if (snd state) % 2 == 0 then ((fst state) + 1, 0) else (fst state, 0)
        | _ -> (fst state, (snd state) + 1)
    ) (0, 0) value |> fst

[<EntryPoint>]
let main argv =
    let text = Console.ReadLine()
    printfn "%A"(solution8 text)
    0