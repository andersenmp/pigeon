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
Module functions
    Public strDirBlocos As String
    Public strDirImagens As String
    Public strDirRelatorios As String
    Public bolCursor As Boolean

    Public Sub Pause(ByVal mili As Integer)
        System.Threading.Thread.Sleep(mili)
    End Sub

    Public Function formatSeconds(ByVal timeMilli As Double) As Double
        formatSeconds = (timeMilli / 1000)
    End Function

    Public Function checkImage(ByVal img As String) As String
        If System.IO.File.Exists(strDirImagens & img & ".png") Then
            checkImage = strDirImagens & img & ".png"
        Else
            checkImage = strDirImagens & "SemImagem.png"
        End If
    End Function


End Module
