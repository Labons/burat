Imports Microsoft.Win32

Public Class Form1
    Public listStudent As New List(Of Student)
    Public studentCurrentUser As Student

    Public Sub New()
        InitializeComponent()
        Dim stud1 As New Student("Jose", "1234", 18, New DateTime(2003, 12, 1), "Male", "Gyattown",
                                 "Wedding", 100, New DateTime(2025, 12, 1))
        Dim stud2 As New Student("Juana", "abcd", 18, New DateTime(2002, 12, 1), "Female", "Skibidi",
                                 "Birthday", 300, New DateTime(2024, 12, 1))
        Dim stud3 As New Student("Me", "aguy", 18, New DateTime(2001, 12, 1), "Male", "Ohio",
                                 "Wedding", 200, New DateTime(2025, 12, 5))

        stud1.SetServices(New List(Of String) From {"Catering", "Videoke"})
        stud2.SetServices(New List(Of String) From {"Clown", "Singer"})
        stud3.SetServices(New List(Of String) From {"Catering", "Dancer", "Videoke"})
        listStudent.Add(stud1)
        listStudent.Add(stud2)
        listStudent.Add(stud3)
    End Sub

    Class Student
        Private services As New List(Of String)
        Private strName As String
        Private strPass As String
        Private dblAgeNo As String
        Private strSex As String
        Private strAddress As String
        Private dtpBirthday As DateTime

        'Event stuff
        Private strType As String
        Private dblNoGuests As String
        Private dtpEventDate As DateTime
        Public Sub New(ByVal strTempName As String, ByVal strTempPass As String, ByVal Age As String, ByVal BirthdayDate As DateTime, ByVal Sex As String, ByVal Address As String,
                       ByVal Type As String, ByVal NoGuests As String, ByVal EventDate As DateTime)
            strName = strTempName
            strPass = strTempPass
            dblAgeNo = Age
            dtpBirthday = BirthdayDate
            strSex = Sex
            strAddress = Address

            'Event Stuff
            strType = Type
            dblNoGuests = NoGuests
            dtpEventDate = EventDate

        End Sub
        Public Sub New()

        End Sub

        'test
        Public Sub SetServices(selectedServices As List(Of String))
            services = selectedServices
        End Sub

        Public Function GetServices() As List(Of String)
            Return services
        End Function

        Public Sub SetUserCredentials(ByVal strTempName As String, ByVal strTempPass As String)
            strName = strTempName
            strPass = strTempPass
        End Sub
        Public Sub SetInfo(ByVal Age As String, ByVal Sex As String, ByVal Address As String)
            dblAgeNo = Age
            strSex = Sex
            strAddress = Address
        End Sub
        'event stuff
        Public Sub SetEventInfo(ByVal Type As String, ByVal NoGuests As String)
            strType = Type
            dblNoGuests = NoGuests
        End Sub

        'event stuff
        Public Sub SetEventDate(ByVal EventDate As DateTime)
            dtpEventDate = EventDate
        End Sub
        Public Sub SetBirthDate(ByVal BirthdayDate As DateTime)
            dtpBirthday = BirthdayDate
        End Sub



        Public Function GetName() As String

            Return strName
        End Function
        Public Function GetPass() As String

            Return strPass
        End Function

        Public Function GetInfo() As Array
            Dim arrayInfo(3) As String
            arrayInfo(0) = dblAgeNo
            arrayInfo(1) = strSex
            arrayInfo(2) = strAddress
            Return arrayInfo
        End Function
        'event stuff
        Public Function GetEventInfo() As Array
            Dim arrayEventInfo(2) As String
            arrayEventInfo(0) = strType
            arrayEventInfo(1) = dblNoGuests
            Return arrayEventInfo
        End Function
        'event stuff
        Public Function GetEventDate() As DateTime
            Return dtpEventDate
        End Function
        Public Function GetBirthDate() As DateTime
            Return dtpBirthday

        End Function
    End Class

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim intCounter = 0
        Do While intCounter < listStudent.Count
            If TextBox1.Text = listStudent(intCounter).GetName() And TextBox2.Text = listStudent(intCounter).GetPass() Then
                MsgBox("Log-in Success")

                Form2.Show()
                Me.Hide()
                studentCurrentUser = listStudent(intCounter)
            End If
            intCounter += 1
        Loop
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.ShowDialog()
    End Sub
End Class
