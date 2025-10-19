using AATM.Contracts.Dtos;

namespace AATM.DataAccess
{
    public interface ISecurityGroupRepository
    {
        Task<List<SecurityGroupLookupDto>> GetSecurityGroupsLookupAsync();
        // Add other signatures as needed, e.g.:
        // Task<SecurityGroupDto> GetSecurityGroupByIdAsync(int idNo);
        // Task<List<SecurityGroupDto>> GetAllSecurityGroupsAsync();
        // etc.
    }
}   