Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmKardex
    Private Sub frmKardex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaDgMatricula()
        ResetCb()
    End Sub
    Sub FiltraGrid()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                ' Definir la consulta SQL
                Dim query As String = "SELECT k.idk,k.id_materia, m.nombre,k.estado,k.calificacion,k.oportunidad,k.aprobado,k.fecha
                                       FROM kardex k
                                       JOIN materia m ON k.id_materia = m.Id_materia
                                       WHERE k.matricula = '" & ComboBox1.SelectedValue.ToString & "'"
                ' Crear un adaptador de datos y un conjunto de datos
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim dataSet As New DataSet()
                adapter.Fill(dataSet, "Results")
                ' Vincular el conjunto de datos al DataGridView
                DataGridView1.DataSource = dataSet.Tables("Results")

                conn.Close()
            Else
                MsgBox("Error en la conexión")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub
    Sub LlenaDgMatricula()
        Dim query As String = "SELECT DISTINCT k.matricula, a.nombre
                               FROM kardex k
                               JOIN Alumno a ON k.matricula = a.Matrícula"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox1.DataSource = dataTable
        ComboBox1.DisplayMember = "matricula"
        ComboBox1.ValueMember = "matricula"

        ComboBox2.DataSource = dataTable
        ComboBox2.DisplayMember = "nombre"
        ComboBox2.ValueMember = "nombre"
    End Sub
    Sub ResetCb()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
    End Sub
    Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox1.SelectionChangeCommitted
        FiltraGrid()
    End Sub
    Private Sub ComboBox2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox2.SelectionChangeCommitted
        FiltraGrid()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        FiltraGrid()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Caso = 1
        frmNvoKardex.Show()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Caso = 2
        frmNvoKardex.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[EliminarKardex]"
                cmd.Parameters.Add("@IDK", SqlDbType.Int).Value = DataGridView1.SelectedRows(0).Cells(0).Value?.ToString()
                cmd.ExecuteNonQuery()
                MsgBox("Registro eliminado del kardex")
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
        LlenaDgMatricula()
        ResetCb()
    End Sub
End Class