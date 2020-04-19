<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RolPermisos
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Nuevo")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Abrir")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Guardar")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Guardar como")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Imprimir")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Archivos", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5})
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Deshacer")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Rehacer")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cortar")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Copiar")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pegar")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Editar", New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11})
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Usuarios")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Roles")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Configuración", New System.Windows.Forms.TreeNode() {TreeNode13, TreeNode14})
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btGuardar = New System.Windows.Forms.Button()
        Me.btNuevo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboRol = New System.Windows.Forms.ComboBox()
        Me.tvPermisos = New System.Windows.Forms.TreeView()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btGuardar)
        Me.GroupBox1.Controls.Add(Me.btNuevo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboRol)
        Me.GroupBox1.Controls.Add(Me.tvPermisos)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 579)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "OPCIONES DE ROL DE USUARIO"
        '
        'btGuardar
        '
        Me.btGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGuardar.Location = New System.Drawing.Point(196, 521)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(112, 43)
        Me.btGuardar.TabIndex = 5
        Me.btGuardar.Text = "GUARDAR"
        Me.btGuardar.UseVisualStyleBackColor = True
        '
        'btNuevo
        '
        Me.btNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btNuevo.Location = New System.Drawing.Point(6, 521)
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.Size = New System.Drawing.Size(112, 43)
        Me.btNuevo.TabIndex = 4
        Me.btNuevo.Text = "NUEVO"
        Me.btNuevo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Escoge un Rol :"
        '
        'cboRol
        '
        Me.cboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRol.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRol.FormattingEnabled = True
        Me.cboRol.Location = New System.Drawing.Point(105, 28)
        Me.cboRol.Name = "cboRol"
        Me.cboRol.Size = New System.Drawing.Size(203, 26)
        Me.cboRol.TabIndex = 2
        '
        'tvPermisos
        '
        Me.tvPermisos.CheckBoxes = True
        Me.tvPermisos.Indent = 20
        Me.tvPermisos.ItemHeight = 20
        Me.tvPermisos.Location = New System.Drawing.Point(6, 69)
        Me.tvPermisos.Name = "tvPermisos"
        TreeNode1.Name = "Nodo0"
        TreeNode1.Text = "Nuevo"
        TreeNode2.Name = "Nodo1"
        TreeNode2.Text = "Abrir"
        TreeNode3.Name = "Nodo2"
        TreeNode3.Text = "Guardar"
        TreeNode4.Name = "Nodo3"
        TreeNode4.Text = "Guardar como"
        TreeNode5.Name = "Nodo4"
        TreeNode5.Text = "Imprimir"
        TreeNode6.Name = "NODO00"
        TreeNode6.Text = "Archivos"
        TreeNode7.Name = "Nodo7"
        TreeNode7.Text = "Deshacer"
        TreeNode8.Name = "Nodo8"
        TreeNode8.Text = "Rehacer"
        TreeNode9.Name = "Nodo9"
        TreeNode9.Text = "Cortar"
        TreeNode10.Name = "Nodo0"
        TreeNode10.Text = "Copiar"
        TreeNode11.Name = "Nodo1"
        TreeNode11.Text = "Pegar"
        TreeNode12.Name = "NODO02"
        TreeNode12.Text = "Editar"
        TreeNode13.Name = "Nodo26"
        TreeNode13.Text = "Usuarios"
        TreeNode14.Name = "Nodo27"
        TreeNode14.Text = "Roles"
        TreeNode15.Name = "Nodo6"
        TreeNode15.Text = "Configuración"
        Me.tvPermisos.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode12, TreeNode15})
        Me.tvPermisos.Size = New System.Drawing.Size(302, 431)
        Me.tvPermisos.TabIndex = 1
        '
        'RolPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 603)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RolPermisos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RolPermisos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tvPermisos As TreeView
    Friend WithEvents Label1 As Label
    Friend WithEvents cboRol As ComboBox
    Friend WithEvents btGuardar As Button
    Friend WithEvents btNuevo As Button
End Class
