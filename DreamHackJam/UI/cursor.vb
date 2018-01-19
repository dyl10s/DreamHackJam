Public Class cursor

    Public Shared textureName As String = ""
    Public Shared size As Vector2 = New Vector2(30, 30)
    Public Shared Sub update()

        Select Case Globals.cursorMode.ToLower
            Case "none"
                textureName = "Main Cursor"
            Case "repair"
                textureName = "repair cursor"
            Case "upgrade"
                textureName = "upgrade cursor"
            Case "destroy"
                textureName = "Demolish Cursor"
        End Select

    End Sub

    Public Shared Sub draw(sb As SpriteBatch)

        Dim ms As MouseState = Microsoft.Xna.Framework.Input.Mouse.GetState

        If ms.Y > 650 Then

            Dim textureImage As Texture2D = Game1.contentMnger.loadTexture("UI Cursor")
            sb.Draw(textureImage, New Rectangle(ms.X, ms.Y, size.X, size.Y), Nothing, Color.LightGreen, Nothing, Nothing, Nothing, 1)

        Else

            Dim textureImage As Texture2D = Game1.contentMnger.loadTexture(textureName)
            sb.Draw(textureImage, New Rectangle(ms.X, ms.Y, size.X, size.Y), Nothing, Color.LightGreen, Nothing, New Vector2((textureImage.Width / 2), (textureImage.Height / 2)), Nothing, 1)


        End If


    End Sub

End Class
