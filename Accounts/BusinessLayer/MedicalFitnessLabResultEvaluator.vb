Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports System.Text.RegularExpressions

Namespace BusinessLayer

    Public NotInheritable Class MedicalFitnessLabAssessmentResult

        Public Property Assessment As String
        Public Property SuggestedStatus As String

    End Class

    Public NotInheritable Class MedicalFitnessLabResultEvaluator

        Public Const NormalAssessment As String = "Normal"
        Public Const OutsideRangeAssessment As String = "Outside Range"
        Public Const NeedsReviewAssessment As String = "Needs Review"

        Private Sub New()
        End Sub

        Public Shared Function Evaluate(resultValue As String, referenceValue As String) As MedicalFitnessLabAssessmentResult
            Dim result = If(resultValue, "").Trim()
            Dim reference = If(referenceValue, "").Trim()
            If result = "" OrElse reference = "" Then
                Return CreateResult(NeedsReviewAssessment, Nothing)
            End If

            Dim numericResult As Decimal
            Dim isNormal As Boolean
            If TryParseResultNumber(result, numericResult) AndAlso
               TryEvaluateNumericReference(numericResult, reference, isNormal) Then
                Return If(isNormal,
                          CreateResult(NormalAssessment, "F"),
                          CreateResult(OutsideRangeAssessment, "U"))
            End If

            If TryEvaluateQualitativeReference(result, reference, isNormal) Then
                Return If(isNormal,
                          CreateResult(NormalAssessment, "F"),
                          CreateResult(OutsideRangeAssessment, "U"))
            End If

            Return CreateResult(NeedsReviewAssessment, Nothing)
        End Function

        Private Shared Function CreateResult(assessment As String, suggestedStatus As String) As MedicalFitnessLabAssessmentResult
            Return New MedicalFitnessLabAssessmentResult With {
                .Assessment = assessment,
                .SuggestedStatus = suggestedStatus}
        End Function

        Private Shared Function TryParseResultNumber(value As String, ByRef number As Decimal) As Boolean
            Dim match = Regex.Match(value, "^\s*[<>]?=?\s*([-+]?\d+(?:[\.,]\d+)?)\s*[^\d\-]*$", RegexOptions.CultureInvariant)
            If Not match.Success Then
                Return False
            End If

            Dim normalized = match.Groups(1).Value.Replace(",", ".")
            Return Decimal.TryParse(normalized, NumberStyles.Float, CultureInfo.InvariantCulture, number)
        End Function

        Private Shared Function TryEvaluateNumericReference(value As Decimal, reference As String, ByRef isNormal As Boolean) As Boolean
            Dim candidate = SelectNormalReferenceLine(reference)
            If candidate Is Nothing Then
                Return False
            End If

            Dim rangeMatch = Regex.Match(candidate,
                "([-+]?\d+(?:[\.,]\d+)?)\s*(?:-|–|—|to)\s*([-+]?\d+(?:[\.,]\d+)?)",
                RegexOptions.IgnoreCase Or RegexOptions.CultureInvariant)
            If rangeMatch.Success Then
                Dim minimum As Decimal
                Dim maximum As Decimal
                If TryParseDecimal(rangeMatch.Groups(1).Value, minimum) AndAlso
                   TryParseDecimal(rangeMatch.Groups(2).Value, maximum) Then
                    isNormal = value >= Math.Min(minimum, maximum) AndAlso value <= Math.Max(minimum, maximum)
                    Return True
                End If
            End If

            Dim upperMatch = Regex.Match(candidate,
                "(?:up\s*to|less\s*than|below|<=|≤|<)\s*([-+]?\d+(?:[\.,]\d+)?)",
                RegexOptions.IgnoreCase Or RegexOptions.CultureInvariant)
            If upperMatch.Success Then
                Dim maximum As Decimal
                If TryParseDecimal(upperMatch.Groups(1).Value, maximum) Then
                    Dim strict = Regex.IsMatch(upperMatch.Value, "(?:less\s*than|below|<(?![=]))", RegexOptions.IgnoreCase)
                    isNormal = If(strict, value < maximum, value <= maximum)
                    Return True
                End If
            End If

            Dim lowerMatch = Regex.Match(candidate,
                "(?:at\s*least|more\s*than|greater\s*than|above|>=|≥|>)\s*([-+]?\d+(?:[\.,]\d+)?)",
                RegexOptions.IgnoreCase Or RegexOptions.CultureInvariant)
            If lowerMatch.Success Then
                Dim minimum As Decimal
                If TryParseDecimal(lowerMatch.Groups(1).Value, minimum) Then
                    Dim strict = Regex.IsMatch(lowerMatch.Value, "(?:more\s*than|greater\s*than|above|>(?![=]))", RegexOptions.IgnoreCase)
                    isNormal = If(strict, value > minimum, value >= minimum)
                    Return True
                End If
            End If

            Return False
        End Function

        Private Shared Function SelectNormalReferenceLine(reference As String) As String
            Dim lines = Regex.Split(reference, "\r?\n").
                Select(Function(line) line.Trim()).
                Where(Function(line) line <> "").
                ToList()
            If lines.Count = 0 Then
                Return Nothing
            End If

            Dim normalLine = lines.FirstOrDefault(
                Function(line) Regex.IsMatch(line, "^\s*(normal|desirable)\s*:", RegexOptions.IgnoreCase))
            If normalLine IsNot Nothing Then
                Return normalLine
            End If

            If lines.Count = 1 AndAlso
               Not Regex.IsMatch(lines(0), "\b(male|female|child|children|adult|age|year|month)\b", RegexOptions.IgnoreCase) Then
                Return lines(0)
            End If

            Return Nothing
        End Function

        Private Shared Function TryEvaluateQualitativeReference(result As String, reference As String, ByRef isNormal As Boolean) As Boolean
            If reference.Contains(vbCr) OrElse reference.Contains(vbLf) Then
                Return False
            End If

            Dim normalizedResult = NormalizeQualitativeValue(result)
            Dim normalizedReference = NormalizeQualitativeValue(reference)
            If normalizedResult = "" OrElse normalizedReference = "" Then
                Return False
            End If

            If normalizedResult = normalizedReference Then
                isNormal = True
                Return True
            End If

            Dim negativeValues = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {
                "NEGATIVE", "NON REACTIVE", "NOT DETECTED", "ABSENT"}
            Dim positiveValues = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {
                "POSITIVE", "REACTIVE", "DETECTED", "PRESENT"}

            If negativeValues.Contains(normalizedReference) AndAlso positiveValues.Contains(normalizedResult) Then
                isNormal = False
                Return True
            End If

            Return False
        End Function

        Private Shared Function NormalizeQualitativeValue(value As String) As String
            Dim normalized = Regex.Replace(value.Trim().ToUpperInvariant(), "[_\-]+", " ")
            Return Regex.Replace(normalized, "\s+", " ")
        End Function

        Private Shared Function TryParseDecimal(value As String, ByRef number As Decimal) As Boolean
            Return Decimal.TryParse(value.Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, number)
        End Function

    End Class

End Namespace
