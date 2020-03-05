Imports AATM.PresentationLayer.Models

''' represents view of a list of SecurityGroup
Public Interface ISecurityGroupsView
    Inherits IView

    WriteOnly Property SecurityGroups As IList(Of SecurityGroupModel)
End Interface