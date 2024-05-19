<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlumnoGrupo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlumnoGrupo))
        Me.picBuscar = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbAlumno = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.picBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picBuscar
        '
        Me.picBuscar.BackColor = System.Drawing.Color.Transparent
        Me.picBuscar.Image = CType(resources.GetObject("picBuscar.Image"), System.Drawing.Image)
        Me.picBuscar.Location = New System.Drawing.Point(382, 52)
        Me.picBuscar.Name = "picBuscar"
        Me.picBuscar.Size = New System.Drawing.Size(32, 32)
        Me.picBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picBuscar.TabIndex = 72
        Me.picBuscar.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(17, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(274, 25)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Asignar alumnos a grupo"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Location = New System.Drawing.Point(79, 106)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(254, 21)
        Me.cmbGrupo.TabIndex = 70
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(32, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Grupo"
        '
        'cmbAlumno
        '
        Me.cmbAlumno.FormattingEnabled = True
        Me.cmbAlumno.Location = New System.Drawing.Point(78, 68)
        Me.cmbAlumno.Name = "cmbAlumno"
        Me.cmbAlumno.Size = New System.Drawing.Size(234, 21)
        Me.cmbAlumno.TabIndex = 68
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(30, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Alumno"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(397, 103)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 66
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(359, 103)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 65
        Me.PictureBox1.TabStop = False
        '
        'frmAlumnoGrupo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.BackgroundImage = Global.SistemaEscuelaFinal.My.Resources.Resources._193417477_arco_iris_abstracto_de_moda_fondo_borroso_ilustración_de_vector_de_acuarela_suave_para_web
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(457, 152)
        Me.Controls.Add(Me.picBuscar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbGrupo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbAlumno)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "frmAlumnoGrupo"
        Me.Text = "frmAlumnoGrupo"
        CType(Me.picBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picBuscar As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbGrupo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbAlumno As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
