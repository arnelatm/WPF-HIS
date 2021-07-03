' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class CommonPresenterNew(Of T As IView, TM As New)
        Inherits PresenterNew(Of T, TM)

        Private _tableDefaultFieldValueList As List(Of DefaultFieldValueModel)

        Shared Sub New()
            CommonModel = New ModelCommon()
            ModelDefaultFieldValue = New ModelDefaultFieldValue
        End Sub

        Public Sub New(itemView As IView)
            MyBase.New(itemView)
            If itemView IsNot Nothing Then
                Dim systemViewName As String
                If DirectCast(itemView, AATM.Libraries.CBaseControlsLibrary.CForm).ViewDisplayName IsNot Nothing Then
                    systemViewName = DirectCast(itemView, AATM.Libraries.CBaseControlsLibrary.CForm).ViewDisplayName.Trim()
                Else
                    systemViewName = DirectCast(itemView, System.Windows.Forms.Control).Name.Trim()
                End If
                ViewDefaultFieldValues = ModelDefaultFieldValue.GetDefaultFieldValue(systemViewName)
            End If
        End Sub

        Protected Sub New()
            MyBase.New()
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

        Public Sub MakeDefaultValues()
            For Each item In ViewDefaultFieldValues
                Select Case item.DataType
                    Case DataTypeSelection.StringType
                        LateBinding.SetProperty(View, item.FieldName, item.DefaultValue)
                    Case DataTypeSelection.Accountype
                        LateBinding.SetProperty(View, item.FieldName, item.DefaultValue)
                    Case DataTypeSelection.IntegerType
                        LateBinding.SetProperty(View, item.FieldName, CInt(item.DefaultValue))
                    Case DataTypeSelection.BooleanType
                        LateBinding.SetProperty(View, item.FieldName, CBool(item.DefaultValue))
                    Case DataTypeSelection.SingleType
                        LateBinding.SetProperty(View, item.FieldName, CSng(item.DefaultValue))
                    Case DataTypeSelection.DoubleType
                        LateBinding.SetProperty(View, item.FieldName, CDbl(item.DefaultValue))
                    Case DataTypeSelection.DecimalType
                        LateBinding.SetProperty(View, item.FieldName, CDec(item.DefaultValue))
                    Case DataTypeSelection.LongType
                        LateBinding.SetProperty(View, item.FieldName, CLng(item.DefaultValue))
                    Case DataTypeSelection.DateType
                        If item.DefaultValue = "today" Then
                            LateBinding.SetProperty(View, item.FieldName, Today())
                        ElseIf item.DefaultValue = "yesterday" Then
                            LateBinding.SetProperty(View, item.FieldName, DateTime.Now.AddDays(-1))
                        ElseIf item.DefaultValue = "tomorrow" Then
                            LateBinding.SetProperty(View, item.FieldName, DateTime.Now.AddDays(1))
                        Else
                            LateBinding.SetProperty(View, item.FieldName, CDate(item.DefaultValue))
                        End If
                    Case DataTypeSelection.ShortType
                        LateBinding.SetProperty(View, item.FieldName, CShort(item.DefaultValue))
                    Case DataTypeSelection.UIntegerType
                        LateBinding.SetProperty(View, item.FieldName, CUInt(item.DefaultValue))
                    Case DataTypeSelection.ULongType
                        LateBinding.SetProperty(View, item.FieldName, CULng(item.DefaultValue))
                    Case DataTypeSelection.UShortType
                        LateBinding.SetProperty(View, item.FieldName, CUShort(item.DefaultValue))
                    Case Else
                        MessageBox.Show($"Default Value Datatype Conversion for Field " & item.FieldName & " in form/view " & item.SystemViewName & " conversion not handled")
                End Select
            Next item
            Return
        End Sub

    End Class

End Namespace