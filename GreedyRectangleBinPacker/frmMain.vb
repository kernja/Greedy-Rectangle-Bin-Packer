Imports System.Windows.Forms.ListBox

Public Class frmMain
    'add the files to the list
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If (openDialog.ShowDialog() = DialogResult.OK) Then
            For Each file As String In openDialog.FileNames
                lstFiles.Items.Add(file)
            Next
        End If
    End Sub

    'delete selected files (if any)
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        For i As Integer = (lstFiles.SelectedItems.Count - 1) To 0 Step -1
            lstFiles.Items.Remove(lstFiles.SelectedItems(i))
        Next
        'unselect files
        lstFiles.SelectedIndex = -1
    End Sub
    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        'require at least 4 files to solve
        If (lstFiles.Items.Count <= 3) Then
            MsgBox("Please add more picture files to the atlas.")
        Else
            'create a new bin solver
            Dim binSolver As GRBSBin = New GRBSBin()
            'convert the list box to a generic list of file paths
            binSolver.Solve(lstFiles.Items.Cast(Of String)().ToList())
            'render it to an image
            picRender.Image = binSolver.ToImage()
            'let the user save
            btnSave.Show()
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If (saveDialog.ShowDialog() = DialogResult.OK) Then
            Dim img As Image = picRender.Image
            img.Save(saveDialog.FileName, Imaging.ImageFormat.Png)
        End If
    End Sub
End Class
