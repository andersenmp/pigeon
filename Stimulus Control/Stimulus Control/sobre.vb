Public Class formSobre

    Private Sub buttonSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonSair.Click
        Me.Close()
    End Sub

    Private Sub formSobre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        labelVersao.Text = Application.ProductVersion.ToString
    End Sub

End Class