#pragma warning disable CS1591
public class TokenResponse
{
    /// <summary>
    /// JWT Token de Autentificação
    /// </summary>
    public string? jwttoken { get; set; }

    /// <summary>
    /// iToken de Autentificação
    /// </summary>
    public string? iToken { get; set; }
}