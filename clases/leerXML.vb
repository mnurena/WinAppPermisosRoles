Imports System.Xml
Imports System.Security.Cryptography
Imports System.Reflection.Assembly
Module leerXML
    Public Function VerDatoXML(ByVal Nodo As String, ByVal Item As String) As String
        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            'Creamos el "XML Document"
            m_xmld = New XmlDocument()

            'Cargamos el archivo
            m_xmld.Load(DLLPath() & "\" & My.Application.Info.Title & ".exe.config")

            'Obtenemos la lista de los nodos "name" "/configuration/connectionStrings/add"
            m_nodelist = m_xmld.SelectNodes(Nodo)

            'Iniciamos el ciclo de lectura
            For Each m_node In m_nodelist
                'Obtenemos el atributo del codigo - "connectionString"
                Dim CadenaCn = m_node.Attributes.GetNamedItem("key").Value
                If CadenaCn = Item Then
                    VerDatoXML = m_node.Attributes.GetNamedItem("value").Value
                End If
                'Obtenemos el Elemento nombre
                'Dim mNombre = m_node.ChildNodes.Item(0).InnerText

                'Obtenemos el Elemento apellido
                'Dim mApellido = m_node.ChildNodes.Item(1).InnerText

            Next
            'm_node = Nothing
            'm_nodelist = Nothing
            'm_xmld = Nothing
        Catch ex As Exception
            'Error trapping
            VerDatoXML = ""
        End Try
    End Function


    Public Function DLLPath(Optional ByVal backSlash As Boolean = False) As String
        Dim s As String = IO.Path.GetDirectoryName(GetExecutingAssembly.Location)
        ' si hay que añadirle el backslash
        If backSlash Then
            s &= "\"
        End If
        Return s
    End Function
End Module
