using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebAuthn.Net.Demo.Mvc.Constants;
using WebAuthn.Net.Demo.Mvc.Extensions;
using WebAuthn.Net.Models.Protocol.Enums;
using WebAuthn.Net.Models.Protocol.RegistrationCeremony.CreateOptions;
using WebAuthn.Net.Services.RegistrationCeremony.Models.CreateOptions;
using WebAuthn.Net.Services.Serialization.Cose.Models.Enums;

namespace WebAuthn.Net.Demo.Mvc.ViewModels.Registration;

[method: JsonConstructor]
public class CreateRegistrationOptionsViewModel(
    string userName,
    RegistrationParametersViewModel registrationParameters,
    Dictionary<string, JsonElement>? extensions)
{
    [JsonPropertyName("username")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public string UserName { get; } = userName;

    [JsonPropertyName("registrationParameters")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [Required]
    public RegistrationParametersViewModel RegistrationParameters { get; } = registrationParameters;

    [JsonPropertyName("extensions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Dictionary<string, JsonElement>? Extensions { get; } = extensions;

    public BeginRegistrationCeremonyRequest ToBeginCeremonyRequest(byte[] userHandle)
    {
        var criteria = new AuthenticatorSelectionCriteria(
            RegistrationParameters.AuthenticatorAttachment.RemapUnsetValue<AuthenticatorAttachment>(),
            RegistrationParameters.ResidentKey.RemapUnsetValue<ResidentKeyRequirement>(),
            RegistrationParameters.RequireResidentKey,
            RegistrationParameters.UserVerification.RemapUnsetValue<UserVerificationRequirement>()
        );
        var coseAlgorithms = RegistrationParameters.PubKeyCredParams.Select(x => (CoseAlgorithm) x).ToArray();
        return new(
            null,
            null,
            HostConstants.WebAuthnDisplayName,
            new(UserName, userHandle, UserName),
            32,
            coseAlgorithms,
            120000,
            RegistrationCeremonyExcludeCredentials.AllExisting(),
            criteria,
            null,
            RegistrationParameters.Attestation.RemapUnsetValue<AttestationConveyancePreference>(),
            null,
            Extensions);
    }
}
