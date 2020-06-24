<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class genCadena
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCadena = New System.Windows.Forms.TextBox()
        Me.txtEncryp = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btEncryp = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(267, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "AQUI PEGA LA CADENA DE CONEXION:"
        '
        'txtCadena
        '
        Me.txtCadena.Location = New System.Drawing.Point(27, 46)
        Me.txtCadena.Name = "txtCadena"
        Me.txtCadena.Size = New System.Drawing.Size(517, 22)
        Me.txtCadena.TabIndex = 1
        '
        'txtEncryp
        '
        Me.txtEncryp.Location = New System.Drawing.Point(31, 126)
        Me.txtEncryp.Name = "txtEncryp"
        Me.txtEncryp.Size = New System.Drawing.Size(513, 22)
        Me.txtEncryp.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(356, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "AQUI ESTA LA CADENA DE CONEXION ENCRIPTADA:"
        '
        'btEncryp
        '
        Me.btEncryp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btEncryp.Location = New System.Drawing.Point(31, 173)
        Me.btEncryp.Name = "btEncryp"
        Me.btEncryp.Size = New System.Drawing.Size(513, 58)
        Me.btEncryp.TabIndex = 4
        Me.btEncryp.Text = "ENCRIPTAR"
        Me.btEncryp.UseVisualStyleBackColor = True
        '
        'genCadena
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 270)
        Me.Controls.Add(Me.btEncryp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEncryp)
        Me.Controls.Add(Me.txtCadena)
        Me.Controls.Add(Me.Label1)
        Me.Name = "genCadena"
        Me.Text = "genCadena"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtCadena As TextBox
    Friend WithEvents txtEncryp As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btEncryp As Button
End Class
