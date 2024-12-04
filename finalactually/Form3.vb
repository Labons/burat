Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click




        Dim pricePerDay As Double = 10000
        Dim totalPrice As Double = 0
        totalPrice += pricePerDay
        'THing
        Dim selectedServices As New List(Of String)
        If chkCatering.Checked Then
            selectedServices.Add("Catering")
            totalPrice += 20000 ' Catering cost
        End If

        If chkClown.Checked Then
            selectedServices.Add("Clown")
            totalPrice += 10000 ' Clown cost
        End If

        If chkSinger.Checked Then
            selectedServices.Add("Singer")
            totalPrice += 7000 ' Singer cost
        End If

        If chkDancer.Checked Then
            selectedServices.Add("Dancer")
            totalPrice += 7000 ' Dancer cost
        End If

        If chkVideoke.Checked Then
            selectedServices.Add("Videoke")
            totalPrice += 1000 ' Videoke cost
        End If
        Dim noOfGuests As Double
        If Double.TryParse(TextBox4.Text, noOfGuests) Then
            Dim multiplierfr As Double = Math.Ceiling(noOfGuests / 50)
            totalPrice *= multiplierfr

        End If


        Dim selectedDateBday As DateTime = DateTimePicker1.Value
        Dim selectedDateEventDate As DateTime = DateTimePicker2.Value
        For Each student As Form1.Student In Form1.listStudent
            If student.GetEventDate() = selectedDateEventDate Then
                MessageBox.Show("The event date is already taken by another student. Please select a different date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ' Exit the procedure if the date is already taken
            End If
        Next
        Dim paymentAmount As String = InputBox("Price is: " & totalPrice, "Payment")


        If Not String.IsNullOrWhiteSpace(paymentAmount) AndAlso IsNumeric(paymentAmount) Then
            Dim amount As Decimal = Decimal.Parse(paymentAmount)
            If amount >= totalPrice Then
                MessageBox.Show("Payment successful! Change: " & (amount - totalPrice).ToString("C"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)


                Dim newStudent As New Form1.Student
                newStudent.SetUserCredentials(TextBox1.Text, TextBox2.Text)
                newStudent.SetInfo(TextBox3.Text, ComboBox1.Text, TextBox5.Text)
                newStudent.SetEventInfo(ComboBox2.Text, TextBox4.Text)
                newStudent.SetBirthDate(selectedDateBday)
                newStudent.SetEventDate(selectedDateEventDate)
                newStudent.SetServices(selectedServices)

                Form1.listStudent.Add(newStudent)
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                ComboBox1.SelectedIndex = -1
                TextBox5.Clear()
                DateTimePicker1.Value = DateTime.Now
                DateTimePicker2.Value = DateTime.Now
                Me.Close()
            Else
                MessageBox.Show("Insufficient Payment. Please pay at least: " & totalPrice.ToString("C"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else
            MessageBox.Show("Invalid payment amount entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class