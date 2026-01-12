using System;

namespace WebAuthn.Net.Services.RegistrationCeremony.Models.CreateCredential;

/// <summary>
///     Result of successful completion of the registration ceremony.
/// </summary>
public class CompleteRegistrationCeremonyResult
{
    /// <summary>
    ///     Constructs <see cref="CompleteRegistrationCeremonyResult" />.
    /// </summary>
    /// <param name="requiringAdditionalAuthenticators">
    ///     <para>Flag referring to <a href="https://www.w3.org/TR/webauthn-3/#sctn-credential-backup">"Credential Backup State"</a>.</para>
    ///     <para>
    ///         When the <a href="https://www.w3.org/TR/webauthn-3/#authdata-flags-be">BE</a> <a href="https://www.w3.org/TR/webauthn-3/#authdata-flags"></a>flag is set to 0, the credential is a
    ///         <a href="https://www.w3.org/TR/webauthn-3/#single-device-credential">single-device credential</a> and the <a href="https://www.w3.org/TR/webauthn-3/#generating-authenticator">generating authenticator</a> will never allow the credential to be backed up.
    ///     </para>
    ///     <para>
    ///         A <a href="https://www.w3.org/TR/webauthn-3/#single-device-credential">single-device credential</a> is not resilient to single device loss. <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Parties</a> SHOULD ensure that each
    ///         <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a> has additional <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticators</a> <a href="https://www.w3.org/TR/webauthn-3/#registration-ceremony">registered</a> and/or an account
    ///         recovery process in place. For example, the user could be prompted to set up an additional <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a>, such as a <a href="https://www.w3.org/TR/webauthn-3/#roaming-authenticators">roaming authenticator</a>
    ///         or an <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a> that is capable of <a href="https://www.w3.org/TR/webauthn-3/#multi-device-credential">multi-device credentials</a>.
    ///     </para>
    /// </param>
    /// <param name="userHandle">Identifier of the user account.</param>
    /// <exception cref="ArgumentNullException">Any of the parameters is <see langword="null" /></exception>
    public CompleteRegistrationCeremonyResult(bool requiringAdditionalAuthenticators, byte[] userHandle)
    {
        ArgumentNullException.ThrowIfNull(userHandle);
        RequiringAdditionalAuthenticators = requiringAdditionalAuthenticators;
        UserHandle = userHandle;
    }

    /// <summary>
    ///     <para>Flag referring to <a href="https://www.w3.org/TR/webauthn-3/#sctn-credential-backup">"Credential Backup State"</a>.</para>
    ///     <para>
    ///         When the <a href="https://www.w3.org/TR/webauthn-3/#authdata-flags-be">BE</a> <a href="https://www.w3.org/TR/webauthn-3/#authdata-flags"></a>flag is set to 0, the credential is a
    ///         <a href="https://www.w3.org/TR/webauthn-3/#single-device-credential">single-device credential</a> and the <a href="https://www.w3.org/TR/webauthn-3/#generating-authenticator">generating authenticator</a> will never allow the credential to be backed up.
    ///     </para>
    ///     <para>
    ///         A <a href="https://www.w3.org/TR/webauthn-3/#single-device-credential">single-device credential</a> is not resilient to single device loss. <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Parties</a> SHOULD ensure that each
    ///         <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a> has additional <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticators</a> <a href="https://www.w3.org/TR/webauthn-3/#registration-ceremony">registered</a> and/or an account
    ///         recovery process in place. For example, the user could be prompted to set up an additional <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a>, such as a <a href="https://www.w3.org/TR/webauthn-3/#roaming-authenticators">roaming authenticator</a>
    ///         or an <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a> that is capable of <a href="https://www.w3.org/TR/webauthn-3/#multi-device-credential">multi-device credentials</a>.
    ///     </para>
    /// </summary>
    public bool RequiringAdditionalAuthenticators { get; }

    /// <summary>
    ///     Identifier of the user account.
    /// </summary>
    public byte[] UserHandle { get; }
}
