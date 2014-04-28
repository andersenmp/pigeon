Public Class formExperimentoHB

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

    Private strCompEi As String
    Private strCompDi As String
    Private strCompC As String

    Private strCompCorreta As String
    Private strPosModelo As String
    Private strNomeBloco As String
    Private strTimeApresentacao As String
    Private strRelatorio As String

    Private intPosicaoAtual As Integer

    Private FILE_NAME As String

    Private nroBicadas As Integer

    'Incluído por Saulo 15/11/2010
    Private nroBicadasCorreta As Integer
    Private nroBicadasIncorreta As Integer
    'Fim inclusão

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
    Private bolComparacao As Boolean

    Dim Box As MyBox

    Private Sub formExperimentoHB_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        GravaRelatorio()
        ShowHideCursor(1)
        FormInvisivel.Hide() 'incluído por Saulo
    End Sub

    Private Sub formExperimentoHB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormInvisivel.Show() 'incluído por Saulo para desativar bicadas na metade superior dos estímulos

        Dim strNomeArquivo As String

        timeInicioSessao = Now
        strRelatorio = ""
        nroBicadas = 0
        nroBicadasCorreta = 0
        nroBicadasIncorreta = 0
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
        LabelBicComp.Text = "0"

        LabelTentativa.Text = "0"
        LabelRepeticao.Text = "0"

        LabelAcertos.Text = "0"
        LabelErros.Text = "0"

        LabelTempo.Text = "0"

        labelFimSessao.Visible = False

        strNomeArquivo = "MTS_4-Escolhas_"

        If formConfig.CheckBoxPontuacao.Checked Then
            LabelPontuacao.Visible = True
        Else
            LabelPontuacao.Visible = False
        End If

        FILE_NAME = strDirRelatorios & strNomeArquivo & formConfig.TextPombo.Text & "_" & Replace(Now.ToShortDateString, "/", "_") & "_" & Replace(Replace(Now.ToShortTimeString, ":", "_"), " ", "_") & ".xls"

        timerIET.Interval = CInt(formConfig.NumericUpDownIET.Value)
        timerLuz.Interval = CInt(formConfig.NumericUpDownLuzIET.Value)
        timerComedouro.Interval = CInt(formConfig.NumericUpDownComedouro.Value)
        timerTimeout.Interval = CInt(formConfig.NumericUpDownTimeout.Value)
        timerApresentacao.Interval = CInt(formConfig.NumericUpDownApresentacao.Value)
        timerResposta.Interval = CInt(formConfig.NumericUpDownTempoResposta.Value)
        timerSessao.Interval = CInt(formConfig.NumericUpDownTempoSessao.Value)
        timerApresentacaoComp.Interval = CInt(formConfig.NumericUpDownTempoCompIncor.Value) 'Incluído por Saulo 15/11/2010

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
            LabelDi.Visible = True
            LabelEi.Visible = True
        Else
            labelC.Visible = False
            labelD.Visible = False
            labelE.Visible = False
            LabelDi.Visible = False
            LabelEi.Visible = False
        End If

        labelC.Text = ""
        labelD.Text = ""
        labelE.Text = ""
        LabelDi.Text = ""
        LabelEi.Text = ""

        If formConfig.CheckBoxCursor.Checked Then
            ShowHideCursor(1)
        Else
            ShowHideCursor(0)
        End If

        Box = New MyBox()
        Box.reset()
        If Not Box.interfaceIOPresent Then
            Terminal("Interface IO não está presente! Por isso não será utilizada.")
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
        Terminal("Fim IET")
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
        Terminal("Início IET")
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
        bolComparacao = False
        nroBicadas = 0
        nroBicadasCorreta = 0
        nroBicadasIncorreta = 0
        nroTentativa = nroTentativa + 1
        LabelBicModelo.Text = "0"
        LabelBicComp.Text = "0"
        LabelTentativa.Text = (intPosicaoAtual + 1).ToString

        pictureC.Visible = False
        pictureE.Visible = False
        pictureD.Visible = False
        PictureDi.Visible = False
        PictureEi.Visible = False

        labelC.Text = ""
        labelD.Text = ""
        labelE.Text = ""
        LabelDi.Text = ""
        LabelEi.Text = ""



        If formConfig.CheckBoxLuzTentativa.Checked Then
            Box.HLightTurnOn()
            Terminal("Acende Luz Tentativa")
        End If

        If intPosicaoAtual <= ListBoxExperimento.Items.Count - 1 Then
            arrayOpcoes = Split(ListBoxExperimento.Items.Item(intPosicaoAtual).ToString, vbTab)
            ListBoxExperimento.SetSelected(intPosicaoAtual, True)

            If arrayOpcoes.Length <> 8 Then
                MsgBox("Arquivo Incorreto para MTS 4-Escolhas!", MsgBoxStyle.Information)
                Box.Close()
                ShowHideCursor(1)
                Me.Dispose()
                Exit Sub
            End If

            strModelo = arrayOpcoes(0)
            strCompC = strModelo
            strCompE = arrayOpcoes(1)
            strCompD = arrayOpcoes(2)
            strCompEi = arrayOpcoes(3)
            strCompDi = arrayOpcoes(4)
            strCompCorreta = arrayOpcoes(5)
            strPosModelo = arrayOpcoes(6)
            strNomeBloco = arrayOpcoes(7)

            'Verifica se a posição correta está ocupada pelo modelo 
            If strCompCorreta = strPosModelo Then
                strCompCorreta = "1"
            End If

            Select Case strPosModelo
                Case "1"
                    pictureC.ImageLocation = checkImage(strModelo)
                    labelC.Text = strModelo
                    pictureC.Visible = True
                Case "2"
                    pictureE.ImageLocation = checkImage(strModelo)
                    labelE.Text = strModelo
                    pictureE.Visible = True
                Case "3"
                    pictureD.ImageLocation = checkImage(strModelo)
                    labelD.Text = strModelo
                    pictureD.Visible = True
                Case "4"
                    PictureEi.ImageLocation = checkImage(strModelo)
                    LabelEi.Text = strModelo
                    PictureEi.Visible = True
                Case "5"
                    PictureDi.ImageLocation = checkImage(strModelo)
                    LabelDi.Text = strModelo
                    PictureDi.Visible = True
                Case Else
                    pictureC.ImageLocation = checkImage(strModelo)
                    labelC.Text = strModelo
                    pictureC.Visible = True
            End Select


            Terminal("Início Modelo - " & strModelo)
            timeInicioModelo = Now

            timerApresentacaoComp.Enabled = False 'Incluído por Saulo 15/11/2010

            intPosicaoAtual = intPosicaoAtual + 1


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
        bolComparacao = True
        nroBicadas = 0
        nroBicadasCorreta = 0
        nroBicadasIncorreta = 0
        LabelBicComp.Text = "0"
        nroQtdTotalComparacoes = nroQtdTotalComparacoes + 1

        If formConfig.CheckBoxDelay.Checked Then
            Pause(CInt(formConfig.NumericUpDownDelay.Value))
        End If

        If strPosModelo <> "2" Then
            pictureE.ImageLocation = checkImage(strCompE)
            labelE.Text = strCompE
        Else
            pictureC.ImageLocation = checkImage(strCompE)
            strCompC = strCompE
            labelC.Text = strCompE
        End If

        If strPosModelo <> "3" Then
            pictureD.ImageLocation = checkImage(strCompD)
            labelD.Text = strCompD
        Else
            pictureC.ImageLocation = checkImage(strCompD)
            strCompC = strCompD
            labelC.Text = strCompD
        End If

        If strPosModelo <> "4" Then
            PictureEi.ImageLocation = checkImage(strCompEi)
            LabelEi.Text = strCompEi
        Else
            pictureC.ImageLocation = checkImage(strCompEi)
            strCompC = strCompEi
            labelC.Text = strCompEi
        End If

        If strPosModelo <> "5" Then
            PictureDi.ImageLocation = checkImage(strCompDi)
            LabelDi.Text = strCompDi
        Else
            pictureC.ImageLocation = checkImage(strCompDi)
            strCompC = strCompDi
            labelC.Text = strCompDi
        End If


        If formConfig.CheckBoxCorrecao.Checked And formConfig.ComboBoxCorrecao.SelectedIndex = 1 And nroQtdCorrecao > formConfig.NumericUpDownCorrecao.Value Then
            If CInt(strCompCorreta) = 3 Then
                pictureD.Visible = True
            ElseIf CInt(strCompCorreta) = 2 Then
                pictureE.Visible = True
            ElseIf CInt(strCompCorreta) = 4 Then
                PictureEi.Visible = True
            ElseIf CInt(strCompCorreta) = 5 Then
                PictureDi.Visible = True
            ElseIf CInt(strCompCorreta) = 1 Then
                pictureC.Visible = True
            End If
            If Not formConfig.CheckBoxDelay.Checked Then
                Select Case strPosModelo
                    Case "1"
                        pictureC.Visible = True
                    Case "2"
                        pictureE.Visible = True
                    Case "3"
                        pictureD.Visible = True
                    Case "4"
                        PictureEi.Visible = True
                    Case "5"
                        PictureDi.Visible = True
                End Select
            End If
        Else

            If Not formConfig.CheckBoxDelay.Checked Then
                pictureC.Visible = True
                pictureE.Visible = True
                pictureD.Visible = True
                PictureDi.Visible = True
                PictureEi.Visible = True
            Else
                If strPosModelo <> "2" Then
                    pictureE.Visible = True
                Else
                    pictureC.Visible = True
                End If

                If strPosModelo <> "3" Then
                    pictureD.Visible = True
                Else
                    pictureC.Visible = True
                End If

                If strPosModelo <> "4" Then
                    PictureEi.Visible = True
                Else
                    pictureC.Visible = True
                End If

                If strPosModelo <> "5" Then
                    PictureDi.Visible = True
                Else
                    pictureC.Visible = True
                End If
            End If
        End If

        timeInicioComparacao = Now
        Terminal("Início Comparações")

    End Sub

    Private Sub fimComparacao(ByVal pic As Integer)
        nroBicadas = nroBicadas + 1
        LabelBicComp.Text = nroBicadas.ToString
        posBicada = pic

        
        'INCLUÍDO POR SAULO 15/11/2010
        If pic = 1 Then
            pictureE.Visible = False
            pictureD.Visible = False
            PictureEi.Visible = False
            PictureDi.Visible = False
        End If

        If pic = 2 Then
            pictureC.Visible = False
            pictureD.Visible = False
            PictureEi.Visible = False
            PictureDi.Visible = False
        End If

        If pic = 3 Then
            pictureC.Visible = False
            pictureE.Visible = False
            PictureEi.Visible = False
            PictureDi.Visible = False
        End If

        If pic = 4 Then
            pictureC.Visible = False
            pictureE.Visible = False
            pictureD.Visible = False
            PictureDi.Visible = False
        End If

        If pic = 5 Then
            pictureC.Visible = False
            pictureE.Visible = False
            PictureEi.Visible = False
            pictureD.Visible = False
        End If
        'FIM INCLUSÃO SAULO


        If pic = CInt(strCompCorreta) Or ((strCompCorreta = strPosModelo) And pic = 1) Then
            nroBicadasCorreta = nroBicadasCorreta + 1
            nroBicadasIncorreta = 0

            If nroBicadasCorreta = formConfig.NumericUpDownBicComp.Value Then

                timeFimComparacao = Now
                timeComparacao = formatSeconds(timeFimComparacao.Subtract(timeInicioComparacao).TotalMilliseconds)
                Terminal("Acertou")
                Terminal("Fim Comparações - Duração: " & timeComparacao.ToString("#0.000") & " s")
                pictureC.Visible = False
                pictureE.Visible = False
                pictureD.Visible = False
                PictureEi.Visible = False
                PictureDi.Visible = False
                labelC.Text = ""
                labelD.Text = ""
                labelE.Text = ""
                LabelDi.Text = ""
                LabelEi.Text = ""
                WriteRelatorio("1")


                If formConfig.CheckBoxBeepReforço.Checked Then
                    Beep()
                End If

                'reincluida por Saulo em 13/11/2010 clausula de somar pontos somente fora da correcao (retirada em 1007)
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

            End If

            'INÍCIO MUDANÇA SAULO 15/11/2010
        ElseIf pic <> CInt(strCompCorreta) Then

            If formConfig.CheckBoxCompIncor.Checked Then
                timerApresentacaoComp.Enabled = True
            Else
                timerApresentacaoComp.Enabled = False
            End If

            nroBicadasIncorreta = nroBicadasIncorreta + 1
            nroBicadasCorreta = 0

            If nroBicadasIncorreta = formConfig.NumericUpDownBicComp.Value Then
                resetTimeResposta()
                Terminal("Errou")

                If formConfig.CheckBoxCorrecao.Checked Then
                    If formConfig.ComboBoxCorrecao.SelectedIndex = 0 Then
                        nroBicadasIncorreta = nroBicadasIncorreta - 1
                        LabelBicComp.Text = nroBicadasIncorreta.ToString
                        Exit Sub
                    End If
                End If

                timeFimComparacao = Now
                timerApresentacaoComp.Enabled = False
                timeComparacao = formatSeconds(timeFimComparacao.Subtract(timeInicioComparacao).TotalMilliseconds)
                Terminal("Fim Comparações - Duração: " & timeComparacao.ToString("#0.000") & " s")
                pictureC.Visible = False
                pictureE.Visible = False
                pictureD.Visible = False
                PictureEi.Visible = False
                PictureDi.Visible = False
                labelC.Text = ""
                labelD.Text = ""
                labelE.Text = ""
                LabelDi.Text = ""
                LabelEi.Text = ""
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
                    Terminal("Início IET")
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
        End If

    End Sub
    'FIM MUDANÇA SAULO

    'INCLUÍDO POR SAULO 15/11/2010
    Private Sub timerApresentacaoComp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerApresentacaoComp.Tick

        resetTimeResposta()

        timeFimComparacao = Now
        timerApresentacaoComp.Enabled = False
        timeComparacao = formatSeconds(timeFimComparacao.Subtract(timeInicioComparacao).TotalMilliseconds)
        Terminal("Comparação Incorreto Expirou - Duração: " & timeComparacao.ToString("#0.000") & " s")
        pictureC.Visible = False
        pictureE.Visible = False
        pictureD.Visible = False
        PictureEi.Visible = False
        PictureDi.Visible = False
        labelC.Text = ""
        labelD.Text = ""
        labelE.Text = ""
        LabelDi.Text = ""
        LabelEi.Text = ""
        WriteRelatorio("2")

        If formConfig.CheckBoxCorrecao.Checked Then
            If formConfig.ComboBoxCorrecao.SelectedIndex = 0 Then
                nroBicadasIncorreta = nroBicadasIncorreta - 1
                LabelBicComp.Text = nroBicadasIncorreta.ToString
                Exit Sub
            End If
        End If

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
            Terminal("Início IET")
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

    End Sub
    
    'FIM INCLUSÃO SAULO

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
        If opt = "H" Then
            strRelatorio = strRelatorio & "Tentativa" & vbTab & _
                        "Acerto" & vbTab & _
                        "Modelo" & vbTab & _
                        "CompE" & vbTab & _
                        "CompD" & vbTab & _
                        "CompEi" & vbTab & _
                        "CompDi" & vbTab & _
                        "S+" & vbTab & _
                        "PosModelo" & vbTab & _
                        "Resposta" & vbTab & _
                        "BicadasCompCorreto" & vbTab & _
                        "TempoMod" & vbTab & _
                        "TempoDelay" & vbTab & _
                        "TempoComp" & vbTab & _
                        "Bloco" & vbTab & _
                        "Correcao"
            'INÍCIO MUDANÇA SAULO (0=erro, 1=acerto, 2=comaparacao expirou, 3=comedouro acionado manualmente)
        ElseIf opt = "0" Or opt = "1" Or opt = "2" Or opt = "3" Then
            If opt = "0" Then nroBicadasIncorreta = nroBicadasIncorreta - 1
            'FIM MUDANÇA SAULO
            strRelatorio = strRelatorio & vbCrLf
            strRelatorio = strRelatorio & nroTentativa.ToString & vbTab & _
                         opt & vbTab & _
                         strModelo & vbTab & _
                         strCompE & vbTab & _
                         strCompD & vbTab & _
                         strCompEi & vbTab & _
                         strCompDi & vbTab & _
                         strCompCorreta & vbTab & _
                         strPosModelo & vbTab & _
                         posBicada & vbTab & _
                         nroBicadas & vbTab & _
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
        writeParameters()
        Box.Close()
        Me.Dispose()
    End Sub

    Private Sub timerApresentacao_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerApresentacao.Tick

        resetTimeResposta()

        timeFimModelo = Now
        timerApresentacao.Enabled = False
        timeModelo = formatSeconds(timeFimModelo.Subtract(timeInicioModelo).TotalMilliseconds)
        Terminal("Modelo Expirou")
        Terminal("Fim Modelo - Duração: " & timeModelo.ToString("#0.000") & " s")


        pictureC.Visible = False
        pictureE.Visible = False
        pictureD.Visible = False
        PictureEi.Visible = False
        PictureDi.Visible = False
        labelC.Text = ""
        labelD.Text = ""
        labelE.Text = ""
        LabelDi.Text = ""
        LabelEi.Text = ""
        picComparacao()

    End Sub

    Private Sub acoesPosBicada()
        pictureC.Visible = False
        pictureE.Visible = False
        pictureD.Visible = False
        PictureEi.Visible = False
        PictureDi.Visible = False
        labelC.Text = ""
        labelD.Text = ""
        labelE.Text = ""
        LabelDi.Text = ""
        LabelEi.Text = ""

        If formConfig.CheckBoxLuzTentativa.Checked Then
            Box.HLightTurnOff()
            Terminal("Apaga Luz Tentativa")
        End If

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
            Terminal("Início IET")
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
        PictureEi.Visible = False
        PictureDi.Visible = False
        labelC.Text = ""
        labelD.Text = ""
        labelE.Text = ""
        LabelDi.Text = ""
        LabelEi.Text = ""
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
        PictureEi.Visible = False
        PictureDi.Visible = False
        labelC.Text = ""
        labelD.Text = ""
        labelE.Text = ""
        LabelDi.Text = ""
        LabelEi.Text = ""
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

        'INÍCIO MUDANÇA SAULO (acionamento do manual comedouro encerra a tentativa e inicia a próxima)
        resetTimeResposta()
        timeFimModelo = Now
        timerApresentacao.Enabled = False
        timeModelo = formatSeconds(timeFimModelo.Subtract(timeInicioModelo).TotalMilliseconds)
        timeFimComparacao = Now
        timerApresentacaoComp.Enabled = False
        timeComparacao = formatSeconds(timeFimComparacao.Subtract(timeInicioComparacao).TotalMilliseconds)
        fimComparacao(CInt(strCompCorreta))
        Terminal("Comedouro Acionado Manualmente")
        Terminal("Fim Tentativa - Duração : " & timeModelo.ToString("#0.000") & " segundos")
        WriteRelatorio("3")
        acoesPosBicada()

            If formConfig.CheckBoxCorrecao.Checked Then
                nroQtdCorrecao = nroQtdCorrecao + 1
                nroQtdTotalCorrecao = nroQtdTotalCorrecao + 1
            End If

            nroQtdCorrecao = 0
            LabelRepeticao.Text = "0"
            LabelBicComp.Text = "0"
        LabelErros.Text = nroQtdTotalCorrecao.ToString
        'FIM MUDANÇA SAULO

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

        'Incluído por Saulo 16/11/2010
        strRelatorio = strRelatorio & vbCrLf & "Chk DuracaoIncor:" & vbTab & formConfig.CheckBoxCompIncor.Checked.ToString()
        strRelatorio = strRelatorio & vbCrLf & "Duracao Incor:" & vbTab & formConfig.NumericUpDownTempoCompIncor.Value.ToString()
        'Fim inclusçao

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
    Private Sub pictureE_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pictureE.MouseDown
        Call pictureE_Click_Fake(sender, e)
    End Sub
    Private Sub pictureEi_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureEi.MouseDown
        Call pictureEi_Click_Fake(sender, e)
    End Sub
    Private Sub pictureD_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pictureD.MouseDown
        Call pictureD_Click_Fake(sender, e)
    End Sub
    Private Sub pictureDi_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureDi.MouseDown
        Call pictureDi_Click_Fake(sender, e)
    End Sub

    Private Sub pictureE_Click_Fake(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bolComparacao And strPosModelo = "2" Then Exit Sub
        If strPosModelo <> "2" Then
            If strCompE = "0" Then Exit Sub
            If formConfig.CheckBoxBeepResposta.Checked Then Beep()
            resetTimeResposta()
            fimComparacao(2)
        Else
            bicadaModelo()
        End If
    End Sub
    Private Sub pictureD_Click_Fake(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bolComparacao And strPosModelo = "3" Then Exit Sub
        If strPosModelo <> "3" Then
            If strCompD = "0" Then Exit Sub
            If formConfig.CheckBoxBeepResposta.Checked Then Beep()
            resetTimeResposta()
            fimComparacao(3)
        Else
            bicadaModelo()
        End If
    End Sub
    Private Sub pictureEi_Click_Fake(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bolComparacao And strPosModelo = "4" Then Exit Sub
        If strPosModelo <> "4" Then
            If strCompEi = "0" Then Exit Sub
            If formConfig.CheckBoxBeepResposta.Checked Then Beep()
            resetTimeResposta()
            fimComparacao(4)
        Else
            bicadaModelo()
        End If
    End Sub
    Private Sub pictureDi_Click_Fake(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bolComparacao And strPosModelo = "5" Then Exit Sub
        If strPosModelo <> "5" Then
            If strCompDi = "0" Then Exit Sub
            If formConfig.CheckBoxBeepResposta.Checked Then Beep()
            resetTimeResposta()
            fimComparacao(5)
        Else
            bicadaModelo()
        End If
    End Sub
    Private Sub pictureC_Click_Fake(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bolComparacao And strPosModelo = "1" Then Exit Sub
        If strPosModelo <> "1" Then
            If strCompC = "0" Then Exit Sub
            If formConfig.CheckBoxBeepResposta.Checked Then Beep()
            resetTimeResposta()
            fimComparacao(1)
        Else
            bicadaModelo()
        End If
    End Sub

    Private Sub ShowHideCursor(ByVal nro As Integer)
        If nro = 1 And Not bolCursor Then
            Windows.Forms.Cursor.Show()
            bolCursor = True
        End If

        If nro = 0 And bolCursor Then
            Windows.Forms.Cursor.Hide()
            bolCursor = False
        End If
    End Sub

    Private Sub TimerTempoTotal_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerTempoTotal.Tick
        LabelTempo.Text = formatSeconds(Now.Subtract(timeInicioSessao).TotalMilliseconds).ToString("#0")
    End Sub

    Private Sub bicadaModelo()
        nroBicadas = nroBicadas + 1
        LabelBicModelo.Text = nroBicadas.ToString
        If formConfig.CheckBoxBeepResposta.Checked Then Beep()
        If nroBicadas = formConfig.NumericUpDownBicModelo.Value Then

            resetTimeResposta()

            timeFimModelo = Now
            pictureC.Visible = False
            pictureE.Visible = False
            pictureD.Visible = False
            PictureEi.Visible = False
            PictureDi.Visible = False
            timeModelo = formatSeconds(timeFimModelo.Subtract(timeInicioModelo).TotalMilliseconds)
            labelC.Text = ""
            labelD.Text = ""
            labelE.Text = ""
            LabelDi.Text = ""
            LabelEi.Text = ""
            Terminal("Fim Modelo - Duração: " & timeModelo.ToString("#0.000") & " s")
            picComparacao()

        End If
    End Sub
    
End Class

