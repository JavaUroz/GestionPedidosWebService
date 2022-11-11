Imports System.Security.Cryptography
Public Class Utilidades
    'Mostrar de manera coqueta errores en un control
    'Para ver un ejemplo, hacer clic derecho sobre esta funcion y "Find All References"
    Public Shared Sub ShowBalloon(ByVal c As Control, ByVal caption As String, ByVal message As String, ByVal icon As ToolTipIcon, Optional tiempo As Integer = 2500)
        Dim tt As New ToolTip()
        tt.IsBalloon = True
        tt.ToolTipTitle = caption
        tt.ToolTipIcon = icon
        tt.Active = False
        tt.Show("", c)
        tt.Active = True
        tt.Show(message, c, tiempo)
    End Sub

    'Validacion para que solo se puedan ingresar valores DECIMALES (Por ejemplo, en un textBox)
    'Para ver un ejemplo, hacer clic derecho sobre esta funcion y "Find All References"
    Public Shared Function SingleDecimal(sender As System.Object, ByRef e As KeyPressEventArgs) As KeyPressEventArgs
        Dim chkstr As String = "0123456789,-."
        If chkstr.IndexOf(e.KeyChar) > -1 OrElse e.KeyChar = Constants.vbBack Then
            e.Handled = False
            'Si viene punto, lo cambio por coma
            If e.KeyChar = "."c Then
                e.KeyChar = ","
            End If

            If e.KeyChar = "," Then
                If DirectCast(sender, TextBox).Text.IndexOf(e.KeyChar) > -1 Then
                    e.Handled = True
                Else
                    e.Handled = False
                End If
            End If
        Else
            e.Handled = True
        End If
        Return e
    End Function

    'Validacion para que solo se puedan ingresar solo Numeros
    Public Shared Function OnlyNumbers(sender As System.Object, eChar As Char) As Boolean
        Dim chkstr As String = "0123456789"
        If chkstr.IndexOf(eChar) > -1 OrElse eChar = Constants.vbBack Then
            Return False
        Else
            Return True
        End If
    End Function


    'Validacion para que solo se puedan ingresar solo Numeros y  comas
    Public Shared Function OnlyNumbersAndComas(sender As System.Object, eChar As Char) As Boolean
        Dim chkstr As String = "0123456789"
        Dim coma As String = ","
        If chkstr.IndexOf(eChar) > -1 OrElse coma.IndexOf(eChar) > -1 OrElse eChar = Constants.vbBack Then
            Return False
        Else
            Return True
        End If
    End Function


    'Validacion para que solo se puedan ingresar solo Numeros y puntos
    Public Shared Function OnlyNumbersAndPuntos(sender As System.Object, eChar As Char) As Boolean
        Dim chkstr As String = "0123456789"
        Dim punto As String = "."
        If chkstr.IndexOf(eChar) > -1 OrElse punto.IndexOf(eChar) > -1 OrElse eChar = Constants.vbBack Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Function MD5Encrypt(ByVal StrPass As String) As String
        Dim PasConMd5 As String = ""
        Dim md5 As New MD5CryptoServiceProvider
        Dim bytValue() As Byte
        Dim bytHash() As Byte
        Dim i As Integer

        bytValue = System.Text.Encoding.UTF8.GetBytes(StrPass)

        bytHash = md5.ComputeHash(bytValue)
        md5.Clear()

        For i = 0 To bytHash.Length - 1
            PasConMd5 &= bytHash(i).ToString("x").PadLeft(2, "0")
        Next

        Return PasConMd5

    End Function
End Class

