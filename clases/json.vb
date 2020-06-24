Imports Newtonsoft.Json
Imports System.IO
Imports WinAppPermisosRoles.My.Resources

' se genera un modelo del json que se utilizara para cargar el TREEVIEW
' a json model is generated which is used to load the TREEVIEW
Module CREAR_JSON
    Public Function GEN_JSON(treeview As TreeView) As String

        ' Se declara un MEMORYSTREAM para almacenar el JSON
        ' en memoria
        Using ms = New MemoryStream()
            Dim nodeDto As New NodeRootDto
            Dim nP As New List(Of NODOHIJO)

            ' Se recorren los nodos en el TREEVIEW 
            For Each padre As TreeNode In treeview.Nodes

                Dim subChield = GetJson_ChieldNode(padre)
                nP.Add(subChield)

            Next padre

            ' Se almacena la estructura 
            nodeDto.Node = nP

            '    ' Se convierte e formato JSON 
            Dim jsonstr As String = JsonConvert.SerializeObject(nodeDto)
            GEN_JSON = jsonstr

        End Using
    End Function

    Private Function GetJson_ChieldNode(node As TreeNode) As NODOHIJO

        Dim chieldResult As New NODOHIJO With {
            .Id = node.Name,
            .Name = node.Text,
            .Value = node.Checked,
            .SubNodo = New List(Of NODOHIJO)
        }

        If node.Nodes IsNot Nothing AndAlso node.Nodes.Count > 0 Then

            For Each ngObject As TreeNode In node.Nodes

                Dim ch = GetJson_ChieldNode(ngObject)
                chieldResult.SubNodo.Add(ch)

            Next ngObject

        End If

        GetJson_ChieldNode = chieldResult

    End Function

    'Carga de datos
    Public Function LoadTree() As NodeRootDto

        Dim result = New NodeRootDto With {
            .Node = New List(Of NODOHIJO)
        }

        Dim nodeArchivos = New NODOHIJO With {
            .Id = "FileMenu",
            .Name = Resource.TreeNode_File, 'Recurso de diccionario
            .Value = False
        }
        nodeArchivos.SubNodo = New List(Of NODOHIJO)

        Dim subNodeNuevo = New NODOHIJO With {
            .Id = "NewToolStripMenuItem",
            .Name = Resource.TREENODE_NEW,
            .Value = False
        }

        'Sub subNodeNuevo  ********************************************************************************

        subNodeNuevo.SubNodo = New List(Of NODOHIJO)

        Dim SubNodoNuevo_New = New NODOHIJO With {
                .Id = "ndoAnadir",
                .Name = "Añadir",
                .Value = False
        }

        Dim SubNodoNuevo_Edit = New NODOHIJO With {
                .Id = "ndoEditar",
                .Name = "Editar",
                .Value = False
        }
        Dim SubNodoNuevo_Del = New NODOHIJO With {
                .Id = "ndoElimi",
                .Name = "Eliminar",
                .Value = False
        }
        subNodeNuevo.SubNodo.Add(SubNodoNuevo_New)
        subNodeNuevo.SubNodo.Add(SubNodoNuevo_Edit)
        subNodeNuevo.SubNodo.Add(SubNodoNuevo_Del)

        ' END Sub subNodeNuevo  ********************************************************************************

        Dim subNodeAbrir = New NODOHIJO With {
            .Id = "OpenToolStripMenuItem",
            .Name = Resource.TREENODE_OPEN,
            .Value = False
        }
        'Sub subNodeAbrir  ********************************************************************************

        subNodeAbrir.SubNodo = New List(Of NODOHIJO)

        Dim SubNodoAbrir_New = New NODOHIJO With {
                .Id = "ndoAnadir",
                .Name = "Añadir",
                .Value = False
        }

        Dim SubNodoAbrir_Edit = New NODOHIJO With {
                .Id = "ndoEditar",
                .Name = "Editar",
                .Value = False
        }
        Dim SubNodoAbrir_Del = New NODOHIJO With {
                .Id = "ndoElimi",
                .Name = "Eliminar",
                .Value = False
        }
        subNodeAbrir.SubNodo.Add(SubNodoAbrir_New)
        subNodeAbrir.SubNodo.Add(SubNodoAbrir_Edit)
        subNodeAbrir.SubNodo.Add(SubNodoAbrir_Del)

        ' END Sub subNodeAbrir  ********************************************************************************


        Dim subNodeGuardar = New NODOHIJO With {
            .Id = "SaveToolStripMenuItem",
            .Name = Resource.TREENODE_SAVE,
            .Value = False
        }
        'Sub subNodeGuardar  ********************************************************************************

        subNodeGuardar.SubNodo = New List(Of NODOHIJO)

        Dim SubNodoGuardar_New = New NODOHIJO With {
                .Id = "ndoAnadir",
                .Name = "Añadir",
                .Value = False
        }

        Dim SubNodoGuardar_Edit = New NODOHIJO With {
                .Id = "ndoEditar",
                .Name = "Editar",
                .Value = False
        }
        Dim SubNodoGuardar_Del = New NODOHIJO With {
                .Id = "ndoElimi",
                .Name = "Eliminar",
                .Value = False
        }
        subNodeGuardar.SubNodo.Add(SubNodoGuardar_New)
        subNodeGuardar.SubNodo.Add(SubNodoGuardar_Edit)
        subNodeGuardar.SubNodo.Add(SubNodoGuardar_Del)

        ' END Sub subNodeGuardar  ********************************************************************************


        Dim subNodeGuardarComo = New NODOHIJO With {
            .Id = "SaveAsToolStripMenuItem",
            .Name = Resource.TREENODE_SAVEAS,
            .Value = False
        }

        'Sub subNodeGuardarCOMO  ********************************************************************************

        subNodeGuardarComo.SubNodo = New List(Of NODOHIJO)

        Dim SubNodoGuardarC_New = New NODOHIJO With {
                .Id = "ndoAnadir",
                .Name = "Añadir",
                .Value = False
        }

        Dim SubNodoGuardarC_Edit = New NODOHIJO With {
                .Id = "ndoEditar",
                .Name = "Editar",
                .Value = False
        }
        Dim SubNodoGuardarC_Del = New NODOHIJO With {
                .Id = "ndoElimi",
                .Name = "Eliminar",
                .Value = False
        }
        subNodeGuardarComo.SubNodo.Add(SubNodoGuardarC_New)
        subNodeGuardarComo.SubNodo.Add(SubNodoGuardarC_Edit)
        subNodeGuardarComo.SubNodo.Add(SubNodoGuardarC_Del)

        ' END Sub subNodeGuardarCOMO  ********************************************************************************


        Dim subNodeImprimir = New NODOHIJO With {
            .Id = "PrintToolStripMenuItem",
            .Name = Resource.TREENODE_PRINT,
            .Value = False
        }

        'Sub subNodeImprimir  ***************************************************************************

        subNodeImprimir.SubNodo = New List(Of NODOHIJO)

        Dim SubNodoImprimir_New = New NODOHIJO With {
                .Id = "ndoAnadir",
                .Name = "Añadir",
                .Value = False
        }

        Dim SubNodoImprimir_Edit = New NODOHIJO With {
                .Id = "ndoEditar",
                .Name = "Editar",
                .Value = False
        }
        Dim SubNodoImprimir_Del = New NODOHIJO With {
                .Id = "ndoElimi",
                .Name = "Eliminar",
                .Value = False
        }
        subNodeImprimir.SubNodo.Add(SubNodoImprimir_New)
        subNodeImprimir.SubNodo.Add(SubNodoImprimir_Edit)
        subNodeImprimir.SubNodo.Add(SubNodoImprimir_Del)

        ' END Sub subNodeImprimir  ********************************************************************************
        nodeArchivos.SubNodo.Add(subNodeNuevo)
        nodeArchivos.SubNodo.Add(subNodeAbrir)
        nodeArchivos.SubNodo.Add(subNodeGuardar)
        nodeArchivos.SubNodo.Add(subNodeGuardarComo)
        nodeArchivos.SubNodo.Add(subNodeImprimir)
        ' END NODO 1 - MENU 1
        ' ************************************************
        'NODO 2 ********************************************************************************
        Dim nodeEditar = New NODOHIJO With {
            .Id = "EditMenu",
            .Name = "Editar",
            .Value = False
        }

        nodeEditar.SubNodo = New List(Of NODOHIJO)

        Dim subNodeDeshacer = New NODOHIJO With {
            .Id = "UndoToolStripMenuItem",
            .Name = "Deshacer",
            .Value = False
        }
        'Sub subNodeDeshacer  ***************************************************************************

        subNodeDeshacer.SubNodo = New List(Of NODOHIJO)

        Dim subNodeDeshacer_New = New NODOHIJO With {
                .Id = "ndoAnadir",
                .Name = "Añadir",
                .Value = False
        }

        Dim subNodeDeshacer_Edit = New NODOHIJO With {
                .Id = "ndoEditar",
                .Name = "Editar",
                .Value = False
        }
        Dim subNodeDeshacer_Del = New NODOHIJO With {
                .Id = "ndoElimi",
                .Name = "Eliminar",
                .Value = False
        }
        subNodeDeshacer.SubNodo.Add(subNodeDeshacer_New)
        subNodeDeshacer.SubNodo.Add(subNodeDeshacer_Edit)
        subNodeDeshacer.SubNodo.Add(subNodeDeshacer_Del)

        ' END Sub subNodeDeshacer  ********************************************************************************

        Dim subNodeRehacer = New NODOHIJO With {
            .Id = "RedoToolStripMenuItem",
            .Name = "Rehacer",
            .Value = False
        }

        'Sub subNodeRehacer  ***************************************************************************

        subNodeRehacer.SubNodo = New List(Of NODOHIJO)

        Dim subNodeRehacer_New = New NODOHIJO With {
                .Id = "ndoAnadir",
                .Name = "Añadir",
                .Value = False
        }

        Dim subNodeRehacer_Edit = New NODOHIJO With {
                .Id = "ndoEditar",
                .Name = "Editar",
                .Value = False
        }
        Dim subNodeRehacer_Del = New NODOHIJO With {
                .Id = "ndoElimi",
                .Name = "Eliminar",
                .Value = False
        }
        subNodeRehacer.SubNodo.Add(subNodeRehacer_New)
        subNodeRehacer.SubNodo.Add(subNodeRehacer_Edit)
        subNodeRehacer.SubNodo.Add(subNodeRehacer_Del)

        ' END Sub subNodeRehacer  ********************************************************************************

        Dim subNodeCortar = New NODOHIJO With {
            .Id = "CutToolStripMenuItem",
            .Name = "Cortar",
            .Value = False
        }

        'Sub subNodeCortar  ***************************************************************************

        subNodeCortar.SubNodo = New List(Of NODOHIJO)

        Dim subNodeCortar_New = New NODOHIJO With {
                .Id = "ndoAnadir",
                .Name = "Añadir",
                .Value = False
        }

        Dim subNodeCortar_Edit = New NODOHIJO With {
                .Id = "ndoEditar",
                .Name = "Editar",
                .Value = False
        }
        Dim subNodeCortar_Del = New NODOHIJO With {
                .Id = "ndoElimi",
                .Name = "Eliminar",
                .Value = False
        }
        subNodeCortar.SubNodo.Add(subNodeCortar_New)
        subNodeCortar.SubNodo.Add(subNodeCortar_Edit)
        subNodeCortar.SubNodo.Add(subNodeCortar_Del)

        ' END Sub subNodeCortar  ********************************************************************************

        Dim subNodeCopiar = New NODOHIJO With {
            .Id = "CopyToolStripMenuItem",
            .Name = "Copiar",
            .Value = False
        }
        'Sub subNodeCopiar  ***************************************************************************

        subNodeCopiar.SubNodo = New List(Of NODOHIJO)

        Dim subNodeCopiar_New = New NODOHIJO With {
                .Id = "ndoAnadir",
                .Name = "Añadir",
                .Value = False
        }

        Dim subNodeCopiar_Edit = New NODOHIJO With {
                .Id = "ndoEditar",
                .Name = "Editar",
                .Value = False
        }
        Dim subNodeCopiar_Del = New NODOHIJO With {
                .Id = "ndoElimi",
                .Name = "Eliminar",
                .Value = False
        }
        subNodeCopiar.SubNodo.Add(subNodeCopiar_New)
        subNodeCopiar.SubNodo.Add(subNodeCopiar_Edit)
        subNodeCopiar.SubNodo.Add(subNodeCopiar_Del)

        ' END Sub subNodeCopiar  ********************************************************************************

        Dim subNodePegar = New NODOHIJO With {
            .Id = "PasteToolStripMenuItem",
            .Name = "Pegar",
            .Value = False
        }
        'Sub subNodePegar  ***************************************************************************

        subNodePegar.SubNodo = New List(Of NODOHIJO)

        Dim subNodePegar_New = New NODOHIJO With {
                .Id = "ndoAnadir",
                .Name = "Añadir",
                .Value = False
        }

        Dim subNodePegar_Edit = New NODOHIJO With {
                .Id = "ndoEditar",
                .Name = "Editar",
                .Value = False
        }
        Dim subNodePegar_Del = New NODOHIJO With {
                .Id = "ndoElimi",
                .Name = "Eliminar",
                .Value = False
        }
        subNodePegar.SubNodo.Add(subNodePegar_New)
        subNodePegar.SubNodo.Add(subNodePegar_Edit)
        subNodePegar.SubNodo.Add(subNodePegar_Del)

        ' END Sub subNodePegar  ********************************************************************************

        nodeEditar.SubNodo.Add(subNodeDeshacer)
        nodeEditar.SubNodo.Add(subNodeRehacer)
        nodeEditar.SubNodo.Add(subNodeCortar)
        nodeEditar.SubNodo.Add(subNodeCopiar)
        nodeEditar.SubNodo.Add(subNodePegar)
        ' END NODO 2 - MENU 1
        ' ************************************************

        'NODO 3 ********************************************************************************
        Dim nodeConfiguracion = New NODOHIJO With {
            .Id = "ConfigMenu",
            .Name = "Configuración",
            .Value = False
        }

        nodeConfiguracion.SubNodo = New List(Of NODOHIJO)

        Dim subUsuarios = New NODOHIJO With {
            .Id = "UsuariosToolStripMenuItem",
            .Name = "Usuarios",
            .Value = False
        }
        'Sub subUsuarios  ***************************************************************************

        subUsuarios.SubNodo = New List(Of NODOHIJO)

        Dim subUsuarios_New = New NODOHIJO With {
                .Id = "ndoAnadir",
                .Name = "Añadir",
                .Value = False
        }

        Dim subUsuarios_Edit = New NODOHIJO With {
                .Id = "ndoEditar",
                .Name = "Editar",
                .Value = False
        }
        Dim subUsuarios_Del = New NODOHIJO With {
                .Id = "ndoElimi",
                .Name = "Eliminar",
                .Value = False
        }
        subUsuarios.SubNodo.Add(subUsuarios_New)
        subUsuarios.SubNodo.Add(subUsuarios_Edit)
        subUsuarios.SubNodo.Add(subUsuarios_Del)

        ' END Sub subUsuarios  ********************************************************************************

        Dim subNodeRoles = New NODOHIJO With {
            .Id = "RolesToolStripMenuItem",
            .Name = "Roles",
            .Value = False
        }
        'Sub subNodeRoles  ***************************************************************************

        subNodeRoles.SubNodo = New List(Of NODOHIJO)

        Dim subNodeRoles_New = New NODOHIJO With {
                .Id = "ndoAnadir",
                .Name = "Añadir",
                .Value = False
        }

        Dim subNodeRoles_Edit = New NODOHIJO With {
                .Id = "ndoEditar",
                .Name = "Editar",
                .Value = False
        }
        Dim subNodeRoles_Del = New NODOHIJO With {
                .Id = "ndoElimi",
                .Name = "Eliminar",
                .Value = False
        }
        subNodeRoles.SubNodo.Add(subNodeRoles_New)
        subNodeRoles.SubNodo.Add(subNodeRoles_Edit)
        subNodeRoles.SubNodo.Add(subNodeRoles_Del)

        ' END Sub subNodeRoles  ********************************************************************************

        nodeConfiguracion.SubNodo.Add(subUsuarios)
        nodeConfiguracion.SubNodo.Add(subNodeRoles)

        'NODO 4 ********************************************************************************
        Dim nodeVentanas = New NODOHIJO With {
            .Id = "WindowsMenu",
            .Name = "Ventanas",
            .Value = False
        }

        nodeVentanas.SubNodo = New List(Of NODOHIJO)

        Dim subNodeNueva = New NODOHIJO With {
            .Id = "NewWindowToolStripMenuItem",
            .Name = "Nueva Ventana",
            .Value = False
        }

        Dim subNodeCascada = New NODOHIJO With {
            .Id = "CascadeToolStripMenuItem",
            .Name = "Cascada",
            .Value = False
        }

        Dim subNodeMosaico = New NODOHIJO With {
            .Id = "TileVerticalToolStripMenuItem",
            .Name = "Mosaico Vertical",
            .Value = False
        }
        Dim subNodeMosaico2 = New NODOHIJO With {
            .Id = "TileHorizontalToolStripMenuItem",
            .Name = "Mosaico Horizontal",
            .Value = False
        }
        Dim subNodeCerrarTodo = New NODOHIJO With {
            .Id = "CloseAllToolStripMenuItem",
            .Name = "Cerrar Todo",
            .Value = False
        }
        Dim subNodeOrganizar = New NODOHIJO With {
            .Id = "ArrangeIconsToolStripMenuItem",
            .Name = "Organizar Iconos",
            .Value = False
        }
        nodeVentanas.SubNodo.Add(subNodeNueva)
        nodeVentanas.SubNodo.Add(subNodeCascada)
        nodeVentanas.SubNodo.Add(subNodeMosaico)
        nodeVentanas.SubNodo.Add(subNodeMosaico2)
        nodeVentanas.SubNodo.Add(subNodeCerrarTodo)
        nodeVentanas.SubNodo.Add(subNodeOrganizar)

        result.Node.Add(nodeArchivos)
        result.Node.Add(nodeEditar)
        result.Node.Add(nodeConfiguracion)
        result.Node.Add(nodeVentanas)

        Return result

    End Function

End Module