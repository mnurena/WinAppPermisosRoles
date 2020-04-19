'Imports System.IO
'Imports System.Text
'Imports System.Text.Json
'Public Class json

'    Public Function CreaJSONAnidado() As String

'    End Function

'    Private Shared Sub JSONAnidado()
'        Dim jsonWOpt As JsonWriterOptions = New JsonWriterOptions With {
'            .Indented = True
'        }

'        Using ms = New MemoryStream()

'            Using writer = New Utf8JsonWriter(ms, jsonWOpt)
'                writer.WriteStartObject()
'                writer.WriteString("nombre", "scrapywar.com")
'                writer.WriteStartObject("admins")
'                writer.WriteString("usuario", "nosoyadmin")
'                writer.WriteString("contrasena", "NoMeAcuerdo")
'                writer.WriteEndObject()
'                writer.WriteEndObject()
'            End Using

'            Dim jsonstr As String = Encoding.UTF8.GetString(ms.ToArray())
'            Console.WriteLine("JSON Anidado: " & jsonstr)
'            File.WriteAllText("yo2.json", jsonstr)
'        End Using
'    End Sub
'End Class
