Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    'Public Interface ICbcRetrievalView
    '    Inherits IView

    '    Property InvoiceNo As String
    '    Property InvoiceType As String
    '    Property InvoiceDate As Date
    '    Property PatientNameEnglish As String
    '    Property PatientName As String
    '    Property Age As Int16
    '    Property AgeYMD As String
    '    Property Sex As String
    '    Property Wbc As String
    '    Property NE As String
    '    Property Ly As String
    '    Property Mo As String
    '    Property Eo As String
    '    Property Ba As String
    '    Property Rbc As String
    '    Property Hgb As String
    '    Property Hct As String
    '    Property Mcv As String
    '    Property Mch As String
    '    Property Mchc As String
    '    Property Rdwcv As String
    '    Property Rdwcd As String
    '    Property Plt As String
    '    Property Pct As String
    '    Property Mpv As String
    '    Property Pdw As String
    '    Property WbcNv As String
    '    Property NENv As String
    '    Property LyNv As String
    '    Property MoNv As String
    '    Property EoNv As String
    '    Property BaNv As String
    '    Property RbcNv As String
    '    Property HgbNv As String
    '    Property HctNv As String
    '    Property McvNv As String
    '    Property MchNv As String
    '    Property MchcNv As String
    '    Property RdwcvNv As String
    '    Property RdwcdNv As String
    '    Property PltNv As String
    '    Property PctNv As String
    '    Property MpvNv As String
    '    Property PdwNv As String
    '    Property WbcR As String
    '    Property NeR As String
    '    Property LyR As String
    '    Property MoR As String
    '    Property EoR As String
    '    Property BaR As String
    '    Property RbcR As String
    '    Property HgbR As String
    '    Property HctR As String
    '    Property McvR As String
    '    Property MchR As String
    '    Property MchcR As String
    '    Property RdwcvR As String
    '    Property RdwcdR As String
    '    Property PltR As String
    '    Property PctR As String
    '    Property MpvR As String
    '    Property PdwR As String
    '    Property WbcRNv As String
    '    Property NeRNv As String
    '    Property LyRNv As String
    '    Property MoRNv As String
    '    Property EoRNv As String
    '    Property BaRNv As String
    '    Property RbcRNv As String
    '    Property HgbRNv As String
    '    Property HctRNv As String
    '    Property McvRNv As String
    '    Property MchRNv As String
    '    Property MchcRNv As String
    '    Property RdwcvRNv As String
    '    Property RdwcdRNv As String
    '    Property PltRNv As String
    '    Property PctRNv As String
    '    Property MpvRNv As String
    '    Property PdwRNv As String
    '    Property Remarks As String
    '    Property LabInvoiceDetails As List(Of Lab_InvoiceDetailsView)
    '    Event RetrieveLabResultRequested()
    'End Interface

    Public Interface ILab_InvoiceGroupView
        Inherits IView

        Property InvoiceNo As Decimal
        Property InvoiceType As String
        Property InvoiceDate As Date
        Property PatientNameEnglish As String
        Property PatientName As String
        Property Age As Decimal
        Property AgeYMD As String
        Property Sex As String
        Property RegistrationNo as Decimal
        Property SampleNo as String
        Property Status as Int32
        Property Wbc As String
        Property NE As String
        Property Ly As String
        Property Mo As String
        Property Eo As String
        Property Ba As String
        Property Rbc As String
        Property Hgb As String
        Property Hct As String
        Property Mcv As String
        Property Mch As String
        Property Mchc As String
        Property Rdwcv As String
        Property Rdwcd As String
        Property Plt As String
        Property Pct As String
        Property Mpv As String
        Property Pdw As String
        Property WbcNv As String
        Property NENv As String
        Property LyNv As String
        Property MoNv As String
        Property EoNv As String
        Property BaNv As String
        Property RbcNv As String
        Property HgbNv As String
        Property HctNv As String
        Property McvNv As String
        Property MchNv As String
        Property MchcNv As String
        Property RdwcvNv As String
        Property RdwcdNv As String
        Property PltNv As String
        Property PctNv As String
        Property MpvNv As String
        Property PdwNv As String
        Property WbcR As String
        Property NeR As String
        Property LyR As String
        Property MoR As String
        Property EoR As String
        Property BaR As String
        Property RbcR As String
        Property HgbR As String
        Property HctR As String
        Property McvR As String
        Property MchR As String
        Property MchcR As String
        Property RdwcvR As String
        Property RdwcdR As String
        Property PltR As String
        Property PctR As String
        Property MpvR As String
        Property PdwR As String
        Property WbcRNv As String
        Property NeRNv As String
        Property LyRNv As String
        Property MoRNv As String
        Property EoRNv As String
        Property BaRNv As String
        Property RbcRNv As String
        Property HgbRNv As String
        Property HctRNv As String
        Property McvRNv As String
        Property MchRNv As String
        Property MchcRNv As String
        Property RdwcvRNv As String
        Property RdwcdRNv As String
        Property PltRNv As String
        Property PctRNv As String
        Property MpvRNv As String
        Property PdwRNv As String
        Property Remarks As String
        Property LabInvoiceDetails As List(Of Lab_InvoiceDetailsView)
        Event RetrieveLabResultRequested()
    End Interface

    Public Interface ILab_InvoiceDetailsView
        Inherits IView
        Property Group_Key As Decimal
        Property SlNo As Decimal
        Property Diagnosis1 As String
        Property Result1 As String
        Property Suffix1 As String
    End Interface

End Namespace