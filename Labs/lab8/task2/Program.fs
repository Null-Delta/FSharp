type Optional<'T> =
    | Value of 'T   
    | Nil

let equal opt1 opt2 =
    match opt1, opt2 with 
    | Value v1, Value v2 -> true
    | Nil, Nil -> true
    | _ -> false
//Функтор
let optionalFunctor func optVal =
    match optVal with
    | Value v -> Value(func v)
    | Nil -> Nil

//Аппликативный функтор
let (<*>) optFunc optVal =
    match optFunc, optVal with
    | Value f, Value v -> Value(f v)
    | _ -> Nil


let appFunctReturn v = 
    Value(v)

//Монада
let OptionalMonade optInput func =
    match optInput with
    | Value v -> func v
    | Nil -> Nil

[<EntryPoint>]
let main argv =

    //первый закон функтора
    let id x = x
    let opt1 = Value(3)
    let opt2 = Nil

    printfn "%A"(optionalFunctor id opt1)
    printfn "%A"(optionalFunctor id opt2)
    printfn ""
    //второй закон функтора
    let f x = x + 3
    let g x = x * 2
    printfn "%A"(optionalFunctor (f >> g) opt1)
    printfn "%A"(optionalFunctor g (optionalFunctor f opt1))
    printfn ""

    //первый закон аппликативного функтора
    let optId = Value(fun x -> x)
    printfn "%A"(optId <*> Value(3))
    printfn "%A"(optId <*> Nil)
    printfn ""

    //второй закон аппликативного функтора
    let func x = x * 3
    let optFunc = Value(func)
    printfn "%A"(equal (optFunc <*> Value(3)) (Value(func 3)))
    printfn "%A"(equal (optFunc <*> Nil) (Nil))
    printfn ""

    //третий закон аппликативного функтора
    //не выполняется так как у <*> нельзя менять аргументы местами

    //четвертый закон аппликативного функтора
    //не выполняется так как у <*> не выполняется ассочиативность
    0