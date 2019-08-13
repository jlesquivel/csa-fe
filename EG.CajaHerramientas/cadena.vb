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


    Public Function SeparaPorAncho(ByVal s As String, ByVal widths As Integer()) As String()
        Dim ret As String() = New String(widths.Length - 1) {}
        Dim c As Char() = s.ToCharArray()
        Dim startPos As Integer = 0

        For i As Integer = 0 To widths.Length - 1
            Dim width As Integer = widths(i)
            ret(i) = New String(c.Skip(startPos).Take(width).ToArray())
            startPos += width
        Next

        Return ret
    End Function


End Class
