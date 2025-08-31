Public Interface IUiLocalizationService
    Event UiLanguageChanged(newCulture As Globalization.CultureInfo, isRtl As Boolean)
    ReadOnly Property CurrentCulture As Globalization.CultureInfo
    ReadOnly Property IsRtl As Boolean
    Sub SwitchLanguage(originalUi As Boolean) ' True = unmirrored (LTR), False = mirrored (RTL)
    Sub Translate(Optional force As Boolean = False)
End Interface