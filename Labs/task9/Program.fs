open System
open System.Windows.Forms
open System.Drawing

let form = new Form(Text = "F# Program", Width = 288)

let firstField = new TextBox()
firstField.Dock <- DockStyle.Fill

let secondField = new TextBox()
secondField.Dock <- DockStyle.Fill

let resultLabel = new Label()
secondField.Dock <- DockStyle.Fill

let btn = new Button()
btn.Dock <- DockStyle.Fill
btn.Text <- "Объединить"

let mainLayout = new TableLayoutPanel()
mainLayout.ColumnCount <- 1
mainLayout.RowCount <- 4
mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f)) |> ignore
mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f)) |> ignore
mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f)) |> ignore
mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f)) |> ignore
mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f)) |> ignore

mainLayout.Dock <- DockStyle.Fill

mainLayout.Controls.Add(firstField)
mainLayout.Controls.Add(secondField)
mainLayout.Controls.Add(btn)
mainLayout.Controls.Add(resultLabel)

form.Controls.Add(mainLayout)

let toList (str: string) =
    let vals = str.Replace(" ","").Split(",")
    List.ofArray vals

let concat l1 l2 = l1@l2

let toString (arr: 'a List) =
    (List.map string arr) |> String.concat ", "

btn.Click.Add((fun e ->
    let arr1 = toList firstField.Text
    let arr2 = toList secondField.Text
    resultLabel.Text <- toString (concat arr1 arr2)
))

Application.Run(form)