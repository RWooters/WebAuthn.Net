using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAuthn.Net.Models.Protocol.Json;

/// <summary>
///     Credential Descriptor (dictionary PublicKeyCredentialDescriptor)
/// </summary>
/// <remarks>
///     <a href="https://www.w3.org/TR/webauthn-3/#dictionary-credential-descriptor">Web Authentication: An API for accessing Public Key Credentials Level 3 - Credential Descriptor (dictionary PublicKeyCredentialDescriptor)</a>
/// </remarks>
// ReSharper disable once InconsistentNaming
public class PublicKeyCredentialDescriptorJSON
{
    /// <summary>
    ///     Constructs <see cref="PublicKeyCredentialDescriptorJSON" />.
    /// </summary>
    /// <param name="type">
    ///     <para>
    ///         This member contains the type of the <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential">public key credential</a> the caller is referring to. The value SHOULD be a member of
    ///         <a href="https://www.w3.org/TR/webauthn-3/#enumdef-publickeycredentialtype">PublicKeyCredentialType</a> but <a href="https://www.w3.org/TR/webauthn-3/#client-platform">client platforms</a> MUST ignore any
    ///         <a href="https://www.w3.org/TR/webauthn-3/#dictdef-publickeycredentialdescriptor">PublicKeyCredentialDescriptor</a> with an unknown <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialdescriptor-type">type</a>.
    ///     </para>
    ///     <para>
    ///         This SHOULD be set to the value of the <a href="https://www.w3.org/TR/webauthn-3/#abstract-opdef-credential-record-type">"type"</a> item of the <a href="https://www.w3.org/TR/webauthn-3/#credential-record">credential record</a> representing the identified
    ///         <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential-source">public key credential source</a>. This mirrors the <a href="https://www.w3.org/TR/credential-management-1/#dom-credential-type">"type"</a> field of
    ///         <a href="https://www.w3.org/TR/webauthn-3/#publickeycredential">PublicKeyCredential</a>.
    ///     </para>
    /// </param>
    /// <param name="id">
    ///     <para>This member contains the <a href="https://www.w3.org/TR/webauthn-3/#credential-id">credential ID</a> of the <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential">public key credential</a> the caller is referring to.</para>
    ///     <para>
    ///         This SHOULD be set to the value of the <a href="https://www.w3.org/TR/webauthn-3/#abstract-opdef-credential-record-id">"id"</a> item of the <a href="https://www.w3.org/TR/webauthn-3/#credential-record">credential record</a> representing the identified
    ///         <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential-source">public key credential source</a>. This mirrors the <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-rawid">"rawId"</a> field of
    ///         <a href="https://www.w3.org/TR/webauthn-3/#publickeycredential">PublicKeyCredential</a>.
    ///     </para>
    /// </param>
    /// <param name="transports">
    ///     <para>
    ///         This OPTIONAL member contains a hint as to how the <a href="https://www.w3.org/TR/webauthn-3/#client">client</a> might communicate with the <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential-source-managing-authenticator">managing authenticator</a> of the
    ///         <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential">public key credential</a> the caller is referring to. The values SHOULD be members of <a href="https://www.w3.org/TR/webauthn-3/#enumdef-authenticatortransport">AuthenticatorTransport</a> but
    ///         <a href="https://www.w3.org/TR/webauthn-3/#client-platform">client platforms</a> MUST ignore unknown values.
    ///     </para>
    ///     <para>
    ///         This SHOULD be set to the value of the <a href="https://www.w3.org/TR/webauthn-3/#abstract-opdef-credential-record-transports">"transports"</a> item of the <a href="https://www.w3.org/TR/webauthn-3/#credential-record">credential record</a> representing the identified
    ///         <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential-source">public key credential source</a>.
    ///         This mirrors the <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-response">response</a>.<a href="https://www.w3.org/TR/webauthn-3/#dom-authenticatorattestationresponse-gettransports">getTransports()</a>
    ///         method of the <a href="https://www.w3.org/TR/webauthn-3/#publickeycredential">PublicKeyCredential</a> structure created by a <a href="https://www.w3.org/TR/credential-management-1/#dom-credentialscontainer-create">create()</a> operation.
    ///     </para>
    /// </param>
    public PublicKeyCredentialDescriptorJSON(string type, string id, string[]? transports)
    {
        Type = type;
        Id = id;
        Transports = transports;
    }

