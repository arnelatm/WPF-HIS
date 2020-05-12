Public Class ToWord
    ''' Group Levels: 987,654,321.234
    ''' 234 : Group Level -1
    ''' 321 : Group Level 0
    ''' 654 : Group Level 1
    ''' 987 : Group Level 2

#Region "Variables & Properties"

    ''' <summary>
    ''' integer part
    ''' </summary>
    Private _intergerValue As Long

    ''' <summary>
    ''' Decimal Part
    ''' </summary>
    Private _decimalValue As Integer

    ''' <summary>
    ''' Number to be converted
    ''' </summary>
    Public Property Number() As [Decimal]
        Get
            Return _mNumber
        End Get
        Set(ByVal value As [Decimal])
            _mNumber = value
        End Set
    End Property
    Private _mNumber As [Decimal]

    ''' <summary>
    ''' Currency to use
    ''' </summary>
    Public Property Currency As CurrencyInfo

    ''' <summary>
    ''' English text to be placed before the generated text
    ''' </summary>
    Public Property EnglishPrefixText() As [String]
        Get
            Return _mEnglishPrefixText
        End Get
        Set(ByVal value As [String])
            _mEnglishPrefixText = value
        End Set
    End Property
    Private _mEnglishPrefixText As [String]

    ''' <summary>
    ''' English text to be placed after the generated text
    ''' </summary>
    Public Property EnglishSuffixText() As [String]
        Get
            Return _mEnglishSuffixText
        End Get
        Set(ByVal value As [String])
            _mEnglishSuffixText = value
        End Set
    End Property
    Private _mEnglishSuffixText As [String]

    ''' <summary>
    ''' Arabic text to be placed before the generated text
    ''' </summary>
    Public Property ArabicPrefixText() As [String]
        Get
            Return _mArabicPrefixText
        End Get
        Set(ByVal value As [String])
            _mArabicPrefixText = value
        End Set
    End Property
    Private _mArabicPrefixText As [String]

    ''' <summary>
    ''' Arabic text to be placed after the generated text
    ''' </summary>
    Public Property ArabicSuffixText() As [String]
        Get
            Return _mArabicSuffixText
        End Get
        Set(ByVal value As [String])
            _mArabicSuffixText = value
        End Set
    End Property
    Private _mArabicSuffixText As [String]
#End Region

#Region "General"

    ''' <summary>
    ''' Constructor: short version
    ''' </summary>
    ''' <param name="number">Number to be converted</param>
    ''' <param name="currency">Currency to use</param>
    Public Sub New(ByVal number As [Decimal], ByVal currency As CurrencyInfo)
        InitializeClass(number, currency, [String].Empty, "only.", "فقط", $"لا غير")
    End Sub

    ''' <summary>
    ''' Constructor: Full Version
    ''' </summary>
    ''' <param name="number">Number to be converted</param>
    ''' <param name="currency">Currency to use</param>
    ''' <param name="englishPrefixText">English text to be placed before the generated text</param>
    ''' <param name="englishSuffixText">English text to be placed after the generated text</param>
    ''' <param name="arabicPrefixText">Arabic text to be placed before the generated text</param>
    ''' <param name="arabicSuffixText">Arabic text to be placed after the generated text</param>
    Public Sub New(ByVal number As [Decimal], ByVal currency As CurrencyInfo, ByVal englishPrefixText As [String], ByVal englishSuffixText As [String], ByVal arabicPrefixText As [String], ByVal arabicSuffixText As [String])
        InitializeClass(number, currency, englishPrefixText, englishSuffixText, arabicPrefixText, arabicSuffixText)
    End Sub

    ''' <summary>
    ''' Initialize Class Variables
    ''' </summary>
    ''' <param name="number">Number to be converted</param>
    ''' <param name="currency">Currency to use</param>
    ''' <param name="englishPrefixText">English text to be placed before the generated text</param>
    ''' <param name="englishSuffixText">English text to be placed after the generated text</param>
    ''' <param name="arabicPrefixText">Arabic text to be placed before the generated text</param>
    ''' <param name="arabicSuffixText">Arabic text to be placed after the generated text</param>
    Private Sub InitializeClass(ByVal number1 As [Decimal], ByVal currency2 As CurrencyInfo, ByVal englishPrefixText3 As [String], ByVal englishSuffixText4 As [String], ByVal arabicPrefixText5 As [String], ByVal arabicSuffixText6 As [String])
        Number = number1
        Currency = currency2
        EnglishPrefixText = englishPrefixText3
        EnglishSuffixText = englishSuffixText4
        ArabicPrefixText = arabicPrefixText5
        ArabicSuffixText = arabicSuffixText6

        ExtractIntegerAndDecimalParts()
    End Sub

    ''' <summary>
    ''' Get Proper Decimal Value
    ''' </summary>
    ''' <param name="decimalPart">Decimal Part as a String</param>
    ''' <returns></returns>
    Private Function GetDecimalValue(ByVal decimalPart As String) As String
        Dim result As String = [String].Empty

        If Currency.PartPrecision <> decimalPart.Length Then

            Dim decimalPartLength As Integer = decimalPart.Length

            For i = 0 To Currency.PartPrecision - decimalPartLength
                decimalPart += "0" 'Fix for 1 number after decimal ( 10.5 , 1442.2 , 375.4 ) 
            Next

            result = [String].Format("{0}.{1}", decimalPart.Substring(0, Currency.PartPrecision), decimalPart.Substring(Currency.PartPrecision, decimalPart.Length - Currency.PartPrecision))

            result = (Math.Round(Convert.ToDecimal(result))).ToString()
        Else
            result = decimalPart
        End If

        For i As Integer = 0 To Currency.PartPrecision - result.Length - 1
            result += "0"
        Next

        Return result
    End Function

    ''' <summary>
    ''' Eextract Interger and Decimal parts
    ''' </summary>
    Private Sub ExtractIntegerAndDecimalParts()
        Dim splits As [String]() = Number.ToString().Split("."c)

        _intergerValue = Convert.ToInt32(splits(0))

        If splits.Length > 1 Then
            _decimalValue = Convert.ToInt32(GetDecimalValue(splits(1)))
        End If
    End Sub
