Public Class Wall

    Public pos As New Vector2(100, 100)
    Public size As New Vector2(10, 50)

    Public colbox As collisionBox

    Public hp As Integer = 300

    Public textureString As String

    Public speed As Integer = 2

    Public realPos As Vector2 = pos - New Vector2(size.X / 2, size.Y / 2)

    Public rotation As Double = 0

    Public Sub New(texture As String, objectSize As Vector2, position As Vector2, DegreeRotation As Integer)

        size = objectSize
        textureString = texture
        pos = position

        rotation = DegreeRotation * (Math.PI / 180)

        colbox = New collisionBox(realPos, size, "wall")

    End Sub

    Public Sub update()

        colbox.update(realPos)

        realPos = pos - New Vector2(size.X / 2, size.Y / 2)

        If hp <= 0 Then
            colbox.destroy()
        End If

        If Not colbox.isAlive = True Then
            destroy()
        End If

    End Sub

    Public Sub destroy()

        Game1.gameLoop.gameScene.walls.Remove(Me)

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim texture As Texture2D = Game1.contentMnger.loadTexture(textureString)
        sb.Draw(texture, New Rectangle(pos.X + Globals.cameraLoc.X, pos.Y + Globals.cameraLoc.Y, size.X, size.Y), Nothing, Color.White, rotation, New Vector2(texture.Width / 2.0F, texture.Height / 2.0F), Nothing, Nothing)

    End Sub

End Class
