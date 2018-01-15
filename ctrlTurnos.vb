Module ctrlTurnos

    'Esta función controla y muestra que equipo juega en cada momento

    Sub controlTurnos(ByRef numTurnos, ByRef turno)
        numTurnos += 1
        If numTurnos Mod 2 = 0 Then
            turno = "blancas"
        Else
            turno = "negras"
        End If
        Console.WriteLine("Juegan las " & turno)
    End Sub
End Module
