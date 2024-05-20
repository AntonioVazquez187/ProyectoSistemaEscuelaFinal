<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaestros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaestros))
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.txtNSS = New System.Windows.Forms.TextBox()
        Me.DelAlumno = New System.Windows.Forms.PictureBox()
        Me.ActAlumno = New System.Windows.Forms.PictureBox()
        Me.AggAlumno = New System.Windows.Forms.PictureBox()
        Me.dgAlumnos = New System.Windows.Forms.DataGridView()
        Me.rtxtDireccion = New System.Windows.Forms.RichTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtFechaNac = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DelAlumno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActAlumno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AggAlumno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAlumnos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbEstado
        '
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        Me.cmbEstado.Location = New System.Drawing.Point(295, 109)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(120, 21)
        Me.cmbEstado.TabIndex = 58
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(240, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Estado"
        '
        'txtTel
        '
        Me.txtTel.Location = New System.Drawing.Point(295, 70)
        Me.txtTel.MaxLength = 10
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(120, 20)
        Me.txtTel.TabIndex = 56
        '
        'txtNSS
        '
        Me.txtNSS.Location = New System.Drawing.Point(83, 63)
        Me.txtNSS.MaxLength = 11
        Me.txtNSS.Name = "txtNSS"
        Me.txtNSS.Size = New System.Drawing.Size(120, 20)
        Me.txtNSS.TabIndex = 55
        '
        'DelAlumno
        '
        Me.DelAlumno.BackColor = System.Drawing.Color.Transparent
        Me.DelAlumno.Image = CType(resources.GetObject("DelAlumno.Image"), System.Drawing.Image)
        Me.DelAlumno.Location = New System.Drawing.Point(129, 109)
        Me.DelAlumno.Name = "DelAlumno"
        Me.DelAlumno.Size = New System.Drawing.Size(32, 32)
        Me.DelAlumno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.DelAlumno.TabIndex = 53
        Me.DelAlumno.TabStop = False
        '
        'ActAlumno
        '
        Me.ActAlumno.BackColor = System.Drawing.Color.Transparent
        Me.ActAlumno.Image = CType(resources.GetObject("ActAlumno.Image"), System.Drawing.Image)
        Me.ActAlumno.Location = New System.Drawing.Point(84, 109)
        Me.ActAlumno.Name = "ActAlumno"
        Me.ActAlumno.Size = New System.Drawing.Size(32, 32)
        Me.ActAlumno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ActAlumno.TabIndex = 52
        Me.ActAlumno.TabStop = False
        '
        'AggAlumno
        '
        Me.AggAlumno.BackColor = System.Drawing.Color.Transparent
        Me.AggAlumno.Image = CType(resources.GetObject("AggAlumno.Image"), System.Drawing.Image)
        Me.AggAlumno.Location = New System.Drawing.Point(45, 109)
        Me.AggAlumno.Name = "AggAlumno"
        Me.AggAlumno.Size = New System.Drawing.Size(32, 32)
        Me.AggAlumno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.AggAlumno.TabIndex = 51
        Me.AggAlumno.TabStop = False
        '
        'dgAlumnos
        '
        Me.dgAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAlumnos.Location = New System.Drawing.Point(31, 147)
        Me.dgAlumnos.Name = "dgAlumnos"
        Me.dgAlumnos.Size = New System.Drawing.Size(630, 261)
        Me.dgAlumnos.TabIndex = 50
        '
        'rtxtDireccion
        '
        Me.rtxtDireccion.Location = New System.Drawing.Point(517, 73)
        Me.rtxtDireccion.Name = "rtxtDireccion"
        Me.rtxtDireccion.Size = New System.Drawing.Size(144, 48)
        Me.rtxtDireccion.TabIndex = 49
        Me.rtxtDireccion.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(448, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Direccion"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(290, 28)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(120, 20)
        Me.txtNombre.TabIndex = 47
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(240, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Telefono"
        '
        'txtMatricula
        '
        Me.txtMatricula.Location = New System.Drawing.Point(84, 28)
        Me.txtMatricula.MaxLength = 6
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.Size = New System.Drawing.Size(120, 20)
        Me.txtMatricula.TabIndex = 45
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(48, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "NSS"
        '
        'dtFechaNac
        '
        Me.dtFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaNac.Location = New System.Drawing.Point(560, 28)
        Me.dtFechaNac.Name = "dtFechaNac"
        Me.dtFechaNac.Size = New System.Drawing.Size(101, 20)
        Me.dtFechaNac.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(448, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Fecha de nacimiento"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(240, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(28, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Matricula"
        '
        'frmMaestros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.ClientSize = New System.Drawing.Size(766, 447)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTel)
        Me.Controls.Add(Me.txtNSS)
        Me.Controls.Add(Me.DelAlumno)
        Me.Controls.Add(Me.ActAlumno)
        Me.Controls.Add(Me.AggAlumno)
        Me.Controls.Add(Me.dgAlumnos)
        Me.Controls.Add(Me.rtxtDireccion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtMatricula)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtFechaNac)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMaestros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMaestros"
        CType(Me.DelAlumno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActAlumno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AggAlumno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgAlumnos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTel As TextBox
    Friend WithEvents txtNSS As TextBox
    Friend WithEvents DelAlumno As PictureBox
    Friend WithEvents ActAlumno As PictureBox
    Friend WithEvents AggAlumno As PictureBox
    Friend WithEvents dgAlumnos As DataGridView
    Friend WithEvents rtxtDireccion As RichTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtMatricula As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtFechaNac As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
