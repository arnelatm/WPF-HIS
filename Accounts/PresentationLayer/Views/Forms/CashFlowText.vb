Imports System.Globalization

Namespace PresentationLayer.Views.Forms
    Friend Module CashFlowText
        Friend Function GetCaption(key As String) As String
            Dim arabic = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
            Dim en = New Dictionary(Of String, String) From {{"Title", "Statement of Cash Flows"}, {"From", "From"}, {"To", "To"}, {"Load", "Generate"}, {"Accounts", "Cash & Cash Equivalents"}, {"SelectAll", "Select all"}, {"ClearSelection", "Clear selection"}, {"Amount", "Amount"}, {"Basis", "Basis: Posted and unposted"}, {"Reconciled", "Reconciled"}, {"OutOfBalance", "OUT OF BALANCE"}, {"ChooseAndLoad", "Select accounts and generate the statement."}, {"CashFlowLoadFailed", "The cash-flow statement could not be loaded."}, {"CashFlowLoginRequired", "Login is required."}, {"CashFlowSelectAccounts", "Select at least one cash account."}, {"CashFlowInvalidDates", "The From date must not be after the To date."}, {"CashFlowSourceUnavailable", "The source journal is unavailable."}}
            Dim ar = New Dictionary(Of String, String) From {{"Title", "قائمة التدفقات النقدية"}, {"From", "من"}, {"To", "إلى"}, {"Load", "إنشاء"}, {"Accounts", "النقد وما في حكمه"}, {"SelectAll", "تحديد الكل"}, {"ClearSelection", "إلغاء التحديد"}, {"Amount", "المبلغ"}, {"Basis", "الأساس: مرحل وغير مرحل"}, {"Reconciled", "متوازن"}, {"OutOfBalance", "غير متوازن"}, {"ChooseAndLoad", "حدد الحسابات ثم أنشئ القائمة."}, {"CashFlowLoadFailed", "تعذر تحميل قائمة التدفقات النقدية."}, {"CashFlowLoginRequired", "يجب تسجيل الدخول."}, {"CashFlowSelectAccounts", "حدد حساباً نقدياً واحداً على الأقل."}, {"CashFlowInvalidDates", "يجب ألا يسبق تاريخ البداية تاريخ النهاية."}, {"CashFlowSourceUnavailable", "المستند المصدر غير متاح."}}
            Dim value As String = Nothing
            If arabic Then ar.TryGetValue(key, value) Else en.TryGetValue(key, value)
            Return If(value, key)
        End Function
    End Module
End Namespace
