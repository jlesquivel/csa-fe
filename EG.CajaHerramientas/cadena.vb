Imports System.Globalization
Imports System.Text

Public Class cadena


    Public Function quitarTildes(stIn As String) As String

        Dim stFormD As String = stIn.Normalize(NormalizationForm.FormD)
        Dim sb As New StringBuilder()

        For ich As Integer = 0 To stFormD.Length - 1
            Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(stFormD(ich))
            If uc <> UnicodeCategory.NonSpacingMark Then
                sb.Append(stFormD(ich))
            End If
        Next

        Return (sb.ToString().Normalize(NormalizationForm.FormC))

    End Function


    Public Function quitarEspacio(stIn As String) As String
        Return (stIn.Trim)
    End Function

    Public Function rellenar(str As String, largo As Integer, caracter As Char) As String
        Return str.PadRight(largo, caracter)
    End Function


End Class
