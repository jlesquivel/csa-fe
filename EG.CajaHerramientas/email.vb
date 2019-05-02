Imports System.Text.RegularExpressions

Public Class email


    Dim regHexHacienda = "\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*"
    Dim regHexNormal = "^[\w._%-]+@[\w.-]+\.[a-zA-Z]{2,4}$"



    Public Function IsValidEmail(ByVal email As String) As Boolean
        If email = String.Empty Then Return False
        ' Compruebo si el formato de la dirección es correcto.
        Dim re As Regex = New Regex(regHexHacienda)

        Dim m As Match = re.Match(email)
        Return (m.Captures.Count <> 0)
    End Function


End Class
