Public Class GRBSImage
    Private _picture As Image
    Private _x As Integer
    Private _y As Integer
    Private _width As Integer
    Private _height As Integer
    Private _placed As Boolean

    Public Sub New(filename As String)
        _picture = New Bitmap(filename)
        _x = 0
        _y = 0
        _width = _picture.Width
        _height = _picture.Height
        _placed = False
    End Sub
    Public Function OccupiesSpace(x As Integer, y As Integer) As Boolean
        'if we're not placed, then we're not occupying space 
        If (_placed = False) Then
            Return False
        End If

        'top left corner 
        Dim x1 As Integer, y1 As Integer
        x1 = _x : y1 = _y

        'bottom right corner 
        Dim x2 As Integer, y2 As Integer
        x2 = x1 + _width - 1 : y2 = y1 + _height - 1

        'see if the coordinates provided occupy the space we have
        If (x >= x1 And y >= y1) And (x <= x2 And y <= y2) Then
            Return True
        End If
        Return False
    End Function
    Public ReadOnly Property Picture As Image
        Get
            Return _picture
        End Get
    End Property
    Public Property X As Integer
        Get
            Return _x
        End Get
        Set(value As Integer)
            _x = value
        End Set
    End Property
    Public Property Y As Integer
        Get
            Return _y
        End Get
        Set(value As Integer)
            _y = value
        End Set
    End Property

    Public ReadOnly Property Width As Integer
        Get
            Return _width
        End Get
    End Property

    Public ReadOnly Property Height As Integer
        Get
            Return _height
        End Get
    End Property

    Public Property Placed As Boolean
        Get
            Return _placed
        End Get
        Set(value As Boolean)
            _placed = value
        End Set
    End Property

    Public ReadOnly Property Area As Integer
        Get
            Return _width * _height
        End Get
    End Property
End Class
