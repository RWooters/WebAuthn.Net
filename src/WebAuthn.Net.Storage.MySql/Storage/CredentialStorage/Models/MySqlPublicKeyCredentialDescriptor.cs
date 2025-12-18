using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using WebAuthn.Net.Models.Protocol;
using WebAuthn.Net.Models.Protocol.Enums;

namespace WebAuthn.Net.Storage.MySql.Storage.CredentialStorage.Models;

/// <summary>
///     Model for representing <see cref="PublicKeyCredentialDescriptor" /> stored in MySQL as part of <see cref="MySqlUserCredentialRecord" />.
/// </summary>
[SuppressMessage("Design", "CA1812:Avoid uninstantiated internal classes")]
public class MySqlPublicKeyCredentialDescriptor
{
    /// <summary>
    ///     Constructs <see cref="MySqlPublicKeyCredentialDescriptor" />.
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
    /// <param name="credentialId">
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
    ///         <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential-source">public key credential source</a>. This mirrors the <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-response">response</a>.
    ///         <a href="https://www.w3.org/TR/webauthn-3/#dom-authenticatorattestationresponse-gettransports">getTransports()</a> method of the <a href="https://www.w3.org/TR/webauthn-3/#publickeycredential">PublicKeyCredential</a> structure created by a
    ///         <a href="https://www.w3.org/TR/credential-management-1/#dom-credentialscontainer-create">create()</a> operation.
    ///     </para>
    ///     <para>For storage in MySQL, the values are transformed into json ('json' data type).</para>
    /// </param>
    /// <param name="createdAtUnixTime">Unix timestamp (in seconds) of when the <see cref="PublicKeyCredentialDescriptor" /> was created.</param>
    public MySqlPublicKeyCredentialDescriptor(int type, byte[] credentialId, string transports, long createdAtUnixTime)
    {
        Type = type;
        CredentialId = credentialId;
        Transports = transports;
        CreatedAtUnixTime = createdAtUnixTime;
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
    public int Type { get; }

    /// <summary>
    ///     <para>This member contains the <a href="https://www.w3.org/TR/webauthn-3/#credential-id">credential ID</a> of the <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential">public key credential</a> the caller is referring to.</para>
    ///     <para>
    ///         This SHOULD be set to the value of the <a href="https://www.w3.org/TR/webauthn-3/#abstract-opdef-credential-record-id">"id"</a> item of the <a href="https://www.w3.org/TR/webauthn-3/#credential-record">credential record</a> representing the identified
    ///         <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential-source">public key credential source</a>. This mirrors the <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-rawid">"rawId"</a> field of
    ///         <a href="https://www.w3.org/TR/webauthn-3/#publickeycredential">PublicKeyCredential</a>.
    ///     </para>
    /// </summary>
    [Required]
    [MaxLength(1024)]
    public byte[] CredentialId { get; }

    /// <summary>
    ///     <para>
    ///         This OPTIONAL member contains a hint as to how the <a href="https://www.w3.org/TR/webauthn-3/#client">client</a> might communicate with the <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential-source-managing-authenticator">managing authenticator</a> of the
    ///         <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential">public key credential</a> the caller is referring to. The values SHOULD be members of <a href="https://www.w3.org/TR/webauthn-3/#enumdef-authenticatortransport">AuthenticatorTransport</a> but
    ///         <a href="https://www.w3.org/TR/webauthn-3/#client-platform">client platforms</a> MUST ignore unknown values.
    ///     </para>
    ///     <para>
    ///         This SHOULD be set to the value of the <a href="https://www.w3.org/TR/webauthn-3/#abstract-opdef-credential-record-transports">"transports"</a> item of the <a href="https://www.w3.org/TR/webauthn-3/#credential-record">credential record</a> representing the identified
    ///         <a href="https://www.w3.org/TR/webauthn-3/#public-key-credential-source">public key credential source</a>. This mirrors the <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredential-response">response</a>.
    ///         <a href="https://www.w3.org/TR/webauthn-3/#dom-authenticatorattestationresponse-gettransports">getTransports()</a> method of the <a href="https://www.w3.org/TR/webauthn-3/#publickeycredential">PublicKeyCredential</a> structure created by a
    ///         <a href="https://www.w3.org/TR/credential-management-1/#dom-credentialscontainer-create">create()</a> operation.
    ///     </para>
    ///     <para>For storage in MySQL, the values are transformed into json ('json' data type).</para>
    /// </summary>
    [Column(TypeName = "json")]
    [Required]
    public string Transports { get; }

    /// <summary>
    ///     Unix timestamp (in seconds) of when the <see cref="PublicKeyCredentialDescriptor" /> was created.
    /// </summary>
    public long CreatedAtUnixTime { get; }

    /// <summary>
    ///     Converts <see cref="MySqlPublicKeyCredentialDescriptor" /> to <see cref="PublicKeyCredentialDescriptor" /> if possible.
    /// </summary>
    /// <param name="result">Output parameter. Contains <see cref="PublicKeyCredentialDescriptor" /> if the conversion was successful and the method returned <see langword="true" />, otherwise - <see langword="null" />.</param>
    /// <returns><see langword="true" /> if the conversion was successful, otherwise - <see langword="false" />.</returns>
    public virtual bool TryToPublicKeyCredentialDescriptor([NotNullWhen(true)] out PublicKeyCredentialDescriptor? result)
    {
        result = null;
        var type = (PublicKeyCredentialType) Type;
        if (!Enum.IsDefined(type))
        {
            return false;
        }

        var transports = Array.Empty<AuthenticatorTransport>();
        if (!string.IsNullOrEmpty(Transports))
        {
            var transportsIntegers = JsonSerializer.Deserialize<int[]>(Transports);
            if (transportsIntegers?.Length > 0)
            {
                var typedTransports = transportsIntegers
                    .Select(x => (AuthenticatorTransport) x)
                    .ToArray();
                foreach (var authenticatorTransport in typedTransports)
                {
                    if (!Enum.IsDefined(authenticatorTransport))
                    {
                        return false;
                    }
                }

                transports = typedTransports;
            }
        }

        result = new(type, CredentialId, transports);
        return true;
    }
}
