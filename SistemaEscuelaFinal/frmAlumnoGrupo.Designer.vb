<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAlumnoGrupo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlumnoGrupo))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbAlumno = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.picAct = New System.Windows.Forms.PictureBox()
        Me.picAgg = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncontrarAlumnoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncoontrarGrupoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.picBuscar = New System.Windows.Forms.PictureBox()
        CType(Me.picAct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAgg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.picBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(17, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(274, 25)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Asignar alumnos a grupo"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Location = New System.Drawing.Point(79, 118)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(254, 21)
        Me.cmbGrupo.TabIndex = 70
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(32, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Grupo"
        '
        'cmbAlumno
        '
        Me.cmbAlumno.FormattingEnabled = True
        Me.cmbAlumno.Location = New System.Drawing.Point(78, 80)
        Me.cmbAlumno.Name = "cmbAlumno"
        Me.cmbAlumno.Size = New System.Drawing.Size(234, 21)
        Me.cmbAlumno.TabIndex = 68
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(30, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Alumno"
        '
        'picAct
        '
        Me.picAct.BackColor = System.Drawing.Color.Transparent
        Me.picAct.Image = CType(resources.GetObject("picAct.Image"), System.Drawing.Image)
        Me.picAct.Location = New System.Drawing.Point(413, 115)
        Me.picAct.Name = "picAct"
        Me.picAct.Size = New System.Drawing.Size(32, 32)
        Me.picAct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picAct.TabIndex = 66
        Me.picAct.TabStop = False
        '
        'picAgg
        '
        Me.picAgg.BackColor = System.Drawing.Color.Transparent
        Me.picAgg.Image = CType(resources.GetObject("picAgg.Image"), System.Drawing.Image)
        Me.picAgg.Location = New System.Drawing.Point(359, 115)
        Me.picAgg.Name = "picAgg"
        Me.picAgg.Size = New System.Drawing.Size(32, 32)
        Me.picAgg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picAgg.TabIndex = 65
        Me.picAgg.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.MediumOrchid
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(457, 24)
        Me.MenuStrip1.TabIndex = 72
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EncontrarAlumnoToolStripMenuItem, Me.EncoontrarGrupoToolStripMenuItem})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'EncontrarAlumnoToolStripMenuItem
        '
        Me.EncontrarAlumnoToolStripMenuItem.Name = "EncontrarAlumnoToolStripMenuItem"
        Me.EncontrarAlumnoToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.EncontrarAlumnoToolStripMenuItem.Text = "Encontrar alumno"
        '
        'EncoontrarGrupoToolStripMenuItem
        '
        Me.EncoontrarGrupoToolStripMenuItem.Name = "EncoontrarGrupoToolStripMenuItem"
        Me.EncoontrarGrupoToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.EncoontrarGrupoToolStripMenuItem.Text = "Encontrar grupo"
        '
        'picBuscar
        '
        Me.picBuscar.BackColor = System.Drawing.Color.Transparent
        Me.picBuscar.Image = CType(resources.GetObject("picBuscar.Image"), System.Drawing.Image)
        Me.picBuscar.Location = New System.Drawing.Point(327, 69)
        Me.picBuscar.Name = "picBuscar"
        Me.picBuscar.Size = New System.Drawing.Size(32, 32)
        Me.picBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picBuscar.TabIndex = 73
        Me.picBuscar.TabStop = False
        '
        'frmAlumnoGrupo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BlueViolet
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(457, 159)
        Me.Controls.Add(Me.picBuscar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbGrupo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbAlumno)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.picAct)
        Me.Controls.Add(Me.picAgg)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmAlumnoGrupo"
        Me.Text = "frmAlumnoGrupo"
        CType(Me.picAct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAgg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.picBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbGrupo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbAlumno As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents picAct As PictureBox
    Friend WithEvents picAgg As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EncontrarAlumnoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EncoontrarGrupoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents picBuscar As PictureBox
End Class
