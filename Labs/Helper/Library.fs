namespace Helper

module Functions =
    let rec readList size =
    if size = 0 then []
    else 
        let head = System.Convert.ToInt32(System.Console.ReadLine())
        let tail = readList (size - 1)
        head::tail

