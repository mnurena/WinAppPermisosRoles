Imports Newtonsoft.Json
Imports System.IO

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
            .Id = "NODO00",
            .Name = "Archivos",
            .Value = False
        }
        nodeArchivos.SubNodo = New List(Of NODOHIJO)

        Dim subNodeNuevo = New NODOHIJO With {
            .Id = "SubNodeArchivo0",
            .Name = "Nuevo",
            .Value = False
        }
        subNodeNuevo.SubNodo = New List(Of NODOHIJO)

        'Sub subNodeNuevo  ********************************************************************************

        Dim SubNodoActionsNuevo = New NODOHIJO With {
                .Id = "ndoAnadir",
                .Name = "Añadir",
                .Value = False
        }

        Dim SubNodoActionsEditar = New NODOHIJO With {
                .Id = "ndoEditar",
                .Name = "Editar",
                .Value = False
        }
        Dim SubNodoActionsElimi = New NODOHIJO With {
                .Id = "ndoElimi",
                .Name = "Eliminar",
                .Value = False
        }
        subNodeNuevo.SubNodo.Add(SubNodoActionsNuevo)
        subNodeNuevo.SubNodo.Add(SubNodoActionsEditar)
        subNodeNuevo.SubNodo.Add(SubNodoActionsElimi)

        'Sub subNodeNuevo  ********************************************************************************

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

        nodeArchivos.SubNodo.Add(subNodeNuevo)
        nodeArchivos.SubNodo.Add(subNodeAbrir)
        nodeArchivos.SubNodo.Add(subNodeGuardar)
        nodeArchivos.SubNodo.Add(subNodeGuardarComo)
        nodeArchivos.SubNodo.Add(subNodeImprimir)

        'NODO 2 ********************************************************************************
        Dim nodeEditar = New NODOHIJO With {
            .Id = "NODO01",
            .Name = "Editar",
            .Value = False
        }

        nodeEditar.SubNodo = New List(Of NODOHIJO)

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

        nodeEditar.SubNodo.Add(subNodeDeshacer)
        nodeEditar.SubNodo.Add(subNodeRehacer)
        nodeEditar.SubNodo.Add(subNodeCortar)
        nodeEditar.SubNodo.Add(subNodeCopiar)
        nodeEditar.SubNodo.Add(subNodePegar)

        'NODO 3 ********************************************************************************
        Dim nodeConfiguracion = New NODOHIJO With {
            .Id = "NODO02",
            .Name = "Configuración",
            .Value = False
        }

        nodeConfiguracion.SubNodo = New List(Of NODOHIJO)

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

        nodeConfiguracion.SubNodo.Add(subUsuarios)
        nodeConfiguracion.SubNodo.Add(subNodeRoles)

        'NODO 4 ********************************************************************************
        Dim nodeVentanas = New NODOHIJO With {
            .Id = "NODO03",
            .Name = "Ventanas",
            .Value = False
        }

        nodeVentanas.SubNodo = New List(Of NODOHIJO)

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

        nodeVentanas.SubNodo.Add(subUsuarios)
        nodeVentanas.SubNodo.Add(subNodeRoles)
        nodeVentanas.SubNodo.Add(subNodeMosaico)

        result.Node.Add(nodeArchivos)
        result.Node.Add(nodeEditar)
        result.Node.Add(nodeConfiguracion)
        result.Node.Add(nodeVentanas)

        Return result

    End Function

End Module