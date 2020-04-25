Imports System.Data.SqlClient
Public Class usuarios
    Public erru As String
    Private md5 As New verifyPass

    Public Function Login(ByVal usu As String, ByVal pass As String) As String
        Try
            Dim dllBD As New cnn
            dllBD.INICIACONEX()
            Dim dpt As New SqlDataAdapter("SP_USU_LOGIN", dllBD.cn)
            dpt.SelectCommand.CommandType = CommandType.StoredProcedure
            dpt.SelectCommand.Parameters.AddWithValue("@LOGIN", usu)
            dpt.SelectCommand.Parameters.AddWithValue("@PASS", md5.getMd5Hash(pass))
            dpt.SelectCommand.Parameters.AddWithValue("@RESULT", " ")
            dpt.SelectCommand.Parameters("@RESULT").Direction = ParameterDirection.Output
            dpt.SelectCommand.ExecuteNonQuery()
            Login = Trim(dpt.SelectCommand.Parameters("@RESULT").Value.ToString)
            dllBD.CERRARCONEX()
            dpt = Nothing
            dllBD = Nothing
        Catch ex As Exception
            Login = "2"
            erru = Err.Description
        End Try
    End Function

    Public Function AddUser(ByVal Nom As String, ByVal Ape As String, ByVal TUsu As Integer, ByVal Login As String, ByVal Pass As String) As String
        Try
            Dim ds As New DataSet
            Dim dllBD As New cnn
            dllBD.INICIACONEX()
            Dim dpt As New SqlDataAdapter("SP_USU_INSERT", dllBD.cn)
            dpt.SelectCommand.CommandType = CommandType.StoredProcedure
            dpt.SelectCommand.Parameters.AddWithValue("@NOM", Nom)
            dpt.SelectCommand.Parameters.AddWithValue("@LOG", Login)
            dpt.SelectCommand.Parameters.AddWithValue("@IDROL", TUsu)
            dpt.SelectCommand.Parameters.AddWithValue("@PASS", md5.getMd5Hash(Pass))
            dpt.SelectCommand.Parameters.AddWithValue("@APE", Ape)
            dpt.SelectCommand.Parameters.AddWithValue("@RESULT", " ")
            dpt.SelectCommand.Parameters("@RESULT").Direction = ParameterDirection.Output
            dpt.SelectCommand.ExecuteNonQuery()
            AddUser = Trim(dpt.SelectCommand.Parameters("@RESULT").Value.ToString)
            dllBD.CERRARCONEX()
            dllBD = Nothing
            dpt = Nothing
        Catch ex As Exception
            erru = Err.Description
            AddUser = "3"
        End Try
    End Function
    Public Function UpUser(ByVal idUsu As String, ByVal Nom As String, ByVal Ape As String, ByVal TUsu As Integer, Optional ByVal Pass As String = Nothing) As String
        Try
            Dim ds As New DataSet
            Dim dllBD As New cnn
            Dim password As String = ""
            dllBD.INICIACONEX()
            Dim dpt As New SqlDataAdapter("SP_USU_UPDATE", dllBD.cn)
            dpt.SelectCommand.CommandType = CommandType.StoredProcedure
            dpt.SelectCommand.Parameters.AddWithValue("@IDUSU", idUsu)
            dpt.SelectCommand.Parameters.AddWithValue("@NOM", Nom)
            dpt.SelectCommand.Parameters.AddWithValue("@APE", Ape)
            If Pass <> "" Then
                password = md5.getMd5Hash(Pass)
            End If
            dpt.SelectCommand.Parameters.AddWithValue("@PASS", password)
            dpt.SelectCommand.Parameters.AddWithValue("@TIPOUSU", TUsu)
            dpt.SelectCommand.Parameters.AddWithValue("@RESULT", " ")
            dpt.SelectCommand.Parameters("@RESULT").Direction = ParameterDirection.Output
            dpt.SelectCommand.ExecuteNonQuery()
            UpUser = Trim(dpt.SelectCommand.Parameters("@RESULT").Value.ToString)
            dllBD.CERRARCONEX()
            dllBD = Nothing
            dpt = Nothing
            ds = Nothing
            password = Nothing
        Catch ex As Exception
            erru = "Error en Clase: " & Err.Description
            UpUser = "3"
        End Try
    End Function


    Public Function ListUsers() As DataSet
        Dim ds As New DataSet
        Dim dllBD As New cnn
        dllBD.INICIACONEX()
        Dim dpt As New SqlDataAdapter("SP_USU_LIST", dllBD.cn)
        dpt.SelectCommand.CommandType = CommandType.StoredProcedure
        dpt.Fill(ds, "SP_USU_LIST")
        dllBD.CERRARCONEX()
        ListUsers = ds
        dllBD = Nothing
        ds = Nothing
        dpt = Nothing
    End Function
    Public Function DelUsu(ByVal DB As String, ByVal usu As String) As Boolean
        Try
            Dim dllBD As New cnn
            If dllBD.INICIACONEX() = True Then
                Dim dpt As New SqlDataAdapter("UST_DELETE_USU", dllBD.cn)
                dpt.SelectCommand.CommandType = CommandType.StoredProcedure
                dpt.SelectCommand.Parameters.AddWithValue("@IDUSU", usu)
                dpt.SelectCommand.ExecuteNonQuery()
                dllBD.CERRARCONEX()
                dpt = Nothing
                dllBD = Nothing
                DelUsu = True
            Else
                erru = dllBD.er
                DelUsu = False
            End If

        Catch ex As Exception
            erru = Err.Description
            DelUsu = False
        End Try
    End Function
    Public Function ListRol() As DataSet
        Dim ds As New DataSet
        Dim dllBD As New cnn
        dllBD.INICIACONEX()
        Dim dpt As New SqlDataAdapter("SP_USU_LISTROL", dllBD.cn)
        dpt.SelectCommand.CommandType = CommandType.StoredProcedure
        dpt.Fill(ds, "SP_USU_LISTROL")
        dllBD.CERRARCONEX()
        ListRol = ds
        dllBD = Nothing
        ds = Nothing
        dpt = Nothing
    End Function
    Public Function VerPermisos(ByVal idRol As Integer) As DataSet
        Try
            Dim ds As New DataSet
            Dim dllBD As New cnn
            dllBD.INICIACONEX()
            Dim dpt As New SqlDataAdapter("SP_USU_VERPERM", dllBD.cn)
            dpt.SelectCommand.CommandType = CommandType.StoredProcedure
            dpt.SelectCommand.Parameters.AddWithValue("@IDROL", idRol)
            'dpt.SelectCommand.Parameters.AddWithValue("@RESULT", " ")
            'dpt.SelectCommand.Parameters("@RESULT").Direction = ParameterDirection.Output
            dpt.Fill(ds, "SP_USU_VERPERM")
            VerPermisos = ds
            dllBD.CERRARCONEX()
            dpt = Nothing
            dllBD = Nothing
        Catch ex As Exception
            erru = Err.Description
        End Try
    End Function
    Public Function UPRol(ByVal idRol As Integer, ByVal permisos As String) As String
        Try
            Dim dllBD As New cnn
            dllBD.INICIACONEX()
            Dim dpt As New SqlDataAdapter("SP_USU_UPPERMISO", dllBD.cn)
            dpt.SelectCommand.CommandType = CommandType.StoredProcedure
            dpt.SelectCommand.Parameters.AddWithValue("@IDROL", idRol)
            dpt.SelectCommand.Parameters.AddWithValue("@PERMISOS", permisos)
            dpt.SelectCommand.Parameters.AddWithValue("@RESULT", " ")
            dpt.SelectCommand.Parameters("@RESULT").Direction = ParameterDirection.Output
            dpt.SelectCommand.ExecuteNonQuery()
            UPRol = Trim(dpt.SelectCommand.Parameters("@RESULT").Value.ToString)
            dllBD.CERRARCONEX()
            dllBD = Nothing
            dpt = Nothing

        Catch ex As Exception
            erru = "Error en Clase: " & Err.Description
            UPRol = "3"
        End Try
    End Function

    Public Function VerDatosLogin(ByVal loginUsu As String) As DataSet
        Try
            Dim ds As New DataSet
            Dim dllBD As New cnn
            dllBD.INICIACONEX()
            Dim dpt As New SqlDataAdapter("SP_USU_VER", dllBD.cn)
            dpt.SelectCommand.CommandType = CommandType.StoredProcedure
            dpt.SelectCommand.Parameters.AddWithValue("@LOGIN", loginUsu)
            dpt.Fill(ds, "SP_USU_VER")
            VerDatosLogin = ds
            dllBD.CERRARCONEX()
            dpt = Nothing
            dllBD = Nothing
        Catch ex As Exception
            erru = Err.Description
        End Try
    End Function
End Class
