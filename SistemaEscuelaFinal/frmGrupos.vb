Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class frmGrupos
    Private Sub frmGrupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizaCB()
        borrar()
    End Sub
    Sub LlenaIdGrupo()
        Dim query As String = "SELECT id_grupo FROM grupo"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox1.DataSource = dataTable
        ComboBox1.DisplayMember = "id_grupo"
        ComboBox1.ValueMember = "id_grupo"
    End Sub
    Sub LlenaIdCarrera()
        Dim query As String = "select num_plan,nombre from carrera"
        Dim adapter As New SqlDataAdapter(query, conn)
        Dim dataTable As New DataTable()
        adapter.Fill(dataTable)

        ComboBox3.DataSource = dataTable
        ComboBox3.DisplayMember = "nombre"
        ComboBox3.ValueMember = "num_plan"
    End Sub
    Sub llenaTurnos()
        ' Crear una lista de ListItem
        Dim items As New List(Of ListItem)()

        ' Agregar elementos a la lista
        items.Add(New ListItem("M", "Matutino"))
        items.Add(New ListItem("V", "Vespertino"))

        ' Asignar la lista como origen de datos del ComboBox
        ComboBox4.DataSource = items

        ' Establecer los campos DisplayMember y ValueMember
        ComboBox4.ValueMember = "Value"
        ComboBox4.DisplayMember = "Text"
    End Sub
    Sub llenaSemestres()
        Dim elementos As String() = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"}
        ComboBox2.Items.AddRange(elementos)
    End Sub
    Sub ActualizaCB()
        LlenaIdCarrera()
        LlenaIdGrupo()
        llenaTurnos()
        llenaSemestres()
    End Sub
    Sub NuevoGrupo()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "NuevoGrupo"
                cmd.Parameters.Add("@id_grupo", SqlDbType.Char).Value = ComboBox1.Text
                cmd.Parameters.Add("@semestre", SqlDbType.Char).Value = ComboBox2.Text
                cmd.Parameters.Add("@Id_carrera", SqlDbType.Char).Value = ComboBox3.SelectedValue
                cmd.Parameters.Add("@turno", SqlDbType.Char).Value = ComboBox4.SelectedValue
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
            borrar()
            ActualizaCB()
        End Try
    End Sub
    Sub ActualizaGrupo()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "ActualizaGrupo"
                cmd.Parameters.Add("@id_grupo", SqlDbType.Char).Value = ComboBox1.Text
                cmd.Parameters.Add("@semestre", SqlDbType.Char).Value = ComboBox2.Text
                cmd.Parameters.Add("@Id_carrera", SqlDbType.Char).Value = ComboBox3.SelectedValue
                cmd.Parameters.Add("@turno", SqlDbType.Char).Value = ComboBox4.SelectedValue
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
            borrar()
            ActualizaCB()
        End Try
    End Sub
    Sub EliminaGrupo()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "EliminarGrupo"
                cmd.Parameters.Add("@id_grupo", SqlDbType.Char).Value = ComboBox1.Text
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
            borrar()
            ActualizaCB()
        End Try
    End Sub
    Sub BuscaGrupo()
        Try
            conn.Open()
            If conn.State = ConnectionState.Open Then
                cmd = conn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "BuscarGrupo"
                cmd.Parameters.Add("@id_grupo", SqlDbType.Char).Value = ComboBox1.SelectedValue.ToString
                'cmd.ExecuteNonQuery()
                sqlread = cmd.ExecuteReader
                While sqlread.Read
                    ComboBox1.Text = (sqlread("id_grupo"))
                    ComboBox2.Text = (sqlread("semestre"))
                    ComboBox3.Text = (sqlread("Id_carrera"))
                    Dim valorDeseado As String = ComboBox3.Text
                    ' Buscar el índice del ítem con el texto deseado en el ComboBox
                    Dim indice As Integer = ComboBox1.FindStringExact(valorDeseado)
                    ' Verificar si se encontró el ítem
                    If indice <> -1 Then
                        ' Seleccionar el ítem con el texto deseado
                        ComboBox3.SelectedIndex = indice
                    End If
                    ComboBox4.Text = (sqlread("turno"))
                    If ComboBox4.Text = "M" Then
                        ComboBox4.SelectedIndex = 0
                    ElseIf ComboBox4.Text = "V" Then
                        ComboBox4.SelectedIndex = 1
                    End If
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
            LlenaIdCarrera()
            llenaTurnos()
            llenaSemestres()
        End Try
    End Sub
    Sub borrar()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        BuscaGrupo()
    End Sub
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        NuevoGrupo()
    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        ActualizaGrupo()
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        EliminaGrupo()
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        frmAlumnoGrupo.Show()
    End Sub
End Class
Public Class ListItem
    Public Property Value As String
    Public Property Text As String
    Public Sub New(value As String, text As String)
        Me.Value = value
        Me.Text = text
    End Sub
End Class