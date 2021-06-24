Imports System.ComponentModel
Imports System.Globalization
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
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

        Public Sub New(itemView As IView)
            MyBase.New(itemView)
            Dim systemViewName As String
            If DirectCast(itemView, AATM.Libraries.CBaseControlsLibrary.CForm).ViewDisplayName IsNot Nothing Then
                systemViewName = DirectCast(itemView, AATM.Libraries.CBaseControlsLibrary.CForm).ViewDisplayName.Trim()
            Else
                systemViewName = DirectCast(itemView, System.Windows.Forms.Control).Name.Trim()
            End If
            ViewDefaultFieldValues = ModelDefaultFieldValue.GetDefaultFieldValue(systemViewName)
        End Sub

        Public Shared Property ModelDefaultFieldValue As IModelDefaultFieldValue
        Public Shared Property ViewDefaultFieldValues As List(Of DefaultFieldValueModel)

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
            Return GetLookupByCodeName()
        End Function

        Public Function GetDetailAccountList(Optional ByVal sortKey As String = "AccountCode")
            ComposeLookupParameters("Account")
            LookUpSortExpression = sortKey
            LookUpFilterKey = "DetailAccount=1"
            Return GetLookupByCodeName()
        End Function

        Public Overrides Sub GoAddRecord()
            MyBase.GoAddRecord()
            MakeDefaultValues()
        End Sub

        Public Overridable Sub Initializer(objectName As String, Optional bizParams As Object = Nothing, Optional daoParams As Object = Nothing)
            Dim className = $"AATM.Common.PresentationLayer.Models.ModelCommon"
            TableName = objectName
            SortOrderKey = objectName + "Name"
            Dim ModelOfPresenter As Object
            Dim tType As Type = Type.GetType(className)
            If tType Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + className + "!")
            End If
            If bizParams Is Nothing AndAlso daoParams Is Nothing Then
                ModelOfPresenter = Activator.CreateInstance(tType, {objectName, bizParams, daoParams})
            Else
                ModelOfPresenter = Activator.CreateInstance(tType, {objectName})
            End If
            OriginalModel = New TM
            DataModel = New TM
        End Sub

        Public Overridable Sub InitializerWithTv(baseClassName As String, Optional bizParams As Object = Nothing, Optional daoParams As Object = Nothing)
            TreeViewMainField = baseClassName + "Name"
            TreeViewSecondaryField = baseClassName + "Code"
            TreeViewList = New List(Of TM)
            Initializer(baseClassName, bizParams, daoParams)
        End Sub

        Public Sub MakeDefaultValues()
            For Each item In ViewDefaultFieldValues
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
                        MessageBox.Show($"Default Value Datatype Conversion for Field " & item.FieldName & " in form/view " & item.SystemViewName & " conversion not handled")
                End Select
            Next item
            Return
        End Sub

    End Class

End Namespace