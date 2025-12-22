using WebAuthn.Net.Services.Common.AuthenticatorDataDecoder.Models.Enums;

namespace WebAuthn.Net.Services.Common.AuthenticatorDataDecoder.Models.Abstractions;

/// <summary>
///     Authenticator Data.
/// </summary>
/// <remarks>
///     <a href="https://www.w3.org/TR/webauthn-3/#sctn-authenticator-data">Web Authentication: An API for accessing Public Key Credentials Level 3 - Authenticator Data</a>
/// </remarks>
public abstract class AbstractAuthenticatorData
{
    /// <summary>
    ///     Raw <a href="https://www.w3.org/TR/webauthn-3/#sctn-authenticator-data">authenticator data</a> value.
    /// </summary>
    public abstract byte[] Raw { get; }

    /// <summary>
    ///     SHA-256 hash of the <a href="https://www.w3.org/TR/webauthn-3/#rp-id">RP ID</a> the <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential">credential</a> is <a href="https://www.w3.org/TR/webauthn-3/#scope">scoped</a> to.
    /// </summary>
    public abstract byte[] RpIdHash { get; }

    /// <summary>
    ///     <a href="https://www.w3.org/TR/webauthn-3/#sctn-authenticator-data">Authenticator data</a> <a href="https://www.w3.org/TR/webauthn-3/#authdata-flags">flags</a>.
    /// </summary>
    public abstract AuthenticatorDataFlags Flags { get; }

    /// <summary>
    ///     <a href="https://www.w3.org/TR/webauthn-3/#signature-counter">Signature counter</a>, 32-bit unsigned big-endian integer.
    /// </summary>
    public abstract uint SignCount { get; }
}
