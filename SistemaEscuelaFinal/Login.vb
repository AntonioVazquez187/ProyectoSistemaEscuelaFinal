Imports System.Data.SqlClient
Imports System.Windows

Public Class Login
    Dim com As New SqlCommand
    Sub Acceso()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "Acceso2"
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = TextBox1.Text
                cmd.Parameters.Add("@contraseña", SqlDbType.VarChar).Value = TextBox2.Text
                'cmd.ExecuteNonQuery()
                sqlread = cmd.ExecuteReader
                While sqlread.Read
                    Rol = (sqlread("Rol"))
                End While
                If sqlread.HasRows Then
                    If Rol = "A" Then
                        MsgBox("igresando como Alumno")
                    ElseIf Rol = "m" Then
                        MsgBox("igresando como Maestro")
                    End If
                    frmMenu.Show()
                    Me.Close()
                Else
                    MsgBox("Datos invalidos")
                End If
                sqlread.Close()
            Else
                MsgBox("Error en la conexión")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            If cmd IsNot Nothing Then
                cmd.Dispose()
            End If
            conn.Close()

        End Try
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        TextBox2.PasswordChar = ""
        PictureBox4.Visible = False
        PictureBox3.Visible = True
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        TextBox2.PasswordChar = "*"
        PictureBox4.Visible = True
        PictureBox3.Visible = False
    End Sub
End Class
