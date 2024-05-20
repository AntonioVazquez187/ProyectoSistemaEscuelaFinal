Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class frmNvoKardex
    Private Sub frmNvoKardex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenaCbIDmateria()
        TraeDatos()
    End Sub
    Sub TraeDatos()
        Try
            Select Case Caso
                Case 1
                    TextBox1.Text = frmKardex.ComboBox1.SelectedValue
                    TextBox6.Text = frmKardex.ComboBox2.SelectedValue
                Case 2
                    TextBox1.Text = frmKardex.ComboBox1.SelectedValue
                    TextBox6.Text = frmKardex.ComboBox2.SelectedValue
                    TextBox2.Text = frmKardex.DataGridView1.SelectedRows(0).Cells(3).Value?.ToString()
                    ComboBox1.Text = frmKardex.DataGridView1.SelectedRows(0).Cells(1).Value?.ToString()
                    TextBox3.Text = frmKardex.DataGridView1.SelectedRows(0).Cells(4).Value?.ToString()
                    TextBox4.Text = frmKardex.DataGridView1.SelectedRows(0).Cells(5).Value?.ToString()
                    TextBox5.Text = frmKardex.DataGridView1.SelectedRows(0).Cells(6).Value?.ToString()
                    DateTimePicker1.Text = frmKardex.DataGridView1.SelectedRows(0).Cells(7).Value?.ToString()
            End Select
        Catch ex As Exception
            MsgBox("Selecciona un renglon por la izquierda")
        End Try
    End Sub
    Sub llenaCbIDmateria()
        Dim query As String = "SELECT Id_materia,nombre FROM materia"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox1.DataSource = dataTable
        ComboBox1.DisplayMember = "nombre"
        ComboBox1.ValueMember = "Id_materia"
    End Sub
    Sub NuevoKardex()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "NuevoKardex"
                cmd.Parameters.Add("@matricula", SqlDbType.Char).Value = TextBox1.Text
                cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = TextBox2.Text
                cmd.Parameters.Add("@id_materia", SqlDbType.Int).Value = ComboBox1.SelectedValue
                cmd.Parameters.Add("@calificacion", SqlDbType.Decimal).Value = TextBox3.Text
                cmd.Parameters.Add("@oportunidad", SqlDbType.Char).Value = TextBox4.Text
                cmd.Parameters.Add("@aprobado", SqlDbType.Char).Value = TextBox5.Text
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = DateTimePicker1.Text
                cmd.ExecuteNonQuery()
                MsgBox("Registro agregado al kardex")
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
    Sub ActualizaKardex()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "ActualizaKardex"
                cmd.Parameters.Add("@idk", SqlDbType.Int).Value = frmKardex.DataGridView1.SelectedRows(0).Cells(0).Value?.ToString()
                cmd.Parameters.Add("@matricula", SqlDbType.Char).Value = TextBox1.Text
                cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = TextBox2.Text
                cmd.Parameters.Add("@id_materia", SqlDbType.Int).Value = ComboBox1.SelectedValue
                cmd.Parameters.Add("@calificacion", SqlDbType.Decimal).Value = TextBox3.Text
                cmd.Parameters.Add("@oportunidad", SqlDbType.Char).Value = TextBox4.Text
                cmd.Parameters.Add("@aprobado", SqlDbType.Char).Value = TextBox5.Text
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = DateTimePicker1.Text
                cmd.ExecuteNonQuery()
                MsgBox("Registro actualizado kardex")
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Select Case Caso
            Case 1
                NuevoKardex()
            Case 2
                ActualizaKardex()
        End Select
    End Sub
End Class