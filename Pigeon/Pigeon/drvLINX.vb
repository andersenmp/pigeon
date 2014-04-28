Public Class formDrvLINX
    Dim Box As MyBox
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label1.Text = "Luz Caixa ACESA"
        Box.HLightTurnOn()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Label1.Text = "Luz Caixa APAGADA"
        Box.HLightTurnOff()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Label2.Text = "Comedouro ABERTO"
        Box.rewardTurnOn()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Label2.Text = "Comedouro FECHADO"
        Box.rewardTurnOff()
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Box.Close()
        Me.Close()
    End Sub
    Private Sub formDrvLINX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Box = New MyBox()
        Box.reset()
        If Not Box.interfaceIOPresent Then
            MsgBox("KDigitalIo não está presente!" & vbCrLf & "Por isso não será utilizada.")
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Beep()
    End Sub
End Class
