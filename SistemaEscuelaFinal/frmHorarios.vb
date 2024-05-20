Imports System.Data.SqlClient
Imports System.Security.Cryptography
Public Class frmHorarios
    Private Sub frmHorarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenaMateriaAsignada()
        llenaIDS()
    End Sub
    Sub llenaIDS()
        Dim query As String = "SELECT DISTINCT idh FROM Horario"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox2.DataSource = dataTable
        ComboBox2.DisplayMember = "idh"
        ComboBox2.ValueMember = "idh"
    End Sub
    Sub llenaMateriaAsignada()
        Dim query As String = "SELECT DISTINCT id_AM FROM Horario"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox1.DataSource = dataTable
        ComboBox1.DisplayMember = "id_AM"
        ComboBox1.ValueMember = "id_AM"
    End Sub
    Sub llenaGrid()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Dim query As String = "SELECT DISTINCT
                                        m.Nombre AS NombreMaestro,
                                        mt.nombre AS NombreMateria,
                                        g.semestre + ' - ' + c.nombre + ' - ' + g.turno AS DetallesGrupo
                                        FROM horario h
                                        JOIN asigna_materia am ON h.Id_AM = am.Id_AM
                                        JOIN Maestro m ON am.Id_maestro = m.Matrícula
                                        JOIN materia mt ON am.Id_materia = mt.Id_materia
                                        JOIN grupo g ON am.Id_grupo = g.id_grupo
                                        JOIN carrera c ON g.Id_carrera = c.num_plan
                                        WHERE h.Id_AM = " & ComboBox1.SelectedValue & ";"
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim dataSet As New DataSet()
                adapter.Fill(dataSet, "Results")
                DataGridView1.DataSource = dataSet.Tables("Results")

                conn.Close()
            Else
                MsgBox("Error en la conexión")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub
    Sub GuardaHorario()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "NuevoHorario"
                cmd.Parameters.Add("@Id_AM", SqlDbType.Int).Value = ComboBox1.Text
                cmd.Parameters.Add("@dia", SqlDbType.Char).Value = TextBox1.Text
                Dim timeValue As TimeSpan = DateTimePicker1.Value.TimeOfDay
                cmd.Parameters.Add("@hora_i", SqlDbType.Time).Value = timeValue
                timeValue = DateTimePicker2.Value.TimeOfDay
                cmd.Parameters.Add("@hora_f", SqlDbType.Time).Value = timeValue
                cmd.ExecuteNonQuery()
                MsgBox("Horario cargado satisfactoriamente")
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
    Sub buscar()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "BuscarHorario"
                cmd.Parameters.Add("@idh", SqlDbType.Int).Value = ComboBox2.SelectedValue
                'cmd.ExecuteNonQuery()
                sqlread = cmd.ExecuteReader
                While sqlread.Read
                    ComboBox1.Text = (sqlread("id_AM"))
                    TextBox1.Text = (sqlread("dia"))
                    Dim timeValue As TimeSpan = (sqlread("Hora_i"))
                    Dim datevalue As DateTime = DateTime.Today.Add(timeValue)
                    DateTimePicker1.Value = datevalue
                    timeValue = (sqlread("Hora_f"))
                    datevalue = DateTime.Today.Add(timeValue)
                    DateTimePicker2.Value = datevalue
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
    Sub eliminaHorario()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "EliminarHorario"
                cmd.Parameters.Add("@idh", SqlDbType.Int).Value = ComboBox1.Text
                cmd.ExecuteNonQuery()
                MsgBox("horario eliminado satisfactoriamentre")
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
    Sub ActualizaHorario()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "ActualizaHorario"
                cmd.Parameters.Add("@idh", SqlDbType.Int).Value = ComboBox2.Text
                cmd.Parameters.Add("@Id_AM", SqlDbType.Int).Value = ComboBox1.Text
                cmd.Parameters.Add("@dia", SqlDbType.Char).Value = TextBox1.Text
                Dim timeValue As TimeSpan = DateTimePicker1.Value.TimeOfDay
                cmd.Parameters.Add("@hora_i", SqlDbType.Time).Value = timeValue
                timeValue = DateTimePicker2.Value.TimeOfDay
                cmd.Parameters.Add("@hora_f", SqlDbType.Time).Value = timeValue
                cmd.ExecuteNonQuery()
                MsgBox("Horario cargado satisfactoriamente")
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
    Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox1.SelectionChangeCommitted
        llenaGrid()
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim idAM As Integer = ComboBox1.Text
        Dim dia As String = TextBox1.Text
        Dim horaInicio As TimeSpan = DateTimePicker1.Value.TimeOfDay
        Dim horaFin As TimeSpan = DateTimePicker2.Value.TimeOfDay
        Dim Resultado As Boolean = AgregarHorario(idAM, dia, horaInicio, horaFin)
        If Resultado = True Then
            GuardaHorario()
            llenaMateriaAsignada()
            llenaIDS()
            MsgBox("Horario agregado exitosamente.")
        Else
            MsgBox("Conflicto de horario detectado.")
        End If

    End Sub
    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click
        buscar()
    End Sub
    Private Sub PictureBox3_Click_1(sender As Object, e As EventArgs) Handles PictureBox3.Click
        eliminaHorario()
        llenaMateriaAsignada()
        llenaIDS()
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim idAM As Integer = ComboBox1.Text
        Dim dia As String = TextBox1.Text
        Dim horaInicio As TimeSpan = DateTimePicker1.Value.TimeOfDay
        Dim horaFin As TimeSpan = DateTimePicker2.Value.TimeOfDay
        Dim Resultado As Boolean = AgregarHorario(idAM, dia, horaInicio, horaFin)
        If Resultado = True Then
            ActualizaHorario()
            llenaMateriaAsignada()
            llenaIDS()
            MsgBox("Horario agregado exitosamente.")
        Else
            MsgBox("Conflicto de horario detectado.")
        End If

    End Sub

    Public Function AgregarHorario(idAM As Integer, dia As String, horaInicio As TimeSpan, horaFin As TimeSpan) As Boolean
        Dim connectionString As String = "data source= DESKTOP-1SLCMB1\TEW_SQLEXPRESS; initial catalog=SistemaEscuela2; integrated security= SSPI; persist security info= false; trusted_connection = yes;"
        Dim query As String = "SELECT hora_i, hora_f FROM horario h INNER JOIN asigna_materia am ON h.Id_AM = am.Id_AM WHERE am.Id_maestro = (SELECT Id_maestro FROM asigna_materia WHERE Id_AM = @IdAM) AND h.dia = @Dia"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Verificar los horarios existentes
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@IdAM", idAM)
                command.Parameters.AddWithValue("@Dia", dia)

                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim horaExistenteInicio As TimeSpan = reader.GetTimeSpan(0)
                        Dim horaExistenteFin As TimeSpan = reader.GetTimeSpan(1)

                        If (horaInicio < horaExistenteFin) AndAlso (horaFin > horaExistenteInicio) Then
                            ' Conflicto de horario
                            Return False
                        End If
                    End While
                End Using
            End Using

            ' Si no hay conflicto, insertar el nuevo horario
            Dim insertQuery As String = "INSERT INTO horario (Id_AM, dia, hora_i, hora_f) VALUES (@IdAM, @Dia, @HoraInicio, @HoraFin)"
            Using insertCommand As New SqlCommand(insertQuery, connection)
                insertCommand.Parameters.AddWithValue("@IdAM", idAM)
                insertCommand.Parameters.AddWithValue("@Dia", dia)
                insertCommand.Parameters.AddWithValue("@HoraInicio", horaInicio)
                insertCommand.Parameters.AddWithValue("@HoraFin", horaFin)
                insertCommand.ExecuteNonQuery()
            End Using
        End Using

        Return True
    End Function
End Class