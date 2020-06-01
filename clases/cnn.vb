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
            cn = New SqlConnection With {
                .ConnectionString = cs}
            cn.Open()
            Return True
        Catch ex As Exception
            er = Err.Description
            Return False
        End Try
    End Function

    Private Function VERCadena(ByVal BD As String) As String
        Dim Serv, Instance, Usuario, Passw, Cadena As String
        Dim sec As New security
        Serv = sec.DecryptText(VerDatoXML("/configuration/appSettings/add", "serv"), "CLAVE")
        Instance = sec.DecryptText(VerDatoXML("/configuration/appSettings/add", "inst"), "CLAVE")
        Usuario = sec.DecryptText(VerDatoXML("/configuration/appSettings/add", "usu"), "CLAVE")
        Passw = sec.DecryptText(VerDatoXML("/configuration/appSettings/add", "pa"), "CLAVE")
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
