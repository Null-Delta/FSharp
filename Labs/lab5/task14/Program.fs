open Functions

let processDividers x (action: int -> int -> int) init = 
    convolution (fun v -> x % v = 0) action 2 x 0

[<EntryPoint>]
let main argv =
    let input = argv[0] |> int
    printfn "%d"(processDividers input (fun x y -> x + y) 0)
    0