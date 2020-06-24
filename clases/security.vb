Imports System
Imports System.Security.Cryptography
Imports System.Text

' se genera encriptacion de contraseñas y cadena de conexion 
' password encryption and connection string is generated
Public Class security
    Function getMd5Hash(ByVal input As String) As String
        ' Create a new instance of the MD5 object.
        Dim md5Hasher As MD5 = MD5.Create()

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function


    ' Verify a hash against a string.
    Function verifyMd5Hash(ByVal input As String, ByVal hash As String) As Boolean
        ' Hash the input.
        Dim hashOfInput As String = getMd5Hash(input)

        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function EncryptText(ByVal strText As String, ByVal strPwd As String) As String
        Dim i As Integer, C As Integer
        Dim strBuff As String = ""

        strPwd = UCase$(strPwd)
        ' 
        'Encrypt string
        If Len(strPwd) > 0 Then
            For i = 1 To Len(strText)
                C = Asc(Mid$(strText, i, 1))
                C += Asc(Mid$(strPwd, (i Mod Len(strPwd)) + 1, 1))
                strBuff &= Chr(C And &HFF)
            Next i
        Else
            strBuff = strText
        End If
        Return strBuff
    End Function
    Public Function DecryptText(ByVal strText As String, ByVal strPwd As String) As String
        Dim i As Integer, C As Integer
        Dim strBuff As String = ""

        strPwd = UCase$(strPwd)

        'Decrypt string
        If Len(strPwd) > 0 Then
            For i = 1 To Len(strText)
                C = Asc(Mid$(strText, i, 1))
                C -= Asc(Mid$(strPwd, (i Mod Len(strPwd)) + 1, 1))
                strBuff &= Chr(C And &HFF)
            Next i
        Else
            strBuff = strText
        End If
        Return strBuff
    End Function
End Class
