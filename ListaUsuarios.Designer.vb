﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListaUsuarios
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dglist = New System.Windows.Forms.DataGridView()
        Me.iduser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.apeuser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nomuser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.loginuser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechCreaUsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechUp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nomRol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btEdit = New System.Windows.Forms.Button()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dglist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dglist)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btEdit)
        Me.GroupBox1.Controls.Add(Me.btAdd)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1324, 628)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "LISTA DE CLIENTES"
        '
        'dglist
        '
        Me.dglist.AllowUserToAddRows = False
        Me.dglist.AllowUserToDeleteRows = False
        Me.dglist.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dglist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dglist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dglist.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.iduser, Me.apeuser, Me.nomuser, Me.loginuser, Me.fechCreaUsu, Me.fechUp, Me.nomRol})
        Me.dglist.Location = New System.Drawing.Point(12, 101)
        Me.dglist.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dglist.Name = "dglist"
        Me.dglist.ReadOnly = True
        Me.dglist.RowHeadersWidth = 51
        Me.dglist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dglist.Size = New System.Drawing.Size(1297, 519)
        Me.dglist.TabIndex = 4
        '
        'iduser
        '
        Me.iduser.DataPropertyName = "id_user"
        Me.iduser.HeaderText = "ID USER"
        Me.iduser.MinimumWidth = 6
        Me.iduser.Name = "iduser"
        Me.iduser.ReadOnly = True
        Me.iduser.Width = 96
        '
        'apeuser
        '
        Me.apeuser.DataPropertyName = "ape_user"
        Me.apeuser.HeaderText = "APELLIDOS"
        Me.apeuser.MinimumWidth = 6
        Me.apeuser.Name = "apeuser"
        Me.apeuser.ReadOnly = True
        Me.apeuser.Width = 127
        '
        'nomuser
        '
        Me.nomuser.DataPropertyName = "nom_user"
        Me.nomuser.HeaderText = "NOMBRES"
        Me.nomuser.MinimumWidth = 6
        Me.nomuser.Name = "nomuser"
        Me.nomuser.ReadOnly = True
        Me.nomuser.Width = 121
        '
        'loginuser
        '
        Me.loginuser.DataPropertyName = "login_user"
        Me.loginuser.HeaderText = "LOGIN"
        Me.loginuser.MinimumWidth = 6
        Me.loginuser.Name = "loginuser"
        Me.loginuser.ReadOnly = True
        Me.loginuser.Width = 88
        '
        'fechCreaUsu
        '
        Me.fechCreaUsu.DataPropertyName = "fech_user"
        DataGridViewCellStyle1.Format = "g"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.fechCreaUsu.DefaultCellStyle = DataGridViewCellStyle1
        Me.fechCreaUsu.HeaderText = "FECHA CREACIÓN"
        Me.fechCreaUsu.MinimumWidth = 6
        Me.fechCreaUsu.Name = "fechCreaUsu"
        Me.fechCreaUsu.ReadOnly = True
        Me.fechCreaUsu.Width = 167
        '
        'fechUp
        '
        Me.fechUp.DataPropertyName = "fechup_user"
        DataGridViewCellStyle2.Format = "g"
        DataGridViewCellStyle2.NullValue = "SIN DATOS"
        Me.fechUp.DefaultCellStyle = DataGridViewCellStyle2
        Me.fechUp.HeaderText = "FECHA ACTUALIZACIÓN"
        Me.fechUp.MinimumWidth = 6
        Me.fechUp.Name = "fechUp"
        Me.fechUp.ReadOnly = True
        Me.fechUp.Width = 205
        '
        'nomRol
        '
        Me.nomRol.DataPropertyName = "nom_Rol"
        Me.nomRol.HeaderText = "ROL DE USUARIO"
        Me.nomRol.MinimumWidth = 6
        Me.nomRol.Name = "nomRol"
        Me.nomRol.ReadOnly = True
        Me.nomRol.Width = 163
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 39)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(438, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Aqui se listan los usuarios que tienen acceso al sistema. "
        '
        'btEdit
        '
        Me.btEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btEdit.Location = New System.Drawing.Point(1003, 23)
        Me.btEdit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btEdit.Name = "btEdit"
        Me.btEdit.Size = New System.Drawing.Size(149, 53)
        Me.btEdit.TabIndex = 2
        Me.btEdit.Text = "MODIFICAR"
        Me.btEdit.UseVisualStyleBackColor = True
        '
        'btAdd
        '
        Me.btAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAdd.Location = New System.Drawing.Point(1160, 23)
        Me.btAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(149, 53)
        Me.btAdd.TabIndex = 1
        Me.btAdd.Text = "AÑADIR"
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'ListaUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1356, 657)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MinimumSize = New System.Drawing.Size(827, 641)
        Me.Name = "ListaUsuarios"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ListaUsuarios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dglist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btEdit As Button
    Friend WithEvents btAdd As Button
    Friend WithEvents dglist As DataGridView
    Friend WithEvents iduser As DataGridViewTextBoxColumn
    Friend WithEvents apeuser As DataGridViewTextBoxColumn
    Friend WithEvents nomuser As DataGridViewTextBoxColumn
    Friend WithEvents loginuser As DataGridViewTextBoxColumn
    Friend WithEvents fechCreaUsu As DataGridViewTextBoxColumn
    Friend WithEvents fechUp As DataGridViewTextBoxColumn
    Friend WithEvents nomRol As DataGridViewTextBoxColumn
End Class
