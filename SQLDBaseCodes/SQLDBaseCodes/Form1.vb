Imports System.Data.SqlClient

Public Class Form1
    ' Create a new class for accessing SQL Server

    Dim DAL = New DataAccessLayer() 'Declaration of Class
    Dim cnstring As String = "Data Source=LAPTOP-LD99UDNN\MSSQLSERVER2008R;Initial Catalog=ToDO;User ID=sa; password=P@ssW0rd"
    Dim query As String = "Select * from tbl_Todo"


    Sub LoadGrid()
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()

        'Implementation of getDataTable
        DataGridView1.DataSource = DAL.getDatatable(query, cnstring, CommandType.Text)
    End Sub
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGrid()
    End Sub

    'Multiple Example Implementation of Execute
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DAL.Execute("Insert into tbl_Todo (taskName, taskComplete)values('" + TextBox1.Text + "', 0) ", cnstring, CommandType.Text)
        LoadGrid()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DAL.Execute("DELETE FROM tbl_Todo WHERE taskID = '" + TextBox2.Text + "'; ", cnstring, CommandType.Text)
        LoadGrid()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DAL.Execute("UPDATE  tbl_Todo set taskComplete = 1 WHERE taskID = '" + TextBox3.Text + "'; ", cnstring, CommandType.Text)
        LoadGrid()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DAL.Execute("UPDATE  tbl_Todo set taskName = '" + TextBox5.Text + "' WHERE taskID = '" + TextBox4.Text + "'; ", cnstring, CommandType.Text)
        LoadGrid()
    End Sub

    'Multiple Example Implementation of Execute
End Class
