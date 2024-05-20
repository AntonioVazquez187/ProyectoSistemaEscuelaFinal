Imports System.Data.SqlClient

Public Class frmAsignaPlanMateria
    Private Sub frmAsignaPlanMateria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenaIdMateria()
        llenaIdPlan()
        LlenaID()
    End Sub
    Sub ObtenerConsecutivo()
        Dim consecutivo As String
        consecutivo = ""
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                Query = "SELECT TOP 1 CONVERT(INTEGER,id)+1 AS id FROM mat_plan ORDER BY id DESC"
                cmd = New SqlClient.SqlCommand(Query, conn)
                cmd.ExecuteNonQuery()
                sqlread = cmd.ExecuteReader

                While sqlread.Read
                    consecutivo = sqlread("Id_materia")
                End While
                sqlread.Close()
                cmd.Dispose()
                conn.Close()
                ComboBox3.Text = consecutivo
            Else
                MsgBox("Conexión fallida")
            End If
        Catch ex As Exception
            MsgBox("Error: " + ex.Message)
        End Try
    End Sub
    Sub LlenaID()
        Dim query As String = "SELECT id FROM mat_plan"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)
        ComboBox3.DataSource = dataTable
        ComboBox3.DisplayMember = "id"
        ComboBox3.ValueMember = "id"
        ObtenerConsecutivo()
    End Sub

    Sub llenaIdMateria()
        Dim query As String = "SELECT Id_materia,nombre FROM materia"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)
        ComboBox1.DataSource = dataTable
        ComboBox1.DisplayMember = "nombre"
        ComboBox1.ValueMember = "Id_materia"
        ComboBox1.Text = ""

        Dim valorDeseado As String = frmMaterias.ComboBox1.Text.ToString
        For i As Integer = 0 To ComboBox1.Items.Count - 1
            ComboBox1.SelectedIndex = i
            Dim valorItem As String = ComboBox1.SelectedValue
            If valorItem = valorDeseado Then
                Exit For
            Else
                ComboBox1.Text = ""
            End If
        Next
    End Sub
    Sub llenaIdPlan()
        Dim query As String = "SELECT num_plan,nombre FROM carrera"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox2.DataSource = dataTable
        ComboBox2.DisplayMember = "nombre"
        ComboBox2.ValueMember = "num_plan"
        ComboBox2.Text = ""
        Dim valorDeseado As String = frmCarrera.ComboBox1.SelectedValue
        For i As Integer = 0 To ComboBox2.Items.Count - 1
            ComboBox2.SelectedIndex = i
            Dim valorItem As String = ComboBox2.SelectedValue
            If valorItem = valorDeseado Then
                Exit For
            Else
                ComboBox2.Text = ""
            End If
        Next
    End Sub

    Sub AsignarNuevaMateria()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "NuevoMateriaPlan"
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ComboBox3.Text
                cmd.Parameters.Add("@Id_materia", SqlDbType.VarChar).Value = ComboBox1.SelectedValue
                cmd.Parameters.Add("@Id_plan", SqlDbType.VarChar).Value = ComboBox2.SelectedValue
                cmd.Parameters.Add("@horas", SqlDbType.VarChar).Value = TextBox1.Text
                cmd.ExecuteNonQuery()
                MsgBox("Nueva carrera agregada correctamente")
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
            borrar()
            LlenaID()
            'llenaIdPlan()
            llenaIdMateria()
        End Try
    End Sub
    Sub ActualizarAsignacion()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "ActualizaMateriaPlan"
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ComboBox3.Text
                cmd.Parameters.Add("@Id_materia", SqlDbType.VarChar).Value = ComboBox1.SelectedValue
                cmd.Parameters.Add("@Id_plan", SqlDbType.VarChar).Value = ComboBox2.SelectedValue
                cmd.Parameters.Add("@horas", SqlDbType.VarChar).Value = TextBox1.Text
                cmd.ExecuteNonQuery()
                MsgBox("Nueva carrera agregada correctamente")
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
            borrar()
            LlenaID()
            'llenaIdPlan()
            llenaIdMateria()
        End Try
    End Sub
    Sub EliminarAsignacion()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "EliminarMateriaPlan"
                cmd.Parameters.Add("@id", SqlDbType.Char).Value = ComboBox3.Text
                cmd.ExecuteNonQuery()
                sqlread = cmd.ExecuteReader
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
    Sub BuscarAsignacion()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "BuscarMateriaPlan"
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ComboBox3.Text
                'cmd.ExecuteNonQuery()
                sqlread = cmd.ExecuteReader
                While sqlread.Read
                    ComboBox1.Text = (sqlread("Id_materia"))
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
                    ComboBox2.Text = (sqlread("Id_plan"))
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
                    TextBox1.Text = (sqlread("horas"))
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
    Sub borrar()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox2.Text = ""
        TextBox1.Text = ""
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        AsignarNuevaMateria()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        ActualizarAsignacion()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        EliminarAsignacion()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        BuscarAsignacion()
    End Sub
End Class