Imports System.IO

Public Class formConfig
    Private Sub formConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConfigOpt.Initialize("Stimulus_Control_Config.cfg")
        ReadConfigValues()
        PopulaDiretorio()
        LabelData.Text = Now.ToString
        bolCursor = True
    End Sub

    Private Sub ReadConfigValues()
        NumericUpDownComedouro.Value = CInt(ConfigOpt.GetOption("timeComedouro").ToString)
        NumericUpDownTimeout.Value = CInt(ConfigOpt.GetOption("timeTimeout").ToString)
        NumericUpDownIET.Value = CInt(ConfigOpt.GetOption("timeIET").ToString)
        NumericUpDownLuzIET.Value = CInt(ConfigOpt.GetOption("timeLuzIET").ToString)
        NumericUpDownApresentacao.Value = CInt(ConfigOpt.GetOption("timeApresentacao").ToString)
        'Incluído por Saulo
        NumericUpDownTempoCompIncor.Value = CInt(ConfigOpt.GetOption("timeCompIncor").ToString)
        'Fim Inclusão
        NumericUpDownBicComp.Value = CInt(ConfigOpt.GetOption("qtdBicadasComparacao").ToString)
        NumericUpDownBicModelo.Value = CInt(ConfigOpt.GetOption("qtdBicadasModelo").ToString)
        NumericUpDownDelay.Value = CInt(ConfigOpt.GetOption("timeDelay").ToString)
        NumericUpDownTempoResposta.Value = CInt(ConfigOpt.GetOption("timeMaxResposta").ToString)
        NumericUpDownTempoSessao.Value = CInt(ConfigOpt.GetOption("timeMaxSessao").ToString)
        checkboxTerminal.Checked = Boolean.Parse(ConfigOpt.GetOption("chkTerminal"))
        CheckBoxPainelControle.Checked = Boolean.Parse(ConfigOpt.GetOption("chkPainelControle"))
        checkboxSaida.Checked = Boolean.Parse(ConfigOpt.GetOption("chkSaida"))
        checkboxLegenda.Checked = Boolean.Parse(ConfigOpt.GetOption("chkLegenda"))
        checkboxLista.Checked = Boolean.Parse(ConfigOpt.GetOption("chkLista"))
        CheckBoxLuzIET.Checked = Boolean.Parse(ConfigOpt.GetOption("chkLuzIET"))
        CheckBoxLuzTentativa.Checked = Boolean.Parse(ConfigOpt.GetOption("chkLuzTentativa"))
        CheckBoxLuzComedouro.Checked = Boolean.Parse(ConfigOpt.GetOption("chkLuzComedouro"))
        CheckBoxComedouro.Checked = Boolean.Parse(ConfigOpt.GetOption("chkComedouro"))
        CheckBoxTimeout.Checked = Boolean.Parse(ConfigOpt.GetOption("chkTimeout"))
        CheckBoxCursor.Checked = Boolean.Parse(ConfigOpt.GetOption("chkCursor"))
        CheckBoxApresentacao.Checked = Boolean.Parse(ConfigOpt.GetOption("chkApresentacao"))
        'Incluído por Saulo
        CheckBoxCompIncor.Checked = Boolean.Parse(ConfigOpt.GetOption("chkDuracaoIncor"))
        'Fim Inclusão
        CheckBoxDelay.Checked = Boolean.Parse(ConfigOpt.GetOption("chkDelay"))
        CheckBoxBeepResposta.Checked = Boolean.Parse(ConfigOpt.GetOption("chkBeepResposta"))
        CheckBoxBeepReforço.Checked = Boolean.Parse(ConfigOpt.GetOption("chkBeepReforço"))
        CheckBoxTempoResposta.Checked = Boolean.Parse(ConfigOpt.GetOption("chkTimeSessao"))
        CheckBoxTempoSessao.Checked = Boolean.Parse(ConfigOpt.GetOption("chkTimeResposta"))
        ComboBoxLocLuzIET.SelectedIndex = CInt(ConfigOpt.GetOption("timeLocLuzIET").ToString)

        CheckBoxCorrecao.Checked = Boolean.Parse(ConfigOpt.GetOption("chkCorrecao"))
        ComboBoxCorrecao.SelectedIndex = CInt(ConfigOpt.GetOption("tipoCorrecao").ToString)
        NumericUpDownCorrecao.Value = CInt(ConfigOpt.GetOption("timesCorrecao").ToString)

        ComboBoxSeparadorDecimal.SelectedIndex = CInt(ConfigOpt.GetOption("tipoSeparadorDecimal").ToString)
        CheckBoxPontuacao.Checked = Boolean.Parse(ConfigOpt.GetOption("chkPontuacao"))
        NumericUpDownPontuacao.Value = CInt(ConfigOpt.GetOption("qtdPontuacao").ToString)

    End Sub

    Private Sub WriteconfigValues()
        ConfigOpt.SetOption("timeComedouro", NumericUpDownComedouro.Value.ToString)
        ConfigOpt.SetOption("timeTimeout", NumericUpDownTimeout.Value.ToString)
        ConfigOpt.SetOption("timeIET", NumericUpDownIET.Value.ToString)
        ConfigOpt.SetOption("timeLuzIET", NumericUpDownLuzIET.Value.ToString)
        ConfigOpt.SetOption("timeApresentacao", NumericUpDownApresentacao.Value.ToString)
        'Incluído por Saulo
        ConfigOpt.SetOption("timeCompIncor", NumericUpDownTempoCompIncor.Value.ToString)
        'Fim Inclusão
        ConfigOpt.SetOption("timeDelay", NumericUpDownDelay.Value.ToString)
        ConfigOpt.SetOption("timeMaxResposta", NumericUpDownTempoResposta.Value.ToString)
        ConfigOpt.SetOption("timeMaxSessao", NumericUpDownTempoSessao.Value.ToString)
        ConfigOpt.SetOption("qtdBicadasComparacao", NumericUpDownBicComp.Value.ToString)
        ConfigOpt.SetOption("qtdBicadasModelo", NumericUpDownBicModelo.Value.ToString)
        ConfigOpt.SetOption("chkTerminal", checkboxTerminal.Checked.ToString())
        ConfigOpt.SetOption("chkPainelControle", CheckBoxPainelControle.Checked.ToString())
        ConfigOpt.SetOption("chkSaida", checkboxSaida.Checked.ToString())
        ConfigOpt.SetOption("chkLegenda", checkboxLegenda.Checked.ToString())
        ConfigOpt.SetOption("chkLista", checkboxLista.Checked.ToString())
        ConfigOpt.SetOption("chkLuzIET", CheckBoxLuzIET.Checked.ToString())
        ConfigOpt.SetOption("chkLuzTentativa", CheckBoxLuzTentativa.Checked.ToString())
        ConfigOpt.SetOption("chkLuzComedouro", CheckBoxLuzComedouro.Checked.ToString())
        ConfigOpt.SetOption("chkComedouro", CheckBoxComedouro.Checked.ToString())
        ConfigOpt.SetOption("chkTimeout", CheckBoxTimeout.Checked.ToString())
        ConfigOpt.SetOption("chkCursor", CheckBoxCursor.Checked.ToString())
        ConfigOpt.SetOption("chkApresentacao", CheckBoxApresentacao.Checked.ToString())
        'Incluído por Saulo
        ConfigOpt.SetOption("chkDuracaoIncor", CheckBoxCompIncor.Checked.ToString())
        'Fim Inclusão
        ConfigOpt.SetOption("chkDelay", CheckBoxDelay.Checked.ToString())
        ConfigOpt.SetOption("chkBeepResposta", CheckBoxBeepResposta.Checked.ToString())
        ConfigOpt.SetOption("chkBeepReforço", CheckBoxBeepReforço.Checked.ToString())
        ConfigOpt.SetOption("chkTimeResposta", CheckBoxTempoResposta.Checked.ToString())
        ConfigOpt.SetOption("chkTimeSessao", CheckBoxTempoSessao.Checked.ToString())
        ConfigOpt.SetOption("timeLocLuzIET", ComboBoxLocLuzIET.SelectedIndex.ToString())

        ConfigOpt.SetOption("timesCorrecao", NumericUpDownCorrecao.Value.ToString)
        ConfigOpt.SetOption("chkCorrecao", CheckBoxCorrecao.Checked.ToString())
        ConfigOpt.SetOption("tipoCorrecao", ComboBoxCorrecao.SelectedIndex.ToString())

        ConfigOpt.SetOption("tipoSeparadorDecimal", ComboBoxSeparadorDecimal.SelectedIndex.ToString())

        ConfigOpt.SetOption("qtdPontuacao", NumericUpDownPontuacao.Value.ToString)
        ConfigOpt.SetOption("chkPontuacao", CheckBoxPontuacao.Checked.ToString())

    End Sub

    Private Sub saveConfigFile()
        WriteconfigValues()
        ConfigOpt.Store()
    End Sub

    Private Sub buttonIniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonIniciar.Click
        saveConfigFile()
        If Trim(TextPombo.Text) = "" Then
            MsgBox("Nome do sujeito não preenchido!", MsgBoxStyle.Information)
            TextPombo.Focus()
            Exit Sub
        End If

        If ListBoxDestino.Items.Count < 1 Then
            MsgBox("Nenhum bloco selecionado para pesquisa!", MsgBoxStyle.Information)
            ListBoxFonte.Focus()
            Exit Sub
        End If

        If RadioButtonMTSHumano.Checked Then
            formExperimentoHB.ShowDialog()
        Else
            formExperimento.ShowDialog()
        End If


    End Sub

    Private Sub buttonSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonSair.Click
        saveConfigFile()
        End
    End Sub

    Private Sub PopulaDiretorio()
        Dim strFileSize As String = ""
        Dim di As New IO.DirectoryInfo(strDirBlocos)
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.txt")
        Dim fi As IO.FileInfo

        For Each fi In aryFi
            strFileSize = (Math.Round(fi.Length / 1024)).ToString()
            ListBoxFonte.Items.Add(fi.Name)
        Next
    End Sub

    Private Sub buttonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonAdd.Click
        Dim i As Integer

        For i = 0 To ListBoxFonte.Items.Count - 1
            If ListBoxFonte.GetSelected(i) = True Then
                ListBoxDestino.Items.Add(ListBoxFonte.Items.Item(i).ToString)
            End If
        Next i

    End Sub

    Private Sub buttonRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonRemove.Click

        If ListBoxDestino.SelectedIndex > -1 Then
            ListBoxDestino.Items.RemoveAt(ListBoxDestino.SelectedIndex)
        End If

    End Sub


    Private Sub ButtonSobre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSobre.Click
        formSobre.ShowDialog()
    End Sub

    Private Sub RadioButtonTreino_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonTreino.CheckedChanged
        If RadioButtonTreino.Checked Then
            CheckBoxApresentacao.Enabled = True
            NumericUpDownApresentacao.Enabled = True
            CheckBoxDelay.Enabled = False
            NumericUpDownDelay.Enabled = False
            NumericUpDownBicModelo.Enabled = True
            CheckBoxBeepResposta.Enabled = True
        End If
    End Sub

    Private Sub RadioButtonMTS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMTS.CheckedChanged
        If RadioButtonMTS.Checked Then
            'Aqui mudou Saulim ApresentacaoComp 05/12/2008
            CheckBoxApresentacao.Enabled = True
            NumericUpDownApresentacao.Enabled = True
            CheckBoxDelay.Enabled = True
            NumericUpDownDelay.Enabled = True
            NumericUpDownBicModelo.Enabled = True
            CheckBoxBeepResposta.Enabled = True
        End If
    End Sub

    Private Sub RadioButtonMTSTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMTSTime.CheckedChanged
        If RadioButtonMTSTime.Checked Then
            'Aqui mudou Saulim ApresentacaoComp 05/12/2008
            CheckBoxApresentacao.Enabled = True
            NumericUpDownApresentacao.Enabled = True
            CheckBoxDelay.Enabled = True
            NumericUpDownDelay.Enabled = True
            NumericUpDownBicModelo.Enabled = False
            CheckBoxBeepResposta.Enabled = True
        End If
    End Sub

    Private Sub ListBoxDestino_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxDestino.DoubleClick
        If ListBoxDestino.SelectedIndex > -1 Then
            ListBoxDestino.Items.RemoveAt(ListBoxDestino.SelectedIndex)
        End If
    End Sub

    Private Sub ListBoxFonte_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxFonte.DoubleClick
        Dim i As Integer

        For i = 0 To ListBoxFonte.Items.Count - 1
            If ListBoxFonte.GetSelected(i) = True Then
                ListBoxDestino.Items.Add(ListBoxFonte.Items.Item(i).ToString)
            End If
        Next i

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        formDrvLINX.ShowDialog()
    End Sub

    Private Sub RadioButtonMTSHumano_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMTSHumano.CheckedChanged
        If RadioButtonMTSHumano.Checked Then
            CheckBoxApresentacao.Enabled = False
            NumericUpDownApresentacao.Enabled = False
            CheckBoxDelay.Enabled = True
            NumericUpDownDelay.Enabled = True
            NumericUpDownBicModelo.Enabled = True
        End If
    End Sub

   
End Class