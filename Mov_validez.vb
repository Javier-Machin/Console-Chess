Module Mov_validez

    'Aqui se comprueba si el movimiento que se desea realizar es válido para el tipo de ficha seleccionada


    Sub movimiento_validez(ByVal H As Integer, ByVal K As Integer, ByRef Ficha As String, ByRef Aux1 As Boolean, ByRef Aux2 As Boolean, ByRef Aux3 As Boolean, _
                           ByRef objetivo As String, ByRef Aux4 As Boolean, ByRef X As String, ByRef Y As String, ByVal Turno As String, ByVal Tablero(,) As FichaAjedrez, _
                           ByVal FichaSeleccionada As FichaAjedrez)

        'Estos contadores se usan para comprobar las distancias entre la posicion inicial de la ficha y la posicion de destino, usando uno diferente para cada eje.
        Dim contador1 As Integer = 0
        Dim contador2 As Integer = 0


        Console.Write("A que posición desea mover la ficha: ")
        objetivo = Console.ReadLine()


        Aux2 = False
        Aux3 = True

        If objetivo <> "exit" And objetivo.Length = 2 Then

            X = objetivo.Substring(0, 1)

            Aux1 = IsNumeric(objetivo.Substring(1, 1))

            If Aux1 = True Then
                Y = 8 - objetivo.Substring(1, 1)
                Aux1 = False
                Aux3 = False
            End If

            If Y < 0 Or Y >= 8 Then
                Console.WriteLine("Movimiento no válido. El número debe estar entre 1 y 8")
                Aux3 = True
            End If

            'Se convierte la letra introducida en el valor numerico correspondiente a la columna seleccionada
            Select Case (X)
                Case "a"
                    X = 0
                Case "b"
                    X = 1
                Case "c"
                    X = 2
                Case "d"
                    X = 3
                Case "e"
                    X = 4
                Case "f"
                    X = 5
                Case "g"
                    X = 6
                Case "h"
                    X = 7
                Case Else
                    Console.WriteLine("Movimiento no válido. Ejemplo: h3")
                    Aux2 = True
            End Select

            If Aux3 = True Then
                Aux2 = True
            End If

            'Aqui se comprueba que el cuadro al que deseamos mover la ficha no se encuentra ocupado por otra de nuestro mismo equipo
            If Aux2 = False Then
                If Tablero(Y, X).equipo.Substring(0, 1) = "n" And Turno.Substring(0, 1) = "n" Then
                    Aux2 = True
                    Console.WriteLine("No puedes atacar a tu propio equipo!")
                ElseIf Tablero(Y, X).equipo.Substring(0, 1) = "b" And Turno.Substring(0, 1) = "b" Then
                    Aux2 = True
                    Console.WriteLine("No puedes atacar a tu propio equipo!")
                End If
            End If

            'Aqui se permiten o deniegan los movimientos, haciendo las comprobaciones apropiadas dependiendo del valor "FichaSeleccionada.Tipo"
            If Aux2 = False Then
                Select Case FichaSeleccionada.tipo
                    Case "torre"
                        If X <> H And Y <> K Then
                            Aux2 = True
                        End If
                    Case "alfil"
                        If X = H Or Y = K Then
                            Aux2 = True
                        End If
                        contador1 = X - H
                        contador2 = Y - K
                        If contador1 < 0 Then
                            contador1 *= -1
                        End If
                        If contador2 < 0 Then
                            contador2 *= -1
                        End If
                        If contador1 <> contador2 Then
                            Aux2 = True
                        End If
                    Case "caballo"
                        Aux2 = True
                        contador1 = X - H
                        contador2 = Y - K
                        If contador1 < 0 Then
                            contador1 *= -1
                        End If
                        If contador2 < 0 Then
                            contador2 *= -1
                        End If
                        If contador1 = 1 And contador2 = 2 Then
                            Aux2 = False
                        ElseIf contador1 = 2 And contador2 = 1 Then
                            Aux2 = False
                        End If
                    Case "reina"
                        contador1 = X - H
                        contador2 = Y - K
                        If contador1 < 0 Then
                            contador1 *= -1
                        End If
                        If contador2 < 0 Then
                            contador2 *= -1
                        End If
                        If X <> H And Y <> K And contador1 <> contador2 Then
                            Aux2 = True
                        End If
                    Case "rey"
                        contador1 = X - H
                        contador2 = Y - K
                        If contador1 < 0 Then
                            contador1 *= -1
                        End If
                        If contador2 < 0 Then
                            contador2 *= -1
                        End If
                        If contador1 > 1 Or contador2 > 1 Then
                            Aux2 = True
                        End If
                    Case "peon"
                        Aux2 = True
                        contador1 = X - H
                        If contador1 < 0 Then
                            contador1 *= -1
                        End If
                        contador2 = Y - K
                        If K = 1 And contador1 = 0 Then
                            If contador2 = 1 Or contador2 = 2 Then
                                Aux2 = False
                            End If
                        ElseIf K <> 1 And contador1 = 0 Then
                            If contador2 = 1 Then
                                Aux2 = False
                            End If
                        ElseIf contador1 = 1 And contador2 = 1 Then
                            Aux2 = False
                        End If
                    Case "peonB"
                        Aux2 = True
                        contador1 = X - H
                        If contador1 < 0 Then
                            contador1 *= -1
                        End If
                        contador2 = Y - K
                        If K = 6 And contador1 = 0 Then
                            If contador2 = -1 Or contador2 = -2 Then
                                Aux2 = False
                            End If
                        ElseIf K <> 6 And contador1 = 0 Then
                            If contador2 = -1 Then
                                Aux2 = False
                            End If
                        ElseIf contador1 = 1 And contador2 = -1 Then
                            Aux2 = False
                        End If
                End Select
            End If
        ElseIf objetivo = "cancel" Then
            Aux2 = True
        Else
            Aux2 = True
            Aux1 = True
        End If
    End Sub
End Module
