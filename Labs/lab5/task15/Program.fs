open Functions

let processUndividers x (action: int -> int -> int) init = 
    convolution (fun v -> 
        convolution (fun t -> v % t = 0 && x % t = 0) (fun v1 v2 -> v2) 1 v = 1 
    ) action 1 x 0

[<EntryPoint>]
let main argv =
    let input = argv[0] |> int
    printfn "%d"(processUndividers input (fun x y -> x + y) 0)
    0