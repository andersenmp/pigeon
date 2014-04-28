Public Class formExperimento

    Private timeInicioSessao As Date
    Private timeFimSessao As Date
    Private timeSessao As Double

    Private timeInicioModelo As Date
    Private timeFimModelo As Date
    Private timeModelo As Double

    Private timeInicioComparacao As Date
    Private timeFimComparacao As Date
    Private timeComparacao As Double

    Private strModelo As String
    Private strCompE As String
    Private strCompD As String

    Private strCompCorreta As String
    Private strNomeBloco As String
    Private strTimeApresentacao As String
    Private strRelatorio As String

    Private intPosicaoAtual As Integer

    Private FILE_NAME As String

    Private nroBicadas As Integer

    Private nroTentativa As Integer
    Private posBicada As Integer

    Private nroAcerto As Integer
    Private nroAcertoSemCorr As Integer
    Private percAcerto As Double
    Private nroQtdCorrecao As Integer
    Private nroQtdTotalPlanejado As Integer
    Private nroQtdTotalCorrecao As Integer
    Private nroQtdTotalComparacoes As Integer

    Private bolRelatorio As Boolean



    Dim Box As MyBox

    Private Sub formExperimento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GravaRelatorio()
        ShowHideCursor(1)
    End Sub

    Private Sub formExperimento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strNomeArquivo As String

        timeInicioSessao = Now
        strRelatorio = ""
        nroBicadas = 0
        nroTentativa = 0
        posBicada = 0
        nroAcerto = 0
        nroQtdCorrecao = 0
        nroQtdTotalPlanejado = 0
        nroQtdTotalCorrecao = 0
        nroQtdTotalComparacoes = 0
        nroAcertoSemCorr = 0
        bolRelatorio = False

        LabelBicModelo.Text = "0"

        LabelTentativa.Text = "0"
        LabelRepeticao.Text = "0"

        LabelAcertos.Text = "0"
        LabelErros.Text = "0"

        LabelTempo.Text = "0"

        labelFimSessao.Visible = False

        If formConfig.CheckBoxPontuacao.Checked Then
            LabelPontuacao.Visible = True
        Else
            LabelPontuacao.Visible = False
        End If

        If formConfig.RadioButtonMTS.Checked Then
            strNomeArquivo = "MTS_"

        ElseIf formConfig.RadioButtonMTSTime.Checked Then
            strNomeArquivo = "MTS_Time_"

        Else
            strNomeArquivo = "PreTreino_"

        End If

        FILE_NAME = strDirRelatorios & strNomeArquivo & formConfig.TextPombo.Text & "_" & Replace(Now.ToShortDateString, "/", "_") & "_" & Replace(Replace(Now.ToShortTimeString, ":", "_"), " ", "_") & ".xls"

        timerIET.Interval = CInt(formConfig.NumericUpDownIET.Value)
        timerLuz.Interval = CInt(formConfig.NumericUpDownLuzIET.Value)
        timerComedouro.Interval = CInt(formConfig.NumericUpDownComedouro.Value)
        timerTimeout.Interval = CInt(formConfig.NumericUpDownTimeout.Value)
        timerApresentacao.Interval = CInt(formConfig.NumericUpDownApresentacao.Value)
        timerResposta.Interval = CInt(formConfig.NumericUpDownTempoResposta.Value)
        timerSessao.Interval = CInt(formConfig.NumericUpDownTempoSessao.Value)

        'Aqui acrescetou Saulim ApresentacaoComp 05/12/2008
        timerApresentacaoComp.Interval = CInt(formConfig.NumericUpDownApresentacao.Value)

        If formConfig.ComboBoxLocLuzIET.SelectedIndex <> 0 Then
            If timerIET.Interval <= timerLuz.Interval Then
                MsgBox("Para opção Luz IET no Final o tempo do IET deve ser maior que o tempo da Luz IET!", MsgBoxStyle.Information)
                 ShowHideCursor(1)
                Me.Dispose()
                Exit Sub
            End If
            timerLocLuzIET.Interval = timerIET.Interval - timerLuz.Interval - 100
        End If

        textTerminal.Text = ""
        ListBoxExperimento.Items.Clear()
        ListBoxExperimento.TopIndex = 0

        intPosicaoAtual = 0

        If formConfig.CheckBoxTempoResposta.Checked Then
            timerResposta.Enabled = True
        Else
            timerResposta.Enabled = False
        End If

        If formConfig.CheckBoxTempoSessao.Checked Then
            timerSessao.Enabled = True
        Else
            timerSessao.Enabled = False
        End If


        If formConfig.checkboxTerminal.Checked Then
            textTerminal.Visible = True
        Else
            textTerminal.Visible = False
        End If

        If formConfig.checkboxSaida.Checked Then
            PictureExit.Enabled = True
        Else
            PictureExit.Enabled = False
        End If

        If formConfig.checkboxLista.Checked Then
            ListBoxExperimento.Visible = True
        Else
            ListBoxExperimento.Visible = False
        End If

        If formConfig.CheckBoxPainelControle.Checked Then
            GroupBoxPainelControle.Visible = True
        Else
            GroupBoxPainelControle.Visible = False
        End If

        If formConfig.checkboxLegenda.Checked Then
            labelC.Visible = True
            labelD.Visible = True
            labelE.Visible = True
        Else
            labelC.Visible = False
            labelD.Visible = False
            labelE.Visible = False
        End If

        labelC.Text = ""
        labelD.Text = ""
        labelE.Text = ""

        If formConfig.CheckBoxCursor.Checked Then
            ShowHideCursor(1)
        Else
            ShowHideCursor(0)
        End If

        Terminal("Este Terminal é somente para testes!")
        Terminal("É necessário desabilitá-lo quando for para produção!")

        Box = New MyBox()
        Box.reset()
        If Not Box.interfaceIOPresent Then
            Terminal("Interface não está presente! Por isso não será utilizada.")
        End If

        LoadExperimento()

        picModelo()

        WriteRelatorio("H")

    End Sub

    Private Sub PictureExit_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureExit.DoubleClick
        GravaRelatorio()
        Box.Close()
        Me.Dispose()
    End Sub

    Private Sub timerIET_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerIET.Tick
        timerIET.Enabled = False

        If formConfig.CheckBoxCorrecao.Checked Then
            If CInt(strCompCorreta) <> posBicada Then
                If formConfig.ComboBoxCorrecao.SelectedIndex = 1 Then
                    intPosicaoAtual = intPosicaoAtual - 1
                End If
            End If
        End If

        picModelo()
    End Sub
    Private Sub timerComedouro_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerComedouro.Tick
        If formConfig.CheckBoxLuzComedouro.Checked Then
            Box.HLightTurnOff()
            Terminal("Apaga Luz Comedouro")
        End If
        Box.rewardTurnOff()
        Terminal("Fecha Comedouro")

        timerIET.Enabled = True
        If formConfig.CheckBoxLuzIET.Checked Then
            If formConfig.ComboBoxLocLuzIET.SelectedIndex = 0 Then
                Box.HLightTurnOn()
                Terminal("Acende Luz IET")
                timerLuz.Enabled = True
            Else
                timerLocLuzIET.Enabled = True
            End If

        End If

        timerComedouro.Enabled = False
    End Sub
    Private Sub timerLuz_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerLuz.Tick
        Box.HLightTurnOff()
        Terminal("Apaga Luz IET")
        timerLuz.Enabled = False
    End Sub

    Private Sub Terminal(ByVal texto As String)
        If formConfig.checkboxTerminal.Checked Then
            textTerminal.AppendText(vbCrLf & Now.ToString & " - " & texto)
        End If
    End Sub

    Private Sub picModelo()
        Dim arrayOpcoes() As String

        nroBicadas = 0
        nroTentativa = nroTentativa + 1
        LabelBicModelo.Text = "0"
        LabelTentativa.Text = (intPosicaoAtual + 1).ToString

        pictureC.Visible = False
        pictureE.Visible = False
        pictureD.Visible = False

        labelC.Text = ""
        labelD.Text = ""
        labelE.Text = ""


        If formConfig.CheckBoxLuzTentativa.Checked Then
            Box.HLightTurnOn()
            Terminal("Acende Luz Tentativa")
        End If




        If intPosicaoAtual <= ListBoxExperimento.Items.Count - 1 Then



            arrayOpcoes = Split(ListBoxExperimento.Items.Item(intPosicaoAtual).ToString, vbTab)
            ListBoxExperimento.SetSelected(intPosicaoAtual, True)

            If formConfig.RadioButtonMTS.Checked Then

                If arrayOpcoes.Length <> 5 Then
                    MsgBox("Arquivo Incorreto para MTS 2 escolhas!", MsgBoxStyle.Information)
                    Box.Close()
                    ShowHideCursor(1)
                    Me.Dispose()
                    Exit Sub
                End If

                strModelo = arrayOpcoes(0)
                strCompE = arrayOpcoes(1)
                strCompD = arrayOpcoes(2)
                strCompCorreta = arrayOpcoes(3)
                strNomeBloco = arrayOpcoes(4)

                If System.IO.File.Exists(strDirImagens & strModelo & ".png") Then
                    pictureC.ImageLocation = strDirImagens & strModelo & ".png"
                Else
                    pictureC.ImageLocation = strDirImagens & "SemImagem.png"
                End If
                labelC.Text = strModelo
                Terminal("Modelo Iniciou - " & strModelo)
                pictureC.Visible = True
                timeInicioModelo = Now
                intPosicaoAtual = intPosicaoAtual + 1

            ElseIf formConfig.RadioButtonMTSTime.Checked Then

                If arrayOpcoes.Length <> 6 Then
                    MsgBox("Arquivo Incorreto para MTS 2 escolhas (Time)!", MsgBoxStyle.Information)
                    Box.Close()
                    ShowHideCursor(1)
                    Me.Dispose()
                    Exit Sub
                End If

                strModelo = arrayOpcoes(0)
                strCompE = arrayOpcoes(1)
                strCompD = arrayOpcoes(2)
                strCompCorreta = arrayOpcoes(3)
                strTimeApresentacao = arrayOpcoes(4)
                strNomeBloco = arrayOpcoes(5)

                If System.IO.File.Exists(strDirImagens & strModelo & ".png") Then
                    pictureC.ImageLocation = strDirImagens & strModelo & ".png"
                Else
                    pictureC.ImageLocation = strDirImagens & "SemImagem.png"
                End If

                timerApresentacao.Interval = CInt(strTimeApresentacao) * 1000

                labelC.Text = strModelo
                Terminal("Modelo Iniciou - " & strModelo)
                pictureC.Visible = True
                timeInicioModelo = Now
                timerApresentacao.Enabled = True
                intPosicaoAtual = intPosicaoAtual + 1

            Else

                If arrayOpcoes.Length <> 3 Then
                    MsgBox("Arquivo incorreto para Treino Preliminar!", MsgBoxStyle.Information)
                    Box.Close()
                    ShowHideCursor(1)
                    Me.Dispose()
                    Exit Sub
                End If

                strModelo = arrayOpcoes(0)
                strCompCorreta = arrayOpcoes(1)
                strNomeBloco = arrayOpcoes(2)

                Dim strImagem As String

                If System.IO.File.Exists(strDirImagens & strModelo & ".png") Then
                    strImagem = strDirImagens & strModelo & ".png"
                    'pictureC.ImageLocation = strDirImagens & strModelo & ".png"
                Else
                    strImagem = strDirImagens & "SemImagem.png"
                    'pictureC.ImageLocation = strDirImagens & "SemImagem.png"
                End If

                Select Case strCompCorreta
                    Case "1"
                        pictureC.ImageLocation = strImagem
                        labelC.Text = strModelo
                        pictureC.Visible = True
                    Case "2"
                        pictureE.ImageLocation = strImagem
                        labelE.Text = strModelo
                        pictureE.Visible = True
                    Case "3"
                        pictureD.ImageLocation = strImagem
                        labelD.Text = strModelo
                        pictureD.Visible = True
                End Select

                timeInicioModelo = Now

                If formConfig.CheckBoxApresentacao.Checked Then
                    timerApresentacao.Enabled = True
                End If

                Terminal("Modelo Iniciou - " & strModelo & " - " & strCompCorreta)
                intPosicaoAtual = intPosicaoAtual + 1
            End If

        Else
            timeFimSessao = Now
            LabelTentativa.Text = "Fim"
            PictureExit.Enabled = True
            labelFimSessao.Visible = True
            Terminal("A sessão terminou")
            timeSessao = formatSeconds(timeFimSessao.Subtract(timeInicioSessao).TotalMilliseconds)
            percAcerto = (nroAcerto * 100) / (nroQtdTotalPlanejado + nroQtdTotalCorrecao)
            WriteRelatorio("F")
            GravaRelatorio()
            ShowHideCursor(1)
        End If
    End Sub


    Private Sub picComparacao()
        nroBicadas = 0
        nroQtdTotalComparacoes = nroQtdTotalComparacoes + 1

        If formConfig.CheckBoxDelay.Checked Then
            Pause(CInt(formConfig.NumericUpDownDelay.Value))
        End If

        If System.IO.File.Exists(strDirImagens & strModelo & ".png") Then
            pictureE.ImageLocation = strDirImagens & strCompE & ".png"
        Else
            pictureE.ImageLocation = strDirImagens & "SemImagem.png"
        End If


        labelE.Text = strCompE

        If System.IO.File.Exists(strDirImagens & strModelo & ".png") Then
            pictureD.ImageLocation = strDirImagens & strCompD & ".png"
        Else
            pictureD.ImageLocation = strDirImagens & "SemImagem.png"
        End If


        If formConfig.CheckBoxCorrecao.Checked And formConfig.ComboBoxCorrecao.SelectedIndex = 1 And nroQtdCorrecao > formConfig.NumericUpDownCorrecao.Value Then
            If CInt(strCompCorreta) = 3 Then
                pictureD.Visible = True
            Else
                pictureE.Visible = True
            End If
        Else
            pictureD.Visible = True
            pictureE.Visible = True
        End If


        labelD.Text = strCompD


        timeInicioComparacao = Now


        'Aqui acrescetou Saulim ApresentacaoComp 05/12/2008
        If formConfig.CheckBoxApresentacao.Checked Then
            timerApresentacaoComp.Enabled = True
        End If

        Terminal("Comparação Iniciou")
    End Sub
    Private Sub pictureD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictureD.Click

        If formConfig.CheckBoxBeepResposta.Checked Then Beep()
        resetTimeResposta()

        'If formConfig.CheckBoxCorrecao.Checked Then
        '    If CInt(strCompCorreta) <> 3 Then
        '        If formConfig.ComboBoxCorrecao.SelectedIndex = 0 Then
        '            Exit Sub
        '        End If
        '    End If
        'End If


        If formConfig.RadioButtonMTS.Checked Or formConfig.RadioButtonMTSTime.Checked Then
            fimComparacao(3)
        Else
            timeFimModelo = Now
            timerApresentacao.Enabled = False
            timeModelo = formatSeconds(timeFimModelo.Subtract(timeInicioModelo).TotalMilliseconds)
            Terminal("Bicou Direita")
            Terminal("Modelo Terminou")
            Terminal("Duração - " & timeModelo.ToString("#0.000") & " segundos")
            acoesPosBicada()
            WriteRelatorio("1")
        End If
    End Sub

    Private Sub fimComparacao(ByVal pic As Integer)
        posBicada = pic

        'Aqui acrescetou Saulim ApresentacaoComp 05/12/2008
        If formConfig.CheckBoxApresentacao.Checked Then
            timerApresentacaoComp.Enabled = False
        End If

        If pic = CInt(strCompCorreta) Then
            timeFimComparacao = Now
            timeComparacao = formatSeconds(timeFimComparacao.Subtract(timeInicioComparacao).TotalMilliseconds)
            Terminal("Acertou")
            Terminal("Comparação Terminou")
            Terminal("Duração - " & timeComparacao.ToString("#0.000") & " segundos")
            pictureE.Visible = False
            pictureD.Visible = False
            labelD.Text = ""
            labelE.Text = ""
            WriteRelatorio("1")

            If formConfig.CheckBoxBeepReforço.Checked Then
                Beep()
            End If

            If nroQtdCorrecao = 0 Then
                nroAcertoSemCorr = nroAcertoSemCorr + 1
            End If
            nroQtdCorrecao = 0
            LabelRepeticao.Text = "0"
            nroAcerto = nroAcerto + 1

            If formConfig.CheckBoxCorrecao.Checked Then
                LabelAcertos.Text = nroAcertoSemCorr.ToString
                LabelPontuacao.Text = "Pontos: " & (nroAcertoSemCorr * CInt(formConfig.NumericUpDownPontuacao.Value)).ToString
            Else
                LabelAcertos.Text = nroAcerto.ToString
                LabelPontuacao.Text = "Pontos: " & (nroAcerto * CInt(formConfig.NumericUpDownPontuacao.Value)).ToString
            End If

            acoesPosBicada()
            Exit Sub
        Else
            Terminal("Errou")
            If formConfig.CheckBoxCorrecao.Checked Then
                If formConfig.ComboBoxCorrecao.SelectedIndex = 0 Then
                    Exit Sub
                End If
            End If
            timeFimComparacao = Now
            timeComparacao = formatSeconds(timeFimComparacao.Subtract(timeInicioComparacao).TotalMilliseconds)
            Terminal("Comparação Terminou")
            Terminal("Duração - " & timeComparacao.ToString("#0.000") & " segundos")
            pictureE.Visible = False
            pictureD.Visible = False
            labelD.Text = ""
            labelE.Text = ""
            WriteRelatorio("0")
            If formConfig.CheckBoxCorrecao.Checked Then
                nroQtdCorrecao = nroQtdCorrecao + 1
                nroQtdTotalCorrecao = nroQtdTotalCorrecao + 1
            End If

            LabelRepeticao.Text = nroQtdCorrecao.ToString
            LabelErros.Text = nroQtdTotalCorrecao.ToString

            If formConfig.CheckBoxLuzTentativa.Checked Then
                Box.HLightTurnOff()
                Terminal("Apaga Luz Tentativa")
            End If

            If formConfig.CheckBoxTimeout.Checked Then
                Terminal("Início Timeout")
                timerTimeout.Enabled = True
            Else
                timerIET.Enabled = True
                If formConfig.CheckBoxLuzIET.Checked Then
                    If formConfig.ComboBoxLocLuzIET.SelectedIndex = 0 Then
                        Box.HLightTurnOn()
                        Terminal("Acende Luz IET")
                        timerLuz.Enabled = True
                    Else
                        timerLocLuzIET.Enabled = True
                    End If
                End If
                Exit Sub
            End If
        End If
    End Sub

    Private Sub pictureE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictureE.Click

        If formConfig.CheckBoxBeepResposta.Checked Then Beep()
        resetTimeResposta()

        'If formConfig.CheckBoxCorrecao.Checked Then
        '    If CInt(strCompCorreta) <> 2 Then
        '        If formConfig.ComboBoxCorrecao.SelectedIndex = 0 Then
        '            Exit Sub
        '        End If
        '    End If
        'End If

        If formConfig.RadioButtonMTS.Checked Or formConfig.RadioButtonMTSTime.Checked Then
            fimComparacao(2)
        Else
            timerApresentacao.Enabled = False
            timeFimModelo = Now
            timeModelo = formatSeconds(timeFimModelo.Subtract(timeInicioModelo).TotalMilliseconds)
            Terminal("Bicou Esquerda")
            Terminal("Modelo Terminou")
            Terminal("Duração - " & timeModelo.ToString("#0.000") & " segundos")
            acoesPosBicada()
            WriteRelatorio("1")
        End If
    End Sub

    Private Sub LoadExperimento()
        Dim blocos As Integer
        Dim strNomeArquivo As String

        Dim oRead As System.IO.StreamReader
        Dim LineIn As String

        For blocos = 0 To formConfig.ListBoxDestino.Items.Count - 1
            strNomeArquivo = strDirBlocos & formConfig.ListBoxDestino.Items.Item(blocos).ToString
            oRead = IO.File.OpenText(strNomeArquivo)


            While oRead.Peek <> -1
                LineIn = oRead.ReadLine()
                If Trim(LineIn) <> "" Then
                    ListBoxExperimento.Items.Add(LineIn & vbTab & formConfig.ListBoxDestino.Items.Item(blocos).ToString)
                End If
            End While
            oRead.Close()
        Next blocos

        nroQtdTotalPlanejado = ListBoxExperimento.Items.Count
        intPosicaoAtual = 0
    End Sub

    Private Sub WriteRelatorio(ByVal opt As String)

        If formConfig.RadioButtonMTS.Checked Or formConfig.RadioButtonMTSTime.Checked Then
            If opt = "H" Then
                strRelatorio = strRelatorio & "Tentativa" & vbTab & _
                            "Acerto" & vbTab & _
                            "Modelo" & vbTab & _
                            "CompE" & vbTab & _
                            "CompD" & vbTab & _
                            "S+" & vbTab & _
                            "Resposta" & vbTab & _
                            "TempoMod" & vbTab & _
                            "TempoDelay" & vbTab & _
                            "TempoComp" & vbTab & _
                            "Bloco" & vbTab & _
                            "Correcao"
                'Aqui mudou Saulim ApresentacaoComp 05/12/2008
            ElseIf opt = "0" Or opt = "1" Or opt = "E" Then
                strRelatorio = strRelatorio & vbCrLf
                strRelatorio = strRelatorio & nroTentativa.ToString & vbTab & _
                             opt & vbTab & _
                             strModelo & vbTab & _
                             strCompE & vbTab & _
                             strCompD & vbTab & _
                             strCompCorreta & vbTab & _
                             posBicada & vbTab & _
                             timeModelo.ToString("#0.000") & vbTab
                If formConfig.CheckBoxDelay.Checked Then
                    strRelatorio = strRelatorio & formatSeconds(formConfig.NumericUpDownDelay.Value).ToString() & vbTab
                Else
                    strRelatorio = strRelatorio & "0.000" & vbTab
                End If

                strRelatorio = strRelatorio & timeComparacao.ToString("#0.000") & vbTab & _
                             strNomeBloco & vbTab & _
                             nroQtdCorrecao.ToString

              
            ElseIf opt = "ES" Then
                strRelatorio = strRelatorio & vbCrLf
                strRelatorio = strRelatorio & "Expirou Sessao:" & vbTab & _
                             formConfig.NumericUpDownTempoSessao.Value.ToString("#0.000")
            ElseIf opt = "ER" Then
                strRelatorio = strRelatorio & vbCrLf
                strRelatorio = strRelatorio & "Expirou Resposta:" & vbTab & _
                             formConfig.NumericUpDownTempoResposta.Value.ToString("#0.000")
            ElseIf opt = "SI" Then
                strRelatorio = strRelatorio & vbCrLf
                strRelatorio = strRelatorio & "Sessao Interrompida Tentativa:" & vbTab & nroTentativa.ToString & vbTab & _
                                "%Acerto parcial:" & vbTab
                strRelatorio = strRelatorio & ((nroAcertoSemCorr * 100) / (nroTentativa - nroQtdTotalCorrecao)).ToString("#0.000") & "%"
                strRelatorio = strRelatorio & vbCrLf
                strRelatorio = strRelatorio & " " & vbTab & vbTab & _
                                "%Acerto parcial correcao:" & vbTab & _
                ((nroAcerto * 100) / nroTentativa).ToString("#0.000") & "%"
            ElseIf opt = "F" Then
                strRelatorio = strRelatorio & vbCrLf
                strRelatorio = strRelatorio & "Tempo total:" & vbTab & _
                             timeSessao.ToString("#0.000") & vbTab & _
                             "%Acerto Geral:" & vbTab

                strRelatorio = strRelatorio & ((nroAcertoSemCorr * 100) / (nroQtdTotalPlanejado)).ToString("#0.000") & "%"
                strRelatorio = strRelatorio & vbCrLf
                strRelatorio = strRelatorio & " " & vbTab & _
                         " " & vbTab & _
                         "%Acerto Geral Correcao:" & vbTab & _
                         percAcerto.ToString("#0.000") & "%"
                strRelatorio = strRelatorio & vbCrLf
                strRelatorio = strRelatorio & "Total Planejado:" & vbTab & _
                         nroQtdTotalPlanejado.ToString("#0.000")
                strRelatorio = strRelatorio & vbCrLf
                strRelatorio = strRelatorio & "Total Correcoes:" & vbTab & _
                             nroQtdTotalCorrecao.ToString("#0.000")
                strRelatorio = strRelatorio & vbCrLf & LabelPontuacao.Text
                writeParameters()


            End If
        Else
            If opt = "H" Then
                strRelatorio = strRelatorio & "Tentativa" & vbTab & _
                            "Modelo" & vbTab & _
                            "Posicao" & vbTab & _
                            "Resposta" & vbTab & _
                            "TempoMod" & vbTab & _
                            "Bloco"
            ElseIf opt = "0" Or opt = "1" Then
                strRelatorio = strRelatorio & vbCrLf
                strRelatorio = strRelatorio & nroTentativa.ToString & vbTab & _
                             strModelo & vbTab & _
                             strCompCorreta & vbTab & _
                             opt & vbTab & _
                             timeModelo.ToString("#0.000") & vbTab & _
                             strNomeBloco
            ElseIf opt = "ES" Then
                strRelatorio = strRelatorio & vbCrLf
                strRelatorio = strRelatorio & "Expirou Sessão:" & vbTab & _
                             formConfig.NumericUpDownTempoSessao.Value.ToString("#0.000")
            ElseIf opt = "ER" Then
                strRelatorio = strRelatorio & vbCrLf
                strRelatorio = strRelatorio & "Expirou Resposta:" & vbTab & _
                             formConfig.NumericUpDownTempoResposta.Value.ToString("#0.000")
            ElseIf opt = "F" Then
                strRelatorio = strRelatorio & vbCrLf
                strRelatorio = strRelatorio & "Tempo total:" & vbTab & _
                             timeSessao.ToString("#0.000")
                writeParameters()
            End If
        End If
    End Sub

    Private Sub GravaRelatorio()

        If Not bolRelatorio Then
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)

            If formConfig.ComboBoxSeparadorDecimal.SelectedIndex = 0 Then
                objWriter.WriteLine(strRelatorio.Replace(".", ","))
            Else
                objWriter.WriteLine(strRelatorio.Replace(",", "."))
            End If
            objWriter.Close()
            bolRelatorio = True
        End If
    End Sub

    Private Sub labelFimSessao_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles labelFimSessao.DoubleClick
        GravaRelatorio()
        Box.Close()
        Me.Dispose()
    End Sub

    Private Sub timerApresentacao_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerApresentacao.Tick

        resetTimeResposta()

        timeFimModelo = Now
        timerApresentacao.Enabled = False
        timeModelo = formatSeconds(timeFimModelo.Subtract(timeInicioModelo).TotalMilliseconds)
        Terminal("Apresentação Expirou")
        Terminal("Modelo Terminou")
        Terminal("Duração - " & timeModelo.ToString("#0.000") & " segundos")

        If formConfig.RadioButtonMTSTime.Checked Then
            pictureC.Visible = False
            pictureE.Visible = False
            pictureD.Visible = False
            labelC.Text = ""
            labelD.Text = ""
            labelE.Text = ""
            picComparacao()
        Else
            WriteRelatorio("0")
            acoesPosBicada()
        End If
    End Sub

    'Aqui acrescetou Saulim ApresentacaoComp 05/12/2008
    Private Sub timerApresentacaoComp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerApresentacaoComp.Tick

        resetTimeResposta()

        timeFimComparacao = Now
        timerApresentacaoComp.Enabled = False
        timeComparacao = formatSeconds(timeFimComparacao.Subtract(timeInicioComparacao).TotalMilliseconds)
        Terminal("Apresentação Expirou")
        Terminal("Comparação Terminou")
        Terminal("Duração - " & timeComparacao.ToString("#0.000") & " segundos")


        WriteRelatorio("E")

        pictureC.Visible = False
        pictureE.Visible = False
        pictureD.Visible = False
        labelC.Text = ""
        labelD.Text = ""
        labelE.Text = ""

        timerIET.Enabled = True

        If formConfig.CheckBoxLuzIET.Checked Then
            If formConfig.ComboBoxLocLuzIET.SelectedIndex = 0 Then
                Box.HLightTurnOn()
                Terminal("Acende Luz IET")
                timerLuz.Enabled = True
            Else
                timerLocLuzIET.Enabled = True
            End If
        End If

    End Sub

    Private Sub acoesPosBicada()
        pictureC.Visible = False
        pictureE.Visible = False
        pictureD.Visible = False
        labelC.Text = ""
        labelD.Text = ""
        labelE.Text = ""

        If formConfig.CheckBoxLuzTentativa.Checked Then
            Box.HLightTurnOff()
            Terminal("Apaga Luz Tentativa")
        End If

        If formConfig.CheckBoxBeepReforço.Checked Then
            Beep()
        End If

        nroAcerto = nroAcerto + 1
        LabelPontuacao.Text = "Pontos: " & (nroAcerto * CInt(formConfig.NumericUpDownPontuacao.Value)).ToString

        If formConfig.CheckBoxComedouro.Checked Then
            If formConfig.CheckBoxLuzComedouro.Checked Then
                Box.HLightTurnOn()
                Terminal("Acende Luz Comedouro")
            End If
            Box.rewardTurnOn()
            Terminal("Abre Comedouro")
            timerComedouro.Enabled = True
        Else
            timerIET.Enabled = True
            If formConfig.CheckBoxLuzIET.Checked Then
                If formConfig.ComboBoxLocLuzIET.SelectedIndex = 0 Then
                    Box.HLightTurnOn()
                    Terminal("Acende Luz IET")
                    timerLuz.Enabled = True
                Else
                    timerLocLuzIET.Enabled = True
                End If
            End If

        End If
    End Sub
    Private Sub timerSessao_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerSessao.Tick
        timeFimSessao = Now
        timerSessao.Enabled = False
        timerResposta.Enabled = False
        pictureC.Visible = False
        pictureE.Visible = False
        pictureD.Visible = False
        labelC.Text = ""
        labelD.Text = ""
        labelE.Text = ""
        PictureExit.Enabled = True
        labelFimSessao.Visible = True
        Terminal("A sessão expirou")
        Box.rewardTurnOff()
        Box.HLightTurnOff()
        timeSessao = formatSeconds(timeFimSessao.Subtract(timeInicioSessao).TotalMilliseconds)
        percAcerto = (nroAcerto * 100) / (nroQtdTotalPlanejado + nroQtdTotalCorrecao)
        WriteRelatorio("ES")
        WriteRelatorio("F")
        GravaRelatorio()
         ShowHideCursor(1)
    End Sub

    Private Sub timerResposta_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerResposta.Tick
        timeFimSessao = Now
        timerResposta.Enabled = False
        timerSessao.Enabled = False
        pictureC.Visible = False
        pictureE.Visible = False
        pictureD.Visible = False
        labelC.Text = ""
        labelD.Text = ""
        labelE.Text = ""
        PictureExit.Enabled = True
        labelFimSessao.Visible = True
        Terminal("A tempo de resposta expirou")
        Box.rewardTurnOff()
        Box.HLightTurnOff()
        timeSessao = formatSeconds(timeFimSessao.Subtract(timeInicioSessao).TotalMilliseconds)
        percAcerto = (nroAcerto * 100) / (nroQtdTotalPlanejado + nroQtdTotalCorrecao)
        WriteRelatorio("ER")
        WriteRelatorio("F")
        GravaRelatorio()
         ShowHideCursor(1)
    End Sub

    Sub resetTimeResposta()
        If formConfig.CheckBoxTempoResposta.Checked Then
            timerResposta.Enabled = False
            timerResposta.Enabled = True
        End If

    End Sub

    Private Sub buttonComedouro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonComedouro.Click
        'If formConfig.CheckBoxBeepResposta.Checked Then Beep()
        resetTimeResposta()
        If formConfig.RadioButtonMTS.Checked Or formConfig.RadioButtonMTSTime.Checked Then
            fimComparacao(CInt(strCompCorreta))
        Else
            timerApresentacao.Enabled = False
            timeFimModelo = Now
            timeModelo = formatSeconds(timeFimModelo.Subtract(timeInicioModelo).TotalMilliseconds)
            Terminal("Comedouro Manual Acionado")
            Terminal("Modelo Terminou")
            Terminal("Duração - " & timeModelo.ToString("#0.000") & " segundos")
            acoesPosBicada()
            WriteRelatorio("1")
        End If

    End Sub

    Private Sub formExperimento_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If e.Button.ToString = "Right" Then
            Call buttonComedouro_Click(sender, e)
        End If

    End Sub

    Private Sub timerLocLuzIET_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerLocLuzIET.Tick
        Box.HLightTurnOn()
        Terminal("Acende Luz IET")
        timerLocLuzIET.Enabled = False
        timerLuz.Enabled = True
    End Sub

    Private Sub timerTimeout_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerTimeout.Tick
        timerIET.Enabled = True
        Terminal("Fim Timeout")
        If formConfig.CheckBoxLuzIET.Checked Then
            If formConfig.ComboBoxLocLuzIET.SelectedIndex = 0 Then
                Box.HLightTurnOn()
                Terminal("Acende Luz IET")
                timerLuz.Enabled = True
            Else
                timerLocLuzIET.Enabled = True
            End If

        End If
        timerTimeout.Enabled = False
    End Sub

    Private Sub buttonSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonSair.Click
        timeFimSessao = Now
        PictureExit.Enabled = True
        labelFimSessao.Visible = True
        Terminal("A sessão foi interropida")
        timeSessao = formatSeconds(timeFimSessao.Subtract(timeInicioSessao).TotalMilliseconds)
        percAcerto = (nroAcerto * 100) / (nroQtdTotalPlanejado + nroQtdTotalCorrecao)
        WriteRelatorio("SI")
        WriteRelatorio("F")
        GravaRelatorio()
        ShowHideCursor(1)
        Box.Close()
        Me.Dispose()
    End Sub

    Private Sub writeParameters()

        strRelatorio = strRelatorio & vbCrLf & vbCrLf & "Parametros"

        strRelatorio = strRelatorio & vbCrLf & "Chk Pontuacao:" & vbTab & formConfig.CheckBoxPontuacao.Checked.ToString()
        strRelatorio = strRelatorio & vbCrLf & "Qtd Pontuacao:" & vbTab & formConfig.NumericUpDownPontuacao.Value.ToString()

        strRelatorio = strRelatorio & vbCrLf & "Tempo IET:" & vbTab & formConfig.NumericUpDownIET.Value.ToString

        strRelatorio = strRelatorio & vbCrLf & "Chk Comedouro:" & vbTab & formConfig.CheckBoxComedouro.Checked.ToString()
        strRelatorio = strRelatorio & vbCrLf & "Tempo Comedouro:" & vbTab & formConfig.NumericUpDownComedouro.Value.ToString()

        strRelatorio = strRelatorio & vbCrLf & "Chk Timeout:" & vbTab & formConfig.CheckBoxTimeout.Checked.ToString()
        strRelatorio = strRelatorio & vbCrLf & "Tempo Timeout:" & vbTab & formConfig.NumericUpDownTimeout.Value.ToString

        strRelatorio = strRelatorio & vbCrLf & "Chk Luz IET:" & vbTab & formConfig.CheckBoxLuzIET.Checked.ToString()
        strRelatorio = strRelatorio & vbCrLf & "Local Luz IET:" & vbTab & formConfig.ComboBoxLocLuzIET.SelectedIndex.ToString()
        strRelatorio = strRelatorio & vbCrLf & "Tempo Luz IET:" & vbTab & formConfig.NumericUpDownLuzIET.Value.ToString

        strRelatorio = strRelatorio & vbCrLf & "Chk TP:" & vbTab & formConfig.CheckBoxApresentacao.Checked.ToString()
        strRelatorio = strRelatorio & vbCrLf & "Tempo TP:" & vbTab & formConfig.NumericUpDownApresentacao.Value.ToString

        strRelatorio = strRelatorio & vbCrLf & "Chk Delay:" & vbTab & formConfig.CheckBoxDelay.Checked.ToString()
        strRelatorio = strRelatorio & vbCrLf & "Tempo Delay:" & vbTab & formConfig.NumericUpDownDelay.Value.ToString

        strRelatorio = strRelatorio & vbCrLf & "Chk Luz Tentativa:" & vbTab & formConfig.CheckBoxLuzTentativa.Checked.ToString()
        strRelatorio = strRelatorio & vbCrLf & "Chk Luz Comedouro:" & vbTab & formConfig.CheckBoxLuzComedouro.Checked.ToString()

        strRelatorio = strRelatorio & vbCrLf & "Chk BeepRes:" & vbTab & formConfig.CheckBoxBeepResposta.Checked.ToString()
        strRelatorio = strRelatorio & vbCrLf & "Chk BeepRef:" & vbTab & formConfig.CheckBoxBeepReforço.Checked.ToString()

        strRelatorio = strRelatorio & vbCrLf & "Chk Tempo Resposta:" & vbTab & formConfig.CheckBoxTempoResposta.Checked.ToString()

        strRelatorio = strRelatorio & vbCrLf & "Tempo Resposta:" & vbTab & formConfig.NumericUpDownTempoResposta.Value.ToString

        strRelatorio = strRelatorio & vbCrLf & "Chk Tempo Sessao:" & vbTab & formConfig.CheckBoxTempoSessao.Checked.ToString()
        strRelatorio = strRelatorio & vbCrLf & "Tempo Sessao:" & vbTab & formConfig.NumericUpDownTempoSessao.Value.ToString

        strRelatorio = strRelatorio & vbCrLf & "Bicadas Modelo:" & vbTab & formConfig.NumericUpDownBicModelo.Value.ToString

        strRelatorio = strRelatorio & vbCrLf & "Bicadas Comp:" & vbTab & formConfig.NumericUpDownBicComp.Value.ToString

    End Sub

    Private Sub pictureC_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pictureC.MouseDown
        Call pictureC_Click_Fake(sender, e)
    End Sub

    Private Sub pictureC_Click_Fake(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If formConfig.RadioButtonMTSTime.Checked Then
            Exit Sub
        End If

        nroBicadas = nroBicadas + 1
        LabelBicModelo.Text = nroBicadas.ToString
        If formConfig.CheckBoxBeepResposta.Checked Then Beep()
        If nroBicadas = formConfig.NumericUpDownBicModelo.Value Then

            resetTimeResposta()

            timeFimModelo = Now
            pictureC.Visible = False
            pictureE.Visible = False
            pictureD.Visible = False
            timeModelo = formatSeconds(timeFimModelo.Subtract(timeInicioModelo).TotalMilliseconds)
            labelC.Text = ""
            labelD.Text = ""
            labelE.Text = ""

            If formConfig.RadioButtonMTS.Checked Then
                Terminal("Modelo Terminou")
                Terminal("Duração - " & timeModelo.ToString("#0.000") & " segundos")
                picComparacao()
            Else
                timerApresentacao.Enabled = False
                Terminal("Bicou Centro")
                Terminal("Modelo Terminou")
                Terminal("Duração - " & timeModelo.ToString("#0.000") & " segundos")
                acoesPosBicada()
                WriteRelatorio("1")
            End If
        End If
    End Sub

    Private Sub ShowHideCursor(ByVal nro As Integer)
        If nro = 1 And Not bolCursor Then
            Windows.Forms.Cursor.Show()
            bolCursor = True
            'MsgBox("Show")
        End If

        If nro = 0 And bolCursor Then
            Windows.Forms.Cursor.Hide()
            bolCursor = False
            'MsgBox("Hide")
        End If
    End Sub

    Private Sub TimerTempoTotal_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerTempoTotal.Tick
        LabelTempo.Text = formatSeconds(Now.Subtract(timeInicioSessao).TotalMilliseconds).ToString("#0.000")
    End Sub

  
End Class

