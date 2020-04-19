Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

Public Class RolPermisos

    Private Sub RolPermisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim rol As New usuarios
        'rol.ListRol.Tables(0).Clear()
        'cborol.DataSource = rol.ListRol.Tables(0)
        'cborol.ValueMember = "id_Rol"
        'cboRol.DisplayMember = "nom_Rol"
        VerPermisos(CInt(cboRol.SelectedValue))
    End Sub

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

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Using ms = New MemoryStream()
            Dim nodeDto As New NodeRootDto
            Dim nP As New List(Of NODOPADRE)

            For Each padre As TreeNode In tvPermisos.Nodes

                Dim nodeParent As New NODOPADRE With {
                    .Id = padre.Name,
                    .Name = padre.Text,
                    .Value = padre.Checked
                }

                If padre.Nodes.Count > 0 Then

                    Dim lst As New List(Of NODOHIJO)

                    For Each hijos As TreeNode In padre.Nodes

                        Dim h As New NODOHIJO With {
                            .Id = hijos.Name,
                            .Name = hijos.Text,
                            .Value = hijos.Checked
                        }
                        lst.Add(h)

                    Next hijos

                    nodeParent.Nodo = lst
                End If

                nP.Add(nodeParent)

            Next padre

            nodeDto.Node = nP

            Dim jsonstr As String = JsonConvert.SerializeObject(nodeDto)

            Dim save As New usuarios
            Dim result As String
            result = save.UPRol(CInt(cboRol.SelectedValue), jsonstr)

            If result = "1" Then
                MsgBox("SE GUARDO CORRECTAMENTE", MsgBoxStyle.Information)
            Else
                MsgBox("ERROR: " & vbNewLine & save.erru, MsgBoxStyle.Critical)
            End If
            ' MsgBox(jsonstr)
        End Using
    End Sub
    Sub VerPermisos(ByVal idrol As Integer)
        'Dim ver As New usuarios
        ' Dim JSONStr As String = ver.VerPermisos(idrol).Tables(0).Rows(0).Item(0).ToString
        Dim jsp = "{""Node"":[{""Id"":""NODO00"",""Name"":""Archivos"",""Value"":false,""Nodo"":[{""Id"":""Nodo0"",""Name"":""Nuevo"",""Value"":true},{""Id"":""Nodo1"",""Name"":""Abrir"",""Value"":false},{""Id"":""Nodo2"",""Name"":""Guardar"",""Value"":true},{""Id"":""Nodo3"",""Name"":""Guardar como"",""Value"":false},{""Id"":""Nodo4"",""Name"":""Im¿rimir"",""Value"":true}]},{""Id"":""NODO02"",""Name"":""Editar"",""Value"":false,""Nodo"":[{""Id"":""Nodo7"",""Name"":""Deshacer"",""Value"":true},{""Id"":""Nodo8"",""Name"":""Rehacer"",""Value"":false},{""Id"":""Nodo9"",""Name"":""Cortar"",""Value"":true},{""Id"":""Nodo0"",""Name"":""Copiar"",""Value"":false},{""Id"":""Nodo1"",""Name"":""Pegar"",""Value"":true}]},{""Id"":""Nodo6"",""Name"":""Configuración"",""Value"":false,""Nodo"":[{""Id"":""Nodo26"",""Name"":""Usuarios"",""Value"":true},{""Id"":""Nodo27"",""Name"":""Roles"",""Value"":false}]},{""Id"":""Nodo10"",""Name"":""Ventanas"",""Value"":false,""Nodo"":[{""Id"":""Nodo12"",""Name"":""Nueva Ventana"",""Value"":true},{""Id"":""Nodo13"",""Name"":""Cascada"",""Value"":false},{""Id"":""Nodo14"",""Name"":""Mosaico Vertical"",""Value"":true}]}]}"

        Dim user = JsonConvert.DeserializeObject(Of NodeRootDto)(jsp)

        tvPermisos.Nodes.Clear()

        Dim parentNode As TreeNode = tvPermisos.Nodes.Add("Sistema")

        populateTreeView(user.Node, parentNode)

        parentNode.Expand()

    End Sub
    Private Sub populateTreeView(childObjects As List(Of NODOPADRE), parentNode As TreeNode)

        If childObjects IsNot Nothing AndAlso childObjects.Count > 0 Then

            For Each ngObject In childObjects
                Dim nodeText As String = ngObject.Name

                Dim childNode As New TreeNode(nodeText)
                childNode.Checked = ngObject.Value

                parentNode.Nodes.Add(childNode)

                populateTreeView2(ngObject.Nodo, childNode)
            Next

        End If

    End Sub

    Private Sub populateTreeView2(childObjects As List(Of NODOHIJO), parentNode As TreeNode)

        If childObjects IsNot Nothing AndAlso childObjects.Count > 0 Then

            For Each ngObject In childObjects
                Dim nodeText As String = ngObject.Name

                Dim childNode As New TreeNode(nodeText)
                childNode.Checked = ngObject.Value

                parentNode.Nodes.Add(childNode)

            Next

        End If

    End Sub
End Class