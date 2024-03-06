namespace Aire.Sdk.Platform.Clients;

public interface IAireMemoryClient
{
    /// <summary>
    /// Destroys or anonymizes all user data
    /// </summary>
    /// <param name="anonymize">Set to true to anoymize</param>
    /// <returns>True if successful, otherwise false</returns>
    public abstract Task<bool> DestroyUserData(bool anonymize);
}
