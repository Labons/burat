Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tempInfo() As String = Form1.studentCurrentUser.GetInfo
        Dim tempEventInfo() As String = Form1.studentCurrentUser.GetEventInfo
        Dim selectedServices As List(Of String) = Form1.studentCurrentUser.GetServices()
        Label8.Text = Form1.studentCurrentUser.GetName
        Label5.Text = tempInfo(0)
        Label6.Text = tempInfo(1)
        Label7.Text = tempInfo(2)
        Label9.Text = Form1.studentCurrentUser.GetBirthDate().ToShortDateString()
        Label14.Text = Form1.studentCurrentUser.GetEventDate().ToShortDateString()

        'event stuff
        Label11.Text = tempEventInfo(0)
        Label12.Text = tempEventInfo(1)
        Label13.Text = String.Join(", ", selectedServices) ' Add a new Label13 to show services
        Label13.Visible = True

        Label9.Visible = True
        Label8.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        Label7.Visible = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Close()
    End Sub
End Class