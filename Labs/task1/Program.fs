open System
open System.Windows.Forms
open System.Drawing

let calculate (x: string) (y: string) (action: double -> double -> string) =
    try
        let xNum = x |> double
        let yNum = y |> double
        action xNum yNum
    with
    | _ -> "Ошибка ввода"

let form = new Form(Text = "F# Program", Width = 288)

let firstField = new TextBox()
firstField.Dock <- DockStyle.Fill

let secondField = new TextBox()
secondField.Dock <- DockStyle.Fill

let resultLabel = new Label()
resultLabel.Dock <- DockStyle.Fill

let mainLayout = new TableLayoutPanel()
mainLayout.ColumnCount <- 1
mainLayout.RowCount <- 4
mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f)) |> ignore
mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f)) |> ignore
mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f)) |> ignore
mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f)) |> ignore
mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f)) |> ignore

mainLayout.Dock <- DockStyle.Fill

let buttonsPanel = new TableLayoutPanel()
buttonsPanel.ColumnCount <- 4
buttonsPanel.RowCount <- 1
buttonsPanel.Dock <- DockStyle.Fill
buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f)) |> ignore
buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f)) |> ignore
buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f)) |> ignore
buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f)) |> ignore
buttonsPanel.Location <- new Point(8, 72)
buttonsPanel.Size <- new Size(256,28)
 
let addBtn = new Button()
addBtn.Dock <- DockStyle.Fill
addBtn.Text <- "+"
addBtn.Click.Add((fun e -> 
    resultLabel.Text <- calculate firstField.Text secondField.Text (fun x y -> (x + y) |> string)
))

let minusBtn = new Button()
minusBtn.Dock <- DockStyle.Fill
minusBtn.Text <- "-"
minusBtn.Click.Add((fun e -> 
    resultLabel.Text <- calculate firstField.Text secondField.Text (fun x y -> (x - y) |> string)
))

let divBtn = new Button()
divBtn.Dock <- DockStyle.Fill
divBtn.Text <- "/"
divBtn.Click.Add((fun e -> 
    resultLabel.Text <- calculate firstField.Text secondField.Text (fun x y -> if y = 0 then "Деление на ноль невозможно" else (x / y) |> string)
))

let multBtn = new Button()
multBtn.Dock <- DockStyle.Fill
multBtn.Text <- "*"
multBtn.Click.Add((fun e -> 
    resultLabel.Text <- calculate firstField.Text secondField.Text (fun x y -> (x * y) |> string)
))

buttonsPanel.Controls.Add(addBtn)
buttonsPanel.Controls.Add(minusBtn)
buttonsPanel.Controls.Add(divBtn)
buttonsPanel.Controls.Add(multBtn)
mainLayout.Controls.Add(firstField)
mainLayout.Controls.Add(secondField)
mainLayout.Controls.Add(buttonsPanel)
mainLayout.Controls.Add(resultLabel)

form.Controls.Add(mainLayout)

Application.Run(form)
