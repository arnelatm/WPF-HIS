' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports System.Drawing.Printing
Imports System.Globalization
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Presenters

    Public MustInherit Class CommonPresenter(Of TV As IView, TM As New)
        Inherits Presenter(Of TV, TM)

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(itemView As IView)
            MyBase.New(itemView)
        End Sub

        Public Overrides Sub GoAddRecord()
            MyBase.GoAddRecord()
            MakeDefaultValues()
        End Sub


        'Protected Sub CreateDataSourceThread(dataSourceNames As Object)
        '    Dim luItems As List(Of DataLookup)
        '    luItems = CreateDataLookups(dataSourceNames)
        '    For Each luItem As DataLookup In luItems
        '        luItem.PropertyControl = GetFieldControlName(luItem.PropertyName)
        '        luItem.Data = luItem.LookUpTask.Result
        '        Invoker.SetPropertyR(luItem.PropertyControl, "DataSource", luItem.Data)
        '        Invoker.SetPropertyR(luItem.PropertyControl, "DisplayMember", luItem.Data.Columns(0).ColumnName)
        '        Invoker.SetPropertyR(luItem.PropertyControl, "ValueMember", luItem.ValueMember)
        '    Next
        'End Sub


        Protected Sub CreateDataSourceThread(dataSourceNames As ArrayList)
            Dim luItems As List(Of DataLookup)
            luItems = CreateDataLookups(dataSourceNames)
            For Each luItem As DataLookup In luItems
                luItem.PropertyControl = GetFieldControlName(luItem.PropertyName)
                luItem.Data = luItem.LookUpTask.Result
                Invoker.SetPropertyR(luItem.PropertyControl, "DataSource", luItem.Data)
                Invoker.SetPropertyR(luItem.PropertyControl, "DisplayMember", luItem.Data.Columns(0).ColumnName)
                Invoker.SetPropertyR(luItem.PropertyControl, "ValueMember", luItem.ValueMember)
            Next
        End Sub

        'Protected Sub CreateLookupDataThread(dataSourceNames As Object)
        '    Dim luItems As List(Of DataLookup)
        '    luItems = CreateDataLookups(dataSourceNames)
        '    For Each luItem As DataLookup In luItems
        '        'luItem.PropertyControl = GetFieldControlName(luItem.PropertyName)
        '        luItem.Data = luItem.LookUpTask.Result
        '        'CallByName(View,luItem.PropertyName.ToString(),CallType.Set, luItem.Data)
        '        Invoker.SetProperty(Me.View, luItem.PropertyName, luItem.Data)
        '        'Invoker.SetPropertyR(luItem.PropertyControl, "DisplayMember", luItem.Data.Columns(0).ColumnName)
        '        'Invoker.SetPropertyR(luItem.PropertyControl, "ValueMember", luItem.ValueMember)
        '    Next
        'End Sub


        Protected Sub CreateLookupDataThread(dataSourceNames As ArrayList)
            Dim luItems As List(Of DataLookup)
            luItems = CreateDataLookups(dataSourceNames)
            For Each luItem As DataLookup In luItems
                luItem.Data = luItem.LookUpTask.Result
                Invoker.SetProperty(Me.View, luItem.PropertyName, luItem.Data)
            Next
        End Sub

        Protected Sub CreateDataSourceGroupCodeThread(GroupCodeCodes As Object)
            Dim nCount = GroupCodeCodes.Length()
            Dim dataSourceNames As New ArrayList
            For i = 0 To nCount / 2 - 1
                Dim idNo As Int16
                idNo = Service.GetRecordFieldWithKeyG(Of Int16, String)(GroupCodeCodes(i, 1), "CodeGroup", "CodeGroupCode", "IdNo")
                dataSourceNames.Add({"ItemCode", GroupCodeCodes(i, 0), "ItemCodeCode,ItemCodeName", "CodeGroupIdNo = " & idNo.ToString()})
            Next
            CreateDataSourceThread(dataSourceNames)
        End Sub

        Private Function CreateDataLookups(dataSourceNames As ArrayList) As List(Of DataLookup)
            Const LookupTableName As Int32 = 0
            Const PropertyFieldName As Int32 = 1
            Const LookupFieldNames As Int32 = 2
            Const LookupFilter As Int32 = 3
            Const LookupSortKey As Int32 = 4
            Dim lookups As New List(Of DataLookup)
            For Each item In dataSourceNames
                Dim dtl As New DataLookup
                dtl.TableName = item(LookupTableName)
                dtl.PropertyName = item(PropertyFieldName)
                If item.Length - 1 > 1 Then
                    dtl.LuFields = item(LookupFieldNames)
                End If
                If item.Length - 1 > 2 Then
                    dtl.Filter = item(LookupFilter)
                End If
                If item.Length - 1 > 3 Then
                    dtl.SortKey = item(LookupSortKey)
                End If
                ComposeLookupProperties(dtl)
                dtl.LookUpTask = Task(Of DataTable).Factory.StartNew(Function() LookupDataTableCreator(dtl))
                lookups.Add(dtl)
            Next
            Return lookups
        End Function

        'Private Function CreateDataLookupsGroupCode(GroupCodeCodes As Object) As List(Of DataLookup)  
        '    Dim dataSourceNames As Object = Nothing
        '    For each item In GroupCodeCodes
        '        Dim idNo As Int16
        '        idNo = Service.GetRecordFieldWithKeyG(Of Int16, String)(item(2), "CodeGroup", "CodeGroupCode", "IdNo")
        '        dataSourceNames.Add("ItemCode",GroupCodeCodes(1),"ItemCodeCode,ItemCodeName","CodeGroupIdNo = " & idNo.ToString())
        '    Next
        '    Return CreateDataLookups(dataSourceNames)
        'End Function


        'Private Function CreateDataLookups(dataSourceNames As Object) As List(Of DataLookup)
        '    Const LookupTableName As Int32 = 0
        '    Const PropertyFieldName As Int32 = 1
        '    Const LookupFieldNames As Int32 = 2
        '    Const LookupFilter As Int32 = 3
        '    Const LookupSortKey As Int32 = 4
        '    Dim lookups As New List(Of DataLookup)
        '    For i = 0 To dataSourceNames.Length()-1
        '        Dim dtl As New DataLookup
        '        dtl.TableName = datasourcenames(i)(LookupTableName)
        '        dtl.PropertyName = dataSourceNames(i)(PropertyFieldName)
        '        If dataSourceNames(i).Length() > 2 Then
        '            dtl.LuFields = dataSourceNames(i)(LookupFieldNames)
        '        End If
        '        If dataSourceNames(i).Length() > 3 Then
        '            dtl.Filter = dataSourceNames(i)(LookupFilter)
        '        End If
        '        If dataSourceNames(i).Length() > 4 Then
        '            dtl.SortKey = dataSourceNames(i)(LookupSortKey)
        '        End If
        '        ComposeLookupProperties(dtl)
        '        dtl.LookUpTask = Task(Of DataTable).Factory.StartNew(Function() LookupDataTableCreator(dtl))
        '        lookups.Add(dtl)
        '    Next
        '    Return lookups
        'End Function

        'Private Function CreateDataLookups(dataSourceNames As Object) As List(Of DataLookup)
        '    Const LookupTableName As Int32 = 0
        '    Const PropertyFieldName As Int32 = 1
        '    Const LookupFieldNames As Int32 = 2
        '    Const LookupFilter As Int32 = 3
        '    Const LookupSortKey As Int32 = 4
        '    Dim lookups As New List(Of DataLookup)
        '    For i = 0 To UBound(dataSourceNames, 1)
        '        Dim dtl As New DataLookup
        '        dtl.TableName = dataSourceNames(i, LookupTableName)
        '        dtl.PropertyName = dataSourceNames(i, PropertyFieldName)
        '        If UBound(dataSourceNames, 2) > 1 Then
        '            dtl.LuFields = dataSourceNames(i, LookupFieldNames)
        '        End If
        '        If UBound(dataSourceNames, 2) > 2 Then
        '            dtl.Filter = dataSourceNames(i, LookupFilter)
        '        End If
        '        If UBound(dataSourceNames, 2) > 3 Then
        '            dtl.SortKey = dataSourceNames(i, LookupSortKey)
        '        End If
        '        ComposeLookupProperties(dtl)
        '        dtl.LookUpTask = Task(Of DataTable).Factory.StartNew(Function() LookupDataTableCreator(dtl))
        '        lookups.Add(dtl)
        '    Next
        '    Return lookups
        'End Function

        Private Sub ComposeLookupProperties(dtl As DataLookup)
            Dim RightToLeftFormat = GlobalFunctions.IsRightToLeft(CultureInfo.CurrentCulture.ToString())
            If dtl.LuFields Is Nothing Then
                dtl.NameFieldOrig = dtl.TableName + "Name"
                dtl.NameField = TranslateNameField(dtl.TableName, dtl.NameFieldOrig)
                dtl.NameDisplayValue = dtl.NameField + "+'-'+" + dtl.TableName + "Code"
                dtl.ValueMember = "IdNo"
                dtl.LuFields = dtl.NameDisplayValue + " COLLATE SQL_Latin1_General_CP1_CI_AS, IdNo"
                dtl.SortKey = dtl.NameField
            Else
                Dim fieldNames = dtl.LuFields.Split(",")
                dtl.NameFieldOrig = fieldNames(0)
                If fieldNames.Count() = 1 Then
                    dtl.NameField = TranslateNameField(dtl.TableName, dtl.NameFieldOrig)
                    dtl.NameDisplayValue = dtl.NameField
                    dtl.ValueMember = "Name"
                    dtl.LuFields = dtl.NameDisplayValue + " COLLATE SQL_Latin1_General_CP1_CI_AS"
                    dtl.SortKey = dtl.NameField
                ElseIf fieldNames.Count() = 2 Then
                    dtl.NameField = TranslateNameField(dtl.TableName, dtl.NameFieldOrig)
                    dtl.NameDisplayValue = dtl.NameField + "+'-'+" + fieldNames(1) + " COLLATE SQL_Latin1_General_CP1_CI_AS"
                    dtl.ValueMember = fieldNames(1).Trim()
                    dtl.LuFields = dtl.NameDisplayValue + "," + fieldNames(1)
                    dtl.SortKey = dtl.NameField
                ElseIf fieldNames.Count() = 3 Then
                    dtl.NameField = fieldNames(0).Trim()
                    dtl.NameDisplayValue = TranslateNameField(dtl.TableName, dtl.NameField) + "+'-'+" + fieldNames(2) + " COLLATE SQL_Latin1_General_CP1_CI_AS"
                    dtl.LuFields = dtl.NameDisplayValue + "," + fieldNames(1)
                    dtl.ValueMember = fieldNames(1).Trim()
                    dtl.SortKey = dtl.NameField
                Else
                    MessageBox.Show("Too much parameters passed!")
                    Debugger.Break()
                End If
            End If
            'TranslateFields(dtl)
        End Sub

        Private Function TranslateNameField(tableName As String, fieldName As String) As String
            Dim retValue As String = fieldName
            If GlobalFunctions.IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
                Dim nameFieldArabic As String = fieldName + "Ara"
                Dim svc As New CommonService
                If svc.FieldExistInTable(tableName, nameFieldArabic) Then
                    retValue = fieldName + "Ara"
                End If
            End If
            Return retValue
        End Function

        Private Function LookupDataTableCreator(dtl As DataLookup, Optional dataBase As String = Nothing) As DataTable
            Dim cd As New DataCreator(Service)
            Dim data As DataTable = cd.CreateDataTable(dtl)
            data.Columns(0).ColumnName = "Name"
            cd = Nothing
            Return data
        End Function

        Protected Sub SetDataSourceInstalledPrinter(controlName As String)
            Dim data As New List(Of Lookup.LookupData)
            ' Find all printers installed
            Dim index As Int16 = 0
            For Each item In PrinterSettings.InstalledPrinters
                Dim dbLookup = New Lookup.LookupData
                dbLookup.IdNo = index
                dbLookup.Name = item
                dbLookup.Code = item
                dbLookup.Index = index
                data.Add(dbLookup)
                index += 1
            Next
            GetControlName(controlName).DataSource = data
        End Sub

        Protected Sub SetPrinterSupportedSources(pPrinterName As String, ByRef paperSource As Int16)
            Dim data = GlobalFunctions.GetPrinterPageInfo(pPrinterName)
            Dim paperSourceLookup As New List(Of Lookup.LookupData)
            Dim index As Int16 = 0
            For Each item As Drawing.Printing.PaperSource In data.PrinterSettings.PaperSources
                Dim dbLookup = New Lookup.LookupData
                dbLookup.IdNo = item.RawKind
                dbLookup.Name = item.SourceName
                dbLookup.Code = item.Kind
                dbLookup.Index = index
                paperSourceLookup.Add(dbLookup)
                index += 1
            Next
            Dim savedPaperSource As Int16? = paperSource
            GetControlName("PaperSource").DataSource = paperSourceLookup
            paperSource = savedPaperSource
            If savedPaperSource Is Nothing OrElse savedPaperSource = 0 Then
                paperSource = data.PrinterSettings.DefaultPageSettings.PaperSource.RawKind
            End If
        End Sub

        Protected Sub SetPrinterSupportedPaperSize(pPrinterName As String, ByRef paperSize As Int16)
            Dim data = GetPrinterPageInfo(pPrinterName)
            Dim paperSizeLookup As New List(Of Lookup.LookupData)
            Dim index As Int16 = 0
            For Each item As Drawing.Printing.PaperSize In data.PrinterSettings.PaperSizes
                Dim dbLookup = New Lookup.LookupData
                dbLookup.IdNo = item.RawKind
                dbLookup.Name = item.PaperName
                dbLookup.Code = item.Kind
                dbLookup.Index = index
                paperSizeLookup.Add(dbLookup)
                index += 1
            Next
            Dim savedDefaultPaperSize As Int16? = paperSize
            GetControlName("PaperSize").DataSource = paperSizeLookup
            paperSize = savedDefaultPaperSize
            If savedDefaultPaperSize Is Nothing OrElse savedDefaultPaperSize = 0 Then
                paperSize = data.PrinterSettings.DefaultPageSettings.PaperSize.RawKind
            End If
        End Sub

        Protected Sub SetPrinterSupportedPaperOrientation(pPrinterName As String, ByRef paperOrientation As Int16)
            Dim data = GetPrinterPageInfo(pPrinterName)
            Dim paperOrientationLookup As New List(Of Lookup.LookupData)
            Dim index As Int16 = 0
            Dim dbLookup = New Lookup.LookupData
            dbLookup.IdNo = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation
            dbLookup.Name = "DefaultPaperOrientation"
            dbLookup.Code = "DefaultPaperOrientation"
            dbLookup.Index = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation
            paperOrientationLookup.Add(dbLookup)
            dbLookup = New Lookup.LookupData
            dbLookup.IdNo = CrystalDecisions.Shared.PaperOrientation.Landscape
            dbLookup.Name = "Landscape"
            dbLookup.Code = "Landscape"
            dbLookup.Index = CrystalDecisions.Shared.PaperOrientation.Landscape
            paperOrientationLookup.Add(dbLookup)
            dbLookup = New Lookup.LookupData
            dbLookup.IdNo = CrystalDecisions.Shared.PaperOrientation.Portrait
            dbLookup.Name = "Portrait"
            dbLookup.Code = "Portrait"
            dbLookup.Index = CrystalDecisions.Shared.PaperOrientation.Portrait
            paperOrientationLookup.Add(dbLookup)
            Dim savedDefaultPaperOrientation As Int16? = paperOrientation
            GetControlName("PaperOrientation").DataSource = paperOrientationLookup
            paperOrientation = savedDefaultPaperOrientation
            If savedDefaultPaperOrientation Is Nothing OrElse savedDefaultPaperOrientation = 0 Then
                paperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation
            End If
        End Sub

    End Class

    Public Class DataLookup
        Public Property TableName As String
        Public Property PropertyName As String
        Public Property PropertyControl As CtComboBox
        Public Property LuFields As String
        Public Property SortKey As String
        Public Property Filter As String
        Public Property ValueMember As String
        Public Property DisplayMember As String
        Public Property Data As DataTable
        Public Property NameField As String
        Public Property NameFieldOrig As String
        Public Property NameDisplayValue As String
        Public Property LookUpTask As Task(Of DataTable)
        Public Property NameFieldToUse As String
    End Class

    Public Class DataCreator

        Private Shared _sv As Service

        Public Sub New(svc As Service)
            _sv = svc
        End Sub

        Public Function CreateDataTable(dtl As DataLookup) As DataTable
            Return _sv.GetDtRecords(dtl.TableName, dtl.LuFields, dtl.Filter, dtl.SortKey)
        End Function

        Public Function CreateData(dataTableName As String) As List(Of Lookup.LookupData)
            Dim lookupObj
            Dim data As List(Of Lookup.LookupData)
            lookupObj = SetLookupObject(dataTableName)
            data = _sv.GetLookup(lookupObj)
            Return data
        End Function

        Public Function SetLookupObject(dataTableName As String, Optional dataFields As String() = Nothing, Optional sortKey As String = Nothing, Optional filter As String = Nothing) As Lookup
            Dim lookupObj As New Lookup(dataTableName)
            If dataFields IsNot Nothing Then
                lookupObj.FieldsToShow = dataFields
            End If
            If Not (sortKey Is Nothing OrElse sortKey = "") Then
                lookupObj.SortKey = sortKey
            End If
            'If Not (Filter() Is Nothing OrElse Filter() = "") Then
            '    lookupObj.FilterKey = Filter()
            'End If
            Return lookupObj
        End Function

    End Class

End Namespace