#End Region

#Region "English Number To Word"

#Region "Variables"

    Private Shared _englishOnes As String() = New String() {"Zero", "One", "Two", "Three", "Four", "Five",
     "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
     "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
     "Eighteen", "Nineteen"}

    Private Shared _englishTens As String() = New String() {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy",
     "Eighty", "Ninety"}

    Private Shared _englishGroup As String() = New String() {"Hundred", "Thousand", "Million", "Billion", "Trillion", "Quadrillion",
     "Quintillion", "Sextillian", "Septillion", "Octillion", "Nonillion", "Decillion",
     "Undecillion", "Duodecillion", "Tredecillion", "Quattuordecillion", "Quindecillion", "Sexdecillion",
     "Septendecillion", "Octodecillion", "Novemdecillion", "Vigintillion", "Unvigintillion", "Duovigintillion",
     "10^72", "10^75", "10^78", "10^81", "10^84", "10^87",
     "Vigintinonillion", "10^93", "10^96", "Duotrigintillion", "Trestrigintillion"}
#End Region

    ''' <summary>
    ''' Process a group of 3 digits
    ''' </summary>
    ''' <param name="groupNumber">The group number to process</param>
    ''' <returns></returns>
    Private Function ProcessGroup(ByVal groupNumber As Integer) As String
        Dim tens As Integer = groupNumber Mod 100

        Dim hundreds As Integer = groupNumber \ 100

        Dim retVal As String = [String].Empty

        If hundreds > 0 Then
            retVal = [String].Format("{0} {1}", _englishOnes(hundreds), _englishGroup(0))
        End If
        If tens > 0 Then
            If tens < 20 Then
                retVal += (If((retVal <> [String].Empty), " ", [String].Empty)) & _englishOnes(tens)
            Else
                Dim ones As Integer = tens Mod 10

                tens = (tens \ 10) - 2
                ' 20's offset
                retVal += (If((retVal <> [String].Empty), " ", [String].Empty)) & _englishTens(tens)

                If ones > 0 Then
                    retVal += (If((retVal <> [String].Empty), " ", [String].Empty)) & _englishOnes(ones)
                End If
            End If
        End If

        Return retVal
    End Function

    ''' <summary>
    ''' Convert stored number to words using selected currency
    ''' </summary>
    ''' <returns></returns>
    Public Function ConvertToEnglish() As String
        Dim tempNumber As [Decimal] = Number

        If tempNumber = 0 Then
            Return "Zero"
        End If

        Dim decimalString As String = ProcessGroup(_decimalValue)

        Dim retVal As String = [String].Empty

        Dim group As Integer = 0

        If tempNumber < 1 Then
            retVal = _englishOnes(0)
        Else
            While tempNumber >= 1
                Dim numberToProcess As Integer = CInt(Math.Truncate(tempNumber Mod 1000))

                tempNumber = tempNumber / 1000

                Dim groupDescription As String = ProcessGroup(numberToProcess)

                If groupDescription <> [String].Empty Then
                    If group > 0 Then
                        retVal = [String].Format("{0} {1}", _englishGroup(group), retVal)
                    End If

                    retVal = [String].Format("{0} {1}", groupDescription, retVal)
                End If

                group += 1
            End While
        End If

        Dim formattedNumber As [String] = [String].Empty
        formattedNumber += If((EnglishPrefixText <> [String].Empty), [String].Format("{0} ", EnglishPrefixText), [String].Empty)
        formattedNumber += If((retVal <> [String].Empty), retVal, [String].Empty)
        formattedNumber += If((retVal <> [String].Empty), (If(_intergerValue = 1, Currency.EnglishCurrencyName, Currency.EnglishPluralCurrencyName)), [String].Empty)
        formattedNumber += If((decimalString <> [String].Empty), " and ", [String].Empty)
        formattedNumber += If((decimalString <> [String].Empty), decimalString, [String].Empty)
        formattedNumber += If((decimalString <> [String].Empty), " " & Convert.ToString((If(_decimalValue = 1, Currency.EnglishCurrencyPartName, Currency.EnglishPluralCurrencyPartName))), [String].Empty)
        formattedNumber += If((EnglishSuffixText <> [String].Empty), [String].Format(" {0}", EnglishSuffixText), [String].Empty)

        Return formattedNumber
    End Function

#End Region

#Region "Arabic Number To Word"

#Region "Variables"

    Private Shared _arabicOnes As String() = New String() {[String].Empty, "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة",
     "ستة", "سبعة", "ثمانية", "تسعة", "عشرة", "أحد عشر",
     "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر",
     "ثمانية عشر", "تسعة عشر"}

    Private Shared _arabicFeminineOnes As String() = New String() {[String].Empty, "إحدى", "اثنتان", "ثلاث", "أربع", "خمس",
     "ست", "سبع", "ثمان", "تسع", "عشر", "إحدى عشرة",
     "اثنتا عشرة", "ثلاث عشرة", "أربع عشرة", "خمس عشرة", "ست عشرة", "سبع عشرة",
     "ثماني عشرة", "تسع عشرة"}

    Private Shared _arabicTens As String() = New String() {"عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون",
     "ثمانون", "تسعون"}

    Private Shared _arabicHundreds As String() = New String() {"", "مائة", "مئتان", "ثلاثمائة", "أربعمائة", "خمسمائة",
     "ستمائة", "سبعمائة", "ثمانمائة", "تسعمائة"}

    Private Shared _arabicAppendedTwos As String() = New String() {"مئتا", "ألفا", "مليونا", "مليارا", "تريليونا", "كوادريليونا",
     "كوينتليونا", "سكستيليونا"}

    Private Shared _arabicTwos As String() = New String() {"مئتان", "ألفان", "مليونان", "ملياران", "تريليونان", "كوادريليونان",
     "كوينتليونان", "سكستيليونان"}

    Private Shared _arabicGroup As String() = New String() {"مائة", "ألف", "مليون", "مليار", "تريليون", "كوادريليون",
     "كوينتليون", "سكستيليون"}

    Private Shared _arabicAppendedGroup As String() = New String() {"", "ألفاً", "مليوناً", "ملياراً", "تريليوناً", "كوادريليوناً",
     "كوينتليوناً", "سكستيليوناً"}

    Private Shared _arabicPluralGroups As String() = New String() {"", "آلاف", "ملايين", "مليارات", "تريليونات", "كوادريليونات",
     "كوينتليونات", "سكستيليونات"}
#End Region

    ''' <summary>
    ''' Get Feminine Status of one digit
    ''' </summary>
    ''' <param name="digit">The Digit to check its Feminine status</param>
    ''' <param name="groupLevel">Group Level</param>
    ''' <returns></returns>
    Private Function GetDigitFeminineStatus(ByVal digit As Integer, ByVal groupLevel As Integer) As String
        If groupLevel = -1 Then
            ' if it is in the decimal part
            If Currency.IsCurrencyPartNameFeminine Then
                Return _arabicFeminineOnes(digit)
            Else
                ' use feminine field
                Return _arabicOnes(digit)
            End If
        ElseIf groupLevel = 0 Then
            If Currency.IsCurrencyNameFeminine Then
                Return _arabicFeminineOnes(digit)
            Else
                ' use feminine field
                Return _arabicOnes(digit)
            End If
        Else
            Return _arabicOnes(digit)
        End If
    End Function

    ''' <summary>
    ''' Process a group of 3 digits
    ''' </summary>
    ''' <param name="groupNumber">The group number to process</param>
    ''' <returns></returns>
    Private Function ProcessArabicGroup(ByVal groupNumber As Integer, ByVal groupLevel As Integer, ByVal remainingNumber As [Decimal]) As String
        Dim tens As Integer = groupNumber Mod 100

        Dim hundreds As Integer = groupNumber \ 100

        Dim retVal As String = [String].Empty

        If hundreds > 0 Then
            If tens = 0 AndAlso hundreds = 2 Then
                ' حالة المضاف
                retVal = [String].Format("{0}", _arabicAppendedTwos(0))
            Else
                '  الحالة العادية
                retVal = [String].Format("{0}", _arabicHundreds(hundreds))
            End If
        End If

        If tens > 0 Then
            If tens < 20 Then
                ' if we are processing under 20 numbers
                If tens = 2 AndAlso hundreds = 0 AndAlso groupLevel > 0 Then
                    ' This is special case for number 2 when it comes alone in the group
                    If _intergerValue = 2000 OrElse _intergerValue = 2000000 OrElse _intergerValue = 2000000000 OrElse _intergerValue = 2000000000000L OrElse _intergerValue = 2000000000000000L OrElse _intergerValue = 2000000000000000000L Then
                        retVal = [String].Format("{0}", _arabicAppendedTwos(groupLevel))
                    Else
                        ' في حالة الاضافة
                        retVal = [String].Format("{0}", _arabicTwos(groupLevel))
                        '  في حالة الافراد
                    End If
                Else
                    ' General case
                    If retVal <> [String].Empty Then
                        retVal += " و "
                    End If

                    If tens = 1 AndAlso groupLevel > 0 AndAlso hundreds = 0 Then
                        retVal += " "
                    ElseIf (tens = 1 OrElse tens = 2) AndAlso (groupLevel = 0 OrElse groupLevel = -1) AndAlso hundreds = 0 AndAlso remainingNumber = 0 Then
                        retVal += [String].Empty
                    Else
                        ' Special case for 1 and 2 numbers like: ليرة سورية و ليرتان سوريتان
                        retVal += GetDigitFeminineStatus(tens, groupLevel)
                        ' Get Feminine status for this digit
                    End If
                End If
            Else
                Dim ones As Integer = tens Mod 10
                tens = (tens \ 10) - 2
                ' 20's offset
                If ones > 0 Then
                    If retVal <> [String].Empty Then
                        retVal += " و "
                    End If

                    ' Get Feminine status for this digit
                    retVal += GetDigitFeminineStatus(ones, groupLevel)
                End If

                If retVal <> [String].Empty Then
                    retVal += " و "
                End If

                ' Get Tens text
                retVal += _arabicTens(tens)
            End If
        End If

        Return retVal
    End Function

    ''' <summary>
    ''' Convert stored number to words using selected currency
    ''' </summary>
    ''' <returns></returns>
    Public Function ConvertToArabic() As String
        Dim tempNumber As [Decimal] = Number

        If tempNumber = 0 Then
            Return "صفر"
        End If

        ' Get Text for the decimal part
        Dim decimalString As String = ProcessArabicGroup(_decimalValue, -1, 0)

        Dim retVal As String = [String].Empty
        Dim group As [Byte] = 0
        While tempNumber >= 1
            ' seperate number into groups
            Dim numberToProcess As Integer = CInt(Math.Truncate(tempNumber Mod 1000))

            tempNumber = tempNumber / 1000

            ' convert group into its text
            Dim groupDescription As String = ProcessArabicGroup(numberToProcess, group, Math.Floor(tempNumber))

            If groupDescription <> [String].Empty Then
                ' here we add the new converted group to the previous concatenated text
                If group > 0 Then
                    If retVal <> [String].Empty Then
                        retVal = [String].Format("{0} {1}", "و", retVal)
                    End If

                    If numberToProcess <> 2 Then
                        If numberToProcess Mod 100 <> 1 Then
                            If numberToProcess >= 3 AndAlso numberToProcess <= 10 Then
                                ' for numbers between 3 and 9 we use plural name
                                retVal = [String].Format("{0} {1}", _arabicPluralGroups(group), retVal)
                            Else
                                If retVal <> [String].Empty Then
                                    ' use appending case
                                    retVal = [String].Format("{0} {1}", _arabicAppendedGroup(group), retVal)
                                Else
                                    retVal = [String].Format("{0} {1}", _arabicGroup(group), retVal)
                                    ' use normal case
                                End If
                            End If
                        Else
                            retVal = [String].Format("{0} {1}", _arabicGroup(group), retVal)
                            ' use normal case
                        End If
                    End If
                End If

                retVal = [String].Format("{0} {1}", groupDescription, retVal)
            End If

            group += 1
        End While

        Dim formattedNumber As [String] = [String].Empty
        formattedNumber += If((ArabicPrefixText <> [String].Empty), [String].Format("{0} ", ArabicPrefixText), [String].Empty)
        formattedNumber += If((retVal <> [String].Empty), retVal, [String].Empty)
        If _intergerValue <> 0 Then
            ' here we add currency name depending on _intergerValue : 1 ,2 , 3--->10 , 11--->99
            Dim remaining100 As Integer = CInt(_intergerValue Mod 100)

            If remaining100 = 0 Then
                formattedNumber += Currency.Arabic1CurrencyName
            ElseIf remaining100 = 1 Then
                formattedNumber += Currency.Arabic1CurrencyName
            ElseIf remaining100 = 2 Then
                If _intergerValue = 2 Then
                    formattedNumber += Currency.Arabic2CurrencyName
                Else
                    formattedNumber += Currency.Arabic1CurrencyName
                End If
            ElseIf remaining100 >= 3 AndAlso remaining100 <= 10 Then
                formattedNumber += Currency.Arabic310CurrencyName
            ElseIf remaining100 >= 11 AndAlso remaining100 <= 99 Then
                formattedNumber += Currency.Arabic1199CurrencyName
            End If
        End If
        formattedNumber += If((_decimalValue <> 0), " و ", [String].Empty)
        formattedNumber += If((_decimalValue <> 0), decimalString, [String].Empty)
        If _decimalValue <> 0 Then
            ' here we add currency part name depending on _intergerValue : 1 ,2 , 3--->10 , 11--->99
            formattedNumber += " "

            Dim remaining100 As Integer = CInt(_decimalValue Mod 100)

            If remaining100 = 0 Then
                formattedNumber += Currency.Arabic1CurrencyPartName
            ElseIf remaining100 = 1 Then
                formattedNumber += Currency.Arabic1CurrencyPartName
            ElseIf remaining100 = 2 Then
                formattedNumber += Currency.Arabic2CurrencyPartName
            ElseIf remaining100 >= 3 AndAlso remaining100 <= 10 Then
                formattedNumber += Currency.Arabic310CurrencyPartName
            ElseIf remaining100 >= 11 AndAlso remaining100 <= 99 Then
                formattedNumber += Currency.Arabic1199CurrencyPartName
            End If
        End If
        formattedNumber += If((ArabicSuffixText <> [String].Empty), [String].Format(" {0}", ArabicSuffixText), [String].Empty)

        Return formattedNumber
    End Function
#End Region
End Class
