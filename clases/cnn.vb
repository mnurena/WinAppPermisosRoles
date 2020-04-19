Imports System.Data
Imports System.Data.SqlClient

Public Class cnn
    Public cn As SqlConnection
    Public er As String
    Public Function INICIACONEX() As Boolean
        Try
            Dim cs As String
            ' Data Source=.;Initial Catalog=BDFARMA;User ID=sa
            cs = "Data Source=.;Initial Catalog=BDFARMA;User ID=sa; Password=272122_MRF" 'VERCadena(DB)
            cn = New SqlConnection
            cn.ConnectionString = cs
            cn.Open()
            INICIACONEX = True
        Catch ex As Exception
            INICIACONEX = False
            er = Err.Description
        End Try
    End Function

    Private Function VERCadena(ByVal BD As String) As String
        Dim Serv, Instance, Usuario, Passw, Cadena As String

        Serv = DecryptText(VerDatoXML("/configuration/appSettings/add", "serv"), "UNISYSTEC_DjMiki")
        Instance = DecryptText(VerDatoXML("/configuration/appSettings/add", "inst"), "UNISYSTEC_DjMiki")
        Usuario = DecryptText(VerDatoXML("/configuration/appSettings/add", "usu"), "UNISYSTEC_DjMiki")
        Passw = DecryptText(VerDatoXML("/configuration/appSettings/add", "pa"), "UNISYSTEC_DjMiki")
        'Data Source=.;Initial Catalog=SISCONTA;Integrated Security=True
        If Usuario = "" And Passw = "" And Instance = "" Then
            Cadena = "Data Source=" & Serv & ";Initial Catalog=" & BD & ";Integrated Security=True"
        ElseIf Usuario <> "" And Passw = "" And Instance = "" Then
            Cadena = "Data Source=" & Serv & ";Initial Catalog=" & BD & ";User ID=" & Usuario
        ElseIf Usuario = "" And Passw = "" And Instance <> "" Then
            Cadena = "Data Source=" & Serv & "\" & Instance & ";Initial Catalog=" & BD & ";Integrated Security=True"
        ElseIf Instance = "" Then
            Cadena = "Data Source=" & Serv & ";Initial Catalog=" & BD & ";User ID=" & Usuario & ";Password=" & Passw
        Else
            Cadena = "Data Source=" & Serv & "\" & Instance & ";Initial Catalog=" & BD & ";User ID=" & Usuario & ";Password=" & Passw
        End If
        VERCadena = Cadena
    End Function
    Public Function CERRARCONEX() As Integer
        Try
            cn.Close()
            cn = Nothing
            CERRARCONEX = Nothing
        Catch ex As Exception
            CERRARCONEX = Nothing
        End Try

    End Function

End Class
