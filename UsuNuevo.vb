Imports System.ComponentModel

Public Class UsuNuevo
    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        If btGuardar.Text = "&AÑADIR" Then
            If txtnom.Text IsNot "" And txtape.Text IsNot "" And txtlogin.Text IsNot "" And txtpass.Text IsNot "" And txtpass2.Text IsNot "" Then
                If txtpass.Text = txtpass2.Text Then
                    Dim save As New usuarios
                    Dim result As String
                    result = save.AddUser(txtnom.Text, txtape.Text, CInt(cborol.SelectedValue), txtlogin.Text, txtpass.Text)
                    If result = "1" Then
                        MsgBox("Se Registro Con Exito", MsgBoxStyle.Information, My.Application.Info.Title)
                        LIMPIAR()
                        Me.Close()

                    ElseIf result = "0" Then
                        MsgBox("El usuario ya Existe", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                        Exit Sub
                    Else
                        MsgBox("ERROR: Se produjo un error en el Servidor de Datos. Intentelo nuevamente" & vbNewLine & "Si persiste contactese con el Administrador del Sistema" _
                               & vbNewLine & save.erru, MsgBoxStyle.Critical, My.Application.Info.Title)
                    End If
                Else
                    MsgBox("Las contraseñas deben ser iguales", MsgBoxStyle.Exclamation, My.Application.Info.Title)

                End If
            Else
                MsgBox("Llenar todos los datos", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            End If
        Else
            If txtnom.Text IsNot "" And txtape.Text IsNot "" And txtlogin.Text IsNot "" Then
                If txtpass.Text = txtpass2.Text Then
                    Dim save As New usuarios
                    Dim result As String
                    result = save.UpUser(txtidUsu.Text, txtnom.Text, txtape.Text, CInt(cborol.SelectedValue), txtpass.Text)
                    If result = "1" Then
                        MsgBox("Se ACTUALIZÓ Con Exito", MsgBoxStyle.Information, My.Application.Info.Title)
                        LIMPIAR()
                        Me.Close()
                    Else
                        MsgBox("ERROR: Se produjo un error en el Servidor de Datos. Intentelo nuevamente" & vbNewLine & "Si persiste contactese con el Administrador del Sistema" _
                               & vbNewLine & save.erru, MsgBoxStyle.Critical, My.Application.Info.Title)
                    End If
                Else
                    MsgBox("Las contraseñas deben ser iguales", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                End If
            Else
                MsgBox("Llenar todos los datos", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            End If
        End If
    End Sub

    Private Sub UsuNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtidUsu.Text = "" Then
            CARGACBO()
        End If
    End Sub
    Sub CARGACBO()
        Dim rol As New usuarios
        rol.ListRol.Tables(0).Clear()
        cborol.DataSource = rol.ListRol.Tables(0)
        cborol.ValueMember = "id_Rol"
        cborol.DisplayMember = "nom_Rol"

    End Sub
    Sub LIMPIAR()
        txtnom.ResetText()
        txtape.ResetText()
        txtlogin.ResetText() : txtlogin.ReadOnly = False
        txtpass.ResetText()
        txtpass2.ResetText()
        txtidUsu.ResetText()
        ListaUsuarios.VerUsers()
    End Sub

    Private Sub UsuNuevo_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        txtnom.ResetText()
        txtape.ResetText()
        txtlogin.ResetText() : txtlogin.ReadOnly = False
        txtpass.ResetText()
        txtpass2.ResetText()
        txtidUsu.ResetText()
    End Sub
End Class