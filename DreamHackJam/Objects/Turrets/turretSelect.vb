Public Class turretSelect

    Public pos As Vector2
    Public size As Vector2

    Public textureString As String

    Public tNumber As Integer = 1

    Public selected As Boolean = False

    Public Sub New(location As Vector2, iconSize As Vector2, textureName As String, turretType As Integer)

        pos = location
        size = iconSize
        textureString = textureName
        tNumber = turretType

    End Sub

    Public Sub update()

        Dim ms As MouseState = Microsoft.Xna.Framework.Input.Mouse.GetState

        If ms.LeftButton = ButtonState.Pressed Then

            If New Rectangle(pos.X, pos.Y, size.X, size.Y).Contains(New Point(ms.X, ms.Y)) Then

                selected = True

            ElseIf New Rectangle(0, 650, 1280, 70).Contains(New Point(ms.X, ms.Y)) Then

                selected = False

            End If

            If New Rectangle(0, 0, 1280, 650).Contains(New Point(ms.X, ms.Y)) AndAlso selected = True Then

                Select Case tNumber
                    Case 1
                        If Globals.totalMoney >= Globals.t1Price Then
                            Game1.gameLoop.gameScene.turret1s.Add(New turret1(New Vector2(ms.X - Globals.cameraLoc.X, ms.Y - Globals.cameraLoc.Y)))
                            For Each p As player In Game1.gameLoop.gameScene.players
                                p.money -= Globals.t1Price
                            Next
                        Else
                            Dim m As New message("You do not have enough money!", 2000)
                        End If
                    Case 2
                        If Globals.totalMoney >= Globals.t2Price Then
                            Game1.gameLoop.gameScene.turret2s.Add(New turret2(New Vector2(ms.X - Globals.cameraLoc.X, ms.Y - Globals.cameraLoc.Y)))
                            For Each p As player In Game1.gameLoop.gameScene.players
                                p.money -= Globals.t2Price
                            Next
                        Else
                            Dim m As New message("You do not have enough money!", 2000)
                        End If
                    Case 3
                        If Globals.totalMoney >= Globals.t3price Then
                            Game1.gameLoop.gameScene.turret3s.Add(New turret3(New Vector2(ms.X - Globals.cameraLoc.X, ms.Y - Globals.cameraLoc.Y)))
                            For Each p As player In Game1.gameLoop.gameScene.players
                                p.money -= Globals.t3price
                            Next
                        Else
                            Dim m As New message("You do not have enough money!", 2000)
                        End If
                End Select

                selected = False

            End If

        End If

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim ms As MouseState = Microsoft.Xna.Framework.Input.Mouse.GetState
        Dim iconImage As Texture2D = Game1.contentMnger.loadTexture(textureString)

        If selected = False Then
            sb.Draw(iconImage, New Rectangle(pos.X, pos.Y, size.X, size.Y), Nothing, Color.White, Nothing, Nothing, Nothing, 0.9)
        Else
            sb.Draw(iconImage, New Rectangle(pos.X, pos.Y, size.X, size.Y), Nothing, Color.Green, Nothing, Nothing, Nothing, 0.9)
        End If

        If New Rectangle(pos.X, pos.Y, size.X, size.Y).Contains(New Point(ms.X, ms.Y)) Then

            Select Case tNumber
                Case 1
                    sb.DrawString(Game1.contentMnger.loadFont("mainfont"), "$ " + Globals.t1Price.ToString, New Vector2(pos.X, pos.Y - 40), Color.Green)
                Case 2
                    sb.DrawString(Game1.contentMnger.loadFont("mainfont"), "$ " + Globals.t2Price.ToString, New Vector2(pos.X, pos.Y - 40), Color.Green)
                Case 3
                    sb.DrawString(Game1.contentMnger.loadFont("mainfont"), "$ " + Globals.t3price.ToString, New Vector2(pos.X, pos.Y - 40), Color.Green)
            End Select

        End If

        If selected = True Then

            If New Rectangle(0, 0, 1280, 650).Contains(New Point(MS.X, MS.Y)) Then

                Select Case tNumber
                    Case 1

                        Dim t1 As New turret1(New Vector2(0, 0))
                        Dim buildTurretImage As Texture2D = Game1.contentMnger.loadTexture("Standard Tower Turret Green")
                        sb.Draw(buildTurretImage, New Rectangle(MS.X, MS.Y, t1.size.X, t1.size.Y), Nothing, Color.White, Nothing, New Vector2((buildTurretImage.Width / 2), (buildTurretImage.Height / 2)), Nothing, 0.9)

                    Case 2

                        Dim buildTurretImage As Texture2D = Game1.contentMnger.loadTexture("8 Side Turret Green")
                        Dim t2 As New turret2(New Vector2(0, 0))
                        sb.Draw(buildTurretImage, New Rectangle(MS.X, MS.Y, t2.size.X, t2.size.Y), Nothing, Color.White, Nothing, New Vector2((buildTurretImage.Width / 2), (buildTurretImage.Height / 2)), Nothing, 0.9)

                    Case 3
                        Dim buildTurretImage As Texture2D = Game1.contentMnger.loadTexture("Big Boom Turret Green")
                        Dim t2 As New turret2(New Vector2(0, 0))
                        sb.Draw(buildTurretImage, New Rectangle(MS.X, MS.Y, t2.size.X, t2.size.Y), Nothing, Color.White, Nothing, New Vector2((buildTurretImage.Width / 2), (buildTurretImage.Height / 2)), Nothing, 0.9)

                End Select


            End If

        End If



    End Sub

End Class
