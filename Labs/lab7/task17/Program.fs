open Functions
open System

let findPairs a b n =
    List.fold ( fun xState x ->
        xState @ ([1..n] |>
            List.fold (fun vState v ->
                if x * v == n && a == x / (NOD x v) && b == v / (NOD x v) then
                    vState@[(x,v)]
                else 
                    vState
            ) [])
    ) [] [1..n]

let solution3 n =
    [1..n] |>
    List.fold (fun xState x ->
        xState @ ([1..n] |>
            List.fold (fun vState v ->
                if (findPairs x v n).Length == 0 then 
                    vState 
                else 
                    vState@[(x,v)]
            ) [])
    ) []

[<EntryPoint>]
let main argv =
    printfn "%A" (solution3 (argv[0] |> int))
    0