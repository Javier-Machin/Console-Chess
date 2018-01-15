Module Estado_obj

    'Esta funcion comprueba la trayectoria que va a realizar la ficha seleccionada y dependiendo de su color y tipo, permite o deniega el movimiento.

    Sub estado_objetivo(ByVal Tablero(,) As FichaAjedrez, ByRef X As Integer, ByRef Y As Integer, ByRef H As Integer, ByRef K As Integer, ByRef Aux2 As Boolean, ByVal Ficha As String, _
                        ByVal FichaSeleccionada As FichaAjedrez)

        Dim I As Integer = 0
        Dim J As Integer = 0

        Dim contador1 As Integer = X - H
        Dim contador2 As Integer = Y - K
        Dim contador3 As Integer = contador1
        Dim contador4 As Integer = contador2


        Aux2 = False

        'Estas son las comprobaciones necesarias para permitir o denegar el movimiento de los peones, siendo diferentes entre peones blancos y negros.

        If FichaSeleccionada.tipo = "peon" And contador1 <> 0 And contador2 <> 0 And Tablero(Y, X).nombre = " (__) " Then
            Aux2 = True
        ElseIf FichaSeleccionada.tipo = "peonB" And contador1 <> 0 And contador2 <> 0 And Tablero(Y, X).nombre = " (__) " Then
            Aux2 = True
        End If
        If FichaSeleccionada.tipo = "peon" And contador1 = 0 And Tablero(Y, X).nombre <> " (__) " And contador2 = 2 Or _
        FichaSeleccionada.tipo = "peon" And contador1 = 0 And Tablero(Y, X).nombre <> " (__) " And contador2 = 1 Then
            Aux2 = True
        ElseIf FichaSeleccionada.tipo = "peonB" And contador1 = 0 And Tablero(Y, X).nombre <> " (__) " And contador2 = -2 Or _
        FichaSeleccionada.tipo = "peonB" And contador1 = 0 And Tablero(Y, X).nombre <> " (__) " And contador2 = -1 Then
            Aux2 = True
        End If

        'Estas son las comprobaciones necesarias para permitir o denegar el movimiento de las fichas que no sean ni caballos ni peones.

        If FichaSeleccionada.tipo <> "caballo" And FichaSeleccionada.tipo <> "peon" And FichaSeleccionada.tipo <> "peonB" Then
            If contador1 < 0 Then
                For I = X To H
                    If contador2 < 0 Then
                        For J = Y To K
                            If Tablero(J, I).nombre <> " (__) " Then
                                If Tablero(J, I).nombre <> Tablero(Y, X).nombre And Tablero(J, I).nombre <> FichaSeleccionada.nombre Then
                                    Aux2 = True
                                End If
                            End If
                        Next
                    ElseIf contador2 >= 0 Then
                        For J = Y To K Step -1
                            If Tablero(J, I).nombre <> " (__) " Then
                                If Tablero(J, I).nombre <> Tablero(Y, X).nombre And Tablero(J, I).nombre <> FichaSeleccionada.nombre Then
                                    Aux2 = True
                                End If
                            End If
                        Next
                    End If
                Next
            ElseIf contador1 >= 0 Then
                For I = X To H Step -1
                    If contador2 < 0 Then
                        For J = Y To K
                            If Tablero(J, I).nombre <> " (__) " Then
                                If Tablero(J, I).nombre <> Tablero(Y, X).nombre And Tablero(J, I).nombre <> FichaSeleccionada.nombre Then
                                    Aux2 = True
                                End If
                            End If
                        Next
                    ElseIf contador2 >= 0 Then
                        For J = Y To K Step -1
                            If Tablero(J, I).nombre <> " (__) " Then
                                If Tablero(J, I).nombre <> Tablero(Y, X).nombre And Tablero(J, I).nombre <> FichaSeleccionada.nombre Then
                                    Aux2 = True
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        End If

        If contador1 < 0 Then
            contador3 = contador1 * -1
        End If
        If contador2 < 0 Then
            contador4 = contador2 * -1
        End If

        'Estas son las comprobaciones necesarias para permitir o denegar movimientos a las piezas que se mueven diagonalmente que no sean peones.

        If contador3 = contador4 And FichaSeleccionada.tipo <> "peon" And FichaSeleccionada.tipo <> "peonB" Then
            J = Y
            Aux2 = False
            If contador1 < 0 Then
                For I = X To H
                    If contador2 < 0 Then
                        If Tablero(J, I).nombre <> " (__) " Then
                            If Tablero(J, I).nombre <> Tablero(Y, X).nombre And Tablero(J, I).nombre <> Tablero(K, H).nombre Then
                                Aux2 = True
                            End If
                        End If
                        J += 1
                    ElseIf contador2 >= 0 Then
                        If Tablero(J, I).nombre <> " (__) " Then
                            If Tablero(J, I).nombre <> Tablero(Y, X).nombre And Tablero(J, I).nombre <> Tablero(K, H).nombre Then
                                Aux2 = True
                            End If
                        End If
                        J -= 1
                    End If
                Next
            ElseIf contador1 >= 0 Then
                For I = X To H Step -1
                    If contador2 < 0 Then
                        If Tablero(J, I).nombre <> " (__) " Then
                            If Tablero(J, I).nombre <> Tablero(Y, X).nombre And Tablero(J, I).nombre <> Tablero(K, H).nombre Then
                                Aux2 = True
                            End If
                        End If
                        J += 1
                    ElseIf contador2 >= 0 Then
                        If Tablero(J, I).nombre <> " (__) " Then
                            If Tablero(J, I).nombre <> Tablero(Y, X).nombre And Tablero(J, I).nombre <> Tablero(K, H).nombre Then
                                Aux2 = True
                            End If
                        End If
                        J -= 1
                    End If
                Next
            End If
        End If

        'Informa de que ficha se encontraba en el cuadro objetivo y que ficha ocupa ahora su lugar
        If Tablero(Y, X).nombre <> " (__) " And Aux2 = False Then
            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine("La posicion objetivo se encontraba ocupada por la ficha " & Tablero(Y, X).nombre & ", y ha sido destruido/a")
        End If
    End Sub
End Module
