using System;
using System.ComponentModel;
using WebAuthn.Net.Models.Protocol.Enums;

namespace WebAuthn.Net.Models.Protocol;

/// <summary>
///     Credential Descriptor (dictionary PublicKeyCredentialDescriptor).
/// </summary>
/// <remarks>
///     <para>
///         <a href="https://www.w3.org/TR/webauthn-3/#dictionary-credential-descriptor">Web Authentication: An API for accessing Public Key Credentials Level 3 - Credential Descriptor (dictionary PublicKeyCredentialDescriptor)</a>
///     </para>
/// </remarks>
public class PublicKeyCredentialDescriptor
{
    /// <summary>
    ///     Constructs <see cref="PublicKeyCredentialDescriptor" />.
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
    /// <exception cref="InvalidEnumArgumentException"><paramref name="type" /> contains a value that is not defined in <see cref="PublicKeyCredentialType" /></exception>
    /// <exception cref="ArgumentNullException"><paramref name="id" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException">The length of <paramref name="id" /> is less than 16</exception>
    /// <exception cref="ArgumentException">The length of <paramref name="id" /> is greater than 1023</exception>
    /// <exception cref="InvalidEnumArgumentException">One of the elements in the <paramref name="transports" /> array contains a value not defined in <see cref="AuthenticatorTransport" /></exception>
    public PublicKeyCredentialDescriptor(
        PublicKeyCredentialType type,
        byte[] id,
        AuthenticatorTransport[]? transports)
    {
        // type
        if (!Enum.IsDefined(type))
        {
            throw new InvalidEnumArgumentException(nameof(type), (int) type, typeof(PublicKeyCredentialType));
        }

        Type = type;

        // id
        ArgumentNullException.ThrowIfNull(id);
        if (id.Length < 16)
        {
            // https://www.w3.org/TR/webauthn-3/#credential-id
            // At least 16 bytes that include at least 100 bits of entropy
            throw new ArgumentException($"The minimum length of the {nameof(id)} is 16.", nameof(id));
        }

        if (id.Length > 1023)
        {
            // https://www.w3.org/TR/webauthn-3/#credential-id
            // At most 1023 bytes long
            throw new ArgumentException($"The max length of the {nameof(id)} is 1023.", nameof(id));
        }

        Id = id;

        // transports
        if (transports?.Length > 0)
        {
            foreach (var transport in transports)
            {
                if (!Enum.IsDefined(transport))
                {
                    throw new InvalidEnumArgumentException(nameof(transports), (int) transport, typeof(AuthenticatorTransport));
                }
            }

            Transports = transports;
        }
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
    public PublicKeyCredentialType Type { get; }

    /// <summary>
    ///     <para>This member contains the <a href="https://www.w3.org/TR/webauthn-3/#credential-id">credential ID</a> of the <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential">public key credential</a> the caller is referring to.</para>
    ///     <para>
    ///         This SHOULD be set to the value of the <a href="https://www.w3.org/TR/webauthn-3/#abstract-opdef-credential-record-id">"id"</a> item of the <a href="https://www.w3.org/TR/webauthn-3/#credential-record">credential record</a> representing the identified
    ///         <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential-source">public key credential source</a>. This mirrors the <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-rawid">"rawId"</a> field of
    ///         <a href="https://www.w3.org/TR/webauthn-3/#publickeycredential">PublicKeyCredential</a>.
    ///     </para>
    /// </summary>
    public byte[] Id { get; }

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
    public AuthenticatorTransport[]? Transports { get; }
}
