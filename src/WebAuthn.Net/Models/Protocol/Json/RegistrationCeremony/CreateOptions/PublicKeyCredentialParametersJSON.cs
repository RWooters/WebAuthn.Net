using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAuthn.Net.Models.Protocol.Json.RegistrationCeremony.CreateOptions;

/// <summary>
///     Parameters for Credential Generation (dictionary PublicKeyCredentialParameters)
/// </summary>
/// <remarks>
///     <para>
///         <a href="https://www.w3.org/TR/webauthn-3/#dictionary-credential-params">Web Authentication: An API for accessing Public Key Credentials Level 3 - Parameters for Credential Generation (dictionary PublicKeyCredentialParameters)</a>
///     </para>
///     <para>
///         <a href="https://www.w3.org/TR/webauthn-3/#sctn-parseCreationOptionsFromJSON">Web Authentication: An API for accessing Public Key Credentials Level 3 - Deserialize Registration ceremony options - PublicKeyCredential’s parseCreationOptionsFromJSON() Method</a>
///     </para>
///     <para>
///         <a href="https://www.w3.org/TR/webauthn-3/#dictionary-makecredentialoptions">Web Authentication: An API for accessing Public Key Credentials Level 3 - Options for Credential Creation (dictionary PublicKeyCredentialCreationOptions)</a>
///     </para>
/// </remarks>
// ReSharper disable once InconsistentNaming
public class PublicKeyCredentialParametersJSON
{
    /// <summary>
    ///     Constructs <see cref="PublicKeyCredentialParametersJSON" />.
    /// </summary>
    /// <param name="type">
    ///     This member specifies the type of credential to be created. The value SHOULD be a member of <a href="https://www.w3.org/TR/webauthn-3/#enumdef-publickeycredentialtype">PublicKeyCredentialType</a> but
    ///     <a href="https://www.w3.org/TR/webauthn-3/#client-platform">client platforms</a> MUST ignore unknown values, ignoring any <a href="https://www.w3.org/TR/webauthn-3/#dictdef-publickeycredentialparameters">PublicKeyCredentialParameters</a> with an unknown
    ///     <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialparameters-type">type</a>.
    /// </param>
    /// <param name="alg">This member specifies the cryptographic signature algorithm with which the newly generated credential will be used, and thus also the type of asymmetric key pair to be generated, e.g., RSA or Elliptic Curve.</param>
    public PublicKeyCredentialParametersJSON(string type, int alg)
    {
        Type = type;
        Alg = alg;
    }

    /// <summary>
    ///     This member specifies the type of credential to be created. The value SHOULD be a member of <a href="https://www.w3.org/TR/webauthn-3/#enumdef-publickeycredentialtype">PublicKeyCredentialType</a> but
    ///     <a href="https://www.w3.org/TR/webauthn-3/#client-platform">client platforms</a> MUST ignore unknown values, ignoring any <a href="https://www.w3.org/TR/webauthn-3/#dictdef-publickeycredentialparameters">PublicKeyCredentialParameters</a> with an unknown
    ///     <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialparameters-type">type</a>.
    /// </summary>
    /// <remarks>DOMString</remarks>
    [Required]
    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Type { get; }

    /// <summary>
    ///     This member specifies the cryptographic signature algorithm with which the newly generated credential will be used, and thus also the type of asymmetric key pair to be generated, e.g., RSA or Elliptic Curve.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <a href="https://www.w3.org/TR/webauthn-3/#typedefdef-cosealgorithmidentifier">COSEAlgorithmIdentifier</a>
    ///     </para>
    /// </remarks>
    [Required]
    [JsonPropertyName("alg")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int Alg { get; }
}
