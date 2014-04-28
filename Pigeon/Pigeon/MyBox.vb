'This file is part of Pigeon.

' Copyright (c) 2008 Andersen Missiaggia Picorone
'Pigeon is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation version 3 of the License.

'Pigeon is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.

'You should have received a copy of the GNU General Public License
'along with Pigeon.  If not, see <http://www.gnu.org/licenses/>.

Imports KDIGIOLib

Public Class MyBox
    'hardware input codes
    Const OUTPUT_OFFSET As Short = 4

    'hardware output codes
    Const REWARD_H As Byte = 32
    Const HLIGHT_H As Byte = 128

    Const REWARD_MASK As Byte = 223
    Const HLIGHT_MASK As Byte = 127

    Dim KPIO As KDigitalIo
    Public interfaceIOPresent As Boolean = False
    Sub rewardTurnOn()
        If Not interfaceIOPresent Then Exit Sub
        Dim code As Byte = KPIO.Read(OUTPUT_OFFSET)
        KPIO.Write(OUTPUT_OFFSET, code Or REWARD_H)
    End Sub

    Sub rewardTurnOff()
        If Not interfaceIOPresent Then Exit Sub
        Dim code As Byte = KPIO.Read(OUTPUT_OFFSET)
        KPIO.Write(OUTPUT_OFFSET, code And REWARD_MASK)
    End Sub
    Sub HLightTurnOn()
        If Not interfaceIOPresent Then Exit Sub
        Dim code As Byte = KPIO.Read(OUTPUT_OFFSET)
        KPIO.Write(OUTPUT_OFFSET, code Or HLIGHT_H)
    End Sub
    Sub HLightTurnOff()
        If Not interfaceIOPresent Then Exit Sub
        Dim code As Byte = KPIO.Read(OUTPUT_OFFSET)
        KPIO.Write(OUTPUT_OFFSET, code And HLIGHT_MASK)
    End Sub
    Sub reset()
        If Not interfaceIOPresent Then Exit Sub
        KPIO.Write(OUTPUT_OFFSET, 0)
    End Sub
    Public Sub New()
        Try
            KPIO = New KDigitalIo
            KPIO.OpenDevice("KPCIISO", 0)
            interfaceIOPresent = True
        Catch ex As Exception
            'MsgBox("KDigitalIo não está presente!" & vbCrLf & "Por isso não será utilizada.")
            interfaceIOPresent = False
        End Try

    End Sub
    Sub Close()
        If Not interfaceIOPresent Then Exit Sub
        interfaceIOPresent = False
        KPIO.Write(OUTPUT_OFFSET, 0)
        KPIO.CloseDevice()
    End Sub
End Class
