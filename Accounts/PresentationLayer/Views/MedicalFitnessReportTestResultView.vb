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
        Public Property Sequence As Int32

        Public Property DisplayOrder As Int32
            Get
                Return Sequence
            End Get
            Set(value As Int32)
                Sequence = value
            End Set
        End Property

        Public Property ResultStatus As String
        Public Property ResultText As String
        Public Property LabResult As String
        Public Property LabReferenceValue As String
        Public Property LabUnit As String
        Public Property LabAssessment As String
        Public Property ResultStatusSource As String
        Public Property Remarks As String
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property DataFilter As String Implements IView.DataFilter

        Public ReadOnly Property IsResultTextOnly As Boolean
            Get
                Return String.Equals(TestCode, "HEIGHT", StringComparison.OrdinalIgnoreCase) OrElse
                       String.Equals(TestCode, "WEIGHT", StringComparison.OrdinalIgnoreCase)
            End Get
        End Property

        Public ReadOnly Property ResultStatusSourceDisplay As String
            Get
                If String.Equals(ResultStatusSource, "A", StringComparison.OrdinalIgnoreCase) Then
                    Return "Automatic"
                End If
                If String.Equals(ResultStatusSource, "M", StringComparison.OrdinalIgnoreCase) Then
                    Return "Manual"
                End If
                Return ""
            End Get
        End Property

        Public Property IsFit As Boolean
            Get
                Return Not IsResultTextOnly AndAlso ResultStatus = "F"
            End Get
            Set(value As Boolean)
                If IsResultTextOnly Then
                    ResultStatus = Nothing
                    Return
                End If

                If value Then
                    ResultStatus = "F"
                    ResultStatusSource = "M"
                ElseIf ResultStatus = "F" Then
                    ResultStatus = Nothing
                    ResultStatusSource = "M"
                End If
            End Set
        End Property

        Public Property IsUnfit As Boolean
            Get
                Return Not IsResultTextOnly AndAlso ResultStatus = "U"
            End Get
            Set(value As Boolean)
                If IsResultTextOnly Then
                    ResultStatus = Nothing
                    Return
                End If

                If value Then
                    ResultStatus = "U"
                    ResultStatusSource = "M"
                ElseIf ResultStatus = "U" Then
                    ResultStatus = Nothing
                    ResultStatusSource = "M"
                End If
            End Set
        End Property

    End Class

End Namespace
