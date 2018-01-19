Public Class destroySelect

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

                            t1.colbox.destroy()

                        End If
                    Next

                    For Each t2 As turret2 In Game1.gameLoop.gameScene.turret2s
                        If New Rectangle(t2.realPos.X, t2.realPos.Y, t2.size.X, t2.size.Y).Contains(New Rectangle(ms.X - Globals.cameraLoc.X, ms.Y - Globals.cameraLoc.Y, 1, 1)) Then

                            t2.colbox.destroy()

                        End If
                    Next

                    For Each t3 As turret3 In Game1.gameLoop.gameScene.turret3s
                        If New Rectangle(t3.realPos.X, t3.realPos.Y, t3.size.X, t3.size.Y).Contains(New Rectangle(ms.X - Globals.cameraLoc.X, ms.Y - Globals.cameraLoc.Y, 1, 1)) Then

                            t3.colbox.destroy()

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

                Globals.cursorMode = "destroy"

            End If
        Else

            If Globals.cursorMode = "destroy" Then
                Globals.cursorMode = "none"
            End If

        End If

        'sb.Draw(Game1.contentMnger.loadTexture("white"), box, Nothing, Color.Black, Nothing, Nothing, Nothing, 0.99)


    End Sub

End Class
