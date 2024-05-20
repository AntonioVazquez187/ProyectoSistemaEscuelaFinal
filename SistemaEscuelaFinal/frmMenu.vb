Public Class frmMenu
    Dim vista As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmAlumno.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmMaestros.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Form11.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmGrupos.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmCarrera.Show()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If vista = False Then
            abrir()
            vista = True
        Else
            cerrar()
            vista = False
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        frmMaterias.Show()
    End Sub
    Sub abrir()
        Panel2.Width = 202
        PictureBox3.Location = New Point(206, 88)
        PictureBox3.Width = 594
        PictureBox3.Height = 394
    End Sub
    Sub cerrar()
        Panel2.Width = 52
        PictureBox3.Location = New Point(240, 151)
        PictureBox3.Width = 381
        PictureBox3.Height = 250
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        frmHorarios.Show()
    End Sub
End Class