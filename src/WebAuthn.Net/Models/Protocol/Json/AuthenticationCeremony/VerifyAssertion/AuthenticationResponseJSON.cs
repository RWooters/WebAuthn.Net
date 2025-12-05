using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebAuthn.Net.Models.Protocol.Json.AuthenticationCeremony.VerifyAssertion;

/// <summary>
///     PublicKeyCredential
/// </summary>
/// <remarks>
///     <para>
///         <a href="https://www.w3.org/TR/webauthn-3/#iface-pkcredential">Web Authentication: An API for accessing Public Key Credentials Level 3 - PublicKeyCredential Interface</a>
///     </para>
///     <para>
///         <a href="https://www.w3.org/TR/webauthn-3/#sctn-public-key-easy">Web Authentication: An API for accessing Public Key Credentials Level 3 - Easily accessing credential data</a>
///     </para>
/// </remarks>
// ReSharper disable once InconsistentNaming
public class AuthenticationResponseJSON
{
    /// <summary>
    ///     Constructs <see cref="AuthenticationResponseJSON" />.
    /// </summary>
    /// <param name="id">
    ///     <list type="bullet">
    ///         <item>
    ///             <term>
    ///                 <b>
    ///                     <a href="https://www.w3.org/TR/webauthn-3/#ref-for-dom-credential-id">WebAuthn</a>
    ///                 </b>
    ///             </term>
    ///             <description>
    ///                 This attribute is inherited from <a href="https://www.w3.org/TR/credential-management-1/#credential">Credential</a>, though <a href="https://www.w3.org/TR/webauthn-3/#publickeycredential">PublicKeyCredential</a> overrides
    ///                 <a href="https://www.w3.org/TR/credential-management-1/#credential">Credential’s</a> getter, instead returning the <a href="https://www.w3.org/TR/webauthn-3/#base64url-encoding">base64url encoding</a> of the data contained in the object’s
    ///                 <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-identifier-slot">[[identifier]]</a> <a href="https://tc39.github.io/ecma262/#sec-object-internal-methods-and-internal-slots">internal slot</a>.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>
    ///                 <b>
    ///                     <a href="https://www.w3.org/TR/credential-management-1/#dom-credential-id">Credential Management</a>
    ///                 </b>
    ///             </term>
    ///             <description>
    ///                 The credential’s identifier. The requirements for the identifier are distinct for each type of <a href="https://www.w3.org/TR/credential-management-1/#concept-credential">credential</a>. It might represent a username for username/password tuples, for example.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </param>
    /// <param name="rawId">This attribute returns the <a href="https://webidl.spec.whatwg.org/#idl-ArrayBuffer">ArrayBuffer</a> contained in the <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-identifier-slot">[[identifier]]</a> internal slot.</param>
    /// <param name="response">This attribute contains the <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator’s</a> response to the client’s request to generate an <a href="https://www.w3.org/TR/webauthn-3/#authentication-assertion">authentication assertion</a>.</param>
    /// <param name="authenticatorAttachment">
    ///     This attribute reports the <a href="https://www.w3.org/TR/webauthn-3/#authenticator-attachment-modality">authenticator attachment modality</a> in effect at the time the
    ///     <a href="https://www.w3.org/TR/credential-management-1/#dom-credentialscontainer-get">navigator.credentials.get()</a> method successfully complete. The attribute’s value SHOULD be a member of
    ///     <a href="https://www.w3.org/TR/webauthn-3/#enumdef-authenticatorattachment">AuthenticatorAttachment</a>. <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Parties</a> SHOULD treat unknown values as if the value were null.
    /// </param>
    /// <param name="clientExtensionResults">
    ///     The value of <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-clientextensionsresults-slot">[[clientExtensionsResults]]</a>, which is a <a href="https://infra.spec.whatwg.org/#ordered-map">map</a> that holds entries for
    ///     <a href="https://www.w3.org/TR/webauthn-3/#extension-identifier">extension identifier</a> → <a href="https://www.w3.org/TR/webauthn-3/#client-extension-output">client extension output</a> produced by the extension's
    ///     <a href="https://www.w3.org/TR/webauthn-3/#client-extension-processing">client extension processing</a>.
    /// </param>
    /// <param name="type">
    ///     This attribute’s getter returns the value of the object’s <a href="https://webidl.spec.whatwg.org/#dfn-interface-object">interface object’s</a> <a href="https://www.w3.org/TR/credential-management-1/#dom-credential-type-slot">[[type]]</a> slot, which specifies
    ///     the <a href="https://www.w3.org/TR/credential-management-1/#credential-credential-type">credential type</a> represented by this object. The <a href="https://www.w3.org/TR/webauthn-3/#publickeycredential">PublicKeyCredential</a>
    ///     <a href="https://webidl.spec.whatwg.org/#dfn-interface-object">interface object’s</a> <a href="https://www.w3.org/TR/credential-management-1/#dom-credential-type-slot">[[type]]</a>
    ///     <a href="https://tc39.github.io/ecma262/#sec-object-internal-methods-and-internal-slots">internal slot’s</a> value is the string "public-key".
    /// </param>
    public AuthenticationResponseJSON(
        string id,
        string rawId,
        AuthenticatorAssertionResponseJSON response,
        string? authenticatorAttachment,
        Dictionary<string, JsonElement> clientExtensionResults,
        string type)
    {
        Id = id;
        RawId = rawId;
        Response = response;
        AuthenticatorAttachment = authenticatorAttachment;
        ClientExtensionResults = clientExtensionResults;
        Type = type;
    }

