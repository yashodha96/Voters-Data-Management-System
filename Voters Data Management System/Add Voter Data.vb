Imports System.ComponentModel
Imports System.Data.SQLite
Imports System

Public Class Add_Voter_Data
    Private Sub Add_Voter_Data_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        Dim sqlconnection As New SQLiteConnection("Data Source = C:\Users\DELL\Desktop\Voterdb.db")
        Try
            If sqlconnection.State = ConnectionState.Closed Then
                sqlconnection.Open()
                Dim sqlstatement As String = "INSERT INTO 'VoterData' ('Name', 'Mobile', 'Email', 'Class') VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "');"
                Dim cmd As SQLiteCommand = New SQLiteCommand
                With cmd
                    .CommandText = sqlstatement
                    .CommandType = CommandType.Text
                    .Connection = sqlconnection
                    .ExecuteNonQuery()

                End With

                sqlconnection.Close()
                MsgBox("Successfully Added!", "Success")
            Else
                sqlconnection.Close()
                MsgBox("Connection Error!", "Error")

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form1.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing

    End Sub
End Class