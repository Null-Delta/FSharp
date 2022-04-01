module Functions

//БУНТ!!!
let (!=) = (<>)
let (==) = (=)

let rec listFilter (predicate: 'a -> bool) (list: 'a list) =
    match list with
    | h::t -> if predicate h then h::(listFilter predicate t) else listFilter predicate t
    | _ -> []

let rec listMap (predicate: 'a -> 'b) (list: 'a list) =
    match list with
    | h::t -> (predicate h)::(listMap predicate t)
    | _ -> []

let rec listValueAtIndex index (list: int list)=
    match index with
    | 0 -> list.Head
    | _ -> 
        let newIndex = index - 1
        listValueAtIndex newIndex list.Tail

let rec listMinIndex (list: 'a list) =      
    let rec findMinIndex initValue list =
        match list with
        | [] -> initValue
        | h::t -> 
            let newValue = if h < initValue then h else initValue
            findMinIndex newValue t
    findMinIndex list.Head list
    
let rec readList size =
    if size = 0 then []
    else
        let head = System.Convert.ToInt32(System.Console.ReadLine())
        let tail = readList (size - 1)
        head::tail

let rec listConvolution (func: 'a -> 'a -> 'a) (list: 'a list) =
    match list with
    | h::[] -> h
    | _ -> func list.Head (listConvolution func list.Tail)

//метод, выполняющий func с начальным значением c всем числам от a до b, которые удовлетворяют predicate 
let convolution (predicate: int -> bool) (func: int -> int -> int) a b c =
    let rec _convolution iter init =
        match iter with 
        | _ when iter == b -> if predicate b then func init b else init
        | _ -> 
            let newIter = iter + 1
            let newInit = if predicate iter then func init iter else init
            _convolution newIter newInit
    _convolution a c

let NOD n m =
    convolution (fun x -> m % x == 0 && n % x == 0) (fun x y -> y) 1 (max n m) 1

let isEasy value = 
    convolution (fun x -> value % x == 0) (fun x y -> x + 1) 2 value 0 == 1

let isContains source (list: int list) =
    (List.fold (fun (state: int list) value ->
        match value with
        | a when state.Length != 0 && a == state.Head -> state.Tail
        | _ when state.Length == 0 -> state
        | _ -> if value == list.Head then list.Tail else list
    ) list source).Length == 0

let rec readArray n =
    match n with
    | 0 -> [||]
    | _ -> 
        let value = System.Console.ReadLine() |> int
        let other = readArray (n - 1)
        Array.concat [|[|value|]; other|]

let rec readStrings n =
    match n with
    | 0 -> []
    | _ -> 
        let value = System.Console.ReadLine()
        let other = readStrings (n - 1)
        value::other

let stringFold (func: 'state -> char -> 'state) (init: 'state) (value: string) =
    let rec _stringFold (index: int) (state: 'state) =
        match index with
        | final when final == value.Length -> state
        | _ -> 
            let newState = func state (value.Chars index)
            let newIndex = index + 1
            _stringFold newIndex newState
    _stringFold 0 init

let splitString splitChar value =
    stringFold (fun state char ->
        match char with
        | ' ' -> ""::state
        | _ -> 
            if state.Length == 0 then 
                (char |> string)::state
            else
                (state.Head + (char |> string))::state.Tail
    ) [] value |> List.rev

let concatinate (withSpacer: char) (list: string list) =
    List.fold (fun state value -> 
        if snd state == list.Length - 1 then
            (fst state + value, 0)
        else
            (fst state + value + (withSpacer |> string), snd state + 1)
    ) ("", 0) list |> fst
