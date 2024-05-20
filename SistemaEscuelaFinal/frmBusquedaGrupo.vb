Public Class frmBusquedaGrupo
    Private Sub frmBusquedaGrupo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Semestre.Items.Clear()
        Nombre.Items.Clear()
        Turno.Items.Clear()
        Dim query As String
        conn.Open()
        query = "select distinct g.semestre AS semestre, c.nombre AS nombre, g.turno AS turno from grupo as g
 inner JOIN carrera as c on g.Id_carrera=c.num_plan WHERE g.Id_carrera like '%" & Busqueda.Text & "%' OR Nombre like '%" & Busqueda.Text & "%'"
        cmd = New SqlClient.SqlCommand(query, conn)
        cmd.ExecuteNonQuery()
        sqlread = cmd.ExecuteReader
        While sqlread.Read
            Semestre.Items.Add(sqlread("semestre"))
            Nombre.Items.Add(sqlread("nombre"))
            Turno.Items.Add(sqlread("turno"))
        End While
        sqlread.Close()
        cmd.Dispose()
        conn.Close()
    End Sub

    Private Sub Busqueda_TextChanged(sender As Object, e As EventArgs) Handles Busqueda.TextChanged
        Semestre.Items.Clear()
        Nombre.Items.Clear()
        Turno.Items.Clear()
        Dim query As String
        conn.Open()
        query = "select distinct g.semestre AS semestre, c.nombre AS nombre, g.turno AS turno from grupo as g
 inner JOIN carrera as c on g.Id_carrera=c.num_plan WHERE g.Id_carrera like '%" & Busqueda.Text & "%' OR Nombre like '%" & Busqueda.Text & "%'"
        cmd = New SqlClient.SqlCommand(query, conn)
        cmd.ExecuteNonQuery()
        sqlread = cmd.ExecuteReader
        While sqlread.Read
            Semestre.Items.Add(sqlread("semestre"))
            Nombre.Items.Add(sqlread("nombre"))
            Turno.Items.Add(sqlread("turno"))
        End While
        sqlread.Close()
        cmd.Dispose()
        conn.Close()
    End Sub

    Private Sub Semestre_DoubleClick(sender As Object, e As EventArgs) Handles Semestre.DoubleClick
        frmAlumnoGrupo.cmbGrupo.Text = Nombre.Text
        Me.Close()
    End Sub

    Private Sub Nombre_DoubleClick(sender As Object, e As EventArgs) Handles Nombre.DoubleClick
        frmAlumnoGrupo.cmbGrupo.Text = Nombre.Text
        Me.Close()
    End Sub

    Private Sub Turno_DoubleClick(sender As Object, e As EventArgs) Handles Turno.DoubleClick
        frmAlumnoGrupo.cmbGrupo.Text = Nombre.Text
        Me.Close()
    End Sub

    Private Sub Semestre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Semestre.SelectedIndexChanged
        Nombre.SelectedIndex = Semestre.SelectedIndex
        Turno.SelectedIndex = Semestre.SelectedIndex
    End Sub

    Private Sub Nombre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Nombre.SelectedIndexChanged
        Semestre.SelectedIndex = Nombre.SelectedIndex
        Turno.SelectedIndex = Nombre.SelectedIndex
    End Sub

    Private Sub Turno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Turno.SelectedIndexChanged
        Semestre.SelectedIndex = Turno.SelectedIndex
        Nombre.SelectedIndex = Turno.SelectedIndex
    End Sub
End Class