Public Property FieldName As Decimal Implements IViewInterface.FieldName
    Get
        Return NumParser(Of Decimal)(txtFieldName.Text)
    End Get
    Set
        txtFieldName.Text = FormatDecimalNumber(Value)
    End Set
End Property



Public Property Active As Boolean Implements IViewInterface.Active
    Get
        Return chkActive.Checked
    End Get
    Set
        chkActive.Checked = Value
    End Set
End Property
