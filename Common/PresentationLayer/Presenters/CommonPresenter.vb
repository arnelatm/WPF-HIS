Imports System.ComponentModel
Imports System.Globalization
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class CommonPresenter(Of T As IView, TM As New)
        Inherits Presenter(Of T, TM)

        Private _tableDefaultFieldValueList As List(Of DefaultFieldValueModel)

        Shared Sub New()
            CommonModel = New ModelCommon()
            ModelDefaultFieldValue = New ModelDefaultFieldValue
        End Sub

        Public Sub New(view As IView)
            MyBase.New(view)
            TableDefaultFieldValues = ModelDefaultFieldValue.GetDefaultFieldValue(TableName)
        End Sub

        Public Shared Property ModelDefaultFieldValue As IModelDefaultFieldValue
        Public Shared Property TableDefaultFieldValues As List(Of DefaultFieldValueModel)

        Private Shared Shadows Property CommonModel As IModelCommon

        Public Function GetAccountTypesList(accountType As String, Optional ByVal sortKey As String = "AccountName")
            ComposeLookupParameters("Account")
            If sortKey IsNot Nothing Then
                LookUpSortExpression = sortKey
            End If
            Dim values = accountType.Split(",")
            LookUpFilterKey = ""
            For Each account In values
                If LookUpFilterKey <> "" Then
                    LookUpFilterKey = LookUpFilterKey + " Or "
                End If
                LookUpFilterKey = LookUpFilterKey + "SpecialAccount = '" & account & "'"
            Next
            Return GetFilteredLookupByCodeName()
        End Function

        Public Function GetDetailAccountList(Optional ByVal sortKey As String = "AccountCode")
            ComposeLookupParameters("Account")
            LookUpSortExpression = sortKey
            LookUpFilterKey = "DetailAccount=1"
            Return GetFilteredLookupByCodeName()
        End Function

        Public Function GetEnumList(Of TE)()
            If EnumConverter Is Nothing Then
                EnumConverter = TypeDescriptor.GetConverter(GetType(TE))
            End If
            Dim dataList As New List(Of ClassesLibrary.LookupData)
            'Dim enumValues = [Enum].GetValues(GetType(TE))
            For Each c In [Enum].GetValues(GetType(TE))
                Dim data As New ClassesLibrary.LookupData With {
                    .IdNo = CInt(c),
                    .Code = EnumToCode(c),
                    .Name = EnumConverter.GetValueText(CultureInfo.CurrentCulture, c)
                }
                dataList.Add(data)
            Next
            Return dataList
        End Function

        Public Overrides Sub GoAddRecord()
            MyBase.GoAddRecord()
            MakeDefaultValues()
        End Sub

        Public Overridable Sub Initializer(baseClassName As String, Optional tableOrViewName As String = Nothing)
            Dim presenterModelName = $"AATM.Common.PresentationLayer.Models.ModelCommon"
            TableName = IIf(tableOrViewName Is Nothing, baseClassName, tableOrViewName)
            SortOrderKey = baseClassName + "Name"
            Dim args As Object() = {baseClassName}
            Dim t As Type = Type.GetType(presenterModelName)
            ModelPresenter = Activator.CreateInstance(t, args)
            OriginalModel = New TM
            DataModel = New TM
        End Sub

        Public Overridable Sub InitializerWithTv(baseClassName As String, Optional tableOrViewName As String = Nothing)
            TreeViewMainField = baseClassName + "Name"
            TreeViewSecondaryField = baseClassName + "Code"
            TreeViewList = New List(Of TM)
            Initializer(baseClassName, tableOrViewName)
        End Sub

        Public Sub MakeDefaultValues()
            For Each item In TableDefaultFieldValues
                Select Case item.DataType
                    Case DataTypeSelection.StringType
                        CallByName(View, item.FieldName, CallType.Set, item.DefaultValue)
                    Case DataTypeSelection.Accountype
                        CallByName(View, item.FieldName, CallType.Set, item.DefaultValue)
                    Case DataTypeSelection.IntegerType
                        CallByName(View, item.FieldName, CallType.Set, CInt(item.DefaultValue))
                    Case DataTypeSelection.BooleanType
                        CallByName(View, item.FieldName, CallType.Set, CBool(item.DefaultValue))
                    Case DataTypeSelection.SingleType
                        CallByName(View, item.FieldName, CallType.Set, CSng(item.DefaultValue))
                    Case DataTypeSelection.DoubleType
                        CallByName(View, item.FieldName, CallType.Set, CDbl(item.DefaultValue))
                    Case DataTypeSelection.DecimalType
                        CallByName(View, item.FieldName, CallType.Set, CDec(item.DefaultValue))
                    Case DataTypeSelection.LongType
                        CallByName(View, item.FieldName, CallType.Set, CLng(item.DefaultValue))
                    Case DataTypeSelection.DateType
                        If item.DefaultValue = "today" Then
                            CallByName(View, item.FieldName, CallType.Set, Today())
                        ElseIf item.DefaultValue = "yesterday" Then
                            CallByName(View, item.FieldName, CallType.Set, DateTime.Now.AddDays(-1))
                        ElseIf item.DefaultValue = "tomorrow" Then
                            CallByName(View, item.FieldName, CallType.Set, DateTime.Now.AddDays(1))
                        Else
                            CallByName(View, item.FieldName, CallType.Set, CDate(item.DefaultValue))
                        End If
                    Case DataTypeSelection.ShortType
                        CallByName(View, item.FieldName, CallType.Set, CShort(item.DefaultValue))
                    Case DataTypeSelection.UIntegerType
                        CallByName(View, item.FieldName, CallType.Set, CUInt(item.DefaultValue))
                    Case DataTypeSelection.ULongType
                        CallByName(View, item.FieldName, CallType.Set, CULng(item.DefaultValue))
                    Case DataTypeSelection.UShortType
                        CallByName(View, item.FieldName, CallType.Set, CUShort(item.DefaultValue))
                    Case Else
                        MessageBox.Show($"Default Value Datatype Conversion for Field " & item.FieldName & " in table " & item.TableName & " conversion not handled")
                End Select
            Next item
            Return
        End Sub

        Public Function MakeEnumComboList(Of TE)()
            Dim dataList As New List(Of ClassesLibrary.LookupData)
            For Each c In [Enum].GetValues(GetType(TE))
                Dim data As New ClassesLibrary.LookupData With {
                    .IdNo = CInt(c),
                    .Code = EnumToCode(c),
                    .Name = Messaging.TranslateCaption(c.ToString().SplitCamelCase())
                }
                dataList.Add(data)
            Next
            Return dataList
        End Function

        Private Sub OnBeforeEdit() Handles MyBase.BeforeEdit
            Dim type As Type = View.GetType
            If type.GetProperty("Posted") IsNot Nothing Then
                Dim cPosted = CallByName(View, "Posted", CallType.Get)
                If cPosted Then
                    Messaging.Show(True, "MsgEditingOfPostedRecordNotAllowed", $"This record has already been posted. Edits not allowed!", "Posted Entry")
                    CancelEdit = True
                End If
            End If
        End Sub

    End Class

End Namespace