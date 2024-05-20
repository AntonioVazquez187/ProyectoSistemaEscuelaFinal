Public Class frmBusquedaAlumno
    Private Sub txtNombrePza_TextChanged(sender As Object, e As EventArgs) Handles Busqueda.TextChanged

        Matricula.Items.Clear()
        Nombre.Items.Clear()
        Estado.Items.Clear()
        Dim query As String
        conn.Open()
        query = "SELECT Matrícula AS Matricula1,Nombre AS Nombre1,Estado AS Estado1 FROM Alumno
      WHERE Matrícula like '%" & Busqueda.Text & "%' OR Nombre like '%" & Busqueda.Text & "%'"
        cmd = New SqlClient.SqlCommand(query, conn)
        cmd.ExecuteNonQuery()
        sqlread = cmd.ExecuteReader
        While sqlread.Read
            Matricula.Items.Add(sqlread("Matricula1"))
            Nombre.Items.Add(sqlread("Nombre1"))
            Estado.Items.Add(sqlread("Estado1"))

        End While
        sqlread.Close()
        cmd.Dispose()
        conn.Close()

    End Sub

    Private Sub frmBusquedaAlumno_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Matricula.Items.Clear()
        Nombre.Items.Clear()
        Estado.Items.Clear()
        Dim query As String
        conn.Open()
        query = "SELECT Matrícula AS Matricula1,Nombre AS Nombre1,Estado AS Estado1 FROM Alumno
      WHERE Matrícula like '%" & Busqueda.Text & "%' OR Nombre like '%" & Busqueda.Text & "%'"
        cmd = New SqlClient.SqlCommand(query, conn)
        cmd.ExecuteNonQuery()
        sqlread = cmd.ExecuteReader
        While sqlread.Read
            Matricula.Items.Add(sqlread("Matricula1"))
            Nombre.Items.Add(sqlread("Nombre1"))
            Estado.Items.Add(sqlread("Estado1"))

        End While
        sqlread.Close()
        cmd.Dispose()
        conn.Close()
    End Sub

    Private Sub Matricula_DoubleClick(sender As Object, e As EventArgs) Handles Matricula.DoubleClick
        frmAlumnoGrupo.cmbAlumno.Text = Nombre.Text
        Me.Close()
    End Sub

    Private Sub Nombre_DoubleClick(sender As Object, e As EventArgs) Handles Nombre.DoubleClick
        frmAlumnoGrupo.cmbAlumno.Text = Nombre.Text
        Me.Close()
    End Sub

    Private Sub Estado_DoubleClick(sender As Object, e As EventArgs) Handles Estado.DoubleClick
        frmAlumnoGrupo.cmbAlumno.Text = Nombre.Text
        Me.Close()
    End Sub

    Private Sub Matricula_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Matricula.SelectedIndexChanged
        Nombre.SelectedIndex = Matricula.SelectedIndex
        Estado.SelectedIndex = Matricula.SelectedIndex
    End Sub

    Private Sub Nombre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Nombre.SelectedIndexChanged
        Matricula.SelectedIndex = Nombre.SelectedIndex
        Estado.SelectedIndex = Nombre.SelectedIndex

    End Sub

    Private Sub Estado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Estado.SelectedIndexChanged
        Matricula.SelectedIndex = Estado.SelectedIndex
        Nombre.SelectedIndex = Estado.SelectedIndex
    End Sub
End Class