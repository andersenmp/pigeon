'This file is part of Stimulus Control.

' Copyright (c) 2008 Andersen Missiaggia Picorone
'Stimulus Control is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation version 3 of the License.

'Stimulus Control is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.

'You should have received a copy of the GNU General Public License
'along with Stimulus Control.  If not, see <http://www.gnu.org/licenses/>.

'Imports KDIGIOLib

Public Class MyBox
    'hardware input codes
    Const OUTPUT_OFFSET As Short = 4

    'hardware output codes
    Const REWARD_H As Byte = 32
    Const HLIGHT_H As Byte = 128

    Const REWARD_MASK As Byte = 223
    Const HLIGHT_MASK As Byte = 127

    Const KPORT_EXE As String = "c:\Arquivos de Programas\kport\kportrlall.exe"
    Const REWARD_PORT As Integer = 1
    Const HLIGHT_PORT As Integer = 2

    'Dim KPIO As KDigitalIo
    Public interfaceIOPresent As Boolean = False
    Sub rewardTurnOn()
        If Not interfaceIOPresent Then Exit Sub
        If formConfig.RadioButtonInterfaceKDigitalIo.Checked Then
            'Dim code As Byte = KPIO.Read(OUTPUT_OFFSET)
            'KPIO.Write(OUTPUT_OFFSET, code Or REWARD_H)
        ElseIf formConfig.RadioButtonInterfaceKport.Checked Then
            Shell(KPORT_EXE & " " & REWARD_PORT, AppWinStyle.Hide)
        End If
    End Sub

    Sub rewardTurnOff()
        If Not interfaceIOPresent Then Exit Sub
        If formConfig.RadioButtonInterfaceKDigitalIo.Checked Then
            'Dim code As Byte = KPIO.Read(OUTPUT_OFFSET)
            'KPIO.Write(OUTPUT_OFFSET, code And REWARD_MASK)
        ElseIf formConfig.RadioButtonInterfaceKport.Checked Then
            Shell(KPORT_EXE & " 0", AppWinStyle.Hide)
        End If
    End Sub
    Sub HLightTurnOn()
        If Not interfaceIOPresent Then Exit Sub
        If formConfig.RadioButtonInterfaceKDigitalIo.Checked Then
            'Dim code As Byte = KPIO.Read(OUTPUT_OFFSET)
            'KPIO.Write(OUTPUT_OFFSET, code Or HLIGHT_H)
        ElseIf formConfig.RadioButtonInterfaceKport.Checked Then
            Shell(KPORT_EXE & " " & HLIGHT_PORT, AppWinStyle.Hide)
        End If
    End Sub
    Sub HLightTurnOff()
        If Not interfaceIOPresent Then Exit Sub
        If formConfig.RadioButtonInterfaceKDigitalIo.Checked Then
            'Dim code As Byte = KPIO.Read(OUTPUT_OFFSET)
            'KPIO.Write(OUTPUT_OFFSET, code And HLIGHT_MASK)
        ElseIf formConfig.RadioButtonInterfaceKport.Checked Then
            Shell(KPORT_EXE & " 0", AppWinStyle.Hide)
        End If
    End Sub
    Sub reset()
        If Not interfaceIOPresent Then Exit Sub
        If formConfig.RadioButtonInterfaceKDigitalIo.Checked Then
            'KPIO.Write(OUTPUT_OFFSET, 0)
        ElseIf formConfig.RadioButtonInterfaceKport.Checked Then
            Shell(KPORT_EXE & " 0", AppWinStyle.Hide)
        End If
    End Sub
    Public Sub New()

        If formConfig.RadioButtonInterfaceKDigitalIo.Checked Then
            Try
                'KPIO = New KDigitalIo
                'KPIO.OpenDevice("KPCIISO", 0)
                interfaceIOPresent = True
            Catch ex As Exception
                MsgBox("KDigitalIo não está presente!" & vbCrLf & "Por isso não será utilizada.")
                interfaceIOPresent = False
            End Try
        ElseIf formConfig.RadioButtonInterfaceKport.Checked Then
            If System.IO.File.Exists(KPORT_EXE) Then
                interfaceIOPresent = True
            Else
                MsgBox("Kport arquivo não está presentes em " & KPORT_EXE & " !" & vbCrLf & "Por isso não será utilizada.")
                interfaceIOPresent = False
            End If
        End If

    End Sub
    Sub Close()
        If Not interfaceIOPresent Then Exit Sub
        interfaceIOPresent = False
        If formConfig.RadioButtonInterfaceKDigitalIo.Checked Then
            'KPIO.Write(OUTPUT_OFFSET, 0)
            'KPIO.CloseDevice()
        ElseIf formConfig.RadioButtonInterfaceKport.Checked Then
            Shell(KPORT_EXE & " 0", AppWinStyle.Hide)
        End If

    End Sub
End Class
