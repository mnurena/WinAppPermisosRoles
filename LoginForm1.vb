Public Class LoginForm1

    ' TODO: inserte el c�digo para realizar autenticaci�n personalizada usando el nombre de usuario y la contrase�a proporcionada 
    ' (Consulte https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuaci�n: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementaci�n de IPrincipal utilizada para realizar la autenticaci�n. 
    ' Posteriormente, My.User devolver� la informaci�n de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If UsernameTextBox.Text = "" Then
            UsernameTextBox.Focus()
        ElseIf PasswordTextBox.Text = "" Then

            PasswordTextBox.Focus()
        Else
            Dim add As String
            Dim LOG As New usuarios
            add = LOG.Login(UsernameTextBox.Text, PasswordTextBox.Text)
            If add = "1" Then
                loginUsu = UsernameTextBox.Text
                Principal.Show()
                Me.Close()
                'MsgBox(add & idUsu)
            ElseIf add = "0" Then
                'MsgBox(login.erru)
                MsgBox("ERROR de USUARIO y CONTRASE�A" & vbNewLine & "Vuelva a Intentarlo", MsgBoxStyle.Critical, "Inicio de Sesi�n " & My.Application.Info.Title)
                PasswordTextBox.ResetText()
                PasswordTextBox.Focus()
            Else
                MsgBox("ERROR de SERVIDOR, revice su conexion y el SERVIDOR." & vbNewLine & "Vuelva a Intentarlo" & vbNewLine & LOG.erru, MsgBoxStyle.Critical, "Inicio de Sesi�n " & My.Application.Info.Title)
            End If
            add = Nothing
            LOG = Nothing
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
