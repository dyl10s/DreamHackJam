Public Class upgradeSelect

    Public pos As Vector2
    Public box As Rectangle

    Public selected As Boolean = False

    Public Sub New(location As Vector2, selectionSize As Rectangle)

        pos = location
        box = selectionSize

    End Sub

    Public Sub update()

        Dim ms As MouseState = Microsoft.Xna.Framework.Input.Mouse.GetState

        If ms.LeftButton = ButtonState.Pressed Then

            If box.Contains(New Point(ms.X, ms.Y)) Then

                selected = True

            ElseIf ms.Y > (720 - 70) Then

                selected = False

            End If

        End If


        If selected = True Then
            If ms.LeftButton = ButtonState.Pressed Then
                If ms.Y < (720 - 70) Then
                    selected = False
                    For Each t1 As turret1 In Game1.gameLoop.gameScene.turret1s
                        If New Rectangle(t1.realPos.X, t1.realPos.Y, t1.size.X, t1.size.Y).Contains(New Rectangle(ms.X - Globals.cameraLoc.X, ms.Y - Globals.cameraLoc.Y, 1, 1)) Then

                            If t1.upgradePrice <> -1 Then
                                If Globals.totalMoney >= t1.upgradePrice Then

                                    selected = False

                                    For Each p As player In Game1.gameLoop.gameScene.players
                                        p.money -= t1.upgradePrice
                                    Next

                                    t1.levelUp()
                                Else

                                    Dim msg As New message("You do not have enough money!", 2000)

                                End If
                            Else

                                Dim msg As New message("This turret is max level!", 2000)

                            End If


                        End If
                    Next

                    For Each t2 As turret2 In Game1.gameLoop.gameScene.turret2s
                        If New Rectangle(t2.realPos.X, t2.realPos.Y, t2.size.X, t2.size.Y).Contains(New Rectangle(ms.X - Globals.cameraLoc.X, ms.Y - Globals.cameraLoc.Y, 1, 1)) Then

                            If t2.upgradePrice <> -1 Then
                                If Globals.totalMoney >= t2.upgradePrice Then

                                    selected = False

                                    For Each p As player In Game1.gameLoop.gameScene.players
                                        p.money -= t2.upgradePrice
                                    Next

                                    t2.levelUp()
                                Else

                                    Dim msg As New message("You do not have enough money!", 2000)

                                End If
                            Else

                                Dim msg As New message("This turret is max level!", 2000)

                            End If


                        End If
                    Next

                    For Each t3 As turret3 In Game1.gameLoop.gameScene.turret3s
                        If New Rectangle(t3.realPos.X, t3.realPos.Y, t3.size.X, t3.size.Y).Contains(New Rectangle(ms.X - Globals.cameraLoc.X, ms.Y - Globals.cameraLoc.Y, 1, 1)) Then

                            If t3.upgradePrice <> -1 Then
                                If Globals.totalMoney >= t3.upgradePrice Then

                                    selected = False

                                    For Each p As player In Game1.gameLoop.gameScene.players
                                        p.money -= t3.upgradePrice
                                    Next

                                    t3.levelUp()
                                Else

                                    Dim msg As New message("You do not have enough money!", 2000)

                                End If

                            Else

                                Dim msg As New message("This turret is max level!", 2000)

                            End If

                        End If
                    Next

                End If
            End If
        End If

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim ms As MouseState = Microsoft.Xna.Framework.Input.Mouse.GetState

        If selected = True Then
            If ms.Y < (720 - 70) Then

                Globals.cursorMode = "upgrade"

            End If
        Else

            If Globals.cursorMode = "upgrade" Then
                Globals.cursorMode = "none"
            End If

        End If

        'sb.Draw(Game1.contentMnger.loadTexture("white"), box, Nothing, Color.Black, Nothing, Nothing, Nothing, 0.99)

        If selected = True Then
            For Each t1 As turret1 In Game1.gameLoop.gameScene.turret1s
                If New Rectangle(t1.realPos.X, t1.realPos.Y, t1.size.X, t1.size.Y).Contains(New Rectangle(ms.X - Globals.cameraLoc.X, ms.Y - Globals.cameraLoc.Y, 1, 1)) Then

                    If t1.upgradePrice <> -1 Then
                        sb.DrawString(Game1.contentMnger.loadFont("mainfont"), "$ " + (t1.upgradePrice).ToString, New Vector2(ms.X + 40, ms.Y), Color.Green, Nothing, Nothing, 1, Nothing, 0.8)
                    Else
                        sb.DrawString(Game1.contentMnger.loadFont("mainfont"), "MAX", New Vector2(ms.X + 40, ms.Y), Color.Green, Nothing, Nothing, 1, Nothing, 0.8)

                    End If

                End If
            Next

            For Each t2 As turret2 In Game1.gameLoop.gameScene.turret2s
                If New Rectangle(t2.realPos.X, t2.realPos.Y, t2.size.X, t2.size.Y).Contains(New Rectangle(ms.X - Globals.cameraLoc.X, ms.Y - Globals.cameraLoc.Y, 1, 1)) Then

                    If t2.upgradePrice <> -1 Then
                        sb.DrawString(Game1.contentMnger.loadFont("mainfont"), "$ " + (t2.upgradePrice).ToString, New Vector2(ms.X + 40, ms.Y), Color.Green, Nothing, Nothing, 1, Nothing, 0.8)
                    Else
                        sb.DrawString(Game1.contentMnger.loadFont("mainfont"), "MAX", New Vector2(ms.X + 40, ms.Y), Color.Green, Nothing, Nothing, 1, Nothing, 0.8)

                    End If

                End If
            Next

            For Each t3 As turret3 In Game1.gameLoop.gameScene.turret3s
                If New Rectangle(t3.realPos.X, t3.realPos.Y, t3.size.X, t3.size.Y).Contains(New Rectangle(ms.X - Globals.cameraLoc.X, ms.Y - Globals.cameraLoc.Y, 1, 1)) Then

                    If t3.upgradePrice <> -1 Then
                        sb.DrawString(Game1.contentMnger.loadFont("mainfont"), "$ " + (t3.upgradePrice).ToString, New Vector2(ms.X + 40, ms.Y), Color.Green, Nothing, Nothing, 1, Nothing, 0.8)
                    Else
                        sb.DrawString(Game1.contentMnger.loadFont("mainfont"), "MAX", New Vector2(ms.X + 40, ms.Y), Color.Green, Nothing, Nothing, 1, Nothing, 0.8)

                    End If

                End If
            Next
        End If

    End Sub

End Class