    /// <summary>
    ///     <list type="bullet">
    ///         <item>
    ///             <term>
    ///                 <b>
    ///                     <a href="https://www.w3.org/TR/webauthn-3/#ref-for-dom-credential-id">WebAuthn</a>
    ///                 </b>
    ///             </term>
    ///             <description>
    ///                 This attribute is inherited from <a href="https://www.w3.org/TR/credential-management-1/#credential">Credential</a>, though <a href="https://www.w3.org/TR/webauthn-3/#publickeycredential">PublicKeyCredential</a> overrides
    ///                 <a href="https://www.w3.org/TR/credential-management-1/#credential">Credential’s</a> getter, instead returning the <a href="https://www.w3.org/TR/webauthn-3/#base64url-encoding">base64url encoding</a> of the data contained in the object’s
    ///                 <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-identifier-slot">[[identifier]]</a> <a href="https://tc39.github.io/ecma262/#sec-object-internal-methods-and-internal-slots">internal slot</a>.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>
    ///                 <b>
    ///                     <a href="https://www.w3.org/TR/credential-management-1/#dom-credential-id">Credential Management</a>
    ///                 </b>
    ///             </term>
    ///             <description>
    ///                 The credential’s identifier. The requirements for the identifier are distinct for each type of <a href="https://www.w3.org/TR/credential-management-1/#concept-credential">credential</a>. It might represent a username for username/password tuples, for example.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </summary>
    /// <remarks>
    ///     <para>Base64URLString</para>
    /// </remarks>
    [JsonPropertyName("id")]
    [Required]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Id { get; }

    /// <summary>
    ///     This attribute returns the <a href="https://webidl.spec.whatwg.org/#idl-ArrayBuffer">ArrayBuffer</a> contained in the <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-identifier-slot">[[identifier]]</a> internal slot.
    /// </summary>
    /// <remarks>
    ///     <para>Base64URLString</para>
    /// </remarks>
    [JsonPropertyName("rawId")]
    [Required]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string RawId { get; }

    /// <summary>
    ///     This attribute contains the <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator’s</a> response to the client’s request to generate an <a href="https://www.w3.org/TR/webauthn-3/#authentication-assertion">authentication assertion</a>.
    /// </summary>
    [JsonPropertyName("response")]
    [Required]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public AuthenticatorAssertionResponseJSON Response { get; }

