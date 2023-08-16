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

        'Protected Sub MakeDataSourceThread(dataSourceName As Array)
        '    Dim luItem As DataLookup
        '    luItem = CreateDataLookup(dataSourceName)

        '    luItem.PropertyControl = GetFieldControlName(luItem.PropertyName)
        '    luItem.Data = luItem.LookUpTask.Result
        '    Invoker.SetPropertyR(luItem.PropertyControl, "DataSource", luItem.Data)
        '    Dim displayColumnNo As Integer = 0
        '    Dim valueColumnNo As Integer = 0
        '    If luItem.DisplayMember = "Name" Then
        '        If luItem.Data.Columns.Count() = 1 Then
        '            displayColumnNo = 0
        '            valueColumnNo = 0
        '        Else
        '            displayColumnNo = 1
        '        End If
        '    ElseIf luItem.DisplayMember = "Code" Then
        '        If luItem.Data.Columns.Count() = 1 Then
        '            displayColumnNo = 0
        '        ElseIf luItem.Data.Columns.Count() = 2 Then
        '            displayColumnNo = 1
        '        Else
        '            displayColumnNo = 2
        '        End If
        '    Else
        '        If luItem.Data.Columns.Count() = 1 Then
        '            displayColumnNo = 0
        '        Else
        '            displayColumnNo = 1
        '        End If
        '    End If
        '    If luItem.ValueMember = "Name" Then
        '        If luItem.Data.Columns.Count() = 1 Then
        '            valueColumnNo = 0
        '        Else
        '            valueColumnNo = 1
        '        End If
        '    ElseIf luItem.DisplayMember = "Code" Then
        '        If luItem.Data.Columns.Count() = 1 Then
        '            valueColumnNo = 0
        '        ElseIf luItem.Data.Columns.Count() = 2 Then
        '            valueColumnNo = 1
        '        Else
        '            valueColumnNo = 2
        '        End If
        '    Else
        '        valueColumnNo = 0
        '    End If

        '    Return .SetPropertyR(luItem.PropertyControl, "DisplayMember", luItem.Data.Columns(displayColumnNo).ColumnName)
        '    Invoker.SetPropertyR(luItem.PropertyControl, "ValueMember", luItem.Data.Columns(valueColumnNo).ColumnName)

        'End Sub

        Protected Sub CreateDataSourceThread(dataSourceNames As ArrayList)
            Dim luItems As List(Of DataLookup)
            luItems = CreateDataLookups(dataSourceNames)
            For Each luItem As DataLookup In luItems
                luItem.PropertyControl = GetFieldControlName(luItem.PropertyName)
                luItem.Data = luItem.LookUpTask.Result
                Invoker.SetPropertyR(luItem.PropertyControl, "DataSource", luItem.Data)
                Dim displayColumnNo As Integer = 0
                Dim valueColumnNo As Integer = 0
                If luItem.DisplayMember = "Name" Then
                    If luItem.Data.Columns.Count() = 1 Then
                        displayColumnNo = 0
                        valueColumnNo = 0
                    Else
                        displayColumnNo = 1
                    End If
                ElseIf luItem.DisplayMember = "Code" Then
                    If luItem.Data.Columns.Count() = 1 Then
                        displayColumnNo = 0
                    ElseIf luItem.Data.Columns.Count() = 2 Then
                        displayColumnNo = 1
                    Else
                        displayColumnNo = 2
                    End If
                Else
                    If luItem.Data.Columns.Count() = 1 Then
                        displayColumnNo = 0
                    Else
                        displayColumnNo = 1
                    End If
                End If
                If luItem.ValueMember = "Name" Then
                    If luItem.Data.Columns.Count() = 1 Then
                        valueColumnNo = 0
                    Else
                        valueColumnNo = 1
                    End If
                ElseIf luItem.DisplayMember = "Code" Then
                    If luItem.Data.Columns.Count() = 1 Then
                        valueColumnNo = 0
                    ElseIf luItem.Data.Columns.Count() = 2 Then
                        valueColumnNo = 1
                    Else
                        valueColumnNo = 2
                    End If
                Else
                    valueColumnNo = 0
                End If

                Invoker.SetPropertyR(luItem.PropertyControl, "DisplayMember", luItem.Data.Columns(displayColumnNo).ColumnName)
                Invoker.SetPropertyR(luItem.PropertyControl, "ValueMember", luItem.Data.Columns(valueColumnNo).ColumnName)
                'Invoker.SetPropertyR(luItem.PropertyControl, "DisplayMember", "Name") 'luItem.DisplayMember)
                'Invoker.SetPropertyR(luItem.PropertyControl, "ValueMember", luItem.ValueMember)
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

        'Private Function CreateDataLookup(dataSourceName As Array) As DataLookup
        '    Const LookupTableName As Int32 = 0
        '    Const PropertyFieldName As Int32 = 1
        '    Const LookupFieldNames As Int32 = 2
        '    Const LookupFilter As Int32 = 3
        '    Const LookupSortKey As Int32 = 4
        '    Const ValueMember As Int32 = 5
        '    Const DisplayMember As Int32 = 6
        '    Dim lookups As New List(Of DataLookup)
        '    Dim item As Array = dataSourceName
        '    Dim dtl As New DataLookup
        '    dtl.TableName = item(LookupTableName)
        '    dtl.PropertyName = item(PropertyFieldName)
        '    If item.Length - 1 > 1 Then
        '        dtl.LuFields = item(LookupFieldNames)
        '    End If
        '    If item.Length - 1 > 2 Then
        '        dtl.Filter = item(LookupFilter)
        '    End If
        '    If item.Length - 1 > 3 Then
        '        dtl.SortKey = item(LookupSortKey)
        '    End If
        '    If item.Length - 1 > 4 Then
        '        dtl.ValueMember = item(ValueMember)
        '    End If
        '    If item.Length - 1 > 5 Then
        '        dtl.DisplayMember = item(DisplayMember)
        '    End If
        '    ComposeLookupProperties(dtl)
        '    dtl.LookUpTask = Task(Of DataTable).Factory.StartNew(Function() LookupDataTableCreator(dtl))
        '    Return dtl
        'End Function

        Private Function CreateDataLookups(dataSourceNames As ArrayList) As List(Of DataLookup)
            Const LookupTableName As Int32 = 0
            Const PropertyFieldName As Int32 = 1
            Const LookupFieldNames As Int32 = 2
            Const LookupFilter As Int32 = 3
            Const LookupSortKey As Int32 = 4
            Const ValueMember As Int32 = 5
            Const DisplayMember As Int32 = 6
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
                If item.Length - 1 > 4 Then
                    dtl.ValueMember = item(ValueMember)
                End If
                If item.Length - 1 > 5 Then
                    dtl.DisplayMember = item(DisplayMember)
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
                dtl.LuFields = "IdNo, " + dtl.NameDisplayValue + " COLLATE SQL_Latin1_General_CP1_CI_AS As Name"
                dtl.SortKey = dtl.NameField
                dtl.DisplayMember = dtl.NameDisplayValue
            Else
                Dim fieldNames = dtl.LuFields.Split(",")
                If fieldNames.Count() = 1 Then
                    dtl.NameFieldOrig = fieldNames(0)
                    dtl.NameField = TranslateNameField(dtl.TableName, dtl.NameFieldOrig)
                    dtl.NameDisplayValue = dtl.NameField
                    dtl.ValueMember = "Name"
                    dtl.DisplayMember = "Name"
                    dtl.LuFields = dtl.NameField
                    dtl.SortKey = fieldNames(0)
                ElseIf fieldNames.Count() = 2 Then
                    ' assumed the first field is the value member and the second field as the display Value
                    dtl.NameFieldOrig = fieldNames(1)
                    dtl.NameField = TranslateNameField(dtl.TableName, dtl.NameFieldOrig)
                    dtl.NameDisplayValue = "Concat(" + dtl.NameField + ",'-'," + fieldNames(0) + ") COLLATE SQL_Latin1_General_CP1_CI_AS"
                    If dtl.ValueMember Is Nothing Then
                        dtl.ValueMember = fieldNames(0).Trim()
                    End If
                    If dtl.DisplayMember Is Nothing Then
                        dtl.NameDisplayValue = "Concat(" + dtl.NameField + ",'-'," + fieldNames(0) + ") COLLATE SQL_Latin1_General_CP1_CI_AS"
                        dtl.DisplayMember = "IdNo"
                    End If
                    dtl.LuFields = fieldNames(0) + " as IdNo," + dtl.NameDisplayValue + " as Name"
                    If dtl.SortKey Is Nothing Then
                        dtl.SortKey = dtl.NameField
                    End If
                ElseIf fieldNames.Count() = 3 Then
                    dtl.NameField = fieldNames(1).Trim()
                    dtl.NameDisplayValue = "Concat(" + TranslateNameField(dtl.TableName, dtl.NameField) + ",'-'," + fieldNames(2) + ") COLLATE SQL_Latin1_General_CP1_CI_AS"
                    If dtl.ValueMember Is Nothing Then
                        dtl.ValueMember = "IdNo"
                    End If
                    If dtl.DisplayMember Is Nothing Then
                        dtl.DisplayMember = "Name"
                    End If
                    dtl.LuFields = fieldNames(0) + " As IdNo," + dtl.NameDisplayValue + " as Name," + fieldNames(2).ToString() + " as Code"
                    If dtl.SortKey Is Nothing Then
                        dtl.SortKey = dtl.NameField
                    End If
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

        Private Function LookupDataTableCreator(dtl As DataLookup) As DataTable
            Dim cd As New DataCreator(Service)
            Dim data As DataTable = cd.CreateDataTable(dtl)
            'data.Columns(0).ColumnName = "Name"
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

        Protected Sub SetPrinterSupportedSources(pPrinterName As String, ByRef paperSource As Int16?)
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

        Protected Sub SetPrinterSupportedPaperSize(pPrinterName As String, ByRef paperSize As Int16?)
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

        Protected Sub SetPrinterSupportedPaperOrientation(pPrinterName As String, ByRef paperOrientation As Int16?)
            'Dim data = GetPrinterPageInfo(pPrinterName)
            Dim paperOrientationLookup As New List(Of Lookup.LookupData)
            Dim index As Int16 = 0
            Dim dbLookup = New Lookup.LookupData
            dbLookup.IdNo = 0 'CInt(CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation)
            dbLookup.Name = "DefaultPaperOrientation"
            dbLookup.Code = "DefaultPaperOrientation"
            dbLookup.Index = 0 'CInt(CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation)
            paperOrientationLookup.Add(dbLookup)
            dbLookup = New Lookup.LookupData
            dbLookup.IdNo = 1 'CInt(CrystalDecisions.Shared.PaperOrientation.Landscape)
            dbLookup.Name = "Landscape"
            dbLookup.Code = "Landscape"
            dbLookup.Index = 1 'CInt(CrystalDecisions.Shared.PaperOrientation.Landscape)
            paperOrientationLookup.Add(dbLookup)
            dbLookup = New Lookup.LookupData
            dbLookup.IdNo = 2 ' CInt(CrystalDecisions.Shared.PaperOrientation.Portrait)
            dbLookup.Name = "Portrait"
            dbLookup.Code = "Portrait"
            dbLookup.Index = 2 'CInt(CrystalDecisions.Shared.PaperOrientation.Portrait)
            paperOrientationLookup.Add(dbLookup)
            Dim savedDefaultPaperOrientation As Int16? = paperOrientation
            GetControlName("PaperOrientation").DataSource = paperOrientationLookup
            paperOrientation = savedDefaultPaperOrientation
            If savedDefaultPaperOrientation Is Nothing OrElse savedDefaultPaperOrientation = 0 Then
                paperOrientation = 0 'CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation
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