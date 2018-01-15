Module seleccion

    'Este procedimiento nos pregunta que ficha queremos mover, se asegura de que esta se encuentre en el tablero 
    'y de que la ficha que seleccionamos corresponde a nuestro equipo

    Sub seleccion_ficha(ByRef Aux1 As Boolean, ByRef Ficha As String, ByRef Aux2 As Boolean, ByRef Aux4 As Boolean, ByRef k As String, ByRef h As String, _
                        ByRef Tablero(,) As FichaAjedrez, ByVal Turno As String, ByRef FichaSeleccionada As FichaAjedrez)

        Dim i As Integer = 0
        Dim j As Integer = 0


        Console.WriteLine()
        Console.WriteLine("¿Qué ficha desea mover?")
        Ficha = Console.ReadLine()

        If Ficha = "exit" Then

            Aux2 = True

        ElseIf Aux2 = False Then
            For i = 0 To 7 'Esto sería Y
                For j = 0 To 7 'Esto sería X
                    If Tablero(i, j).nombre = Ficha Then
                        Aux2 = True
                        Console.WriteLine("Ha seleccionado la ficha " & Ficha)
                        k = i
                        h = j
                        FichaSeleccionada.nombre = Tablero(k, h).nombre
                        FichaSeleccionada.equipo = Tablero(k, h).equipo
                        FichaSeleccionada.tipo = Tablero(k, h).tipo
                    End If
                Next
            Next
        End If

        If Aux2 = False Then
            Console.WriteLine("Esa ficha no se encuentra en el tablero")
        End If

        If Ficha <> "exit" And Ficha.Length > 0 And Aux2 = True Then
            If FichaSeleccionada.equipo.Substring(0, 1) = "b" And Turno.Substring(0, 1) = "n" Then
                Aux2 = False
                Console.WriteLine()
                Console.WriteLine("Esa ficha es del equipo rival! Selecciona una de tu equipo.")
            ElseIf FichaSeleccionada.equipo.Substring(0, 1) <> "b" And Turno.Substring(0, 1) = "b" Then
                Aux2 = False
                Console.WriteLine()
                Console.WriteLine("Esa ficha es del equipo rival! Selecciona una de tu equipo.")
            End If
        End If

    End Sub
End Module