    /// <summary>
    ///     This attribute reports the <a href="https://www.w3.org/TR/webauthn-3/#authenticator-attachment-modality">authenticator attachment modality</a> in effect at the time the
    ///     <a href="https://www.w3.org/TR/credential-management-1/#dom-credentialscontainer-get">navigator.credentials.get()</a> method successfully complete. The attribute’s value SHOULD be a member of
    ///     <a href="https://www.w3.org/TR/webauthn-3/#enumdef-authenticatorattachment">AuthenticatorAttachment</a>. <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Parties</a> SHOULD treat unknown values as if the value were null.
    /// </summary>
    /// <remarks>
    ///     <para>DOMString</para>
    ///     <para>
    ///         If, as the result of <a href="https://www.w3.org/TR/webauthn-3/#authentication-ceremony">authentication ceremony</a>, <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-authenticatorattachment">authenticatorAttachment’s</a> value is "cross-platform" and
    ///         concurrently <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-isuserverifyingplatformauthenticatoravailable">isUserVerifyingPlatformAuthenticatorAvailable</a> returns true, then the user employed a
    ///         <a href="https://www.w3.org/TR/webauthn-3/#roaming-authenticators">roaming authenticator</a> for this <a href="https://www.w3.org/TR/webauthn-3/#ceremony">ceremony</a> while there is an available
    ///         <a href="https://www.w3.org/TR/webauthn-3/#platform-authenticators">platform authenticator</a>. Thus the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> has the opportunity to prompt the user to register the available
    ///         <a href="https://www.w3.org/TR/webauthn-3/#platform-authenticators">platform authenticator</a>, which may enable more streamlined user experience flows.
    ///     </para>
    ///     <para>
    ///         An <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator’s</a> <a href="https://www.w3.org/TR/webauthn-3/#authenticator-attachment-modality">attachment modality</a> could change over time. For example, a mobile phone might at one time only support
    ///         <a href="https://www.w3.org/TR/webauthn-3/#platform-attachment">platform attachment</a> but later receive updates to support <a href="https://www.w3.org/TR/webauthn-3/#cross-platform-attachment">cross-platform attachment</a> as well.
    ///     </para>
    /// </remarks>
    [JsonPropertyName("authenticatorAttachment")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? AuthenticatorAttachment { get; }

    /// <summary>
    ///     The value of <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-clientextensionsresults-slot">[[clientExtensionsResults]]</a>, which is a <a href="https://infra.spec.whatwg.org/#ordered-map">map</a> that holds entries for
    ///     <a href="https://www.w3.org/TR/webauthn-3/#extension-identifier">extension identifier</a> → <a href="https://www.w3.org/TR/webauthn-3/#client-extension-output">client extension output</a> produced by the extension's
    ///     <a href="https://www.w3.org/TR/webauthn-3/#client-extension-processing">client extension processing</a>.
    /// </summary>
    [JsonPropertyName("clientExtensionResults")]
    [Required]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public Dictionary<string, JsonElement> ClientExtensionResults { get; }

    /// <summary>
    ///     This attribute’s getter returns the value of the object’s <a href="https://webidl.spec.whatwg.org/#dfn-interface-object">interface object’s</a> <a href="https://www.w3.org/TR/credential-management-1/#dom-credential-type-slot">[[type]]</a> slot, which specifies the
    ///     <a href="https://www.w3.org/TR/credential-management-1/#credential-credential-type">credential type</a> represented by this object. The <a href="https://www.w3.org/TR/webauthn-3/#publickeycredential">PublicKeyCredential</a>
    ///     <a href="https://webidl.spec.whatwg.org/#dfn-interface-object">interface object’s</a> <a href="https://www.w3.org/TR/credential-management-1/#dom-credential-type-slot">[[type]]</a>
    ///     <a href="https://tc39.github.io/ecma262/#sec-object-internal-methods-and-internal-slots">internal slot’s</a> value is the string "public-key".
    /// </summary>
    /// <remarks>
    ///     <para>Always "public-key"</para>
    /// </remarks>
    [JsonPropertyName("type")]
    [Required]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Type { get; }
}
