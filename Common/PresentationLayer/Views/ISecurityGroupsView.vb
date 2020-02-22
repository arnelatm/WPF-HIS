Imports AATM.PresentationLayer.Views
Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Views

    ''' represents view of a list of SecurityGroup
    Public Interface ISecurityGroupsView
        Inherits IView

        WriteOnly Property SecurityGroups As IList(Of SecurityGroupModel)
    End Interface

End Namespace