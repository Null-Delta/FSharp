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
    | h::t -> func h (listConvolution func t)

//метод, выполняющий func с начальным значением c всем числам от a до b, которые удовлетворяют predicate 
let convolution (predicate: 'a -> bool) (func: 'a -> 'a -> 'a) a b c =
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