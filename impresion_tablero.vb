Module impresion_tablero

    'Esta funcion dibuja y muestra el tablero

    Sub imprime_tablero(ByVal Tablero(,) As FichaAjedrez)

        Dim i As Integer = 0
        Dim j As Integer = 0

        Console.WriteLine()
        Console.WriteLine("            (A)    (B)    (C)    (D)    (E)    (F)    (G)    (H) ")
        Console.WriteLine("         ----------------------------------------------------------")
        For i = 0 To 7
            Console.Write("         " & 8 - i)
            For j = 0 To 7
                If j <> 7 Then
                    Console.Write("|" & Tablero(i, j).nombre & "")
                Else
                    Console.WriteLine("|" & Tablero(i, j).nombre & "|")
                End If
            Next
            Console.WriteLine("         ----------------------------------------------------------")
        Next
    End Sub
End Module
