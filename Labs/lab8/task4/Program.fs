open System

let printerAgent = MailboxProcessor.Start(fun inbox->
    let rec messageLoop() = async{
        let! msg = inbox.Receive()
        
        match msg with
        | "F#" -> printfn "%s"("Подлиза")
        | "Php" | "Python" -> printfn "%s"("Кринж")
        | "Swift" -> printfn "%s"("Сразу видно - хороший человек")
        | other -> printfn "%s"($"Впервые слышу о {other}")
        return! messageLoop()
        }
    messageLoop()

    )
[<EntryPoint>]
let main argv =
    let arg1 = printerAgent.Post("Php")
    let arg2 = printerAgent.Post("Swift")
    let arg2 = printerAgent.Post("Prolog")
    Console.ReadKey()
    0 // return an integer exit code