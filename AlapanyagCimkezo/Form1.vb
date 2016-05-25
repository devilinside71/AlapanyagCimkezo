Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LoadZPLSamples()
        Call LoadPrinters()
        Call LoadMaterials()
        ComboBoxPrinter.Items.Clear()
        For Each lsa In printernames
            ComboBoxPrinter.Items.Add(lsa)
        Next
        ComboBoxPrinter.SelectedIndex = 0
    End Sub

    Private Sub TextBoxKod_TextChanged(sender As Object, e As EventArgs) Handles TextBoxKod.TextChanged
        Dim strKat As String
        strKat = Trim(TextBoxKod.Text)
        If Len(strKat) = 10 Then
            TextBoxMegnev.Text = GetMegnev(TextBoxKod.Text)
            TextBoxDb.SelectAll()
            TextBoxSarzs.Text = vbNullString
            TextBoxSarzs.Focus()
            gintEnterCounter = 0

        End If
    End Sub

    Private Sub TextBoxDb_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDb.TextChanged

    End Sub

    Private Sub TextBoxDb_ReadOnlyChanged(sender As Object, e As EventArgs) Handles TextBoxDb.ReadOnlyChanged

    End Sub

    Private Sub TextBoxDb_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxDb.KeyDown
        If e.KeyCode = Keys.Enter Then
            gintEnterCounter = gintEnterCounter + 1
            If gintEnterCounter = 2 Then
                'MsgBox("Nyomtat")
                If TextBoxMegnev.Text <> "" Then
                    Call PrintZPL()
                End If
                TextBoxMegnev.Text = ""
                TextBoxKod.Focus()
                TextBoxKod.Text = ""
                gintEnterCounter = 0
            End If
        End If
    End Sub

    Private Sub ButtonPrint_Click(sender As Object, e As EventArgs) Handles ButtonPrint.Click
        Call PrintZPL()

    End Sub

    Private Sub TextBoxSarzs_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSarzs.TextChanged
        Dim strKat As String
        strKat = Trim(TextBoxSarzs.Text)
        If Len(strKat) = 10 Then
            TextBoxDb.SelectAll()
            TextBoxDb.Focus()
        End If
    End Sub

    Private Sub TextBoxSarzs_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxSarzs.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBoxDb.SelectAll()
            TextBoxDb.Focus()

        End If
    End Sub
End Class
