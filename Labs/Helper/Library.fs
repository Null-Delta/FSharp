module Functions

let rec listFilter (predicate: 'a -> bool) (list: 'a list) =
    match list with
    | h::t -> if predicate h then h::(listFilter predicate t) else listFilter predicate t
    | _ -> []

let rec listValueAtIndex index (list: int list)=
    match index with
    | 0 -> list.Head
    | _ -> 
        let newIndex = index - 1
        listValueAtIndex newIndex list.Tail

let rec readList size =
    if size = 0 then []
    else 
        let head = System.Convert.ToInt32(System.Console.ReadLine())
        let tail = readList (size - 1)
        head::tail

