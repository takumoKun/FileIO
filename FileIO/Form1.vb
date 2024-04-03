Imports System.IO

Public Class Form1
    Public Property lineCounter As Integer
    Public txtData As New List(Of String)

    'Method when add button is clicked
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim id, firstName, lastName, age, gender As String

        'check if the number of data is zero
        If txtData.Count - 1 < 0 Then
            'set the id of the item being added as 1
            id = 1
        Else
            'if not 1, then check the id of the last data on the text file
            Dim lastData As String() = txtData(txtData.Count - 1).Split(","c)

            'set the id to the last id + 1
            id = lastData(0) + 1
        End If

        Try
            'get the first name using getInput method
            getInput(firstName, "Enter First Name: ")
            'get the last name using getInput method
            getInput(lastName, "Enter Last Name: ")
            'get the age using getInput method
            getInput(age, "Enter Age: ")
            'get gender using getInput method
            getInput(gender, "Enter Gender: ")

            'combine the data into a string and add it to the list
            txtData.Add(id & "," & firstName & "," & lastName & "," & age & "," & gender)

            'set the line counter to the last index of the list where the added data is added
            lineCounter = txtData.Count - 1

            'display the data on the textboxes using the displayData method
            displayData(lineCounter)

            'enable the buttons if there are more than one data in the list
            If txtData.Count > 0 Then
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
    Private Sub getInput(ByRef input As String, ByVal message As String)
        'ByRef is used to modify the value of the variable passed to the method
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
    End Sub

    'Method when delete button is clicked
    Private Sub btn_del_Click(sender As Object, e As EventArgs) Handles btn_del.Click
        'check if the line counter is within the range of the list
        If lineCounter >= 0 And lineCounter < txtData.Count Then
            'ask user if they are sure
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo)

            'if user says no, exit the method
            If result = DialogResult.No Then
                Exit Sub
            End If

            'remove the data from the list
            txtData.RemoveAt(lineCounter)
            'decrement the line counter
            lineCounter -= 1

            'if the line counter is less than 0, set it to 0
            If lineCounter < 0 Then
                lineCounter = 0
            End If
        End If

        'display the updated data on the textboxes using the displayData method
        displayData(lineCounter)

        'save the data to the text file using the saveData method
        saveData()
    End Sub

    Private Sub btn_prev_Click(sender As Object, e As EventArgs) Handles btn_prev.Click
        'check if the line counter is greater than 0
        If lineCounter > 0 Then
            lineCounter -= 1
            'display the data on the textboxes using the displayData method
            displayData(lineCounter)
        Else
            MessageBox.Show("No more records to show")
        End If
    End Sub

    Private Sub btn_next_Click(sender As Object, e As EventArgs) Handles btn_next.Click
        'check if the line counter is less than the number of data in the list
        If lineCounter < txtData.Count - 1 Then
            lineCounter += 1
            'display the data on the textboxes using the displayData method
            displayData(lineCounter)
        Else
            MessageBox.Show("No more records to show")
        End If
    End Sub

    'Method when edit button is clicked
    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        'get the input from the user using the getInput method
        Dim input As String = InputBox("Enter the number of the field you want to edit: " & vbCrLf & "1. First Name" & vbCrLf & "2. Last Name" & vbCrLf & "3. Age" & vbCrLf & "4. Gender", "Edit Data")

        'split the the current data into an array
        Dim editData = txtData(lineCounter).Split(","c)

        'check the input of the user
        Select Case input
            Case "1" ' get the new first name if the input is 1
                editData(1) = InputBox("Enter the new first Name: ", "Edit Name")
            Case "2" ' get the new last name if the input is 2
                editData(2) = InputBox("Enter the new last Name: ", "Edit Name")
            Case "3" ' get the new age if the input is 3
                editData(3) = InputBox("Enter the new age : ", "Edit Name")
            Case "4" 'get the new gender if the input is 4
                editData(4) = InputBox("Enter the new gender: ", "Edit Name")
        End Select

        'combine the data into a string and update the data in the list
        txtData(lineCounter) = String.Join(",", editData)
        'display the updated data on the textboxes using the displayData method
        displayData(lineCounter)
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
                    txtData.Add(reader.ReadLine())
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("File not found ")
        End Try

        'display the data on the textboxes using the displayData method
        displayData(lineCounter)

    End Sub

    'Method to save the data to the text file
    Private Sub saveData()
        'save the data to the text file
        Using writer As New StreamWriter("C:\CodeFolderrrrrrr\visual studio\FileIO\FileIO\data.txt")
            'loop through the list of data
            For Each line As String In txtData
                'write the data to the text file
                writer.WriteLine(line)
            Next
        End Using
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        'get the search input from the user using the getInput method
        Dim search As String = InputBox("Enter the ID to search: ")
        Dim found As Boolean = False

        'loop through the list of data
        For i As Integer = 0 To txtData.Count - 1
            'split the data into an array
            Dim usrData As String() = txtData(i).Split(","c)
            'check if the first element of the array is equal to the search input
            If usrData(0).ToLower = search.ToLower Then
                'display a message if the data is found
                MessageBox.Show("Data Found!")
                displayData(i)
                lineCounter = i
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
    Private Sub displayData(index As Integer)

        'check if the index is within the range of the list
        If txtData.Count > 0 Then
            'split the data into an array
            Dim usrData As String() = txtData(index).Split(","c)

            'display the data on the textboxes
            txtb_ID.Text = usrData(0)
            txtb_fname.Text = usrData(1)
            txtb_lname.Text = usrData(2)
            txtb_age.Text = usrData(3)
            txtb_gender.Text = usrData(4)
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