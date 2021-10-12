Imports System.ComponentModel
Imports System.Data.SQLite
Imports System
Public Class ViewData
    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn As New SQLiteConnection("Data Source = C:\Users\DELL\Desktop\Voterdb.db")
        conn.Open()

        Dim sqlcmd As New SQLiteCommand
        sqlcmd.Connection = conn
        If ComboBox1.SelectedIndex = 0 Then
            sqlcmd.CommandText = "SELECT * From VoterData WHERE Name like '%" & TextBox1.Text & "%' OR Mbile like '%" & TextBox1.Text & "%' OR Email like '%" & TextBox1.Text & "%' OR Class Like '%" & TextBox1.Text & "%' "
        Else
            sqlcmd.CommandText = "SELECT * From VoterData WHERE " & ComboBox1.Text & " like '%" & TextBox1.Text & "%'"
        End If

        Dim sqlread As SQLiteDataReader = sqlcmd.ExecuteReader
        Dim sqldt As New DataTable
        sqldt.Load(sqlread)
        sqlread.Close()
        conn.Close()
        DataGridView1.DataSource = sqldt


    End Sub

    Private Sub ViewData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0

        Dim conn As New SQLiteConnection("Data Source = C:\Users\DELL\Desktop\Voterdb.db")
        conn.Open()

        Dim sqlcmd As New SQLiteCommand
        sqlcmd.Connection = conn
        sqlcmd.CommandText = "SELECT * From VoterData"

        Dim sqlread As SQLiteDataReader = sqlcmd.ExecuteReader
        Dim sqldt As New DataTable
        sqldt.Load(sqlread)
        sqlread.Close()
        conn.Close()
        DataGridView1.DataSource = sqldt

    End Sub
End Class