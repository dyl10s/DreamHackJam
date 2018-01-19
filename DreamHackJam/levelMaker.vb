Public Class levelMaker

    Public timeTill As Integer = 5
    Public timer As New Stopwatch

    Public waveNum As Integer = 1

    Public wave As waveMaker

    Public Sub update()

        If wave Is Nothing Then
            wave = New waveMaker(200, 0, 100, 0, 0, 5, 0, 0)
            Dim msg As message = New message("There are strange mutants coming from the south!", 5000)
        End If

        If wave.update = True Then
            If timer.IsRunning = True Then
                If timer.ElapsedMilliseconds > timeTill * 1000 Then
                    timer.Stop()

                    For Each p As player In Game1.gameLoop.gameScene.players
                        p.hp = 200
                    Next

                    waveNum += 1

                    Select Case waveNum

                        Case 2
                            wave = New waveMaker(100, 0, 100, 0, 0, 7, 0, 0)
                            Dim msg As message = New message("More mutants, coming from the south!", 2000)
                        Case 3
                            wave = New waveMaker(100, 0, 0, 100, 0, 0, 3, 0)
                            Dim msg As message = New message("More mutants, this time coming from the east!", 2000)
                        Case 4
                            wave = New waveMaker(100, 100, 0, 0, 0, 0, 0, 3)
                            Dim msg As message = New message("More mutants, this time coming from the north!", 2000)
                        Case 5
                            wave = New waveMaker(100, 0, 0, 0, 100, 5, 2, 1)
                            Dim msg As message = New message("More mutants, this time coming from the west!", 2000)
                        Case 6
                            wave = New waveMaker(100, 25, 25, 25, 25, 5, 2, 1)
                            Dim msg As message = New message("There are coming from everywhere!", 2000)
                        Case 7
                            wave = New waveMaker(100, 25, 25, 25, 25, 10, 0, 0)
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)
                        Case 8
                            wave = New waveMaker(75, 25, 25, 25, 25, 0, 5, 0)
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)
                        Case 9
                            wave = New waveMaker(75, 25, 25, 25, 25, 0, 0, 5)
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)
                        Case 10
                            wave = New waveMaker(75, 25, 25, 25, 25, 5, 5, 5)
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)
                        Case 11
                            wave = New waveMaker(50, 25, 25, 25, 25, 7, 8, 4)
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)
                        Case 12
                            wave = New waveMaker(50, 25, 25, 25, 25, 10, 2, 2)
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)
                        Case 13
                            wave = New waveMaker(50, 25, 25, 25, 25, 5, 3, 6)
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)
                        Case 14
                            wave = New waveMaker(50, 25, 25, 25, 25, 7, 2, 6)
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)
                        Case 15
                            wave = New waveMaker(50, 25, 25, 25, 25, 20, 0, 0)
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)
                        Case 16
                            wave = New waveMaker(50, 25, 25, 25, 25, 5, 5, 10)
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)
                        Case 17
                            wave = New waveMaker(25, 25, 25, 25, 25, 0, 0, 20)
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)
                        Case 18
                            wave = New waveMaker(25, 25, 25, 25, 25, 0, 10, 0)
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)
                        Case 19
                            wave = New waveMaker(25, 25, 25, 25, 25, 10, 5, 10)
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)
                        Case 20
                            wave = New waveMaker(10, 25, 25, 25, 25, 15, 0, 10)
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)
                        Case Else

                            Randomize()
                            wave = New waveMaker(100, 25, 25, 25, 25, Math.Floor(Rnd() * (waveNum * waveNum)), Math.Floor(0.5 * Math.Floor(Rnd() * (waveNum * waveNum))), 1 * Math.Floor(Rnd() * (waveNum * waveNum)))
                            Dim msg As message = New message("Another wave of mutants has been spoted!", 2000)

                    End Select


                End If
            Else
                Dim msg As message = New message("You killed them all, nice job!", 2000)
                timer.Restart()
            End If
        End If


    End Sub

    Public Sub draw(sb As SpriteBatch)

    End Sub

End Class
