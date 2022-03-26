open Functions

let processUndividers x (action: int -> int -> int) init = 
    convolution (fun v -> NOD v x == 1) action 1 x 0

[<EntryPoint>]
let main argv =
    let input = argv[0] |> int
    printfn "%d"(processUndividers input (fun x y -> x + y) 0)
    0