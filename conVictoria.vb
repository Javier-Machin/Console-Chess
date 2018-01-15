Module conVictoria

    'Esta función busca el rey enemigo después de cada movimiento, y en caso de que falte, sube la bandera que señala la victoria
    'del equipo que corresponda.

    Sub condicionVictoria(ByVal Tablero(,) As FichaAjedrez, ByVal Turno As String, ByRef victoria As Boolean)

        Dim I As Integer = 0
        Dim J As Integer = 0

        victoria = True

        For I = 0 To 7
            For J = 0 To 7
                If Turno = "blancas" Then
                    If Tablero(I, J).nombre = "-king-" Then
                        victoria = False
                    End If
                ElseIf Turno = "negras" Then
                    If Tablero(I, J).nombre = "bking-" Then
                        victoria = False
                    End If
                End If
            Next
        Next
    End Sub
End Module
