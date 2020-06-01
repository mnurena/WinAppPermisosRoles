Option Strict Off
Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports System.IO

Public Class Principal

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        frmNew.MdiParent = Me
        frmNew.Show()

    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: agregue código aquí para abrir el archivo.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: agregue código aquí para guardar el contenido actual del formulario en un archivo.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Utilice My.Computer.Clipboard.GetText() o My.Computer.Clipboard.GetData para recuperar la información del Portapapeles.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Cierre todos los formularios secundarios del principal.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoginForm1.Close()
        '###########################################################################
        'Obtengo el JSON con los permisos de la base de datos de acuerdo al usuario 
        'lo Deserealizo y utilizo la funcion LlenarMenu y le envio el JSON utilizando
        'el modelo creado
        Dim SEC As New security
        Dim ver As New usuarios
        JSONStr = ver.VerDatosLogin(loginUsu).Tables(0).Rows(0).Item(3).ToString

        Dim user = JsonConvert.DeserializeObject(Of NodeRootDto)(SEC.DecryptText(JSONStr, "CLAVE"))
        'MsgBox(user.Node(0).Id)
        LlenarMenu(user.Node)
        '##########################################################################
    End Sub

    '#############################################################################
    'Funcion que me permite determinar que menu o que opcion del menu esta permitida
    'segun los roles elegidos para dicho usuario.
    Private Sub LlenarMenu(childObjects As List(Of NODOHIJO))

        If childObjects IsNot Nothing AndAlso childObjects.Count > 0 Then

            For Each ngObject In childObjects

                For Each oOpcionMenu As ToolStripMenuItem In MenuStrip.Items
                    If oOpcionMenu.Name = ngObject.Id Then
                        oOpcionMenu.Enabled = ngObject.Value
                    End If
                    If (ngObject.SubNodo IsNot Nothing AndAlso ngObject.SubNodo.Count > 0) Then
                        RecorrerSubMenu(ngObject.SubNodo, oOpcionMenu.DropDownItems)
                    End If

                Next

            Next ngObject

        End If

    End Sub

    'Funcion para recorrer los SubMenus de cada Menu del MDI
    Private Sub RecorrerSubMenu(childObjects As List(Of NODOHIJO), ByVal oSubmenuItems As ToolStripItemCollection)

        If childObjects IsNot Nothing AndAlso childObjects.Count > 0 Then
            For Each ngObject In childObjects
                Dim nodeText As String = ngObject.Name
                For Each oSubItem As ToolStripItem In oSubmenuItems
                    If oSubItem.GetType Is GetType(ToolStripMenuItem) Then
                        If oSubItem.Name = ngObject.Id Then
                            oSubItem.Enabled = ngObject.Value
                            Exit For
                        End If
                    End If
                Next
            Next

        End If

    End Sub

    Private Sub RolesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RolesToolStripMenuItem.Click
        'RolPermisos.MdiParent = Me
        RolPermisos.ShowDialog()

    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem.Click
        ListaUsuarios.MdiParent = Me
        ListaUsuarios.Show()
    End Sub

End Class
