' formulario para encriptar cadena de conexion 
' connection string encryption form
Public Class genCadena
    Private Sub btEncryp_Click(sender As Object, e As EventArgs) Handles btEncryp.Click
        Dim SEC As New security
        txtEncryp.Text = SEC.EncryptText(txtCadena.Text, "SECURITY_KEY")
    End Sub
End Class