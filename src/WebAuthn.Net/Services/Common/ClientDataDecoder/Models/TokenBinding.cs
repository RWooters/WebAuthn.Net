using WebAuthn.Net.Services.Common.ClientDataDecoder.Models.Enums;

namespace WebAuthn.Net.Services.Common.ClientDataDecoder.Models;

/// <summary>
///     Information about the state of the Token Binding protocol.
/// </summary>
/// <remarks>
///     <a href="https://www.w3.org/TR/webauthn-3/#dom-collectedclientdata-tokenbinding">Web Authentication: An API for accessing Public Key Credentials Level 3 - Client Data Used in WebAuthn Signatures</a>
/// </remarks>
public class TokenBinding
{
    /// <summary>
    ///     Constructs <see cref="TokenBinding" />.
    /// </summary>
    /// <param name="status">
    ///     This member SHOULD be a member of <a href="https://www.w3.org/TR/webauthn-3/#enumdef-tokenbindingstatus">TokenBindingStatus</a> but <a href="https://www.w3.org/TR/webauthn-3/#client-platform">client platforms</a> MUST ignore unknown values, treating an
    ///     unknown value as if the <a href="https://www.w3.org/TR/webauthn-3/#dom-collectedclientdata-tokenbinding">"tokenBinding"</a> <a href="https://infra.spec.whatwg.org/#map-exists">member does not exist</a>.
    /// </param>
    /// <param name="id">This member MUST be present if status is present, and MUST be a base64url encoding of the Token Binding ID that was used when communicating with the Relying Party.</param>
    public TokenBinding(TokenBindingStatus status, byte[]? id)
    {
        Status = status;
        Id = id;
    }

    /// <summary>
    ///     This member SHOULD be a member of <a href="https://www.w3.org/TR/webauthn-3/#enumdef-tokenbindingstatus">TokenBindingStatus</a> but <a href="https://www.w3.org/TR/webauthn-3/#client-platform">client platforms</a> MUST ignore unknown values, treating an unknown value as if
    ///     the <a href="https://www.w3.org/TR/webauthn-3/#dom-collectedclientdata-tokenbinding">"tokenBinding"</a> <a href="https://infra.spec.whatwg.org/#map-exists">member does not exist</a>.
    /// </summary>
    public TokenBindingStatus Status { get; }

    /// <summary>
    ///     This member MUST be present if status is present, and MUST be a base64url encoding of the Token Binding ID that was used when communicating with the Relying Party.
    /// </summary>
    /// <remarks>
    ///     Obtaining a <a href="https://datatracker.ietf.org/doc/html/rfc8471#section-3.2">Token Binding ID</a> is a <a href="https://www.w3.org/TR/webauthn-3/#client-platform">client platform-specific</a> operation.
    /// </remarks>
    public byte[]? Id { get; }
}
