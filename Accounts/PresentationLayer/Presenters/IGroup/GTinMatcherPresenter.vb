Imports System.Dynamic
Imports System.Net.Http.Headers
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class GTinMatcherPresenter(Of TM As New)
        Inherits CommonPresenter(Of IGTinMatcherView, TM)

        Private _drugList As Object

        Public Sub New(itemView As IGTinMatcherView)
            MyBase.New(itemView)
            Service = New AccountsService("ItemDetails")
            TableName = "ItemDetailsQty_View"
            SortOrderKey = "ItemNameEnglish"
            WithTreeView = False
            AddHandler View.UpdateDrugDisplay, AddressOf OnUpdateDrugDisplay
            AddHandler View.UpdateItemDisplay, AddressOf OnUpdateItemDisplay
            AddHandler View.GTinValueChanged, AddressOf OnGTinValueChanged
            AddHandler View.MatchGTinRequested, AddressOf OnMatchGTinRequested
        End Sub

        Private Sub OnMatchGTinRequested(gTinNumber As String, itemDetailIdNo As Integer)
            Service.UpdateRecordWithIdNo(Of String)(View.IdNo, "ItemDetails", "GTIN", View.DrugGTin)
            UpdateViewDisplay()
        End Sub

        Private Sub OnGTinValueChanged(sender As DataGridView, gTinValue As String)
            If gTinValue Is DBNull.Value Or gTinValue Is Nothing Or gTinValue = "" Then
                ClearDrugDisplay()
                ClearItemDrugDisplay()
            Else
                Dim rowIndex As Integer = MatchingRowIndex(sender, "GTIN", gTinValue)
                Dim drugIdNo As Integer = sender.Rows(rowIndex).Cells("IdNo").Value
                Dim drug As Object = MakeDrug(drugIdNo)
                If drug IsNot Nothing Then
                    DisplayDrug(drug)
                    sender.FirstDisplayedScrollingRowIndex = rowIndex
                    sender.CurrentCell = sender.Rows(rowIndex).Cells(0)
                End If
            End If
        End Sub

        Public Shared Function MatchingRowIndex(ByVal dgv As DataGridView, ByVal columnName As String, ByVal searchValue As String) As Integer
            Dim rowIndex As Integer = -1
            Dim tempAllowUserToAddRows As Boolean = dgv.AllowUserToAddRows
            dgv.AllowUserToAddRows = False

            If dgv.Rows.Count > 0 AndAlso dgv.Columns.Count > 0 AndAlso dgv.Columns(columnName) IsNot Nothing Then
                Dim row As DataGridViewRow = dgv.Rows.Cast(Of DataGridViewRow)().FirstOrDefault(Function(r) r.Cells(columnName).Value.ToString().Equals(searchValue))
                rowIndex = row.Index
            End If

            dgv.AllowUserToAddRows = tempAllowUserToAddRows
            Return rowIndex
        End Function

        'Private Sub UndeleteSectionInGrid(ByVal sectionLetter As String)
        '    Dim sectionRowIndex As Integer = MatchingRowIndex(dgvSections, "SectionLetter", sectionLetter)
        '    dgvSections.Rows(sectionRowIndex).Cells("DeleteSection").Value = False
        'End Sub

        Private Function GetDrugIdNo(ByRef gTinValue As String) As Int32
            Return Service.GetField(Of Int32, String)(gTinValue, "DrugList", "GTin", "IdNo")
        End Function

        Private Sub OnUpdateDrugDisplay(itemDetailIdNo As Integer)
            Dim drug As Object = MakeDrug(itemDetailIdNo)
            DisplayDrug(drug)
        End Sub

        Private Sub OnUpdateItemDisplay(idNo As Integer)
            'CreateDataSources()
            RecordPositionNumber = GetSortedRecordPosition(idNo)
        End Sub

        Public Overrides Sub UpdateViewData(idNo As Int32)
            MyBase.UpdateViewData(idNo)
            View.CurrentIndex = RecordPositionNumber
        End Sub

        Private Function MakeDrug(drugIdNo As Integer) As Object
            Return Service.GetFieldsWithIdNo(drugIdNo, "DrugList", "IdNo,GTin,[Trade Name],[Dosage Form],[Generic Name],[Package Size],[Package Type],[Public Price],[RegistrationNo],[Route Of Administration],[Strength Value],[Unit Of Strength],[Unit Of Volume],Volume", "IdNo")
        End Function

        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"DrugDosageForm_View", "DosageForm", "DosageForm"})
            data.Add({"DrugUnitOfVolume_View", "UnitOfVolume", "UnitOfVolume"})
            data.Add({"DrugUnitOfStrength_View", "UnitOfStrength", "UnitOfStrength"})
            data.Add({"DrugPackageType_View", "PackageType", "PackageType"})
            data.Add({"DrugRouteOfAdministration_View", "RouteOfAdministration", "RouteOfAdministration"})
            CreateControlDataSources(data)
        End Sub

        Public Overrides Sub GoFilter()
            If DataFilter Is Nothing Or DataFilter = "" Then
                DataFilter = "QtyOnHand <> 0 and isnull(GTin,'')=''"
            Else
                DataFilter = ""
            End If
            View.DataFilter = DataFilter
            GoFirstRecord()
        End Sub

        'Private Sub OnGTinMatcherValueChanged(sender As DataGridView, gTin As String)
        '    If gTin IsNot Nothing Or gTin <> "" Then
        '        Dim gTinIdNo As Integer = GetGTinIdNo(gTin)
        '        Dim drug As Object = MakeDrug(gTinIdNo)
        '        If drug Is Nothing Then
        '            ClearItemDrugDisplay()
        '            ClearDrugDisplay()
        '        Else
        '            DisplayDrug(drug)
        '            View.DosageForm = NoDbNull(drug.DosageForm)
        '            View.GenericName = NoDbNull(drug.GenericName)
        '            View.PackageSize = NoDbNull(drug.PackageSize)
        '            View.PackageType = NoDbNull(drug.PackageType)
        '            View.RegistrationNo = NoDbNull(drug.RegistrationNo)
        '            View.RouteOfAdministration = NoDbNull(drug.RouteOfAdministration)
        '            View.StrengthValue = NoDbNull(drug.StrengthValue)
        '            View.UnitOfStrength = NoDbNull(drug.UnitOfStrength)
        '            View.UnitOfVolume = NoDbNull(drug.UnitOfVolume)
        '            View.Volume = NoDbNull(drug.Volume)
        '            Dim searchValue = View.GTIN
        '            Dim row = Enumerable.Where(Of DataGridViewRow)(sender.Rows.Cast(Of DataGridViewRow)(), Function(x) Not x.IsNewRow).FirstOrDefault(Function(x) CType(x.DataBoundItem, DataRowView)("GTin").ToString().Equals(searchValue))
        '            sender.CurrentCell = row.Cells(0)
        '        End If
        '    Else
        '        ClearItemDrugDisplay()
        '        ClearDrugDisplay()
        '    End If
        'End Sub

        Private Sub ClearItemDrugDisplay()
            View.DosageForm = Nothing
            View.GenericName = Nothing
            View.PackageSize = Nothing
            View.PackageType = Nothing
            View.RegistrationNo = Nothing
            View.RouteOfAdministration = Nothing
            View.StrengthValue = Nothing
            View.UnitOfStrength = Nothing
            View.UnitOfVolume = Nothing
            View.Volume = Nothing
        End Sub

        Private Sub DisplayDrug(drug As Object)
            If drug Is Nothing Then
                ClearDrugDisplay()
            Else
                View.DrugIdNo = NoDbNull(drug.IdNo)
                View.DrugGTin = NoDbNull(drug.GTin).ToString()
                View.DrugTradeName = NoDbNull(drug.TradeName).ToString()
                View.DrugGenericName = NoDbNull(drug.GenericName).ToString()
                View.DrugDosageForm = NoDbNull(drug.DosageForm).ToString()
                View.DrugGenericName = NoDbNull(drug.GenericName).ToString()
                View.DrugPackageSize = NoDbNull(drug.PackageSize).ToString()
                View.DrugPackageType = NoDbNull(drug.PackageType).ToString()
                View.DrugRegistrationNo = NoDbNull(drug.RegistrationNo).ToString()
                View.DrugRouteOfAdministration = NoDbNull(drug.RouteOfAdministration).ToString()
                View.DrugStrengthValue = NoDbNull(drug.StrengthValue).ToString()
                View.DrugUnitOfStrength = NoDbNull(drug.UnitOfStrength).ToString()
                View.DrugUnitOfVolume = NoDbNull(drug.UnitOfVolume).ToString()
                View.DrugVolume = NoDbNull(drug.Volume)
                View.DrugPublicPrice = NoDbNull(drug.PublicPrice)
            End If
        End Sub

        Private Sub ClearDrugDisplay()
            View.DrugIdNo = Nothing
            View.DrugTradeName = Nothing
            View.DrugGenericName = Nothing
            View.DrugDosageForm = Nothing
            View.DrugRegistrationNo = Nothing
            View.DrugPackageType = Nothing
            View.DrugPackageSize = Nothing
            View.DrugRouteOfAdministration = Nothing
            View.DrugStrengthValue = Nothing
            View.DrugUnitOfStrength = Nothing
            View.DrugUnitOfVolume = Nothing
            View.DrugVolume = Nothing
            View.DrugGTin = Nothing
            View.DrugPublicPrice = Nothing
        End Sub

        Private Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                If View.ItemDetailsCode Is Nothing Or View.ItemDetailsCode = "" Then
                    View.ItemDetailsCode = Service.GenerateCode(View.IdNo)
                End If
            End If
        End Sub

        Public Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            If View.GTIN IsNot Nothing Or View.GTIN <> "" Then
                Dim drugIdNo As Int32 = Service.GetField(Of Int32, String)(View.GTIN, "DrugList", "GTin", "IdNo")
                Dim drug As Object = MakeDrug(drugIdNo)
                DisplayDrug(drug)
            End If
        End Sub

    End Class

End Namespace