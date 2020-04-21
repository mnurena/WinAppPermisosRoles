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
End Module