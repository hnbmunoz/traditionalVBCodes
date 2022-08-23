Imports System.Data.SqlClient
Imports System.IO

Public Class DataAccessLayer
    'Copy Entire Code
    'Start Copy Here
    Dim cmd As SqlCommand = New SqlCommand()
    Dim da As New SqlDataAdapter()
    Public Function getDatatable(ByVal cmdtxt As String, ByVal cnstring As String, ByVal cmdType As CommandType, ByVal Optional param As SqlParameter() = Nothing) As DataTable
        Dim con As SqlConnection = New SqlConnection(cnstring)
        Dim dt As DataTable = New DataTable()
        Try
            cmd.Connection = con
            cmd.CommandText = cmdtxt
            cmd.CommandType = cmdType
            da.SelectCommand = cmd
            da.Fill(dt)
        Catch e As Exception
            MessageBox.Show(e.ToString())
        End Try

        Return dt
    End Function

    Public Sub Execute(ByVal cmdtxt As String, ByVal cnstring As String, ByVal cmdType As CommandType, ByVal Optional param As SqlParameter() = Nothing)
        Dim connection As SqlConnection = New SqlConnection(cnstring)
        Dim sql As String = cmdtxt
        cmd.Connection = connection
        cmd.CommandText = sql
        cmd.CommandType = cmdType
        connection.Open()
        cmd.ExecuteNonQuery()
        connection.Close()
        connection.Dispose()
    End Sub
    'End Copy Here
End Class
