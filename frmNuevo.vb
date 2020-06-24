Imports Newtonsoft.Json
Imports WinAppPermisosRoles.My.Resources

' formulario de prueba de botones y acciones
' Buttons and Actions Test Form
Public Class frmNew
    Private Sub frmNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sec As New security
        Dim buttons = JsonConvert.DeserializeObject(Of NodeRootDto)(sec.DecryptText(JSONStr, "SECURITY_KEY"))
        btNew.Enabled = buttons.Node(0).SubNodo(0).SubNodo(0).Value
        btEdit.Enabled = buttons.Node(0).SubNodo(0).SubNodo(1).Value
        btDel.Enabled = buttons.Node(0).SubNodo(0).SubNodo(2).Value
    End Sub
End Class