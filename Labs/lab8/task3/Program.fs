open FParsec
open System
open Functions

type Expr =
| Value of float
| Plus of Expr * Expr
| Minus of Expr * Expr

let rec Execute Expr =
    match Expr with
    | Value(a) -> a
    | Plus(a,b) | Minus(a,b) ->
        let left = 
            match a with
            | Value(v) -> v
            | Plus(_,_) | Minus(_,_) -> Execute a
        let right = 
            match b with
            | Value(v) -> v
            | Plus(_,_) | Minus(_,_) -> Execute b
        match Expr with
        | Plus(_,_) -> left + right
        | Minus(_,_) -> left - right
        | _ -> 0


[<EntryPoint>]
let main argv =

    let expression = Console.ReadLine();
    let expWithoutSpaces = stringFold (fun (state: string) char -> if char == ' ' then state else state + char.ToString() ) "" expression 

    println expWithoutSpaces

    let parseExpression, implementation = createParserForwardedToRef<Expr, unit>()

    let operatorExpression char =
        tuple2 (parseExpression .>> pstring char) parseExpression |>> 
        match char with
        | "+" -> Plus
        | "-" -> Minus
    let operatorPlus = operatorExpression "+"
    let operatorMinus = operatorExpression "-"

    let parseNum = pfloat |>> Value

    let parseOp = between (pstring "(") (pstring ")") (attempt operatorPlus <|> operatorMinus)
    
    implementation := parseNum <|> parseOp

    let expr1Parser = run parseExpression expWithoutSpaces
    printfn "%A" expr1Parser

    match expr1Parser with
    | Success(result, _, _)   ->
        let eval1 = Execute(result)
        printfn "Результат вычислений: %f" eval1
    | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg
    0