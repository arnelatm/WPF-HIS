' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public MustInherit Class CommonPresenterNew(Of TV As IView, TM As New)
        Inherits PresenterNew(Of TV, TM)

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

        Public Overrides Sub GoAddRecord()
            MyBase.GoAddRecord()
            MakeDefaultValues()
        End Sub

        Public Sub MakeDefaultValues()
            For Each item In ViewDefaultFieldValues
                Select Case item.DataType
                    Case DataTypeSelection.StringType
                        Invoker.SetProperty(View, item.FieldName, item.DefaultValue)
                    Case DataTypeSelection.Accountype
                        Invoker.SetProperty(View, item.FieldName, item.DefaultValue)
                    Case DataTypeSelection.IntegerType
                        Invoker.SetProperty(View, item.FieldName, CInt(item.DefaultValue))
                    Case DataTypeSelection.BooleanType
                        Invoker.SetProperty(View, item.FieldName, CBool(item.DefaultValue))
                    Case DataTypeSelection.SingleType
                        Invoker.SetProperty(View, item.FieldName, CSng(item.DefaultValue))
                    Case DataTypeSelection.DoubleType
                        Invoker.SetProperty(View, item.FieldName, CDbl(item.DefaultValue))
                    Case DataTypeSelection.DecimalType
                        Invoker.SetProperty(View, item.FieldName, CDec(item.DefaultValue))
                    Case DataTypeSelection.LongType
                        Invoker.SetProperty(View, item.FieldName, CLng(item.DefaultValue))
                    Case DataTypeSelection.DateType
                        If item.DefaultValue = "today" Then
                            Invoker.SetProperty(View, item.FieldName, Today())
                        ElseIf item.DefaultValue = "yesterday" Then
                            Invoker.SetProperty(View, item.FieldName, DateTime.Now.AddDays(-1))
                        ElseIf item.DefaultValue = "tomorrow" Then
                            Invoker.SetProperty(View, item.FieldName, DateTime.Now.AddDays(1))
                        Else
                            Invoker.SetProperty(View, item.FieldName, CDate(item.DefaultValue))
                        End If
                    Case DataTypeSelection.ShortType
                        Invoker.SetProperty(View, item.FieldName, CShort(item.DefaultValue))
                    Case DataTypeSelection.UIntegerType
                        Invoker.SetProperty(View, item.FieldName, CUInt(item.DefaultValue))
                    Case DataTypeSelection.ULongType
                        Invoker.SetProperty(View, item.FieldName, CULng(item.DefaultValue))
                    Case DataTypeSelection.UShortType
                        Invoker.SetProperty(View, item.FieldName, CUShort(item.DefaultValue))
                    Case Else
                        MessageBox.Show($"Default Value Datatype Conversion for Field " & item.FieldName & " in form/view " & item.SystemViewName & " conversion not handled")
                End Select
            Next item
            Return
        End Sub

    End Class

End Namespace