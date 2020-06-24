Imports System.Data
Imports System.Data.SqlClient
Imports WinAppPermisosRoles.My.Resources

' realiza la conexion a la base de datos 
' make the connection to the database
Public Class CNN
    Public cn As SqlConnection
    Public er As String
    Public Function INICIACONEX() As Boolean
        Try
            Dim SEC As New security
            Dim cs = SEC.DecryptText(System.Configuration.ConfigurationManager.ConnectionStrings("Connection").ConnectionString, "SECURITY_KEY")

            cn = New SqlConnection(cs)
            If cn.State = 0 Then
                cn.Open()
            End If
            Return True
        Catch ex As Exception
            er = Err.Description
            Return False
        End Try
    End Function

    Public Function CERRARCONEX() As Integer
        Try
            If cn.State = 1 Then
                cn.Close()
            End If
            Return 1
        Catch ex As Exception
            Return 0
        End Try

    End Function

End Class
