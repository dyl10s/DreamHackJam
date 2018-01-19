Public Class animatedTexture

    Public textureName As String
    Public curAnim As Integer = 0

    Public size As Vector2

    Public totalImages As Integer

    Public animationTimer As Stopwatch
    Public frameTick As Integer

    Public Sub New(frameInterval As Integer, texturesName As String, totalFrames As Integer, finalSize As Vector2)

        textureName = texturesName
        frameTick = frameInterval

        totalImages = totalFrames

        size = finalSize

        animationTimer.Start()

    End Sub

    Public Sub update()

        If animationTimer.ElapsedMilliseconds > frameTick Then
            animationTimer.Restart()
            curAnim += 1

            If curAnim > totalImages Then
                curAnim = 1
            End If

        End If

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim imageWidth As Integer = Game1.contentMnger.loadTexture(textureName).Width / totalImages
        Dim imageHeight As Integer = Game1.contentMnger.loadTexture(textureName).Height

        sb.Draw(Game1.contentMnger.loadTexture(textureName), New Rectangle(0, 0, size.X, size.Y), New Rectangle(imageWidth * curAnim, imageHeight * curAnim, imageWidth, imageHeight), Color.White)

    End Sub

End Class
