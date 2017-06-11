Public Class GRBSBin
    Private _picture As Image
    Private _pictureList As IList(Of GRBSImage)
    Private _width As Integer
    Private _height As Integer
    Private _solved As Boolean
    Public Sub New()
        'initialize list
        _pictureList = New List(Of GRBSImage)
        'we're not solved
        _solved = False
    End Sub

    Public Sub Solve(files As IList(Of String))
        'load in the pictures to memory
        For Each s In files
            _pictureList.Add(New GRBSImage(s))
        Next
        'sort all of the pictures by height, from biggest to smallest
        _pictureList = _pictureList.OrderByDescending(Function(item) item.Height).ToList()
        'total area of all images
        Dim area As Integer = _pictureList.Sum(Function(item) item.Area)
        Dim sqrt As Integer = Math.Sqrt(area)

        'initially set the width and height to the square root of the image area
        _width = sqrt : _height = sqrt

        'figure out the minimum length of each side of the bin we need to put the pictures in
        Dim minWidth As Integer = _pictureList.Max(Function(item) item.Width)
        Dim minHeight As Integer = _pictureList.Max(Function(item) item.Height)

        'make sure we have the minimum height and width required by the iages 
        If (_width < minWidth) Then
            _width = minWidth
        End If
        If (_height < minHeight) Then
            _height = minHeight
        End If
        'round up these values to the next power of two
        _width = NearestSuperiorPowerOf2(_width)
        _height = NearestSuperiorPowerOf2(_height)

        'square the image
        'this isn't necessary, but it's helpful for 3d applications on that platforms
        'that require square textures
        If (_width > _height) Then
            _height = _width
        Else
            _width = _height
        End If

        'place the images
        'iterate through the picture list untili all are placed
        While _pictureList.Any(Function(item) item.Placed = False)
            'go through the canvas, each line vertically followed by each line horizontally
            For ty As Integer = 0 To _height - 1
                For tx As Integer = 0 To _width - 1
                    'placeholder variables as using iterator variables in a query can cause odd things to happen
                    Dim x As Integer = tx, y As Integer = ty

                    'get the first image that occupies the space at the given coordinates (if any)
                    Dim eI As GRBSImage = _pictureList.FirstOrDefault(Function(item) item.OccupiesSpace(x, y))
                    'get the first image that isn't placed, that could occupy this place without going over the boundaries of the bin
                    Dim nI As GRBSImage = _pictureList.FirstOrDefault(Function(item) (item.Placed = False And
                                                                             (x + item.Width - 1 <= _width) And
                                                                            (y + item.Height - 1 <= _height)))
                    'we can  only place if there's no image placed at the location AND
                    'if there's a new image that can fit
                    If (eI Is Nothing) And Not (nI Is Nothing) Then
                        'place the image
                        nI.Placed = True
                        nI.X = x
                        nI.Y = y
                        'move the cursor over by the width of the image.
                        tx = tx + nI.Width - 1
                    End If
                    'break if there's nothing left to place
                    If Not (_pictureList.Any(Function(item) item.Placed = False)) Then Exit For
                Next tx
                'break if there's nothing left to place
                If Not (_pictureList.Any(Function(item) item.Placed = False)) Then Exit For
            Next ty
        End While

        _solved = True
    End Sub
    Public Function ToImage() As Image
        'if we're not solved, throw an error
        If (_solved = False) Then
            Throw New Exception()
        End If

        'render the images
        'create the canvas
        Dim canvas As Image = New Bitmap(_width, _height)
        'go through each image in the list
        For Each img As GRBSImage In _pictureList
            'create a brush with each image
            Using brush As TextureBrush = New TextureBrush(img.Picture, Drawing2D.WrapMode.Tile)
                'create a graphic context and paste the brush to it, at the location
                Using g As Graphics = Graphics.FromImage(canvas)
                    g.FillRectangle(brush, Convert.ToSingle(img.X), Convert.ToSingle(img.Y), Convert.ToSingle(img.Width), Convert.ToSingle(img.Height))
                End Using
            End Using
        Next

        'return the image
        Return canvas
    End Function
    Private Function NearestSuperiorPowerOf2(n As Integer) As Integer
        Return Math.Pow(2, Math.Ceiling(Math.Log(n) / Math.Log(2)))
    End Function

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

    Public ReadOnly Property Solved As Boolean
        Get
            Return _solved
        End Get
    End Property
End Class
