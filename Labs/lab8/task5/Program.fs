type DriverLicense(sn: string,n: string,bd: string,ed: string,c: string list,i: int) =
    let mutable surname = sn
    let mutable name = n
    let mutable birthDay = bd
    let mutable endDate = ed
    let mutable categories = c
    let mutable id = i
    override this.ToString() = 
        $"Права №{id}\nФИО: {surname} {name}\nДата рождения: {birthDay}\nКатегории: {categories}\nДата окончания децствия прав: {endDate}"

[<EntryPoint>]
let main argv =
    let license = DriverLicense("Нагалевский", "Артем", "01.01.1001", "02.01.1001", ["A";"B"], 104564)
    printfn "%s"(license.ToString())
    0