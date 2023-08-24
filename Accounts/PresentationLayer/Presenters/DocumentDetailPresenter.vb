Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Presenters

    Public Class DocumentDetailPresenter(Of TM As New)
        Inherits CommonPresenter(Of IDocumentDetailView, DocumentDetailModel)

        Public Sub New(view As IDocumentDetailView)
            MyBase.New(view)
            AddHandler view.AddNewDocumentType, AddressOf OnAddNewDocumentType
            AddHandler view.DocumentTypeChanged, AddressOf OnDocumentTypeChanged
            AddHandler view.LookupNeedsUpdate, AddressOf OnLookupNeedsUpdate
            Service = New AccountsService("DocumentDetail")
            TableName = "DocumentDetail"
            WithTreeView = False
            SortOrderKey = "IdNo"
        End Sub

        Private Sub OnLookupNeedsUpdate()
            UpdateLookupSources()
        End Sub

        Private Sub OnDocumentTypeChanged()
            Dim documentType As String
            documentType = Service.GetField(Of String, Int32)(View.DocumentIdNo, "Document", "IdNo", "DocumentType")
            If documentType = EnumToCode(DocumentTypeSelection.Establishment) Then
                View.ShowContactIdSelector = False
            Else
                View.ShowContactIdSelector = True
                documentType = Service.GetField(Of String, Int32)(View.DocumentIdNo, "Document", "IdNo", "DocumentType")
                UpdateLookupSources()
            End If
        End Sub

        Private Sub UpdateLookupSources()
            Dim data As New ArrayList
            Dim documentType As String
            documentType = Service.GetField(Of String, Int32)(View.DocumentIdNo, "Document", "IdNo", "DocumentType")
            If documentType = EnumToCode(DocumentTypeSelection.Employee) Then
                data.Add({"Employee", View.ContactIdDataName})
                View.ContactDescription = Libraries.MessagingLibrary.Messaging.TranslateCaption("Employee")
            ElseIf documentType = EnumToCode(DocumentTypeSelection.Customer) Then
                data.Add({"Customer", View.ContactIdDataName})
                View.ContactDescription = Libraries.MessagingLibrary.Messaging.TranslateCaption("Customer")
            ElseIf documentType = EnumToCode(DocumentTypeSelection.Supplier) Then
                data.Add({"Supplier", View.ContactIdDataName})
                View.ContactDescription = Libraries.MessagingLibrary.Messaging.TranslateCaption("Supplier")
            End If
            CreateLookupDataThread(data)
        End Sub

        Private Sub OnAddNewDocumentType()
            Dim formToRun = Activator.CreateInstance(GetType(DocumentEntryTv))
            Dim pType As Type = GetType(DocumentPresenter(Of DocumentModel))
            formToRun.Presenter = Activator.CreateInstance(pType, {formToRun})
            formToRun.AddOnOpen = True
            formToRun.QuitOnSave = True
            formToRun.Show()
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int16)(View.IdNo, "EmployeeDocumentDetail", "DocumentDetailIdNo") Then
                Return True
            ElseIf CheckDependentRecords(View.IdNo, "EmployeeDocumentDetailCredit", "DocumentDetailIdNo") Then
                Return True
            ElseIf CheckDependentRecords(View.IdNo, "Holiday", "DocumentDetailIdNo") Then
                Return True
            End If
            Return False
        End Function

        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"Document", "DocumentIdNo", Nothing, Nothing})
            CreateDataSourceThread(data)

        End Sub

        Private Function CreateFileFromDataImage(imageIdNo As Short) As String
            Dim dao = New DataImageDao
            Dim dataImage As DataImage = dao.GetRecordByIdNo(imageIdNo)
            Dim tempFileName As String = System.IO.Path.GetRandomFileName()
            tempFileName = tempFileName + ".jpeg"
            Dim saveImage As New Bitmap(dataImage.Image)
            saveImage.Save(tempFileName, Imaging.ImageFormat.Jpeg)
            Return tempFileName
        End Function

        Private Sub GetDocumentImage(index As Int16)
            Dim documentFileName As String = Nothing
            Dim originalDocumentFileName As String = Nothing
            If View.DataImageIdNo > 0 Then
                originalDocumentFileName = CreateFileFromDataImage(View.DataImageIdNo)
                If View.ImageFileName Is Nothing OrElse View.ImageFileName = "" Then
                    documentFileName = originalDocumentFileName
                Else
                    documentFileName = View.ImageFileName
                End If
            ElseIf View.DataImageIdNo < 0 Then
                documentFileName = View.ImageFileName
            End If
            Dim imageFileName As String = Nothing
            Dim remarks As String = View.ContactType + "-" + View.ContactIdNo
            imageFileName = SelectImage(documentFileName, remarks)
            Dim changed As Boolean = View.Changed
            View.ImageFileName = imageFileName
            If imageFileName <> originalDocumentFileName Then
                View.Changed = True
            Else
                View.Changed = False
            End If
            If imageFileName = "" Then
                ' the user selected to clear the image
                View.DataImageIdNo = 0
            End If
        End Sub

        Private Sub DisplayImage(cFileName As String, cRemarks As String)
            If cFileName Is Nothing Or cFileName = "" Then
                Libraries.MessagingLibrary.Messaging.Show(True, "MsgNoImageEntered")
            Else
                Dim cPictureViewer As New CPictureViewer(cFileName, cRemarks, True)
                cPictureViewer.ShowDialog()
            End If
        End Sub

        Private Function SelectImage(cFileName As String, cRemarks As String) As String
            Dim cPictureViewer As New CPictureViewer(cFileName, cRemarks, False)
            Dim dialogResult As DialogResult = cPictureViewer.ShowDialog()
            If dialogResult = DialogResult.OK Then
                Return cPictureViewer.ImageFileName
            ElseIf dialogResult = DialogResult.Cancel Then
                Return cFileName
            ElseIf dialogResult = DialogResult.Abort Then

            End If
            Return Nothing
        End Function


        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.Active = True
            View.Changed = False
        End Sub

    End Class

End Namespace