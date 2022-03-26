open Functions

let runDividers value (action: int -> int -> int) =
    convolution (fun x -> value % x == 0) action 1 value 0

let runUndividers value (action: int -> int -> int) =
    convolution (fun x -> NOD x value == 1) action 1 value 0

[<EntryPoint>]
let main argv =
    let n = argv[0] |> int
    printfn "%d"(runDividers n (fun x y -> x + y))
    printfn "%d"(runUndividers n (fun x y -> x + y))
    0