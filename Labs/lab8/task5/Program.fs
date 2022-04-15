open System.Text.RegularExpressions
open System
open System.Diagnostics

type DriverLicense(sn: string,n: string,bd: string,ed: string,c: string,i: int) =
    member this.surname
        with get() = sn
        and set(newValue: string) =
            if (Regex.IsMatch (newValue, @"[а-яА-Я]"))
            then this.surname <- newValue
            else printfn "%s"("Ошибка формата ввода")
    member this.name
        with get() = n
        and set(newValue: string) =
            if (Regex.IsMatch (newValue, @"[а-яА-Я]"))
            then this.name <- newValue
            else printfn "%s"("Ошибка формата ввода")
    member this.birthDay
        with get() = bd
        and set(newValue: string) =
            if (Regex.IsMatch (newValue, @"[0-9]{2}.[0-9]{2}.[0-9]{4}"))
            then this.birthDay <- newValue
            else printfn "%s"("Ошибка формата ввода")
    member this.endDate
        with get() = ed
        and set(newValue: string) =
            if (Regex.IsMatch (newValue, @"[0-9]{2}.[0-9]{2}.[0-9]{4}"))
            then this.endDate <- newValue
            else printfn "%s"("Ошибка формата ввода")
    member this.category
        with get() = c
        and set(newValue: string) =
            if (Regex.IsMatch (newValue, @"(A|B|C|D|E)"))
            then this.category <- newValue
            else printfn "%s"("Ошибка формата ввода")
    member this.id 
        with get() = i
        and set(newValue: int) =
            if (Regex.IsMatch (newValue |> string, @"[0-9]{6}"))
            then this.id <- newValue
            else printfn "%s"("Ошибка формата ввода")
    override this.ToString() = $"Права №{id}\nФИО: {this.surname} {this.name}\nДата рождения: {this.birthDay}\nКатегория: {this.category}\nДата окончания децствия прав: {this.endDate}"
    override this.Equals(obj1) = 
        match obj1 with
        | :? DriverLicense as license ->
            license.id = this.id
        | _ -> false
    interface IComparable with
        member this.CompareTo obj = 
            match obj with
            | :? DriverLicense as license -> this.id.CompareTo(license.id)
            | _ -> 1
        end
    override this.GetHashCode() = this.id.GetHashCode()

[<AbstractClass>]
type DocumentCollection() =
    abstract member searchDocument: DriverLicense -> Boolean

type DocumentList(l: DriverLicense list) =
    inherit DocumentCollection()
    member this.list: (DriverLicense list) = l
    override this.searchDocument (doc: DriverLicense) = 
        (this.list |> List.filter (fun x -> x = doc)).Length > 0

type DocumentArray(l: DriverLicense list) =
    inherit DocumentCollection()
    member this.array: (DriverLicense array) = Array.ofList l
    override this.searchDocument (doc: DriverLicense) = 
        Array.exists (fun x -> x = doc) this.array

type DocumentSet(l: DriverLicense list) =
    inherit DocumentCollection()
    member this.set: (Set<DriverLicense>) = Set.ofList l
    override this.searchDocument (doc: DriverLicense) = 
        Set.contains doc this.set

type DocumentBynary(l: DriverLicense list) =
    inherit DocumentCollection()
    let rec binarySearch (l:DriverLicense list) (el:DriverLicense) =
        match (List.length l) with
        |0->false
        |i->
            let mid = i/2
            match sign <| compare el l.[mid] with
            |0->true
            |1->binarySearch l.[..mid - 1] el
            |_->binarySearch l.[mid + 1..] el    
            
    member this.list: (DriverLicense list) = l |> List.sortBy (fun x -> x.id)
    override this.searchDocument (doc: DriverLicense) = binarySearch this.list doc

[<EntryPoint>]
let main argv =
    
    let random = System.Random()
    let listOfDocs = [ for i in 1 .. 1000000 -> DriverLicense("None" , "Nil", "23.01.2003", "24.03.2003", "A", random.Next(100000,999999))]
    
    let randDoc = DriverLicense("None" , "Nil", "23.01.2003", "24.03.2003", "A", random.Next(100000,999999))

    let arr = DocumentArray(listOfDocs)
    let ls = DocumentList(listOfDocs)
    let set = DocumentSet(listOfDocs)
    let bynary = DocumentBynary(listOfDocs)

    let watch = new Stopwatch()
    watch.Start()
    ls.searchDocument(randDoc)
    watch.Stop()
    Console.WriteLine("Список: {0}", watch.Elapsed)
    watch.Restart()

    let watch = new Stopwatch()
    watch.Start()
    arr.searchDocument(randDoc)
    watch.Stop()
    Console.WriteLine("Массив: {0}", watch.Elapsed)
    watch.Restart()

    let watch = new Stopwatch()
    watch.Start()
    set.searchDocument(randDoc)
    watch.Stop()
    Console.WriteLine("Множество: {0}", watch.Elapsed)
    watch.Restart()
    
    let watch = new Stopwatch()
    watch.Start()
    bynary.searchDocument(randDoc)
    watch.Stop()
    Console.WriteLine("Бинарный поиск: {0}", watch.Elapsed)
    watch.Restart()
    0