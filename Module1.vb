Module Module1

    'Crear un tablero de ajedrez, en el cual se muestre el tablero, sus fichas y las coordenadas en los bordes.
    'Las fichas se pueden mover, el programa comprueba que ficha hemos selecccionado, pregunta dónde la queremos mover
    'y nos informa en el caso de que la casilla estuviese ya ocupada, que ficha contenia y procede a eliminarla y colocar
    'la que hemos seleccionado en su lugar.
    'Si escribimos "exit" cuando se nos pregunta por ficha o movimiento, salimos de la aplicacion.



    Sub Main()

        'Declaramos variables y matrices.

        Dim Tablero(7, 7) As FichaAjedrez
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim Aux1 As Boolean = False
        Dim objetivo As String = 0
        Dim numTurnos As Integer = 1
        Dim turno As String = 0
        Dim victoria As Boolean = False
        Dim Aux2 As Boolean = False

        'Creamos objetos en cada posicion del array, correspondiendose estos con las piezas y los cuadros vacios

        Tablero(0, 0) = New FichaAjedrez("torreB", "negras", "torre")
        Tablero(0, 1) = New FichaAjedrez("horseN", "negras", "caballo")
        Tablero(0, 2) = New FichaAjedrez("alfilB", "negras", "alfil")
        Tablero(0, 3) = New FichaAjedrez("-reina", "negras", "reina")
        Tablero(0, 4) = New FichaAjedrez("-king-", "negras", "rey")
        Tablero(0, 5) = New FichaAjedrez("alfilN", "negras", "alfil")
        Tablero(0, 6) = New FichaAjedrez("horseB", "negras", "caballo")
        Tablero(0, 7) = New FichaAjedrez("torreN", "negras", "torre")
        Tablero(1, 0) = New FichaAjedrez("peon-1", "negras", "peon")
        Tablero(1, 1) = New FichaAjedrez("peon-2", "negras", "peon")
        Tablero(1, 2) = New FichaAjedrez("peon-3", "negras", "peon")
        Tablero(1, 3) = New FichaAjedrez("peon-4", "negras", "peon")
        Tablero(1, 4) = New FichaAjedrez("peon-5", "negras", "peon")
        Tablero(1, 5) = New FichaAjedrez("peon-6", "negras", "peon")
        Tablero(1, 6) = New FichaAjedrez("peon-7", "negras", "peon")
        Tablero(1, 7) = New FichaAjedrez("peon-8", "negras", "peon")
        Tablero(7, 0) = New FichaAjedrez("btowrN", "blancas", "torre")
        Tablero(7, 1) = New FichaAjedrez("bhrseB", "blancas", "caballo")
        Tablero(7, 2) = New FichaAjedrez("balflN", "blancas", "alfil")
        Tablero(7, 3) = New FichaAjedrez("breina", "blancas", "reina")
        Tablero(7, 4) = New FichaAjedrez("bking-", "blancas", "rey")
        Tablero(7, 5) = New FichaAjedrez("balflB", "blancas", "alfil")
        Tablero(7, 6) = New FichaAjedrez("bhrseN", "blancas", "caballo")
        Tablero(7, 7) = New FichaAjedrez("btowrB", "blancas", "torre")
        Tablero(6, 0) = New FichaAjedrez("bpeon1", "blancas", "peonB")
        Tablero(6, 1) = New FichaAjedrez("bpeon2", "blancas", "peonB")
        Tablero(6, 2) = New FichaAjedrez("bpeon3", "blancas", "peonB")
        Tablero(6, 3) = New FichaAjedrez("bpeon4", "blancas", "peonB")
        Tablero(6, 4) = New FichaAjedrez("bpeon5", "blancas", "peonB")
        Tablero(6, 5) = New FichaAjedrez("bpeon6", "blancas", "peonB")
        Tablero(6, 6) = New FichaAjedrez("bpeon7", "blancas", "peonB")
        Tablero(6, 7) = New FichaAjedrez("bpeon8", "blancas", "peonB")

        'En las posiciones de la matriz que se corresponden con cuadros vacios del tablero creamos objetos 
        'con propiedades específicas que los identifican como cuadros vacios
        For i = 2 To 5
            For j = 0 To 7
                Tablero(i, j) = New FichaAjedrez(" (__) ", "vacio", "vacio")
            Next
        Next

        'Activa la musica de fondo.

        'musicafondo()

        'Muestra la pantalla de titulo.

        impresion_titulo()

        'Muestra el tablero por pantalla con las coordenadas.

        imprime_tablero(Tablero)

        While Aux1 = False

            'Señala a que equipo le toca jugar

            If objetivo <> "cancel" Then
                controlTurnos(numTurnos, turno)
            End If

            'Llama al procedimiento para mover fichas.

            mover_fichas(Tablero, Aux1, i, j, objetivo, turno, Aux2)

            'Comprueba si el rey del equipo rival ha sido destruido

            condicionVictoria(Tablero, turno, victoria)

            If victoria = True Then
                Aux1 = True
                Console.WriteLine("Fin de partida! las " & turno & " ganan!")
                Console.Read()
            End If

            'Esto muestra el tablero actualizado.

            If Aux2 = False Then

                imprime_tablero(Tablero)

            End If

        End While

    End Sub
End Module
