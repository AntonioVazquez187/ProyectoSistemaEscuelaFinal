Public Class frmAlumnoGrupo
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

    Private Sub cmbAlumno_TextChanged(sender As Object, e As EventArgs) Handles cmbAlumno.TextChanged
        Try

        Catch ex As Exception
            MsgBox("Error en la conexión." + ex.ToString)
        End Try
    End Sub
End Class