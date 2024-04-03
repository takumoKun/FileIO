<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtb_fname = New TextBox()
        btn_add = New Button()
        txtb_lname = New TextBox()
        txtb_age = New TextBox()
        txtb_gender = New TextBox()
        btn_prev = New Button()
        btn_del = New Button()
        btn_next = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        btn_edit = New Button()
        btn_search = New Button()
        Label5 = New Label()
        txtb_ID = New TextBox()
        SuspendLayout()
        ' 
        ' txtb_fname
        ' 
        txtb_fname.Location = New Point(45, 94)
        txtb_fname.Name = "txtb_fname"
        txtb_fname.ReadOnly = True
        txtb_fname.Size = New Size(100, 23)
        txtb_fname.TabIndex = 0
        ' 
        ' btn_add
        ' 
        btn_add.Location = New Point(22, 240)
        btn_add.Name = "btn_add"
        btn_add.Size = New Size(75, 23)
        btn_add.TabIndex = 1
        btn_add.Text = "Add"
        btn_add.UseVisualStyleBackColor = True
        ' 
        ' txtb_lname
        ' 
        txtb_lname.Location = New Point(171, 94)
        txtb_lname.Name = "txtb_lname"
        txtb_lname.ReadOnly = True
        txtb_lname.Size = New Size(100, 23)
        txtb_lname.TabIndex = 2
        ' 
        ' txtb_age
        ' 
        txtb_age.Location = New Point(171, 159)
        txtb_age.Name = "txtb_age"
        txtb_age.ReadOnly = True
        txtb_age.Size = New Size(100, 23)
        txtb_age.TabIndex = 3
        ' 
        ' txtb_gender
        ' 
        txtb_gender.Location = New Point(45, 159)
        txtb_gender.Name = "txtb_gender"
        txtb_gender.ReadOnly = True
        txtb_gender.Size = New Size(100, 23)
        txtb_gender.TabIndex = 4
        ' 
        ' btn_prev
        ' 
        btn_prev.Location = New Point(22, 211)
        btn_prev.Name = "btn_prev"
        btn_prev.Size = New Size(75, 23)
        btn_prev.TabIndex = 1
        btn_prev.Text = "< Previous"
        btn_prev.UseVisualStyleBackColor = True
        ' 
        ' btn_del
        ' 
        btn_del.Location = New Point(122, 240)
        btn_del.Name = "btn_del"
        btn_del.Size = New Size(75, 23)
        btn_del.TabIndex = 1
        btn_del.Text = "Delete"
        btn_del.UseVisualStyleBackColor = True
        ' 
        ' btn_next
        ' 
        btn_next.Location = New Point(230, 211)
        btn_next.Name = "btn_next"
        btn_next.Size = New Size(75, 23)
        btn_next.TabIndex = 1
        btn_next.Text = "Next >"
        btn_next.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(65, 76)
        Label1.Name = "Label1"
        Label1.Size = New Size(64, 15)
        Label1.TabIndex = 5
        Label1.Text = "First Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(190, 76)
        Label2.Name = "Label2"
        Label2.Size = New Size(63, 15)
        Label2.TabIndex = 5
        Label2.Text = "Last Name"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(205, 141)
        Label3.Name = "Label3"
        Label3.Size = New Size(28, 15)
        Label3.TabIndex = 5
        Label3.Text = "Age"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(71, 141)
        Label4.Name = "Label4"
        Label4.Size = New Size(45, 15)
        Label4.TabIndex = 6
        Label4.Text = "Gender"
        ' 
        ' btn_edit
        ' 
        btn_edit.Location = New Point(230, 240)
        btn_edit.Name = "btn_edit"
        btn_edit.Size = New Size(75, 23)
        btn_edit.TabIndex = 9
        btn_edit.Text = "Edit"
        btn_edit.UseVisualStyleBackColor = True
        ' 
        ' btn_search
        ' 
        btn_search.Location = New Point(122, 211)
        btn_search.Name = "btn_search"
        btn_search.Size = New Size(75, 23)
        btn_search.TabIndex = 10
        btn_search.Text = "Search"
        btn_search.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(149, 15)
        Label5.Name = "Label5"
        Label5.Size = New Size(18, 15)
        Label5.TabIndex = 12
        Label5.Text = "ID"
        ' 
        ' txtb_ID
        ' 
        txtb_ID.Location = New Point(109, 33)
        txtb_ID.Name = "txtb_ID"
        txtb_ID.ReadOnly = True
        txtb_ID.Size = New Size(100, 23)
        txtb_ID.TabIndex = 11
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(319, 297)
        Controls.Add(Label5)
        Controls.Add(txtb_ID)
        Controls.Add(btn_search)
        Controls.Add(btn_edit)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtb_gender)
        Controls.Add(txtb_age)
        Controls.Add(txtb_lname)
        Controls.Add(btn_next)
        Controls.Add(btn_prev)
        Controls.Add(btn_del)
        Controls.Add(btn_add)
        Controls.Add(txtb_fname)
        ImeMode = ImeMode.On
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtb_fname As TextBox
    Friend WithEvents btn_add As Button
    Friend WithEvents txtb_lname As TextBox
    Friend WithEvents txtb_age As TextBox
    Friend WithEvents txtb_gender As TextBox
    Friend WithEvents btn_prev As Button
    Friend WithEvents btn_del As Button
    Friend WithEvents btn_next As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btn_Start As Button
    Friend WithEvents btn_save As Button
    Friend WithEvents btn_edit As Button
    Friend WithEvents btn_search As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtb_ID As TextBox


End Class
