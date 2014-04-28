Public Class formSplash
    Private Sub timerSplash_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerSplash.Tick
        timerSplash.Enabled = False
        formConfig.ShowDialog()
        Me.Close()
    End Sub
    Private Sub formSplash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        timerSplash.Enabled = False
        formConfig.ShowDialog()
        Me.Close()
    End Sub
    Private Sub formSplash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strDirBlocos = Application.StartupPath & "\blocos\"
        strDirImagens = Application.StartupPath & "\imagens\"
        strDirRelatorios = Application.StartupPath & "\relatorios\"
        timerSplash.Interval = 1
        timerSplash.Enabled = True
    End Sub
End Class