    /// <summary>
    ///     <para>
    ///         This member contains the type of the <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential">public key credential</a> the caller is referring to. The value SHOULD be a member of
    ///         <a href="https://www.w3.org/TR/webauthn-3/#enumdef-publickeycredentialtype">PublicKeyCredentialType</a> but <a href="https://www.w3.org/TR/webauthn-3/#client-platform">client platforms</a> MUST ignore any
    ///         <a href="https://www.w3.org/TR/webauthn-3/#dictdef-publickeycredentialdescriptor">PublicKeyCredentialDescriptor</a> with an unknown <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialdescriptor-type">type</a>.
    ///     </para>
    ///     <para>
    ///         This SHOULD be set to the value of the <a href="https://www.w3.org/TR/webauthn-3/#abstract-opdef-credential-record-type">"type"</a> item of the <a href="https://www.w3.org/TR/webauthn-3/#credential-record">credential record</a> representing the identified
    ///         <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential-source">public key credential source</a>. This mirrors the <a href="https://www.w3.org/TR/credential-management-1/#dom-credential-type">"type"</a> field of
    ///         <a href="https://www.w3.org/TR/webauthn-3/#publickeycredential">PublicKeyCredential</a>.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     <para>DOMString</para>
    /// </remarks>
    [JsonPropertyName("type")]
    [Required]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Type { get; }

    /// <summary>
    ///     <para>This member contains the <a href="https://www.w3.org/TR/webauthn-3/#credential-id">credential ID</a> of the <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential">public key credential</a> the caller is referring to.</para>
    ///     <para>
    ///         This SHOULD be set to the value of the <a href="https://www.w3.org/TR/webauthn-3/#abstract-opdef-credential-record-id">"id"</a> item of the <a href="https://www.w3.org/TR/webauthn-3/#credential-record">credential record</a> representing the identified
    ///         <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential-source">public key credential source</a>. This mirrors the <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-rawid">"rawId"</a> field of
    ///         <a href="https://www.w3.org/TR/webauthn-3/#publickeycredential">PublicKeyCredential</a>.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     <para>Base64URLString</para>
    /// </remarks>
    [JsonPropertyName("id")]
    [Required]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Id { get; }

    /// <summary>
    ///     <para>
    ///         This OPTIONAL member contains a hint as to how the <a href="https://www.w3.org/TR/webauthn-3/#client">client</a> might communicate with the <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential-source-managing-authenticator">managing authenticator</a> of the
    ///         <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential">public key credential</a> the caller is referring to. The values SHOULD be members of <a href="https://www.w3.org/TR/webauthn-3/#enumdef-authenticatortransport">AuthenticatorTransport</a> but
    ///         <a href="https://www.w3.org/TR/webauthn-3/#client-platform">client platforms</a> MUST ignore unknown values.
    ///     </para>
    ///     <para>
    ///         This SHOULD be set to the value of the <a href="https://www.w3.org/TR/webauthn-3/#abstract-opdef-credential-record-transports">"transports"</a> item of the <a href="https://www.w3.org/TR/webauthn-3/#credential-record">credential record</a> representing the identified
    ///         <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential-source">public key credential source</a>.
    ///         This mirrors the <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-response">response</a>.<a href="https://www.w3.org/TR/webauthn-3/#dom-authenticatorattestationresponse-gettransports">getTransports()</a>
    ///         method of the <a href="https://www.w3.org/TR/webauthn-3/#publickeycredential">PublicKeyCredential</a> structure created by a <a href="https://www.w3.org/TR/credential-management-1/#dom-credentialscontainer-create">create()</a> operation.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     <para>DOMString</para>
    /// </remarks>
    [JsonPropertyName("transports")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string[]? Transports { get; }
}
