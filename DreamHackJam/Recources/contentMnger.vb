Public Class contentMnger

    Dim content As ContentManager

    'Content List

    Public player As String = "President Sprite"
    Public zombie As String = "zombie"
    Public bullet As String = "zombie"
    Public Shared fenceUP As String = "fenceUP"
    Public Shared fenceSIDE As String = "fenceSIDE"

    Public Sub New(c As ContentManager)
        content = c
    End Sub

    Public Function loadTexture(name As String) As Texture2D

        Return content.Load(Of Texture2D)(name)

    End Function

    Public Function loadFont(name As String) As SpriteFont

        Return content.Load(Of SpriteFont)(name)

    End Function

End Class
