Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmAlumno
    Private Sub frmAlumno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenaGrid()
    End Sub
    Sub FiltraGrid()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim query As String = "select * from alumno where Matrícula like '%" & txtMatricula.Text & "%'"
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim dataSet As New DataSet()
                adapter.Fill(dataSet, "Results")
                dgAlumnos.DataSource = dataSet.Tables("Results")
                conn.Close()
            Else
                MsgBox("Error en la conexión")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Sub llenaGrid()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                ' Definir la consulta SQL
                Dim query As String = "select * from alumno"
                ' Crear un adaptador de datos y un conjunto de datos
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim dataSet As New DataSet()
                adapter.Fill(dataSet, "Results")
                ' Vincular el conjunto de datos al DataGridView
                dgAlumnos.DataSource = dataSet.Tables("Results")

                conn.Close()
            Else
                MsgBox("Error en la conexión")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtMatricula.TextChanged
        FiltraGrid()
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles dgAlumnos.SelectionChanged
        If dgAlumnos.SelectedRows.Count > 0 Then 'Si hay una fila seleccionada
            Dim filaSeleccionada As DataGridViewRow = dgAlumnos.SelectedRows(0) 'guarda la fila seleccionada
            ' Obtener los valores de las celdas de la fila seleccionada
            Dim Matrícula As String = filaSeleccionada.Cells(0).Value?.ToString()
            Dim Nombre As String = filaSeleccionada.Cells(1).Value?.ToString()
            Dim NSS As String = filaSeleccionada.Cells(2).Value?.ToString()
            Dim fecha_nac As String = filaSeleccionada.Cells(3).Value?.ToString()
            Dim telefono As String = filaSeleccionada.Cells(4).Value?.ToString()
            Dim direccion As String = filaSeleccionada.Cells(5).Value?.ToString()

            txtMatricula.Text = Matrícula
            txtNombre.Text = Nombre
            txtNSS.Text = NSS
            dtFechaNac.Text = fecha_nac
            txtTel.Text = telefono
            rtxtDireccion.Text = direccion
        End If
    End Sub
    Sub NuevoAlumno()
        If cmbEstado.Text <> "BAJA DEF" And cmbEstado.Text <> "BAJA TEMP" And cmbEstado.Text <> "IRREGULAR" Then
            If txtMatricula.Text <> "" And txtNombre.Text <> "" And txtNSS.Text <> "" And txtTel.Text <> "" And rtxtDireccion.Text <> "" And cmbEstado.Text <> "" Then
                Try
                    conn.Open()
                    If conn.State = ConnectionState.Open Then
                        cmd = conn.CreateCommand
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = "NuevoAlumno"
                        cmd.Parameters.Add("@Matrícula", SqlDbType.Char).Value = txtMatricula.Text
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = txtNombre.Text
                        cmd.Parameters.Add("@NSS", SqlDbType.VarChar).Value = txtNSS.Text
                        cmd.Parameters.Add("@fecha_nac", SqlDbType.Date).Value = dtFechaNac.Text
                        cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = txtTel.Text
                        cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = rtxtDireccion.Text
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = cmbEstado.Text
                        cmd.ExecuteNonQuery()
                        MsgBox("El alumno se agrego correctamente")
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
                End Try
            Else
                MsgBox("Verifique que ha llenado todos los campos antes de agregar un nuevo alumno.")
            End If
        Else
            MsgBox("El alumno de nuevo ingreso solo puede tener estado REGULAR")
        End If

    End Sub
    Sub ActualizarAlumno()
        If txtMatricula.Text <> "" And txtNombre.Text <> "" And txtNSS.Text <> "" And txtTel.Text <> "" And rtxtDireccion.Text <> "" And cmbEstado.Text <> "" Then
            Try
                conn.Open()
                If conn.State = ConnectionState.Open Then
                    cmd = conn.CreateCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "ActualizaAlumno"
                    cmd.Parameters.Add("@Matrícula", SqlDbType.Char).Value = txtMatricula.Text
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = txtNombre.Text
                    cmd.Parameters.Add("@NSS", SqlDbType.VarChar).Value = txtNSS.Text
                    cmd.Parameters.Add("@fecha_nac", SqlDbType.Date).Value = dtFechaNac.Text
                    cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = txtTel.Text
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = rtxtDireccion.Text
                    cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = cmbEstado.Text
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    MsgBox("El alumno se agrego correctamente")
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
            End Try
        Else
            MsgBox("Verifique que ha llenado todos los campos antes de actualizar un alumno.")
        End If
    End Sub
    Sub BorrarAlumno()
        If txtMatricula.Text <> "" Then
            Try
                conn.Open()
                If conn.State = ConnectionState.Open Then
                    If txtMatricula.Text <> "" Then

                    End If
                    cmd = conn.CreateCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "EliminarAlumno"
                    cmd.Parameters.Add("@Matrícula", SqlDbType.Char).Value = txtMatricula.Text.ToString
                    cmd.ExecuteNonQuery()
                    MsgBox("El alumno se eliminó correctamente")
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
            End Try
        Else
            MsgBox("Error. Debe seleccionar la matrícula del alumno a borrar.")
        End If

    End Sub
    Sub Borrar()
        txtMatricula.Clear()
        txtNombre.Clear()
        txtNSS.Clear()
        dtFechaNac.ResetText()
        txtTel.Clear()
        rtxtDireccion.Clear()
        cmbEstado.ResetText()
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles AggAlumno.Click
        NuevoAlumno()
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles ActAlumno.Click
        ActualizarAlumno()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles DelAlumno.Click
        BorrarAlumno()
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles alumno_grupo.Click
        Form7.Show()
    End Sub

    'Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    'End Sub
End Class