Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class frmMaterias
    Private Sub frmMaterias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaMaterias()
        ObtenerConsecutivo()
    End Sub
    Sub ObtenerConsecutivo()
        Dim consecutivo, TMP As String
        consecutivo = ""
        TMP = ""
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Query = "SELECT TOP 1 CONVERT(INTEGER,Id_materia)+1 AS Id_materia FROM materia ORDER BY Id_materia DESC"
                cmd = New SqlClient.SqlCommand(Query, conn)
                cmd.ExecuteNonQuery()
                sqlread = cmd.ExecuteReader

                While sqlread.Read
                    consecutivo = sqlread("Id_materia")
                End While
                sqlread.Close()
                cmd.Dispose()
                conn.Close()
                For i = consecutivo.Length + 1 To 3
                    TMP = TMP + "0"
                Next i
                consecutivo = TMP + consecutivo
                ComboBox1.Text = consecutivo
            Else
                MsgBox("Conexión fallida")
            End If
        Catch ex As Exception
            MsgBox("Error: " + ex.Message)
        End Try
    End Sub
    Sub LlenaMaterias()
        Dim query As String = "SELECT Id_materia FROM materia"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox1.DataSource = dataTable
        ComboBox1.DisplayMember = "Id_materia"
        ComboBox1.ValueMember = "Id_materia"
    End Sub
    Sub llenaNombre()
        Dim query As String = "SELECT nombre FROM materia"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox2.DataSource = dataTable
        ComboBox2.DisplayMember = "nombre"
        ComboBox2.ValueMember = "nombre"
    End Sub
    Sub TraeDescripcion()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "BuscarMateria"
                cmd.Parameters.Add("@Id_materia", SqlDbType.Char).Value = ComboBox1.SelectedValue.ToString
                'cmd.ExecuteNonQuery()
                sqlread = cmd.ExecuteReader
                While sqlread.Read
                    RichTextBox1.Text = (sqlread("descripcion"))
                    ComboBox2.Text = (sqlread("nombre"))
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
    Sub NuevaMateria()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "NuevaMateria"
                cmd.Parameters.Add("@Id_materia", SqlDbType.Char).Value = ComboBox1.Text
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = ComboBox2.Text
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = RichTextBox1.Text
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                MsgBox("Nueva materia agregada correctamente")
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
            Borrar()
            LlenaMaterias()
        End Try
    End Sub
    Sub ActualizaMateria()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "ActualizaMateria"
                cmd.Parameters.Add("@Id_materia", SqlDbType.Char).Value = ComboBox1.SelectedValue
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = ComboBox2.SelectedValue
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = RichTextBox1.Text
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                MsgBox("La materia a sido actualizada")
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
            Borrar()
            LlenaMaterias()
        End Try
    End Sub
    Sub EliminaMateria()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "EliminarMateria"
                cmd.Parameters.Add("@Id_materia", SqlDbType.Char).Value = ComboBox1.SelectedValue
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                MsgBox("La materia a sido Elimnada")
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
            Borrar()
            LlenaMaterias()
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TraeDescripcion()
    End Sub
    Sub Borrar()
        RichTextBox1.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ObtenerConsecutivo()
        NuevaMateria()
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        ActualizaMateria()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        EliminaMateria()
    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        frmAsignaPlanMateria.Show()
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        TraeDescripcion()
    End Sub
End Class