module Functions

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

