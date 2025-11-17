namespace AATM.DataAccess
{
    public interface IScalarQueryRepository
    {
    object ExecuteScalar(string sql, params object[] parameters);
    }
}
