
namespace AATM.Core.Configuration
{
    /// <summary>
/// Defines the contract for a centralized configuration service.
/// </summary>
    public interface IConfigurationService
    {
        /// <summary>
    /// Gets the value for a specified key from the configuration file.
    /// </summary>
    /// <param name="key">The key of the setting to retrieve.</param>
    /// <returns>The value associated with the key, or String.Empty if the key is not found.</returns>
        string GetSetting(string key);
    }
}