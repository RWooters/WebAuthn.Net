using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAuthn.Net.Services.Common.ClientDataDecoder.Implementation.Models;

/// <summary>
///     Information about the state of the Token Binding protocol.
/// </summary>
/// <remarks>
///     <a href="https://www.w3.org/TR/webauthn-3/#dom-collectedclientdata-tokenbinding">Web Authentication: An API for accessing Public Key Credentials Level 3 - Client Data Used in WebAuthn Signatures</a>
/// </remarks>
public class TokenBindingJson
{
    /// <summary>
    ///     Constructs <see cref="TokenBindingJson" />.
    /// </summary>
    /// <param name="status">
    ///     This member SHOULD be a member of <a href="https://www.w3.org/TR/webauthn-3/#enumdef-tokenbindingstatus">TokenBindingStatus</a> but <a href="https://www.w3.org/TR/webauthn-3/#client-platform">client platforms</a> MUST ignore unknown values, treating an
    ///     unknown value as if the <a href="https://www.w3.org/TR/webauthn-3/#dom-collectedclientdata-tokenbinding">"tokenBinding"</a> <a href="https://infra.spec.whatwg.org/#map-exists">member does not exist</a>.
    /// </param>
    /// <param name="id">This member MUST be present if status is present, and MUST be a base64url encoding of the Token Binding ID that was used when communicating with the Relying Party.</param>
    public TokenBindingJson(string status, string? id)
    {
        Status = status;
        Id = id;
    }

    /// <summary>
    ///     This member SHOULD be a member of <a href="https://www.w3.org/TR/webauthn-3/#enumdef-tokenbindingstatus">TokenBindingStatus</a> but <a href="https://www.w3.org/TR/webauthn-3/#client-platform">client platforms</a> MUST ignore unknown values, treating an unknown value as if
    ///     the <a href="https://www.w3.org/TR/webauthn-3/#dom-collectedclientdata-tokenbinding">"tokenBinding"</a> <a href="https://infra.spec.whatwg.org/#map-exists">member does not exist</a>.
    /// </summary>
    [JsonPropertyName("status")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public string Status { get; }

    /// <summary>
    ///     This member MUST be present if status is present, and MUST be a base64url encoding of the Token Binding ID that was used when communicating with the Relying Party.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Id { get; }
}
