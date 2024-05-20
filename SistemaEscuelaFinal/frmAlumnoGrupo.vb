Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmAlumnoGrupo
    Private ignoreTextChanged As Boolean = False
    Private Sub frmAlumnoGrupo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmbAlumno_DropDown(sender As Object, e As EventArgs) Handles cmbAlumno.DropDown
        Try
            conn.Open()
            Query = "select Matrícula,Nombre from Alumno"
            cmd = New SqlClient.SqlCommand(Query, conn)
            cmd.ExecuteNonQuery()
            sqlread = cmd.ExecuteReader
            While sqlread.Read
                cmbAlumno.Items.Add(New ObtenerID(sqlread("Nombre"), sqlread("Matrícula")))
            End While
            sqlread.Close()
            cmd.Dispose()
            conn.Close()
        Catch ex As Exception
            MsgBox("Error en la conexión." + ex.ToString)
        End Try
    End Sub

    Private Sub limpiar()
        cmbAlumno.ResetText()
        cmbGrupo.ResetText()
    End Sub

    Private Sub cmbGrupo_DropDown(sender As Object, e As EventArgs) Handles cmbGrupo.DropDown
        Try
            conn.Open()
            Query = "select distinct g.semestre, c.nombre, g.turno, g.Id_carrera from grupo as g
                JOIN carrera as c on g.Id_carrera=c.num_plan"
            cmd = New SqlClient.SqlCommand(Query, conn)
            cmd.ExecuteNonQuery()
            sqlread = cmd.ExecuteReader
            While sqlread.Read
                Dim nombre As String = sqlread("semestre") & " - " & sqlread("nombre") & "-" & sqlread("turno").ToString()
                Dim matricula As String = sqlread("Id_carrera").ToString
                cmbGrupo.Items.Add(New ObtenerID(nombre, matricula))
            End While
            sqlread.Close()
            cmd.Dispose()
            conn.Close()
        Catch ex As Exception
            MsgBox("Error en la conexión." + ex.ToString)
        End Try
    End Sub

    Private Sub picAgg_Click(sender As Object, e As EventArgs) Handles picAgg.Click
        If cmbAlumno.Text <> "" And cmbGrupo.Text <> "" Then
            Dim matricula, id_gpo As String
            matricula = CType(cmbAlumno.Items(cmbAlumno.SelectedIndex), ObtenerID).ItemData
            id_gpo = CType(cmbGrupo.Items(cmbGrupo.SelectedIndex), ObtenerID).ItemData
            Try
                conn.Open()
                If conn.State = ConnectionState.Open Then
                    cmd = conn.CreateCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "NuevoAlumnoGrupo"
                    cmd.Parameters.Add("@id_alumno", SqlDbType.Char).Value = matricula
                    cmd.Parameters.Add("@id_grupo", SqlDbType.Char).Value = id_gpo
                    cmd.ExecuteNonQuery()
                    MsgBox("El alumno se asignó al grupo correctamente")
                    cmd.Dispose()
                    conn.Close()
                    limpiar()
                Else
                    MsgBox("Error en la conexión")
                End If
            Catch ex As Exception
                MsgBox("Error en la conexión." + ex.Message)
            End Try
        End If
    End Sub

    Private Sub picAct_Click(sender As Object, e As EventArgs) Handles picAct.Click
        If cmbAlumno.Text <> "" And cmbGrupo.Text <> "" Then
            Dim matricula, id_gpo As String
            matricula = CType(cmbAlumno.Items(cmbAlumno.SelectedIndex), ObtenerID).ItemData
            id_gpo = CType(cmbGrupo.Items(cmbGrupo.SelectedIndex), ObtenerID).ItemData
            Try
                conn.Open()
                If conn.State = ConnectionState.Open Then
                    cmd = conn.CreateCommand
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "ActualizaAlumnoGrupo"
                    cmd.Parameters.Add("@id_alumno", SqlDbType.Char).Value = matricula
                    cmd.Parameters.Add("@id_grupo", SqlDbType.Char).Value = id_gpo
                    cmd.ExecuteNonQuery()
                    MsgBox("El alumno se asignó al grupo correctamente")
                    cmd.Dispose()
                    conn.Close()
                    limpiar()
                Else
                    MsgBox("Error en la conexión")
                End If
            Catch ex As Exception
                MsgBox("Error en la conexión." + ex.Message)
            End Try
        End If
    End Sub

    Private Sub picBuscar_Click(sender As Object, e As EventArgs) Handles picBuscar.Click
        cmbGrupo.Text = ""
        BuscaGrupoAsignado()
    End Sub

    Sub BuscaGrupoAsignado()
        Dim matricula As String
        Dim encontro As Boolean = False
        matricula = CType(cmbAlumno.Items(cmbAlumno.SelectedIndex), ObtenerID).ItemData
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "BuscarAlumnoGrupo"
                cmd.Parameters.Add("@id_alumno", SqlDbType.Char).Value = matricula
                'cmd.ExecuteNonQuery()
                sqlread = cmd.ExecuteReader
                While sqlread.Read
                    cmbGrupo.Text = (sqlread("id_grupo"))
                    Dim valorDeseado1 As String = cmbGrupo.Text
                    Dim indice1 As Integer = cmbGrupo.FindStringExact(valorDeseado1)
                    If indice1 <> -1 Then
                        cmbGrupo.SelectedIndex = indice1
                        encontro = True
                    End If
                End While
                sqlread.Close()
                Dim query As String
                    query = "select id_grupo,semestre from grupo WHERE id_grupo='" & cmbGrupo.Text & "'"
                    cmd = New SqlClient.SqlCommand(query, conn)
                    cmd.ExecuteNonQuery()
                    sqlread = cmd.ExecuteReader
                    While sqlread.Read
                        cmbGrupo.Text = (New ObtenerID(sqlread("semestre"), sqlread("id_grupo"))).ToString
                    End While
                    sqlread.Close()
                    cmd.Dispose()
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

    Private Sub EncontrarAlumnoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncontrarAlumnoToolStripMenuItem.Click
        frmBusquedaAlumno.Show()
    End Sub
End Class