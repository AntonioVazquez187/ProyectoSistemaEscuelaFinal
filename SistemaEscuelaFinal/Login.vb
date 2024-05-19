Imports System.Data.SqlClient
Imports System.Windows

Public Class Login
    Dim con As New SqlConnection
    Dim com As New SqlCommand
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        TextBox2.PasswordChar = ""
        PictureBox4.Visible = False
        PictureBox3.Visible = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        Dim cons As String = "select * from usc where usuario='" & TextBox1.Text & "' and contraseña= '" & TextBox2.Text & "'"
        com = New SqlCommand(cons, con)
        Dim lec As SqlDataReader
        lec = com.ExecuteReader
        If lec.HasRows Then
            frmMenu.Show()
            Me.Hide()
        Else
            MsgBox("Datos invalidos")
        End If
        con.Close()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New SqlConnection("server=DESKTOP-NHJL7EQ;database=SistemaEscuela; integrated security=true")
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        TextBox2.PasswordChar = "*"
        PictureBox4.Visible = True
        PictureBox3.Visible = False
    End Sub
End Class
