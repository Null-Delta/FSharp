open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup

let mwXaml = """
<Window 
xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
Title="MainWindow" Height="450" Width="800">
    <Grid
Margin="8,8,8,8"
>
<Grid.RowDefinitions>
    <RowDefinition Height="32"/>
    <RowDefinition Height="32"/>
    <RowDefinition Height="32"/>
    <RowDefinition Height="32"/>
</Grid.RowDefinitions>

<TextBox Grid.Row="0" Height="24" x:Name="fstField"/>
<TextBox Grid.Row="1" Height="24" x:Name="sndField"/>

<Grid Grid.Row="2">
    <Grid.ColumnDefinitions>
        <ColumnDefinition/>
        <ColumnDefinition/>
        <ColumnDefinition/>
        <ColumnDefinition/>
    </Grid.ColumnDefinitions>
    <Button Content="+" Grid.Column="0" Margin="0,0,8,0" x:Name="addBtn"/>
    <Button Content="-" Grid.Column="1" Margin="8,0,8,0" x:Name="minusBtn"/>
    <Button Content="/" Grid.Column="2" Margin="8,0,8,0" x:Name="divBtn"/>
    <Button Content="*" Grid.Column="3" Margin="8,0,0,0" x:Name="multBtn"/>
</Grid>

<Label Grid.Row="3" Content="" x:Name="result"/>
    </Grid>
</Window>
"""
let getWindow(mwXaml) =
    let xamlObj=XamlReader.Parse(mwXaml)
    xamlObj :?> Window
    
let win = getWindow(mwXaml)


let addBtn = win.FindName("addBtn") :?> Button
let minusBtn = win.FindName("minusBtn") :?> Button
let divBtn = win.FindName("divBtn") :?> Button
let multBtn = win.FindName("multBtn") :?> Button

let fstField = win.FindName("fstField") :?> TextBox
let sndField = win.FindName("sndField") :?> TextBox
let resultLabel = win.FindName("result") :?> Label

let calculate (x: string) (y: string) (action: double -> double -> string) =
    try
        let xNum = x |> double
        let yNum = y |> double
        action xNum yNum
    with
    | _ -> "Ошибка ввода"


addBtn.Click.AddHandler((fun _ _ -> 
    resultLabel.Content <- calculate fstField.Text sndField.Text (fun x y -> (x + y) |> string)
))

minusBtn.Click.Add((fun e -> 
    resultLabel.Content <- calculate fstField.Text sndField.Text (fun x y -> (x - y) |> string)
))

divBtn.Click.Add((fun e -> 
    resultLabel.Content <- calculate fstField.Text sndField.Text (fun x y -> if y = 0 then "Деление на ноль невозможно" else (x / y) |> string)
))

multBtn.Click.Add((fun e -> 
    resultLabel.Content <- calculate fstField.Text sndField.Text (fun x y -> (x * y) |> string)
))

[<STAThread>] ignore <| (new Application()).Run win