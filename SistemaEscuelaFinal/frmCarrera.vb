Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmCarrera
    Private Sub frmCarrera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaCarrera()
        llenaNombre()
    End Sub
    Sub LlenaCarrera()
        Dim query As String = "SELECT num_plan FROM carrera"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox1.DataSource = dataTable
        ComboBox1.DisplayMember = "num_plan"
        ComboBox1.ValueMember = "num_plan"
    End Sub
    Sub llenaNombre()
        Dim query As String = "SELECT nombre FROM carrera"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox2.DataSource = dataTable
        ComboBox2.DisplayMember = "nombre"
        ComboBox2.ValueMember = "nombre"
    End Sub
    Sub NuevaCarrera()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "NuevaCarrera"
                cmd.Parameters.Add("@num_plan", SqlDbType.Char).Value = ComboBox1.Text
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = ComboBox2.Text
                cmd.Parameters.Add("@semestres", SqlDbType.VarChar).Value = TextBox1.Text
                cmd.ExecuteNonQuery()
                MsgBox("Nueva carrera agregada correctamente")
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
            borrar()
            LlenaCarrera()
            llenaNombre()
        End Try
    End Sub
    Sub ActualizaCarrera()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "ActualizaCarrera"
                cmd.Parameters.Add("@num_plan", SqlDbType.Char).Value = ComboBox1.Text
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = ComboBox2.Text
                cmd.Parameters.Add("@semestres", SqlDbType.VarChar).Value = TextBox1.Text
                cmd.ExecuteNonQuery()
                MsgBox("Carrera Actualizada Correctamente")
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
            borrar()
            LlenaCarrera()
            llenaNombre()
        End Try
    End Sub
    Sub BorrarCarrera()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "EliminarCarrera"
                cmd.Parameters.Add("@num_plan", SqlDbType.Char).Value = ComboBox1.Text
                cmd.ExecuteNonQuery()
                sqlread = cmd.ExecuteReader
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
            LlenaCarrera()
            llenaNombre()
        End Try
    End Sub
    Sub BuscarCarrera()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "BuscarCarrera"
                cmd.Parameters.Add("@num_plan", SqlDbType.Char).Value = ComboBox1.Text
                'cmd.ExecuteNonQuery()
                sqlread = cmd.ExecuteReader
                While sqlread.Read
                    ComboBox2.Text = (sqlread("nombre"))
                    TextBox1.Text = (sqlread("semestres"))
                End While
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
    Sub borrar()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TextBox1.Clear()
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        BuscarCarrera()
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        NuevaCarrera()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        ActualizaCarrera()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        BorrarCarrera()
    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        frmAsignaPlanMateria.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        BuscarCarrera()
    End Sub
End Class