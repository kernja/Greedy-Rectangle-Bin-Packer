<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstFiles = New System.Windows.Forms.ListBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.picRender = New System.Windows.Forms.PictureBox()
        Me.openDialog = New System.Windows.Forms.OpenFileDialog()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.saveDialog = New System.Windows.Forms.SaveFileDialog()
        CType(Me.picRender, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstFiles
        '
        Me.lstFiles.FormattingEnabled = True
        Me.lstFiles.Location = New System.Drawing.Point(13, 13)
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.Size = New System.Drawing.Size(451, 82)
        Me.lstFiles.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(470, 13)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(140, 23)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add Picture..."
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(616, 13)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(29, 23)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "X"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(470, 42)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(175, 53)
        Me.btnRun.TabIndex = 3
        Me.btnRun.Text = "RUN"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'picRender
        '
        Me.picRender.Location = New System.Drawing.Point(12, 101)
        Me.picRender.Name = "picRender"
        Me.picRender.Size = New System.Drawing.Size(452, 452)
        Me.picRender.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picRender.TabIndex = 4
        Me.picRender.TabStop = False
        '
        'openDialog
        '
        Me.openDialog.Filter = ".PNG|*.png|.BMP|*.bmp|.JPG|*.jpg"
        Me.openDialog.Multiselect = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(470, 101)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(175, 23)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save Output"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'saveDialog
        '
        Me.saveDialog.Filter = ".PNG|*.png"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 561)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.picRender)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lstFiles)
        Me.Name = "frmMain"
        Me.Text = "Greedy Rectangle Bin Packer"
        CType(Me.picRender, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstFiles As ListBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnRun As Button
    Friend WithEvents picRender As PictureBox
    Friend WithEvents openDialog As OpenFileDialog
    Friend WithEvents btnSave As Button
    Friend WithEvents saveDialog As SaveFileDialog
End Class
