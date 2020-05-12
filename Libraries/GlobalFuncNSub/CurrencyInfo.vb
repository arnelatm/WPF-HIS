Public Class CurrencyInfo
    Public Enum Currencies
        SaudiArabia = 0
        UAE
        Syria
        Tunisia
        Gold
    End Enum

#Region "Constructors"

    Public Sub New(ByVal currency As Currencies)
        Select Case currency

            Case Currencies.SaudiArabia
                CurrencyID = 0
                CurrencyCode = "SAR"
                IsCurrencyNameFeminine = False
                EnglishCurrencyName = "Saudi Riyal"
                EnglishPluralCurrencyName = "Saudi Riyals"
                EnglishCurrencyPartName = "Halala"
                EnglishPluralCurrencyPartName = "Halalas"
                Arabic1CurrencyName = "ريال سعودي"
                Arabic2CurrencyName = "ريالان سعوديان"
                Arabic310CurrencyName = "ريالات سعودية"
                Arabic1199CurrencyName = "ريالاً سعودياً"
                Arabic1CurrencyPartName = "هللة"
                Arabic2CurrencyPartName = "هللتان"
                Arabic310CurrencyPartName = "هللات"
                Arabic1199CurrencyPartName = "هللة"
                PartPrecision = 2
                IsCurrencyPartNameFeminine = True
                Exit Select

            Case Currencies.Syria
                CurrencyID = 2
                CurrencyCode = "SYP"
                IsCurrencyNameFeminine = True
                EnglishCurrencyName = "Syrian Pound"
                EnglishPluralCurrencyName = "Syrian Pounds"
                EnglishCurrencyPartName = "Piaster"
                EnglishPluralCurrencyPartName = "Piasteres"
                Arabic1CurrencyName = "ليرة سورية"
                Arabic2CurrencyName = "ليرتان سوريتان"
                Arabic310CurrencyName = "ليرات سورية"
                Arabic1199CurrencyName = "ليرة سورية"
                Arabic1CurrencyPartName = "قرش"
                Arabic2CurrencyPartName = "قرشان"
                Arabic310CurrencyPartName = "قروش"
                Arabic1199CurrencyPartName = "قرشاً"
                PartPrecision = 2
                IsCurrencyPartNameFeminine = False
                Exit Select

            Case Currencies.UAE
                CurrencyID = 1
                CurrencyCode = "AED"
                IsCurrencyNameFeminine = False
                EnglishCurrencyName = "UAE Dirham"
                EnglishPluralCurrencyName = "UAE Dirhams"
                EnglishCurrencyPartName = "Fils"
                EnglishPluralCurrencyPartName = "Fils"
                Arabic1CurrencyName = "درهم إماراتي"
                Arabic2CurrencyName = "درهمان إماراتيان"
                Arabic310CurrencyName = "دراهم إماراتية"
                Arabic1199CurrencyName = "درهماً إماراتياً"
                Arabic1CurrencyPartName = "فلس"
                Arabic2CurrencyPartName = "فلسان"
                Arabic310CurrencyPartName = "فلوس"
                Arabic1199CurrencyPartName = "فلساً"
                PartPrecision = 2
                IsCurrencyPartNameFeminine = False
                Exit Select


            Case Currencies.Tunisia
                CurrencyID = 3
                CurrencyCode = "TND"
                IsCurrencyNameFeminine = False
                EnglishCurrencyName = "Tunisian Dinar"
                EnglishPluralCurrencyName = "Tunisian Dinars"
                EnglishCurrencyPartName = "milim"
                EnglishPluralCurrencyPartName = "millimes"
                Arabic1CurrencyName = "دينار تونسي"
                Arabic2CurrencyName = "ديناران تونسيان"
                Arabic310CurrencyName = "دنانير تونسية"
                Arabic1199CurrencyName = "ديناراً تونسياً"
                Arabic1CurrencyPartName = "مليم"
                Arabic2CurrencyPartName = "مليمان"
                Arabic310CurrencyPartName = "ملاليم"
                Arabic1199CurrencyPartName = "مليماً"
                PartPrecision = 3
                IsCurrencyPartNameFeminine = False
                Exit Select

            Case Currencies.Gold
                CurrencyID = 4
                CurrencyCode = "XAU"
                IsCurrencyNameFeminine = False
                EnglishCurrencyName = "Gram"
                EnglishPluralCurrencyName = "Grams"
                EnglishCurrencyPartName = "Milligram"
                EnglishPluralCurrencyPartName = "Milligrams"
                Arabic1CurrencyName = "جرام"
                Arabic2CurrencyName = "جرامان"
                Arabic310CurrencyName = "جرامات"
                Arabic1199CurrencyName = "جراماً"
                Arabic1CurrencyPartName = "ملجرام"
                Arabic2CurrencyPartName = "ملجرامان"
                Arabic310CurrencyPartName = "ملجرامات"
                Arabic1199CurrencyPartName = "ملجراماً"
                PartPrecision = 2
                IsCurrencyPartNameFeminine = False
                Exit Select

        End Select
    End Sub

