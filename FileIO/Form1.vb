Imports System.IO

Public Class Employee
    Private Fname, Lname, Gender As String
    Private ID, Age As Integer

    Public Sub setID(ByVal val As Integer)
        ID = val
    End Sub

    Public Sub setFName(ByVal val As String)
        Fname = val
    End Sub

    Public Sub setLName(ByVal val As String)
        Lname = val
    End Sub

    Public Sub setAge(ByVal val As Integer)
        Age = val
    End Sub

    Public Sub setGender(ByVal val As String)
        Gender = val
    End Sub

    Public Function getID() As Integer
        Return ID
    End Function

    Public Function getFName() As String
        Return Fname
    End Function

    Public Function getLName() As String
        Return Lname
    End Function

    Public Function getAge() As Integer
        Return Age
    End Function

    Public Function getGender() As String
        Return Gender
    End Function


End Class

Public Class Form1
    Public employee As Employee
    Public Property employeeCtr As Integer
    Public employeeList As New List(Of Employee)

    'Method when add button is clicked
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim employee As New Employee
        'check if the number of data is zero
        If employeeList.Count - 1 < 0 Then
            'set the id of the item being added as 1
            employee.setID(1)
        Else
            'if not 1, then check the id of the last data on the text file
            Dim lastID = employeeList(employeeList.Count - 1).getID
            'set the id to the last id + 1
            employee.setID(lastID + 1)
        End If

        Try
            'get the first name using getInput method
            employee.setFName(getInput("Enter First Name: "))
            'get the last name using getInput method
            employee.setLName(getInput("Enter Last Name: "))
            'get the age using getInput method
            employee.setAge(Integer.Parse(getInput("Enter Age: ")))
            'get gender using getInput method
            employee.setGender(getInput("Enter Gender: "))

            'combine the data into a string and add it to the list
            employeeList.Add(employee)

            'set the line counter to the last index of the list where the added data is added
            employeeCtr = employeeList.Count - 1

            'display the data on the textboxes using the displayData method
            displayData()

            'enable the buttons if there are more than one data in the list
            If employeeList.Count > 0 Then
                btn_del.Enabled = True
                btn_edit.Enabled = True
                btn_search.Enabled = True
                btn_next.Enabled = True
                btn_prev.Enabled = True
            End If

            'save the data to the text file
            saveData()
        Catch ex As Exception
            MessageBox.Show("Adding data cancelled")
        End Try
    End Sub

    'Method to get the input from the user
    Private Function getInput(ByVal message As String) As String
        Dim input As String
        'ByVal is used to pass the value of the variable to the method without modifying it

        'use an infinite while loop
        While True
            'get the input from the user
            input = InputBox(message, "Input")

            'check if the input is empty
            If input = "" Then
                MessageBox.Show("Input cannot be empty!")
            Else
                Exit While
            End If
        End While

        Return input
    End Function

    'Method when delete button is clicked
    Private Sub btn_del_Click(sender As Object, e As EventArgs) Handles btn_del.Click
        'check if the line counter is within the range of the list
        If employeeCtr >= 0 And employeeCtr < employeeList.Count Then
            'ask user if they are sure
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo)

            'if user says no, exit the method
            If result = DialogResult.No Then
                Exit Sub
            End If

            'remove the data from the list
            employeeList.RemoveAt(employeeCtr)
            'decrement the line counter
            employeeCtr -= 1

            'if the line counter is less than 0, set it to 0
            If employeeCtr < 0 Then
                employeeCtr = 0
            End If
        End If

        'display the updated data on the textboxes using the displayData method
        displayData()

        'save the data to the text file using the saveData method
        saveData()
    End Sub

    Private Sub btn_prev_Click(sender As Object, e As EventArgs) Handles btn_prev.Click
        'check if the line counter is greater than 0
        If employeeCtr > 0 Then
            employeeCtr -= 1
            'display the data on the textboxes using the displayData method
            displayData()
        Else
            MessageBox.Show("No more records to show")
        End If
    End Sub

    Private Sub btn_next_Click(sender As Object, e As EventArgs) Handles btn_next.Click
        'check if the line counter is less than the number of data in the list
        If employeeCtr < employeeList.Count - 1 Then
            employeeCtr += 1
            'display the data on the textboxes using the displayData method
            displayData()
        Else
            MessageBox.Show("No more records to show")
        End If
    End Sub

    'Method when edit button is clicked
    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        'get the input from the user using the getInput method
        Dim input As String = InputBox("Enter the number of the field you want to edit: " & vbCrLf & "1. First Name" & vbCrLf & "2. Last Name" & vbCrLf & "3. Age" & vbCrLf & "4. Gender", "Edit Data")

        'split the the current data into an array
        Dim employee = employeeList(employeeCtr)

        'check the input of the user
        Select Case input
            Case "1" ' get the new first name if the input is 1
                employee.setFName(InputBox("Enter the new first Name: ", "Edit Name"))
            Case "2" ' get the new last name if the input is 2
                employee.setLName(InputBox("Enter the new last Name: ", "Edit Name"))
            Case "3" ' get the new age if the input is 3
                employee.setAge(InputBox("Enter the new age : ", "Edit Name"))
            Case "4" 'get the new gender if the input is 4
                employee.setGender(InputBox("Enter the new gender: ", "Edit Name"))
        End Select

        'display the updated data on the textboxes using the displayData method
        displayData()
        'save the data to the text file using the saveData method
        saveData()
    End Sub

    'Method activates when the form is loaded
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'read the data from the text file
            Using reader As New StreamReader("C:\CodeFolderrrrrrr\visual studio\FileIO\FileIO\data.txt")
                'loop through the text file
                While Not reader.EndOfStream
                    'add the data to the list
                    Dim line As String() = reader.ReadLine().Split(","c)
                    Dim employee As New Employee
                    employee.setID(Integer.Parse(line(0)))
                    employee.setFName(line(1))
                    employee.setLName(line(2))
                    employee.setAge(Integer.Parse(line(3)))
                    employee.setGender(line(4))
                    employeeList.Add(employee)
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("File not found ")
        End Try

        'display the data on the textboxes using the displayData method
        displayData()
    End Sub

    'Method to save the data to the text file
    Private Sub saveData()
        'save the data to the text file
        Using writer As New StreamWriter("C:\CodeFolderrrrrrr\visual studio\FileIO\FileIO\data.txt")
            'loop through the list of data
            For Each employee As Employee In employeeList
                'write the data to the text file
                writer.WriteLine(employee.getID & "," & employee.getFName & "," & employee.getLName & "," & employee.getAge & "," & employee.getGender)
            Next
        End Using
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        'get the search input from the user using the getInput method
        Dim search As Integer = InputBox("Enter the ID to search: ")
        Dim found As Boolean = False

        'loop through the list of data
        For Each employee As Employee In employeeList
            'check if the id of current employee is equal to the search id
            If employee.getID = search Then
                'display a message if the data is found
                MessageBox.Show("Data Found!")
                employeeCtr = employeeList.IndexOf(employee)
                displayData()
                found = True
                Exit For
            End If
        Next

        'if the data is not found, display a message
        If Not found Then
            MessageBox.Show("Name not found")
        End If

    End Sub

    'Method to display the data on the textboxes
    Private Sub displayData()
        'check if the index is within the range of the list
        If employeeList.Count > 0 Then
            'split the data into an array
            Dim employee As Employee = employeeList(employeeCtr)

            'display the data on the textboxes
            txtb_ID.Text = employee.getID
            txtb_fname.Text = employee.getFName
            txtb_lname.Text = employee.getLName
            txtb_age.Text = employee.getAge
            txtb_gender.Text = employee.getGender
        Else
            'if the list is empty, display empty on the textboxes
            txtb_ID.Text = "EMPTY"
            txtb_lname.Text = "EMPTY"
            txtb_age.Text = "EMPTY"
            txtb_fname.Text = "EMPTY"
            txtb_gender.Text = "EMPTY"
            btn_del.Enabled = False
            btn_edit.Enabled = False
            btn_search.Enabled = False
            btn_next.Enabled = False
            btn_prev.Enabled = False
        End If
    End Sub
End Class
