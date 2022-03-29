open System

type IPrint = interface
    abstract member Print: unit -> unit
    end

[<AbstractClass>]
type Shape() = 
    abstract member square: unit -> double

type Rectangle(w: double, h: double) = 
    inherit Shape()
    let mutable width = w
    let mutable height = h
    override this.square() = width * height
    override this.ToString() = 
        $"Прямоугольник с шириной {width} и шириной {height}"
    
    interface IPrint with
        member this.Print(): unit = printfn "%s"(this.ToString())
        end

type Square(s: double) =
    inherit Rectangle(s,s)
    let mutable side = s
    override this.ToString() = 
        $"Квадрат со стороной {side}"
    interface IPrint with
        member this.Print(): unit = printfn "%s"(this.ToString())
        end

type Circle(r: double) =
    inherit Shape()
    let mutable radius = r
    override this.square() = Math.PI * r * r
    override this.ToString() = 
        $"Окружность с радиусом {radius}"
    interface IPrint with
        member this.Print(): unit = printfn "%s"(this.ToString())
        end

[<EntryPoint>]
let main argv =
    let rect = Rectangle(10,20)
    (rect :> IPrint).Print()

    let squr = Square(10)
    (squr :> IPrint).Print()

    let circ = Circle(10)
    (circ :> IPrint).Print()

    0