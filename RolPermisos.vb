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

        'M4Nvx
        Dim dr As DataRow
        Dim dt = New DataTable()
        Dim idCoulumn = New DataColumn("id_Rol", Type.GetType("System.Int32"))
        Dim nameCoulumn = New DataColumn("nom_Rol", Type.GetType("System.String"))

        dt.Columns.Add(idCoulumn)
        dt.Columns.Add(nameCoulumn)

        dr = dt.NewRow()
        dr("id_Rol") = 1
        dr("nom_Rol") = "Name1"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("id_Rol") = 2
        dr("nom_Rol") = "Name2"
        dt.Rows.Add(dr)

        cboRol.DataSource = dt
        cboRol.ValueMember = "id_Rol"
        cboRol.DisplayMember = "nom_Rol"

        LoadTree()

    End Sub

    Private Sub cboRol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRol.SelectedIndexChanged

        Dim a = cboRol.Text

        If (a.Equals("Name1")) Then
            VerPermisos(1)
        End If


        If (a.Equals("Name2")) Then
            VerPermisos(2)
        End If

        'Cargar segun selección en bsae de datos
        'VerPermisos(CInt(cboRol.SelectedValue))

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


    'Carga de datos
    Sub LoadTree()

        Dim result = New NodeRootDto With {
            .Node = New List(Of NODOPADRE)
        }

        Dim nodeArchivos = New NODOPADRE With {
            .Id = "NODO00",
            .Name = "Archivos",
            .Value = False
        }
        nodeArchivos.Nodo = New List(Of NODOHIJO)

        Dim subNodeNuevo = New NODOHIJO With {
            .Id = "SubNodeArchivo0",
            .Name = "Nuevo",
            .Value = False
        }

        Dim subNodeAbrir = New NODOHIJO With {
            .Id = "SubNodeArchivo1",
            .Name = "Abrir",
            .Value = False
        }

        Dim subNodeGuardar = New NODOHIJO With {
            .Id = "SubNodeArchivo2",
            .Name = "Guardar",
            .Value = False
        }

        Dim subNodeGuardarComo = New NODOHIJO With {
            .Id = "SubNodeArchivo3",
            .Name = "Guardar como",
            .Value = False
        }

        Dim subNodeImprimir = New NODOHIJO With {
            .Id = "SubNodeArchivo4",
            .Name = "Imprimir",
            .Value = False
        }

        nodeArchivos.Nodo.Add(subNodeNuevo)
        nodeArchivos.Nodo.Add(subNodeAbrir)
        nodeArchivos.Nodo.Add(subNodeGuardar)
        nodeArchivos.Nodo.Add(subNodeGuardarComo)
        nodeArchivos.Nodo.Add(subNodeImprimir)

        'NODO 2 ********************************************************************************
        Dim nodeEditar = New NODOPADRE With {
            .Id = "NODO01",
            .Name = "Editar",
            .Value = False
        }

        nodeEditar.Nodo = New List(Of NODOHIJO)

        Dim subNodeDeshacer = New NODOHIJO With {
            .Id = "SubNodeEditar0",
            .Name = "Deshacer",
            .Value = False
        }

        Dim subNodeRehacer = New NODOHIJO With {
            .Id = "SubNodeEditar1",
            .Name = "Rehacer",
            .Value = False
        }

        Dim subNodeCortar = New NODOHIJO With {
            .Id = "SubNodeEditar2",
            .Name = "Cortar",
            .Value = False
        }

        Dim subNodeCopiar = New NODOHIJO With {
            .Id = "SubNodeEditar3",
            .Name = "Copiar",
            .Value = False
        }

        Dim subNodePegar = New NODOHIJO With {
            .Id = "SubNodeEditar4",
            .Name = "Pegar",
            .Value = False
        }

        nodeEditar.Nodo.Add(subNodeDeshacer)
        nodeEditar.Nodo.Add(subNodeRehacer)
        nodeEditar.Nodo.Add(subNodeCortar)
        nodeEditar.Nodo.Add(subNodeCopiar)
        nodeEditar.Nodo.Add(subNodePegar)

        'NODO 3 ********************************************************************************
        Dim nodeConfiguracion = New NODOPADRE With {
            .Id = "NODO02",
            .Name = "Configuración",
            .Value = False
        }

        nodeConfiguracion.Nodo = New List(Of NODOHIJO)

        Dim subUsuarios = New NODOHIJO With {
            .Id = "SubNodeConfiguracion0",
            .Name = "Usuarios",
            .Value = False
        }

        Dim subNodeRoles = New NODOHIJO With {
            .Id = "SubNodeConfiguracion1",
            .Name = "Roles",
            .Value = False
        }

        nodeConfiguracion.Nodo.Add(subUsuarios)
        nodeConfiguracion.Nodo.Add(subNodeRoles)

        'NODO 4 ********************************************************************************
        Dim nodeVentanas = New NODOPADRE With {
            .Id = "NODO03",
            .Name = "Ventanas",
            .Value = False
        }

        nodeVentanas.Nodo = New List(Of NODOHIJO)

        Dim subNodeNueva = New NODOHIJO With {
            .Id = "SubNodeVentana0",
            .Name = "Nueva Ventana",
            .Value = False
        }

        Dim subNodeCascada = New NODOHIJO With {
            .Id = "SubNodeVentana1",
            .Name = "Cascada",
            .Value = False
        }

        Dim subNodeMosaico = New NODOHIJO With {
            .Id = "SubNodeVentana2",
            .Name = "Mosaico Vertical",
            .Value = False
        }

        nodeVentanas.Nodo.Add(subUsuarios)
        nodeVentanas.Nodo.Add(subNodeRoles)
        nodeVentanas.Nodo.Add(subNodeMosaico)

        result.Node.Add(nodeArchivos)
        result.Node.Add(nodeEditar)
        result.Node.Add(nodeConfiguracion)
        result.Node.Add(nodeVentanas)

        tvPermisos.Nodes.Clear()

        populateTreeView(result.Node)

    End Sub


    'Buscar en base de datos segun el rol seleccionado
    Sub VerPermisos(ByVal idrol As Integer)
        'Dim ver As New usuarios
        ' Dim JSONStr As String = ver.VerPermisos(idrol).Tables(0).Rows(0).Item(0).ToString
        Dim jsp = ""

        If (idrol = 1) Then
            jsp = "{""Node"":[{""Id"":"""",""Name"":""Archivos"",""Value"":false,""Nodo"":[{""Id"":"""",""Name"":""Nuevo"",""Value"":false},{""Id"":"""",""Name"":""Abrir"",""Value"":true},{""Id"":"""",""Name"":""Guardar"",""Value"":false},{""Id"":"""",""Name"":""Guardar como"",""Value"":true},{""Id"":"""",""Name"":""Imprimir"",""Value"":false}]},{""Id"":"""",""Name"":""Editar"",""Value"":false,""Nodo"":[{""Id"":"""",""Name"":""Deshacer"",""Value"":false},{""Id"":"""",""Name"":""Rehacer"",""Value"":true},{""Id"":"""",""Name"":""Cortar"",""Value"":false},{""Id"":"""",""Name"":""Copiar"",""Value"":true},{""Id"":"""",""Name"":""Pegar"",""Value"":false}]},{""Id"":"""",""Name"":""Configuración"",""Value"":false,""Nodo"":[{""Id"":"""",""Name"":""Usuarios"",""Value"":true},{""Id"":"""",""Name"":""Roles"",""Value"":false}]},{""Id"":"""",""Name"":""Ventanas"",""Value"":false,""Nodo"":[{""Id"":"""",""Name"":""Usuarios"",""Value"":false},{""Id"":"""",""Name"":""Roles"",""Value"":true},{""Id"":"""",""Name"":""Mosaico Vertical"",""Value"":false}]}]}"

        End If

        If (idrol = 2) Then
            jsp = "{""Node"":[{""Id"":""NODO00"",""Name"":""Archivos"",""Value"":false,""Nodo"":[{""Id"":""Nodo0"",""Name"":""Nuevo"",""Value"":true},{""Id"":""Nodo1"",""Name"":""Abrir"",""Value"":false},{""Id"":""Nodo2"",""Name"":""Guardar"",""Value"":true},{""Id"":""Nodo3"",""Name"":""Guardar como"",""Value"":false},{""Id"":""Nodo4"",""Name"":""Imprimir"",""Value"":true}]},
                    {""Id"":""NODO02"",""Name"":""Editar"",""Value"":false,""Nodo"":[{""Id"":""Nodo7"",""Name"":""Deshacer"",""Value"":true},{""Id"":""Nodo8"",""Name"":""Rehacer"",""Value"":false},{""Id"":""Nodo9"",""Name"":""Cortar"",""Value"":true},{""Id"":""Nodo0"",""Name"":""Copiar"",""Value"":false},{""Id"":""Nodo1"",""Name"":""Pegar"",""Value"":true}]},
                    {""Id"":""Nodo6"",""Name"":""Configuración"",""Value"":false,""Nodo"":[{""Id"":""Nodo26"",""Name"":""Usuarios"",""Value"":true},{""Id"":""Nodo27"",""Name"":""Roles"",""Value"":false}]},{""Id"":""Nodo10"",""Name"":""Ventanas"",""Value"":false,""Nodo"":[{""Id"":""Nodo12"",""Name"":""Nueva Ventana"",""Value"":true},{""Id"":""Nodo13"",""Name"":""Cascada"",""Value"":false},{""Id"":""Nodo14"",""Name"":""Mosaico Vertical"",""Value"":true}]}]}"

        End If

        Dim user = JsonConvert.DeserializeObject(Of NodeRootDto)(jsp)

        tvPermisos.Nodes.Clear()

        populateTreeView(user.Node)

    End Sub

    Private Sub populateTreeView(childObjects As List(Of NODOPADRE))

        If childObjects IsNot Nothing AndAlso childObjects.Count > 0 Then

            For Each ngObject In childObjects
                Dim nodeText As String = ngObject.Name

                Dim childNode As New TreeNode(nodeText) With {
                    .Checked = ngObject.Value
                }

                tvPermisos.Nodes.Add(childNode)

                populateTreeView2(ngObject.Nodo, childNode)
            Next

        End If

        tvPermisos.ExpandAll()


    End Sub

    Private Sub populateTreeView2(childObjects As List(Of NODOHIJO), parentNode As TreeNode)

        If childObjects IsNot Nothing AndAlso childObjects.Count > 0 Then

            For Each ngObject In childObjects
                Dim nodeText As String = ngObject.Name

                Dim childNode As New TreeNode(nodeText) With {
                    .Checked = ngObject.Value
                }

                parentNode.Nodes.Add(childNode)

            Next

        End If

    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        LoadTree()
    End Sub
End Class