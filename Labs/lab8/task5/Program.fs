open System.Text.RegularExpressions
open System

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

    override this.ToString() = 
        $"Права №{id}\nФИО: {this.surname} {this.name}\nДата рождения: {this.birthDay}\nКатегория: {this.category}\nДата окончания децствия прав: {this.endDate}"
    override this.Equals(obj1) = 
        match obj1 with
        | :? DriverLicense as license ->
            license.id = this.id
        | _ -> false

[<EntryPoint>]
let main argv =
    let license = DriverLicense("Нагалевский", "Артем", "01.01.1001", "02.01.1001", "A", 104564)
    let license2 = DriverLicense("Нагалевский", "Артем", "01.01.1001", "02.01.1001", "B", 104564)

    license.surname <- "102945"
    printfn "%A"(license = license2)
    0