using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAuthn.Net.Demo.Mvc.ViewModels.Registration;

[method: JsonConstructor]
public class RegistrationParametersViewModel(
    int[] pubKeyCredParams,
    string authenticatorAttachment,
    string residentKey,
    string userVerification,
    string attestation)
{
    // https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialcreationoptions-pubkeycredparams
    [JsonPropertyName("pubKeyCredParams")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public int[] PubKeyCredParams { get; } = pubKeyCredParams;

    /// <summary>
    ///     <para>https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialcreationoptions-authenticatorselection</para>
    ///     <para>https://www.w3.org/TR/webauthn-3/#dom-authenticatorselectioncriteria-authenticatorattachment</para>
    /// </summary>
    [JsonPropertyName("authenticatorAttachment")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public string AuthenticatorAttachment { get; } = authenticatorAttachment;

    /// <summary>
    ///     <para>https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialcreationoptions-authenticatorselection</para>
    ///     <para>https://www.w3.org/TR/webauthn-3/#dom-authenticatorselectioncriteria-residentkey</para>
    /// </summary>
    [JsonPropertyName("residentKey")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public string ResidentKey { get; } = residentKey;

    /// <summary>
    ///     <para>https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialcreationoptions-authenticatorselection</para>
    ///     <para>https://www.w3.org/TR/webauthn-3/#dom-authenticatorselectioncriteria-requireresidentkey</para>
    /// </summary>
    public bool RequireResidentKey => ResidentKey.Equals("required", StringComparison.Ordinal);

    /// <summary>
    ///     <para>https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialcreationoptions-authenticatorselection</para>
    ///     <para>https://www.w3.org/TR/webauthn-3/#dom-authenticatorselectioncriteria-userverification</para>
    /// </summary>
    [JsonPropertyName("userVerification")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public string UserVerification { get; } = userVerification;

    /// <summary>
    ///     https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialcreationoptions-attestation
    /// </summary>
    [JsonPropertyName("attestation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public string Attestation { get; } = attestation;
}
