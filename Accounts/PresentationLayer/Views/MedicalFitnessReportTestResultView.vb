Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class MedicalFitnessReportTestResultView
        Implements IView

        Public Property IdNo As Int32
        Public Property MedicalFitnessReportIdNo As Int32
        Public Property SectionCode As String
        Public Property TestCode As String
        Public Property TestNameEnglish As String
        Public Property TestNameArabic As String
        Public Property DisplayOrder As Int32
        Public Property ResultStatus As String
        Public Property ResultText As String
        Public Property Remarks As String
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property DataFilter As String Implements IView.DataFilter

        Public Property IsFit As Boolean
            Get
                Return ResultStatus = "F"
            End Get
            Set(value As Boolean)
                If value Then
                    ResultStatus = "F"
                ElseIf ResultStatus = "F" Then
                    ResultStatus = Nothing
                End If
            End Set
        End Property

        Public Property IsUnfit As Boolean
            Get
                Return ResultStatus = "U"
            End Get
            Set(value As Boolean)
                If value Then
                    ResultStatus = "U"
                ElseIf ResultStatus = "U" Then
                    ResultStatus = Nothing
                End If
            End Set
        End Property

    End Class

End Namespace
