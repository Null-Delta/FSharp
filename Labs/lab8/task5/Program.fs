type DriverLicense(sn: string,n: string,bd: string,ed: string,c: string list,i: int) =
    member this.surname = sn
    member this.name = n
    member this.birthDay = bd
    member this.endDate = ed
    member this.categories = c
    member this.id = i
    override this.ToString() = 
        $"Права №{id}\nФИО: {this.surname} {this.name}\nДата рождения: {this.birthDay}\nКатегории: {this.categories}\nДата окончания децствия прав: {this.endDate}"
    override this.Equals(obj1) = 
        match obj1 with
        | :? DriverLicense as license ->
            license.id = this.id
        | _ -> false

[<EntryPoint>]
let main argv =
    let license = DriverLicense("Нагалевский", "Артем", "01.01.1001", "02.01.1001", ["A";"B"], 104564)
    let license2 = DriverLicense("Нагалевский", "Артем", "01.01.1001", "02.01.1001", ["A";"B"], 104564)
    printfn "%A"(license = license2)
    0