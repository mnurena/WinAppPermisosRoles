<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNew
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
        Me.btEdit = New System.Windows.Forms.Button()
        Me.btNew = New System.Windows.Forms.Button()
        Me.btDel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btEdit
        '
        Me.btEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btEdit.Location = New System.Drawing.Point(42, 178)
        Me.btEdit.Name = "btEdit"
        Me.btEdit.Size = New System.Drawing.Size(184, 95)
        Me.btEdit.TabIndex = 0
        Me.btEdit.Text = "EDITAR"
        Me.btEdit.UseVisualStyleBackColor = True
        '
        'btNew
        '
        Me.btNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btNew.Location = New System.Drawing.Point(304, 75)
        Me.btNew.Name = "btNew"
        Me.btNew.Size = New System.Drawing.Size(184, 95)
        Me.btNew.TabIndex = 1
        Me.btNew.Text = "NUEVO"
        Me.btNew.UseVisualStyleBackColor = True
        '
        'btDel
        '
        Me.btDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btDel.Location = New System.Drawing.Point(556, 178)
        Me.btDel.Name = "btDel"
        Me.btDel.Size = New System.Drawing.Size(184, 95)
        Me.btDel.TabIndex = 2
        Me.btDel.Text = "ELIMINAR"
        Me.btDel.UseVisualStyleBackColor = True
        '
        'frmNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btDel)
        Me.Controls.Add(Me.btNew)
        Me.Controls.Add(Me.btEdit)
        Me.Name = "frmNew"
        Me.Text = "Formulario de Prueba: NUEVO"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btEdit As Button
    Friend WithEvents btNew As Button
    Friend WithEvents btDel As Button
End Class
