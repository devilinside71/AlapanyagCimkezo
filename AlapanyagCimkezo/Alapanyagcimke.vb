Module Alapanyagcimke
    Public gintEnterCounter As Integer

    Public Sub PrintZPL()
        Dim s As String
        Dim pd As New PrintDialog()
        Dim res As Boolean

        s = labelcodes(0)
        s = s.Replace("VONALKOD", Form1.TextBoxKod.Text)
        s = s.Replace("ALAPMEGNEV", Form1.TextBoxMegnev.Text)
        s = s.Replace("ALAPSARZS", Form1.TextBoxSarzs.Text)
        s = s.Replace("ALAPZPL", ZebraPrint.GetZPLutf8Code(Form1.TextBoxMegnev.Text))
        s = s.Replace("LABELQTY", Form1.TextBoxDb.Text)

        Console.WriteLine(s)

        ' Open the printer dialog box, and then allow the user to select a printer.
        res = ZebraPrint.SendStringToPrinter(printerwinnames(Form1.ComboBoxPrinter.SelectedIndex), s)
    End Sub
    Public Function GetMegnev(kod As String) As String
        GetMegnev = vbNullString
        For i = 0 To alapanyagcodes.Count - 1
            If alapanyagcodes(i) = kod Then
                GetMegnev = alapanyagdescs(i)
            End If
        Next
    End Function
End Module
