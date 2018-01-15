Module Mov_fichas

    'Esta funcion contiene los procedimientos y las llamadas a las funciones relacionadas con el movimiento de fichas, desde la seleccion hasta la modificacion del tablero

    Sub mover_fichas(ByRef Tablero(,) As FichaAjedrez, ByRef Aux1 As Boolean, ByRef i As Integer, ByRef j As Integer, ByRef objetivo As String, ByVal Turno As String, ByRef Aux2 As Boolean)

        Dim m As Integer = 0
        Dim posicionficha As String = 0
        Dim Aux3 As Boolean = False
        Dim Aux4 As Boolean = False
        Dim k As Integer = 0
        Dim h As Integer = 0
        Dim Ficha As String = 0
        Dim FichaSeleccionada As FichaAjedrez = New FichaAjedrez(" (__) ", "vacio", "vacio")
        Dim X As String = 0
        Dim Y As Integer = 0


        While Aux2 = False

            'Aquií se llama al procedimiento que nos pregunta que ficha queremos mover, se asegura de que esta se encuentre en el tablero 
            'y de que la ficha que seleccionamos corresponde a nuestro equipo.

            seleccion_ficha(Aux1, Ficha, Aux2, Aux4, k, h, Tablero, Turno, FichaSeleccionada)

        End While

        If Ficha = "exit" Then
            Aux2 = False
            Aux1 = True
        End If

        While Aux2 = True

            'En caso de que la selección sea válida, pregunta que movimiento queremos hacer, comprueba si es un movimiento válido 

            movimiento_validez(h, k, Ficha, Aux1, Aux2, Aux3, objetivo, Aux4, X, Y, Turno, Tablero, FichaSeleccionada)

            'Aqui se comprueba si la posicion estaba ocupada por otra ficha y si hay otras fichas en la trayectoria

            If Aux2 = False Then
                estado_objetivo(Tablero, X, Y, h, k, Aux2, Ficha, FichaSeleccionada)
            End If

            'Aqui se actualizan las posiciones.

            If Aux2 = False Then

                Tablero(Y, X).PosicionarFicha(FichaSeleccionada)

                Tablero(k, h).VaciarCuadro()

            End If

            If Aux2 = True And objetivo <> "exit" And objetivo <> "cancel" Then
                Console.WriteLine("Movimiento no válido.")
            End If

            If Ficha = "exit" Or objetivo = "exit" Then
                Aux1 = True
                Aux2 = False
            End If

            'Aqui se cancela la seleccion permitiendo cambiar de ficha
            If objetivo = "cancel" Then
                Aux2 = False
                Console.WriteLine("Seleccion cancelada.")
            End If

        End While
    End Sub
End Module
