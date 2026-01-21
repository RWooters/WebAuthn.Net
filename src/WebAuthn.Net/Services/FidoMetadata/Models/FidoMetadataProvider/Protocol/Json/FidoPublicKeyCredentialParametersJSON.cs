using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAuthn.Net.Services.FidoMetadata.Models.FidoMetadataProvider.Protocol.Json;

/// <summary>
///     <a href="https://www.w3.org/TR/webauthn-3/#dictionary-credential-params">Parameters for Credential Generation</a> used in FIDO Metadata Service
/// </summary>

// ReSharper disable once InconsistentNaming
public class FidoPublicKeyCredentialParametersJSON
{
    /// <summary>
    ///     Constructs <see cref="FidoPublicKeyCredentialParametersJSON" />.
    /// </summary>
    /// <param name="type">
    ///     This member specifies the type of credential to be created. The value SHOULD be a member of <a href="https://w3c.github.io/webauthn/#enumdef-publickeycredentialtype">PublicKeyCredentialType</a> but
    ///     <a href="https://w3c.github.io/webauthn/#client-platform">client platforms</a> MUST ignore unknown values, ignoring any <a href="https://w3c.github.io/webauthn/#dictdef-publickeycredentialparameters">PublicKeyCredentialParameters</a> with an unknown
    ///     <a href="https://w3c.github.io/webauthn/#dom-publickeycredentialparameters-type">type</a>.
    /// </param>
    /// <param name="alg">This member specifies the cryptographic signature algorithm with which the newly generated credential will be used, and thus also the type of asymmetric key pair to be generated, e.g., RSA or Elliptic Curve.</param>
    [JsonConstructor]
    public FidoPublicKeyCredentialParametersJSON(string type, int alg)
    {
        Type = type;
        Alg = alg;
    }

    /// <summary>
    ///     This member specifies the type of credential to be created. The value SHOULD be a member of <a href="https://w3c.github.io/webauthn/#enumdef-publickeycredentialtype">PublicKeyCredentialType</a> but
    ///     <a href="https://w3c.github.io/webauthn/#client-platform">client platforms</a> MUST ignore unknown values, ignoring any <a href="https://w3c.github.io/webauthn/#dictdef-publickeycredentialparameters">PublicKeyCredentialParameters</a> with an unknown
    ///     <a href="https://w3c.github.io/webauthn/#dom-publickeycredentialparameters-type">type</a>.
    /// </summary>
    [JsonPropertyName("type")]
    [Required]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Type { get; }

    /// <summary>
    ///     This member specifies the cryptographic signature algorithm with which the newly generated credential will be used, and thus also the type of asymmetric key pair to be generated, e.g., RSA or Elliptic Curve.
    /// </summary>
    [JsonPropertyName("alg")]
    [Required]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int Alg { get; }
}
