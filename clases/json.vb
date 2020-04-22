Imports Newtonsoft.Json
Imports System.IO
Module CREAR_JSON
    Public Function GEN_JSON(treeview As TreeView) As String
        ' Se declara un MEMORYSTREAM para almacenar el JSON
        ' en memoria
        Using ms = New MemoryStream()
            Dim nodeDto As New NodeRootDto
            Dim nP As New List(Of NODOPADRE)

            ' Se recorren los nodos en el TREEVIEW 
            For Each padre As TreeNode In treeview.Nodes

                Dim nodeParent As New NODOPADRE With {
                    .Id = padre.Name,
                    .Name = padre.Text,
                    .Value = padre.Checked
                }

                ' Se evalua si el NODO PADRE tiene NODOS HIJOS 
                ' y se recorren todos los NODOS HIJOS
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

            ' Se almacena la estructura 
            nodeDto.Node = nP

            ' Se convierte e formato JSON 
            Dim jsonstr As String = JsonConvert.SerializeObject(nodeDto)
            GEN_JSON = jsonstr

        End Using
    End Function

    'Carga de datos
    Public Function LoadTree() As NodeRootDto

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
        subNodeNuevo.SubNodo = New List(Of Actions)

        Dim SubNodoActionsNuevo = New Actions With {
                .Id = "action1",
                .Name = "Nuevo",
                .Value = True
        }

        Dim SubNodoActionsEditar = New Actions With {
                .Id = "action2",
                .Name = "Editar",
                .Value = True
        }
        Dim SubNodoActionsElimi = New Actions With {
                .Id = "action3",
                .Name = "Eliminar",
                .Value = True
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
        subNodeNuevo.SubNodo.Add(SubNodoActionsNuevo)
        subNodeNuevo.SubNodo.Add(SubNodoActionsEditar)
        subNodeNuevo.SubNodo.Add(SubNodoActionsElimi)

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

        Return result

    End Function

End Module