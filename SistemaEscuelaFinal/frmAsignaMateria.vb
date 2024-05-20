Imports System.Data.SqlClient

Public Class frmAsignaMateria
    Private Sub frmAsignaMateria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaidAsignamateria()
        llenaGrupo()
        LlenaIdMaestro()
        LlenaMaterias()
    End Sub
    Sub LlenaidAsignamateria()
        Dim query As String = "SELECT Id_AM FROM asigna_materia"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox1.DataSource = dataTable
        ComboBox1.DisplayMember = "Id_AM"
        ComboBox1.ValueMember = "Id_AM"
    End Sub
    Sub LlenaIdMaestro()
        Dim query As String = "SELECT Matrícula,Nombre FROM Maestro"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox2.DataSource = dataTable
        ComboBox2.DisplayMember = "Nombre"
        ComboBox2.ValueMember = "Matrícula"
    End Sub
    Sub LlenaMaterias()

        Dim query As String = "SELECT Id_materia,nombre FROM materia"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox4.DataSource = dataTable
        ComboBox4.DisplayMember = "nombre"
        ComboBox4.ValueMember = "Id_materia"
    End Sub
    Sub llenaGrupo()
        Dim query As String = "SELECT 
                                (g.semestre + ' - ' + c.nombre + ' - ' + g.turno) AS DescripcionGrupo, 
                                 g.id_grupo AS id_grupo
                                 FROM grupo g
                                 JOIN carrera c ON g.Id_carrera = c.num_plan;"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox3.DataSource = dataTable
        ComboBox3.DisplayMember = "DescripcionGrupo"
        ComboBox3.ValueMember = "id_grupo"
    End Sub

    Sub GuardaMaestroMateria()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "NuevoAsignaMateria"
                cmd.Parameters.Add("@Id_AM", SqlDbType.Int).Value = ComboBox1.Text
                cmd.Parameters.Add("@Id_maestro", SqlDbType.Char).Value = ComboBox2.SelectedValue
                cmd.Parameters.Add("@Id_materia", SqlDbType.Char).Value = ComboBox3.SelectedValue
                cmd.Parameters.Add("@Id_grupo", SqlDbType.Char).Value = ComboBox4.SelectedValue
                cmd.Parameters.Add("@fecha_alta", SqlDbType.Date).Value = DateTimePicker1.Text
                cmd.Parameters.Add("@fecha_baja", SqlDbType.Date).Value = DateTimePicker2.Text
                cmd.ExecuteNonQuery()
                MsgBox("Materia Asignada")
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
    Sub ActualizaMaestroMateria()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "ActualizaAsignaMateria"
                cmd.Parameters.Add("@Id_AM", SqlDbType.Int).Value = ComboBox1.SelectedValue
                cmd.Parameters.Add("@Id_maestro", SqlDbType.Char).Value = ComboBox2.SelectedValue
                cmd.Parameters.Add("@Id_materia", SqlDbType.Char).Value = ComboBox3.SelectedValue
                cmd.Parameters.Add("@Id_grupo", SqlDbType.Char).Value = ComboBox4.SelectedValue
                cmd.Parameters.Add("@fecha_alta", SqlDbType.Date).Value = DateTimePicker1.Text
                cmd.Parameters.Add("@fecha_baja", SqlDbType.Date).Value = DateTimePicker2.Text
                cmd.ExecuteNonQuery()
                MsgBox("Materia Asignada actualizada")
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
    Sub EliminaMaestroMateria()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "EliminarAsignaMateria"
                cmd.Parameters.Add("@Id_AM", SqlDbType.Int).Value = ComboBox1.SelectedValue
                cmd.ExecuteNonQuery()
                MsgBox("Materia Asignada actualizada")
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
    Sub Busca()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "BuscarAsignaMateria"
                cmd.Parameters.Add("@Id_AM", SqlDbType.Int).Value = ComboBox1.SelectedValue
                'cmd.ExecuteNonQuery()
                sqlread = cmd.ExecuteReader
                While sqlread.Read
                    ComboBox1.Text = (sqlread("Id_AM"))
                    Dim valorDeseado As String = ComboBox1.Text
                    For i As Integer = 0 To ComboBox1.Items.Count - 1
                        ComboBox1.SelectedIndex = i
                        Dim valorItem As String = ComboBox1.SelectedValue
                        If valorItem = valorDeseado Then
                            Exit For
                        Else
                            ComboBox1.Text = ""
                        End If
                    Next
                    ComboBox2.Text = (sqlread("Id_maestro"))
                    valorDeseado = ComboBox2.Text
                    For i As Integer = 0 To ComboBox2.Items.Count - 1
                        ComboBox2.SelectedIndex = i
                        Dim valorItem As String = ComboBox2.SelectedValue
                        If valorItem = valorDeseado Then
                            Exit For
                        Else
                            ComboBox2.Text = ""
                        End If
                    Next
                    ComboBox3.Text = (sqlread("Id_materia"))
                    valorDeseado = ComboBox3.Text
                    For i As Integer = 0 To ComboBox3.Items.Count - 1
                        ComboBox3.SelectedIndex = i
                        Dim valorItem As String = ComboBox3.SelectedValue
                        If valorItem = valorDeseado Then
                            Exit For
                        Else
                            ComboBox3.Text = ""
                        End If
                    Next
                    ComboBox4.Text = (sqlread("Id_grupo"))
                    valorDeseado = ComboBox4.Text
                    For i As Integer = 0 To ComboBox4.Items.Count - 1
                        ComboBox4.SelectedIndex = i
                        Dim valorItem As String = ComboBox4.SelectedValue
                        If valorItem = valorDeseado Then
                            Exit For
                        Else
                            ComboBox4.Text = ""
                        End If
                    Next
                    DateTimePicker1.Text = (sqlread("fecha_alta"))
                    DateTimePicker2.Text = (sqlread("fecha_baja"))
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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        GuardaMaestroMateria()
        LlenaidAsignamateria()
        llenaGrupo()
        LlenaIdMaestro()
        LlenaMaterias()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        ActualizaMaestroMateria()
        LlenaidAsignamateria()
        llenaGrupo()
        LlenaIdMaestro()
        LlenaMaterias()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        EliminaMaestroMateria()
        LlenaidAsignamateria()
        llenaGrupo()
        LlenaIdMaestro()
        LlenaMaterias()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Busca()
    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        frmHorarios.Show()
    End Sub
End Class


