Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports WinAppPermisosRoles.My.Resources

' Formulario para dar permisos al sistema y acciones a un determinado grupo de usuarios
' Form to give system permissions and actions to a certain group of users
Public Class RolPermisos

    Private Sub RolPermisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Creamos una objeto ROL del tipo USUARIOS
        ' para poder obtener el listado de los ROLES EN EL SISTEMA
        ' y lo cargamos en un CONBOBOX
        Dim rol As New usuarios
        Try
            rol.ListRol.Tables(0).Clear()
            cboRol.DataSource = rol.ListRol.Tables(0)
            cboRol.ValueMember = "id_Rol"
            cboRol.DisplayMember = "nom_Rol"

        Catch ex As Exception
            MsgBox(Resource.RolPermisos_Mensaje_Error & rol.erru, MsgBoxStyle.Critical)
        End Try

        'tvPermisos.Nodes.Clear()
        'populateTreeView(LoadTree().Node)

    End Sub

    Private Sub cboRol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRol.SelectedIndexChanged
        ' Mostramos los PERMISOS cuando el valor del combobox
        ' cambie o el usuario elija entre el listado
        If (IsNumeric(cboRol.SelectedValue)) Then
            'Cargar segun selección en bsae de datos
            VerPermisos(CInt(cboRol.SelectedValue))
        End If

    End Sub

    ' TOMADO DE LA DOCUMENTACION DE .NET 
    Private Sub CheckAllChildNodes(treeNode As TreeNode, nodeChecked As Boolean)
        Dim node As TreeNode
        For Each node In treeNode.Nodes
            node.Checked = nodeChecked
            If node.Nodes.Count > 0 Then
                ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                Me.CheckAllChildNodes(node, nodeChecked)
            End If
        Next node
    End Sub

    ' NOTE   This code can be added to the BeforeCheck event handler instead of the AfterCheck event.
    ' After a tree node's Checked property is changed, all its child nodes are updated to the same value.
    Private Sub TvPermisos_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tvPermisos.AfterCheck
        ' The code only executes if the user caused the checked state to change.
        If e.Action <> TreeViewAction.Unknown Then
            If e.Node.Nodes.Count > 0 Then
                ' Calls the CheckAllChildNodes method, passing in the current 
                ' Checked value of the TreeNode whose checked state changed. 
                Me.CheckAllChildNodes(e.Node, e.Node.Checked)
            End If
        End If
    End Sub

    ' APORTE AÑADIDO POR M4Nvx
    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click

        'Manux
        ' Se declaran variables para poder guardar el JSON generado
        ' y se envia un mensaje de confirmacion o del posible error.
        Dim sec As New security
        Dim save As New usuarios
        Dim result = save.UPRol(CInt(cboRol.SelectedValue), sec.EncryptText(GEN_JSON(tvPermisos), "SECURITY_KEY"))
        If result = "1" Then
            MsgBox(Resource.RolPermisos_Mensaje_Ok, MsgBoxStyle.Information)
        Else
            MsgBox("ERROR: " & vbNewLine & save.erru, MsgBoxStyle.Critical)
        End If
    End Sub

    'Buscar en base de datos segun el rol seleccionado
    Sub VerPermisos(ByVal idrol As Integer)

        tvPermisos.Nodes.Clear()

        Dim ver As New usuarios

        Dim sec As New security
        Dim JSONStr As String = ver.VerPermisos(idrol).Tables(0).Rows(0).Item(0).ToString
        ' ##################################################################################
        ' AQUI APARECE EL PROBLEMA, OBTIENE EL JSON DE LA BD, PERO NO LO DESEREALIZA
        ' AGREGUE NUEVOS NODOS, "ACTIONS"

        'TODO Siempre validar
        If JSONStr IsNot Nothing And JSONStr IsNot "" Then

            Dim user = JsonConvert.DeserializeObject(Of NodeRootDto)(sec.DecryptText(JSONStr, "SECURITY_KEY"))
            populateTreeView(user.Node)
        Else
            tvPermisos.Nodes.Clear()
            populateTreeView(LoadTree().Node)
        End If

    End Sub

    Private Sub populateTreeView(childObjects As List(Of NODOHIJO))

        If childObjects IsNot Nothing AndAlso childObjects.Count > 0 Then

            For Each ngObject In childObjects
                Dim nodeText As String = ngObject.Name

                Dim childNode As New TreeNode(nodeText) With {
                    .Checked = ngObject.Value,
                    .Name = ngObject.Id
                }

                tvPermisos.Nodes.Add(childNode)

                If (ngObject.SubNodo IsNot Nothing AndAlso ngObject.SubNodo.Count > 0) Then

                    populateTreeView2(ngObject.SubNodo, childNode)

                End If

            Next ngObject

        End If
        tvPermisos.ExpandAll()

    End Sub

    Private Sub populateTreeView2(childObjects As List(Of NODOHIJO), parentNode As TreeNode)

        If childObjects IsNot Nothing AndAlso childObjects.Count > 0 Then

            For Each ngObject In childObjects
                Dim nodeText As String = ngObject.Name

                Dim childNode As New TreeNode(nodeText) With {
                    .Checked = ngObject.Value,
                    .Name = ngObject.Id
                }

                parentNode.Nodes.Add(childNode)

                If ngObject.SubNodo IsNot Nothing AndAlso ngObject.SubNodo.Count > 0 Then

                    populateTreeView2(ngObject.SubNodo, childNode)

                End If

            Next

        End If

    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        Dim NOM_Rol As String
        Dim adrol As New usuarios
        NOM_Rol = InputBox("Ingresa el NOMBRE del nuevo rol", "NUEVO ROL", "")
        If NOM_Rol <> "" And NOM_Rol <> "null" Then
            If adrol.AddRol(NOM_Rol) = 1 Then
                MsgBox("Se inserto correctamente el nuevo ROL", vbInformation)
                RolPermisos_Load(sender, e)
                cboRol.Text = NOM_Rol
                tvPermisos.Nodes.Clear()

                populateTreeView(LoadTree().Node)
            Else
                MsgBox(adrol.erru, vbCritical)
            End If
        End If


    End Sub
End Class