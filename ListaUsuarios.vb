Public Class ListaUsuarios
    Private Sub btAddUSU_Click(sender As Object, e As EventArgs) Handles btAdd.Click
        UsuNuevo.ShowDialog()
    End Sub

    Private Sub ListaUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VerUsers()
    End Sub
    Sub VerUsers()
        Dim CpaNeg As New usuarios
        CpaNeg.ListUsers().Tables(0).Clear()
        dgList.DataSource = CpaNeg.ListUsers().Tables(0)
    End Sub

    Private Sub btModUsu_Click(sender As Object, e As EventArgs) Handles btEdit.Click

        If dglist.CurrentRow IsNot Nothing Then
            With UsuNuevo
                .txtnom.Text = dglist.Item(2, dglist.CurrentRow.Index).Value.ToString
                .txtape.Text = dglist.Item(1, dglist.CurrentRow.Index).Value.ToString
                .txtidUsu.Text = dglist.Item(0, dglist.CurrentRow.Index).Value.ToString
                .txtlogin.ReadOnly = True : .txtlogin.Text = dglist.Item(3, dglist.CurrentRow.Index).Value.ToString
                .CARGACBO()
                .cborol.Text = dglist.Item(6, dglist.CurrentRow.Index).Value.ToString
                .btGuardar.Text = "&ACTUALIZAR"
            End With
            UsuNuevo.ShowDialog()
        End If

    End Sub
End Class