#End Region

#Region "Properties"

    ''' <summary>
    ''' Currency ID
    ''' </summary>
    Public Property CurrencyID As Integer

    ''' <summary>
    ''' Standard Code
    ''' Syrian Pound: SYP
    ''' UAE Dirham: AED
    ''' </summary>
    Public Property CurrencyCode As String

    ''' <summary>
    ''' Is the currency name feminine ( Mua'anath مؤنث)
    ''' ليرة سورية : مؤنث = true
    ''' درهم : مذكر = false
    ''' </summary>
    Public Property IsCurrencyNameFeminine As [Boolean]

    ''' <summary>
    ''' English Currency Name for single use
    ''' Syrian Pound
    ''' UAE Dirham
    ''' </summary>
    Public Property EnglishCurrencyName As String

    ''' <summary>
    ''' English Plural Currency Name for Numbers over 1
    ''' Syrian Pounds
    ''' UAE Dirhams
    ''' </summary>
    Public Property EnglishPluralCurrencyName As String

    ''' <summary>
    ''' Arabic Currency Name for 1 unit only
    ''' ليرة سورية
    ''' درهم إماراتي
    ''' </summary>
    Public Property Arabic1CurrencyName As String

    ''' <summary>
    ''' Arabic Currency Name for 2 units only
    ''' ليرتان سوريتان
    ''' درهمان إماراتيان
    ''' </summary>
    Public Property Arabic2CurrencyName As String

    ''' <summary>
    ''' Arabic Currency Name for 3 to 10 units
    ''' خمس ليرات سورية
    ''' خمسة دراهم إماراتية
    ''' </summary>
    Public Property Arabic310CurrencyName As String

    ''' <summary>
    ''' Arabic Currency Name for 11 to 99 units
    ''' خمس و سبعون ليرةً سوريةً
    ''' خمسة و سبعون درهماً إماراتياً
    ''' </summary>
    Public Property Arabic1199CurrencyName As String

    ''' <summary>
    ''' Decimal Part Precision
    ''' for Syrian Pounds: 2 ( 1 SP = 100 parts)
    ''' for Tunisian Dinars: 3 ( 1 TND = 1000 parts)
    ''' </summary>
    Public Property PartPrecision As [Byte]

    ''' <summary>
    ''' Is the currency part name feminine ( Mua'anath مؤنث)
    ''' هللة : مؤنث = true
    ''' قرش : مذكر = false
    ''' </summary>
    Public Property IsCurrencyPartNameFeminine As [Boolean]

    ''' <summary>
    ''' English Currency Part Name for single use
    ''' Piaster
    ''' Fils
    ''' </summary>
    Public Property EnglishCurrencyPartName As String

    ''' <summary>
    ''' English Currency Part Name for Plural
    ''' Piasters
    ''' Fils
    ''' </summary>
    Public Property EnglishPluralCurrencyPartName As String

    ''' <summary>
    ''' Arabic Currency Part Name for 1 unit only
    ''' قرش
    ''' هللة
    ''' </summary>
    Public Property Arabic1CurrencyPartName As String

    ''' <summary>
    ''' Arabic Currency Part Name for 2 unit only
    ''' قرشان
    ''' هللتان
    ''' </summary>
    Public Property Arabic2CurrencyPartName As String

    ''' <summary>
    ''' Arabic Currency Part Name for 3 to 10 units
    ''' قروش
    ''' هللات
    ''' </summary>
    Public Property Arabic310CurrencyPartName As String

    ''' <summary>
    ''' Arabic Currency Part Name for 11 to 99 units
    ''' قرشاً
    ''' هللةً
    ''' </summary>
    Public Property Arabic1199CurrencyPartName As String

#End Region
End Class
