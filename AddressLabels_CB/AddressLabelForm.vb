Option Explicit On
Option Strict On

Public Class AddressLabelForm
    ''' <summary>
    ''' verify all text fields on form are valid/correct desired input 
    ''' alert user otherwise
    ''' </summary>
    ''' <returns>True if all inputs are valid</returns>
    Function ValidInput() As Boolean
        Dim allValid As Boolean = True
        Dim zip As Integer

        'only lets the user input numbers in the zip box
        Try
            zip = CInt(ZipTextBox.Text)
        Catch ex As Exception
            AccumulateMessage("Zip Code must be a number")
            ZipTextBox.Focus()
            allValid = False
        End Try

        'if the text box is empty the text box will be focused
        'and a message displayed prompting user to enter text
        If StateTextBox.Text = "" Then
            AccumulateMessage("State must be entered")
            StateTextBox.Focus()
            allValid = False
        End If

        If CityTextBox.Text = "" Then
            AccumulateMessage("City must be entered")
            CityTextBox.Focus()
            allValid = False
        End If


        If StreetTextBox.Text = "" Then
            AccumulateMessage("Street name must be entered")
            StreetTextBox.Focus()
            allValid = False
        End If


        If LastNameTextBox.Text = "" Then
            AccumulateMessage("Last name must be entered")
            LastNameTextBox.Focus()
            allValid = False
        End If

        If FirstNameTextBox.Text = "" Then
            AccumulateMessage("First name must be entered")
            FirstNameTextBox.Focus()
            allValid = False
        End If

        If AccumulateMessage() <> "" Then
            MsgBox(AccumulateMessage())
            AccumulateMessage(, True)
            allValid = False
        End If

        Return allValid
    End Function
    Private Function AccumulateMessage(Optional newMessage As String = "", Optional clear As Boolean = False) As String
        Static _message As String
        Select Case clear
            Case False
                If newMessage <> "" Then
                    _message &= newMessage & vbCrLf
                End If
            Case Else
                _message = ""
        End Select
        Return _message
    End Function
    Private Function Summary(Optional addRecord As Boolean = True) As String
        Static _summary As String
        'example of output
        'First last
        'Street Address
        'City State Zip code
        If addRecord Then
            _summary &= $"{FirstNameTextBox.Text} {LastNameTextBox.Text}" & vbNewLine
            _summary &= $"{StreetTextBox.Text}" & vbNewLine
            _summary &= $"{CityTextBox.Text}" & "," & $" {StateTextBox.Text} {ZipTextBox.Text}"
        End If
        Return _summary
    End Function
    Private Sub Clear()
        'reset all text boxes to default, empty
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        StreetTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipTextBox.Text = ""
        OutputLabel.Text = ""
        'clear any stored messages
        AccumulateMessage(, True)
    End Sub
    Private Sub DisplayButton_Click(sender As Object, e As EventArgs) Handles DisplayLabelButton.Click
        'if input is valid then it will display the text
        If ValidInput() Then
            Summary()
            Clear()
        End If
        OutputLabel.Text = Summary(False)
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutForm.Show()
        Me.Hide()
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        Clear()
    End Sub
    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        Clear()
    End Sub
End Class
