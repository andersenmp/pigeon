<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formExperimentoHB
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pictureE = New System.Windows.Forms.PictureBox
        Me.pictureC = New System.Windows.Forms.PictureBox
        Me.pictureD = New System.Windows.Forms.PictureBox
        Me.PictureExit = New System.Windows.Forms.PictureBox
        Me.timerIET = New System.Windows.Forms.Timer(Me.components)
        Me.timerComedouro = New System.Windows.Forms.Timer(Me.components)
        Me.timerLuz = New System.Windows.Forms.Timer(Me.components)
        Me.textTerminal = New System.Windows.Forms.TextBox
        Me.labelE = New System.Windows.Forms.Label
        Me.labelC = New System.Windows.Forms.Label
        Me.labelD = New System.Windows.Forms.Label
        Me.ListBoxExperimento = New System.Windows.Forms.ListBox
        Me.labelFimSessao = New System.Windows.Forms.Label
        Me.timerApresentacao = New System.Windows.Forms.Timer(Me.components)
        Me.timerSessao = New System.Windows.Forms.Timer(Me.components)
        Me.timerResposta = New System.Windows.Forms.Timer(Me.components)
        Me.buttonComedouro = New System.Windows.Forms.Button
        Me.timerLocLuzIET = New System.Windows.Forms.Timer(Me.components)
        Me.timerTimeout = New System.Windows.Forms.Timer(Me.components)
        Me.buttonSair = New System.Windows.Forms.Button
        Me.GroupBoxPainelControle = New System.Windows.Forms.GroupBox
        Me.LabelBicComp = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.LabelTempo = New System.Windows.Forms.Label
        Me.LabelErros = New System.Windows.Forms.Label
        Me.LabelAcertos = New System.Windows.Forms.Label
        Me.LabelRepeticao = New System.Windows.Forms.Label
        Me.LabelTentativa = New System.Windows.Forms.Label
        Me.LabelBicModelo = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TimerTempoTotal = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureDi = New System.Windows.Forms.PictureBox
        Me.PictureEi = New System.Windows.Forms.PictureBox
        Me.LabelEi = New System.Windows.Forms.Label
        Me.LabelDi = New System.Windows.Forms.Label
        Me.LabelPontuacao = New System.Windows.Forms.Label
        Me.timerApresentacaoComp = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pictureE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxPainelControle.SuspendLayout()
        CType(Me.PictureDi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureE
        '
        Me.pictureE.BackColor = System.Drawing.Color.Transparent
        Me.pictureE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pictureE.Location = New System.Drawing.Point(214, -8)
        Me.pictureE.Name = "pictureE"
        Me.pictureE.Size = New System.Drawing.Size(126, 126)
        Me.pictureE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pictureE.TabIndex = 0
        Me.pictureE.TabStop = False
        Me.pictureE.Visible = False
        Me.pictureE.WaitOnLoad = True
        '
        'pictureC
        '
        Me.pictureC.BackColor = System.Drawing.Color.Transparent
        Me.pictureC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pictureC.Location = New System.Drawing.Point(449, -8)
        Me.pictureC.Name = "pictureC"
        Me.pictureC.Size = New System.Drawing.Size(126, 126)
        Me.pictureC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pictureC.TabIndex = 1
        Me.pictureC.TabStop = False
        Me.pictureC.Visible = False
        Me.pictureC.WaitOnLoad = True
        '
        'pictureD
        '
        Me.pictureD.BackColor = System.Drawing.Color.Transparent
        Me.pictureD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pictureD.Location = New System.Drawing.Point(684, -8)
        Me.pictureD.Name = "pictureD"
        Me.pictureD.Size = New System.Drawing.Size(126, 126)
        Me.pictureD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pictureD.TabIndex = 2
        Me.pictureD.TabStop = False
        Me.pictureD.Visible = False
        Me.pictureD.WaitOnLoad = True
        '
        'PictureExit
        '
        Me.PictureExit.BackColor = System.Drawing.Color.Transparent
        Me.PictureExit.Location = New System.Drawing.Point(293, 731)
        Me.PictureExit.Name = "PictureExit"
        Me.PictureExit.Size = New System.Drawing.Size(420, 35)
        Me.PictureExit.TabIndex = 3
        Me.PictureExit.TabStop = False
        '
        'timerIET
        '
        Me.timerIET.Interval = 10000
        '
        'timerComedouro
        '
        Me.timerComedouro.Interval = 2500
        '
        'timerLuz
        '
        '
        'textTerminal
        '
        Me.textTerminal.BackColor = System.Drawing.Color.Black
        Me.textTerminal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textTerminal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textTerminal.ForeColor = System.Drawing.Color.Silver
        Me.textTerminal.Location = New System.Drawing.Point(185, 640)
        Me.textTerminal.Multiline = True
        Me.textTerminal.Name = "textTerminal"
        Me.textTerminal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textTerminal.Size = New System.Drawing.Size(511, 68)
        Me.textTerminal.TabIndex = 4
        '
        'labelE
        '
        Me.labelE.AutoSize = True
        Me.labelE.BackColor = System.Drawing.Color.Transparent
        Me.labelE.ForeColor = System.Drawing.Color.Black
        Me.labelE.Location = New System.Drawing.Point(457, 650)
        Me.labelE.Name = "labelE"
        Me.labelE.Size = New System.Drawing.Size(21, 13)
        Me.labelE.TabIndex = 5
        Me.labelE.Text = "XX"
        '
        'labelC
        '
        Me.labelC.AutoSize = True
        Me.labelC.BackColor = System.Drawing.Color.Transparent
        Me.labelC.ForeColor = System.Drawing.Color.Black
        Me.labelC.Location = New System.Drawing.Point(500, 676)
        Me.labelC.Name = "labelC"
        Me.labelC.Size = New System.Drawing.Size(21, 13)
        Me.labelC.TabIndex = 6
        Me.labelC.Text = "XX"
        '
        'labelD
        '
        Me.labelD.AutoSize = True
        Me.labelD.BackColor = System.Drawing.Color.Transparent
        Me.labelD.ForeColor = System.Drawing.Color.Black
        Me.labelD.Location = New System.Drawing.Point(547, 650)
        Me.labelD.Name = "labelD"
        Me.labelD.Size = New System.Drawing.Size(21, 13)
        Me.labelD.TabIndex = 7
        Me.labelD.Text = "XX"
        '
        'ListBoxExperimento
        '
        Me.ListBoxExperimento.BackColor = System.Drawing.Color.Black
        Me.ListBoxExperimento.ForeColor = System.Drawing.Color.Silver
        Me.ListBoxExperimento.FormattingEnabled = True
        Me.ListBoxExperimento.Location = New System.Drawing.Point(185, 709)
        Me.ListBoxExperimento.Name = "ListBoxExperimento"
        Me.ListBoxExperimento.Size = New System.Drawing.Size(511, 43)
        Me.ListBoxExperimento.TabIndex = 8
        '
        'labelFimSessao
        '
        Me.labelFimSessao.AutoSize = True
        Me.labelFimSessao.BackColor = System.Drawing.Color.Transparent
        Me.labelFimSessao.ForeColor = System.Drawing.Color.White
        Me.labelFimSessao.Location = New System.Drawing.Point(432, 752)
        Me.labelFimSessao.Name = "labelFimSessao"
        Me.labelFimSessao.Size = New System.Drawing.Size(130, 13)
        Me.labelFimSessao.TabIndex = 9
        Me.labelFimSessao.Text = "Dois cliques aqui para sair"
        Me.labelFimSessao.Visible = False
        '
        'timerApresentacao
        '
        '
        'timerSessao
        '
        Me.timerSessao.Interval = 120000
        '
        'timerResposta
        '
        Me.timerResposta.Interval = 60000
        '
        'buttonComedouro
        '
        Me.buttonComedouro.BackColor = System.Drawing.Color.GreenYellow
        Me.buttonComedouro.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonComedouro.Location = New System.Drawing.Point(293, 645)
        Me.buttonComedouro.Name = "buttonComedouro"
        Me.buttonComedouro.Size = New System.Drawing.Size(118, 114)
        Me.buttonComedouro.TabIndex = 10
        Me.buttonComedouro.Text = "Abrir &Comedouro"
        Me.buttonComedouro.UseVisualStyleBackColor = False
        '
        'timerLocLuzIET
        '
        '
        'timerTimeout
        '
        Me.timerTimeout.Interval = 2500
        '
        'buttonSair
        '
        Me.buttonSair.Location = New System.Drawing.Point(321, 671)
        Me.buttonSair.Name = "buttonSair"
        Me.buttonSair.Size = New System.Drawing.Size(75, 22)
        Me.buttonSair.TabIndex = 11
        Me.buttonSair.Text = "&Interromper"
        Me.buttonSair.UseVisualStyleBackColor = True
        '
        'GroupBoxPainelControle
        '
        Me.GroupBoxPainelControle.BackColor = System.Drawing.Color.Black
        Me.GroupBoxPainelControle.Controls.Add(Me.LabelBicComp)
        Me.GroupBoxPainelControle.Controls.Add(Me.Label7)
        Me.GroupBoxPainelControle.Controls.Add(Me.LabelTempo)
        Me.GroupBoxPainelControle.Controls.Add(Me.LabelErros)
        Me.GroupBoxPainelControle.Controls.Add(Me.LabelAcertos)
        Me.GroupBoxPainelControle.Controls.Add(Me.LabelRepeticao)
        Me.GroupBoxPainelControle.Controls.Add(Me.LabelTentativa)
        Me.GroupBoxPainelControle.Controls.Add(Me.LabelBicModelo)
        Me.GroupBoxPainelControle.Controls.Add(Me.Label6)
        Me.GroupBoxPainelControle.Controls.Add(Me.Label5)
        Me.GroupBoxPainelControle.Controls.Add(Me.Label4)
        Me.GroupBoxPainelControle.Controls.Add(Me.Label3)
        Me.GroupBoxPainelControle.Controls.Add(Me.Label2)
        Me.GroupBoxPainelControle.Controls.Add(Me.Label1)
        Me.GroupBoxPainelControle.ForeColor = System.Drawing.Color.Silver
        Me.GroupBoxPainelControle.Location = New System.Drawing.Point(699, 640)
        Me.GroupBoxPainelControle.Name = "GroupBoxPainelControle"
        Me.GroupBoxPainelControle.Size = New System.Drawing.Size(149, 123)
        Me.GroupBoxPainelControle.TabIndex = 12
        Me.GroupBoxPainelControle.TabStop = False
        Me.GroupBoxPainelControle.Text = "Painel de Controle"
        '
        'LabelBicComp
        '
        Me.LabelBicComp.AutoSize = True
        Me.LabelBicComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBicComp.ForeColor = System.Drawing.Color.Silver
        Me.LabelBicComp.Location = New System.Drawing.Point(95, 57)
        Me.LabelBicComp.Name = "LabelBicComp"
        Me.LabelBicComp.Size = New System.Drawing.Size(14, 13)
        Me.LabelBicComp.TabIndex = 13
        Me.LabelBicComp.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Silver
        Me.Label7.Location = New System.Drawing.Point(2, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Bicadas Comp:"
        '
        'LabelTempo
        '
        Me.LabelTempo.AutoSize = True
        Me.LabelTempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTempo.ForeColor = System.Drawing.Color.Silver
        Me.LabelTempo.Location = New System.Drawing.Point(95, 105)
        Me.LabelTempo.Name = "LabelTempo"
        Me.LabelTempo.Size = New System.Drawing.Size(14, 13)
        Me.LabelTempo.TabIndex = 11
        Me.LabelTempo.Text = "0"
        '
        'LabelErros
        '
        Me.LabelErros.AutoSize = True
        Me.LabelErros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelErros.ForeColor = System.Drawing.Color.Silver
        Me.LabelErros.Location = New System.Drawing.Point(95, 86)
        Me.LabelErros.Name = "LabelErros"
        Me.LabelErros.Size = New System.Drawing.Size(14, 13)
        Me.LabelErros.TabIndex = 10
        Me.LabelErros.Text = "0"
        '
        'LabelAcertos
        '
        Me.LabelAcertos.AutoSize = True
        Me.LabelAcertos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAcertos.ForeColor = System.Drawing.Color.Silver
        Me.LabelAcertos.Location = New System.Drawing.Point(95, 73)
        Me.LabelAcertos.Name = "LabelAcertos"
        Me.LabelAcertos.Size = New System.Drawing.Size(14, 13)
        Me.LabelAcertos.TabIndex = 9
        Me.LabelAcertos.Text = "0"
        '
        'LabelRepeticao
        '
        Me.LabelRepeticao.AutoSize = True
        Me.LabelRepeticao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRepeticao.ForeColor = System.Drawing.Color.Silver
        Me.LabelRepeticao.Location = New System.Drawing.Point(95, 30)
        Me.LabelRepeticao.Name = "LabelRepeticao"
        Me.LabelRepeticao.Size = New System.Drawing.Size(14, 13)
        Me.LabelRepeticao.TabIndex = 8
        Me.LabelRepeticao.Text = "0"
        '
        'LabelTentativa
        '
        Me.LabelTentativa.AutoSize = True
        Me.LabelTentativa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTentativa.ForeColor = System.Drawing.Color.Silver
        Me.LabelTentativa.Location = New System.Drawing.Point(95, 17)
        Me.LabelTentativa.Name = "LabelTentativa"
        Me.LabelTentativa.Size = New System.Drawing.Size(14, 13)
        Me.LabelTentativa.TabIndex = 7
        Me.LabelTentativa.Text = "0"
        '
        'LabelBicModelo
        '
        Me.LabelBicModelo.AutoSize = True
        Me.LabelBicModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBicModelo.ForeColor = System.Drawing.Color.Silver
        Me.LabelBicModelo.Location = New System.Drawing.Point(95, 43)
        Me.LabelBicModelo.Name = "LabelBicModelo"
        Me.LabelBicModelo.Size = New System.Drawing.Size(14, 13)
        Me.LabelBicModelo.TabIndex = 6
        Me.LabelBicModelo.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Silver
        Me.Label6.Location = New System.Drawing.Point(2, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Tempo Total:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Silver
        Me.Label5.Location = New System.Drawing.Point(2, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Repetição:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(2, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Tentativa:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Silver
        Me.Label3.Location = New System.Drawing.Point(2, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Total Erros:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(2, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total Acertos:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(2, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bicadas Modelo:"
        '
        'TimerTempoTotal
        '
        Me.TimerTempoTotal.Enabled = True
        Me.TimerTempoTotal.Interval = 1000
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(293, 645)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(199, 114)
        Me.Panel1.TabIndex = 13
        '
        'PictureDi
        '
        Me.PictureDi.BackColor = System.Drawing.Color.Transparent
        Me.PictureDi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureDi.Location = New System.Drawing.Point(867, 637)
        Me.PictureDi.Name = "PictureDi"
        Me.PictureDi.Size = New System.Drawing.Size(126, 126)
        Me.PictureDi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureDi.TabIndex = 14
        Me.PictureDi.TabStop = False
        Me.PictureDi.Visible = False
        Me.PictureDi.WaitOnLoad = True
        '
        'PictureEi
        '
        Me.PictureEi.BackColor = System.Drawing.Color.Transparent
        Me.PictureEi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureEi.Location = New System.Drawing.Point(16, 637)
        Me.PictureEi.Name = "PictureEi"
        Me.PictureEi.Size = New System.Drawing.Size(126, 126)
        Me.PictureEi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureEi.TabIndex = 15
        Me.PictureEi.TabStop = False
        Me.PictureEi.Visible = False
        Me.PictureEi.WaitOnLoad = True
        '
        'LabelEi
        '
        Me.LabelEi.AutoSize = True
        Me.LabelEi.BackColor = System.Drawing.Color.Transparent
        Me.LabelEi.ForeColor = System.Drawing.Color.Black
        Me.LabelEi.Location = New System.Drawing.Point(457, 706)
        Me.LabelEi.Name = "LabelEi"
        Me.LabelEi.Size = New System.Drawing.Size(21, 13)
        Me.LabelEi.TabIndex = 16
        Me.LabelEi.Text = "XX"
        '
        'LabelDi
        '
        Me.LabelDi.AutoSize = True
        Me.LabelDi.BackColor = System.Drawing.Color.Transparent
        Me.LabelDi.ForeColor = System.Drawing.Color.Black
        Me.LabelDi.Location = New System.Drawing.Point(547, 706)
        Me.LabelDi.Name = "LabelDi"
        Me.LabelDi.Size = New System.Drawing.Size(21, 13)
        Me.LabelDi.TabIndex = 17
        Me.LabelDi.Text = "XX"
        '
        'LabelPontuacao
        '
        Me.LabelPontuacao.AutoSize = True
        Me.LabelPontuacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPontuacao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelPontuacao.Location = New System.Drawing.Point(12, 19)
        Me.LabelPontuacao.Name = "LabelPontuacao"
        Me.LabelPontuacao.Size = New System.Drawing.Size(97, 24)
        Me.LabelPontuacao.TabIndex = 18
        Me.LabelPontuacao.Text = "Pontos: 0"
        '
        'timerApresentacaoComp
        '
        '
        'formExperimentoHB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.ControlBox = False
        Me.Controls.Add(Me.labelFimSessao)
        Me.Controls.Add(Me.textTerminal)
        Me.Controls.Add(Me.ListBoxExperimento)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.buttonComedouro)
        Me.Controls.Add(Me.LabelPontuacao)
        Me.Controls.Add(Me.LabelDi)
        Me.Controls.Add(Me.LabelEi)
        Me.Controls.Add(Me.PictureDi)
        Me.Controls.Add(Me.PictureEi)
        Me.Controls.Add(Me.GroupBoxPainelControle)
        Me.Controls.Add(Me.buttonSair)
        Me.Controls.Add(Me.labelD)
        Me.Controls.Add(Me.labelC)
        Me.Controls.Add(Me.labelE)
        Me.Controls.Add(Me.PictureExit)
        Me.Controls.Add(Me.pictureD)
        Me.Controls.Add(Me.pictureC)
        Me.Controls.Add(Me.pictureE)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "formExperimentoHB"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pictureE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxPainelControle.ResumeLayout(False)
        Me.GroupBoxPainelControle.PerformLayout()
        CType(Me.PictureDi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pictureE As System.Windows.Forms.PictureBox
    Friend WithEvents pictureC As System.Windows.Forms.PictureBox
    Friend WithEvents pictureD As System.Windows.Forms.PictureBox
    Friend WithEvents PictureExit As System.Windows.Forms.PictureBox
    Friend WithEvents timerIET As System.Windows.Forms.Timer
    Friend WithEvents timerComedouro As System.Windows.Forms.Timer
    Friend WithEvents timerLuz As System.Windows.Forms.Timer
    Friend WithEvents textTerminal As System.Windows.Forms.TextBox
    Friend WithEvents labelE As System.Windows.Forms.Label
    Friend WithEvents labelC As System.Windows.Forms.Label
    Friend WithEvents labelD As System.Windows.Forms.Label
    Friend WithEvents ListBoxExperimento As System.Windows.Forms.ListBox
    Friend WithEvents labelFimSessao As System.Windows.Forms.Label
    Friend WithEvents timerApresentacao As System.Windows.Forms.Timer
    Friend WithEvents timerSessao As System.Windows.Forms.Timer
    Friend WithEvents timerResposta As System.Windows.Forms.Timer
    Friend WithEvents buttonComedouro As System.Windows.Forms.Button
    Friend WithEvents timerLocLuzIET As System.Windows.Forms.Timer
    Friend WithEvents timerTimeout As System.Windows.Forms.Timer
    Friend WithEvents buttonSair As System.Windows.Forms.Button
    Friend WithEvents GroupBoxPainelControle As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelTempo As System.Windows.Forms.Label
    Friend WithEvents LabelErros As System.Windows.Forms.Label
    Friend WithEvents LabelAcertos As System.Windows.Forms.Label
    Friend WithEvents LabelRepeticao As System.Windows.Forms.Label
    Friend WithEvents LabelTentativa As System.Windows.Forms.Label
    Friend WithEvents LabelBicModelo As System.Windows.Forms.Label
    Friend WithEvents TimerTempoTotal As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureDi As System.Windows.Forms.PictureBox
    Friend WithEvents PictureEi As System.Windows.Forms.PictureBox
    Friend WithEvents LabelEi As System.Windows.Forms.Label
    Friend WithEvents LabelDi As System.Windows.Forms.Label
    Friend WithEvents LabelPontuacao As System.Windows.Forms.Label
    Friend WithEvents LabelBicComp As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents timerApresentacaoComp As System.Windows.Forms.Timer
End Class
