Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

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

            ' Aqui verificamos que el valor  que obtenemos  sea NUMERICO
            ' si lo es mostramos los permisos en el TREEWVIEW enviandole
            ' como parametro el ID del ROL
            ' añadido por M4Nvx
            'If (IsNumeric(cboRol.SelectedValue)) Then
            '    'Cargar segun selección en bsae de datos
            '    VerPermisos(CInt(cboRol.SelectedValue))
            'End If


            'M4Nvx
            'Dim dr As DataRow
            'Dim dt = New DataTable()
            'Dim idCoulumn = New DataColumn("id_Rol", Type.GetType("System.Int32"))
            'Dim nameCoulumn = New DataColumn("nom_Rol", Type.GetType("System.String"))

            'dt.Columns.Add(idCoulumn)
            'dt.Columns.Add(nameCoulumn)

            'dr = dt.NewRow()
            'dr("id_Rol") = 1
            'dr("nom_Rol") = "Name1"
            'dt.Rows.Add(dr)

            'dr = dt.NewRow()
            'dr("id_Rol") = 2
            'dr("nom_Rol") = "Name2"
            'dt.Rows.Add(dr)

            'cboRol.DataSource = dt

        Catch ex As Exception
            MsgBox("Error cargando los permisos del ROL" & rol.erru, MsgBoxStyle.Critical)
        End Try

        tvPermisos.Nodes.Clear()

        populateTreeView(LoadTree().Node)

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
        'GEN_JSON(tvPermisos)

        ' Se declaran variables para poder guardar el JSON generado
        ' y se envia un mensaje de confirmacion o del posible error.
        Dim save As New usuarios
        Dim result = save.UPRol(CInt(cboRol.SelectedValue), GEN_JSON(tvPermisos))

        If result = "1" Then
            MsgBox("SE GUARDO CORRECTAMENTE", MsgBoxStyle.Information)
        Else
            MsgBox("ERROR: " & vbNewLine & save.erru, MsgBoxStyle.Critical)
        End If
    End Sub

    'Buscar en base de datos segun el rol seleccionado
    Sub VerPermisos(ByVal idrol As Integer)

        tvPermisos.Nodes.Clear()

        Dim ver As New usuarios

        'Dim JSONStr As String = "{""NODOPADRE"":[{""Id"":"""",""Name"":""Archivos"",""Value"":true,
        '""NODOHIJO"":[{""Id"":"""",""Name"":""Nuevo"",""Value"":true,
        '""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]},{""Id"":"""",""Name"":""Abrir"",""Value"":true,""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]},{""Id"":"""",""Name"":""Guardar"",""Value"":true,
        '""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]},{""Id"":"""",""Name"":""Guardar como"",""Value"":true,""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]},{""Id"":"""",""Name"":""Imprimir"",""Value"":true,
        '""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]}]},{""Id"":"""",""Name"":""Editar"",""Value"":true,""NODOHIJO"":[{""Id"":"""",""Name"":""Deshacer"",""Value"":true,""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]},
        '{""Id"":"""",""Name"":""Rehacer"",""Value"":true,""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]},{""Id"":"""",""Name"":""cortar"",""Value"":true,""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]},{""Id"":"""",""Name"":""copiar"",""Value"":true,""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]},{""Id"":"""",""Name"":""Pegar"",""Value"":true,""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]}]},{""Id"":"""",""Name"":""configuración"",""Value"":true,""NODOHIJO"":[{""Id"":"""",""Name"":""Usuarios"",""Value"":true,""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]},{""Id"":"""",""Name"":""Roles"",""Value"":true,""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]}]},{""Id"":"""",""Name"":""Ventanas"",""Value"":true,""NODOHIJO"":[{""Id"":"""",""Name"":""Nueva Ventana"",""Value"":true,""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]},{""Id"":"""",""Name"":""cascada"",""Value"":true,""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]},{""Id"":"""",""Name"":""Mosaico Vertical"",""Value"":true,""Actions"":[{""Id"":"""",""Name"":""New"",""Value"":true},{""Id"":"""",""Name"":""Edit"",""Value"":true},{""Id"":"""",""Name"":""Delete"",""Value"":true}]}]}]}"

        'M4Nvx
        'Dim JSONStr As String = "{""Node"":[{""Id"":""NODO00"",""Name"":""Archivos"",""Value"":false,""Nodo"":[{""Id"":""Nodo0"",""Name"":""Nuevo"",""Value"":true},{""Id"":""Nodo1"",""Name"":""Abrir"",""Value"":false},{""Id"":""Nodo2"",""Name"":""Guardar"",""Value"":true},{""Id"":""Nodo3"",""Name"":""Guardar como"",""Value"":false},{""Id"":""Nodo4"",""Name"":""Imprimir"",""Value"":true}]},
        '            {""Id"":""NODO02"",""Name"":""Editar"",""Value"":false,""Nodo"":[{""Id"":""Nodo7"",""Name"":""Deshacer"",""Value"":true},{""Id"":""Nodo8"",""Name"":""Rehacer"",""Value"":false},{""Id"":""Nodo9"",""Name"":""Cortar"",""Value"":true},{""Id"":""Nodo0"",""Name"":""Copiar"",""Value"":false},{""Id"":""Nodo1"",""Name"":""Pegar"",""Value"":true}]},
        '            {""Id"":""Nodo6"",""Name"":""Configuración"",""Value"":false,""Nodo"":[{""Id"":""Nodo26"",""Name"":""Usuarios"",""Value"":true},{""Id"":""Nodo27"",""Name"":""Roles"",""Value"":false}]},{""Id"":""Nodo10"",""Name"":""Ventanas"",""Value"":false,""Nodo"":[{""Id"":""Nodo12"",""Name"":""Nueva Ventana"",""Value"":true},{""Id"":""Nodo13"",""Name"":""Cascada"",""Value"":false},{""Id"":""Nodo14"",""Name"":""Mosaico Vertical"",""Value"":true}]}]}"

        'Dim JSONStr As String = ver.VerPermisos(idrol).Tables(0).Rows(0).Item(0).ToString
        ' ##################################################################################
        ' AQUI APARECE EL PROBLEMA, OBTIENE EL JSON DE LA BD, PERO NO LO DESEREALIZA
        ' AGREGUE NUEVOS NODOS, "ACTIONS"
        'Dim user = JsonConvert.DeserializeObject(Of NodeRootDto)(JSONStr)
        'Clipboard.SetText(JSONStr)
        'populateTreeView(user.Node)

    End Sub

    Private Sub populateTreeView(childObjects As List(Of NODOPADRE))

        If childObjects IsNot Nothing AndAlso childObjects.Count > 0 Then

            For Each ngObject In childObjects
                Dim nodeText As String = ngObject.Name

                Dim childNode As New TreeNode(nodeText) With {
                    .Checked = ngObject.Value,
                    .Name = ngObject.Id
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
                populateTreeView3(ngObject.SubNodo, parentNode)

            Next

        End If


    End Sub

    Private Sub populateTreeView3(childObjects As List(Of Actions), parentNode As TreeNode)

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
        tvPermisos.Nodes.Clear()

        populateTreeView(LoadTree().Node)
    End Sub
End Class