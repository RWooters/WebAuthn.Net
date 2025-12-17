using System;

namespace WebAuthn.Net.Models.Protocol.RegistrationCeremony.CreateOptions;

/// <summary>
///     User Account Parameters for Credential Generation (dictionary PublicKeyCredentialUserEntity)
/// </summary>
/// <remarks>
///     <para>
///         <a href="https://www.w3.org/TR/webauthn-3/#dictionary-user-credential-params">Web Authentication: An API for accessing Public Key Credentials Level 3 - User Account Parameters for Credential Generation (dictionary PublicKeyCredentialUserEntity)</a>
///     </para>
///     <para>
///         <a href="https://www.w3.org/TR/webauthn-3/#sctn-parseCreationOptionsFromJSON">Web Authentication: An API for accessing Public Key Credentials Level 3 - Deserialize Registration ceremony options - PublicKeyCredential’s parseCreationOptionsFromJSON() Method</a>
///     </para>
///     <para>
///         <a href="https://www.w3.org/TR/webauthn-3/#dictionary-makecredentialoptions">Web Authentication: An API for accessing Public Key Credentials Level 3 - Options for Credential Creation (dictionary PublicKeyCredentialCreationOptions)</a>
///     </para>
/// </remarks>
public class PublicKeyCredentialUserEntity
{
    /// <summary>
    ///     Constructs <see cref="PublicKeyCredentialUserEntity" />.
    /// </summary>
    /// <param name="name">
    ///     <para>
    ///         A <a href="https://www.w3.org/TR/webauthn-3/#human-palatability">human-palatable</a> identifier for a <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a>. This identifier is the primary value displayed to users by
    ///         <a href="https://www.w3.org/TR/webauthn-3/#client">Clients</a> to help users understand with which <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a> a credential is associated.
    ///     </para>
    ///     <para>The <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> MAY let the user choose this value.</para>
    ///     <para>
    ///         When storing a <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialentity-name">"name"</a> member’s value, the value MAY be truncated as described in <a href="https://www.w3.org/TR/webauthn-3/#sctn-strings-truncation">"String Truncation"</a> using a size
    ///         limit greater than or equal to 64 bytes.
    ///     </para>
    /// </param>
    /// <param name="id">
    ///     <para>
    ///         The <a href="https://www.w3.org/TR/webauthn-3/#user-handle">user handle</a> of the <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a>. A <a href="https://www.w3.org/TR/webauthn-3/#user-handle">user handle</a> is an opaque
    ///         <a href="https://infra.spec.whatwg.org/#byte-sequence">byte sequence</a> with a maximum size of 64 bytes, and is not meant to be displayed to the user.
    ///     </para>
    ///     <para>
    ///         To ensure secure operation, authentication and authorization decisions MUST be made on the basis of this <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialuserentity-id">"id"</a> member, not the
    ///         <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialuserentity-displayname">"displayName"</a> nor <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialentity-name">"name"</a> members. See
    ///         <a href="https://www.rfc-editor.org/rfc/rfc8266#section-6.1">Section 6.1 of [RFC8266]</a>.
    ///     </para>
    ///     <para>
    ///         The <a href="https://www.w3.org/TR/webauthn-3/#user-handle">user handle</a> MUST NOT contain personally identifying information about the user, such as a username or e-mail address. See
    ///         <a href="https://www.w3.org/TR/webauthn-3/#sctn-user-handle-privacy">"User Handle Contents"</a> for details. The <a href="https://www.w3.org/TR/webauthn-3/#user-handle">user handle</a> MUST NOT be empty.
    ///     </para>
    ///     <para>
    ///         The <a href="https://www.w3.org/TR/webauthn-3/#user-handle">user handle</a> SHOULD NOT be a constant value across different <a href="https://www.w3.org/TR/webauthn-3/#user-account">user accounts</a>, even for
    ///         <a href="https://www.w3.org/TR/webauthn-3/#non-discoverable-credential">non-discoverable credentials</a>, because some authenticators always create <a href="https://www.w3.org/TR/webauthn-3/#discoverable-credential">discoverable credentials</a>. Thus a constant
    ///         <a href="https://www.w3.org/TR/webauthn-3/#user-handle">user handle</a> would prevent a user from using such an authenticator with more than one <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a> at the
    ///         <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a>.
    ///     </para>
    /// </param>
    /// <param name="displayName">
    ///     <para>
    ///         A <a href="https://www.w3.org/TR/webauthn-3/#human-palatability">human-palatable</a> name for the <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a>, intended only for display. The
    ///         <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> SHOULD let the user choose this, and SHOULD NOT restrict the choice more than necessary. If no suitable or <a href="https://www.w3.org/TR/webauthn-3/#human-palatability">human-palatable</a> name
    ///         is available, the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> SHOULD set this value to an empty string.
    ///     </para>
    ///     <para>
    ///         When storing a <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialuserentity-displayname">"displayName"</a> member’s value, the value MAY be truncated as described in
    ///         <a href="https://www.w3.org/TR/webauthn-3/#sctn-strings-truncation">"String Truncation"</a> using a size limit greater than or equal to 64 bytes.
    ///     </para>
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="name" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentNullException"><paramref name="id" /> is <see langword="null" /></exception>
    /// <exception cref="ArgumentException"><paramref name="id" /> must contain at least 1 byte</exception>
    /// <exception cref="ArgumentException"><paramref name="id" /> contains an array longer than 64 bytes</exception>
    /// <exception cref="ArgumentNullException"><paramref name="displayName" /> is <see langword="null" /></exception>
    public PublicKeyCredentialUserEntity(string name, byte[] id, string displayName)
    {
        // name
        ArgumentNullException.ThrowIfNull(name);
        Name = name;

        // id
        ArgumentNullException.ThrowIfNull(id);
        if (id.Length == 0)
        {
            throw new ArgumentException("The array must contain at least 1 byte", nameof(id));
        }

        if (id.Length > 64)
        {
            throw new ArgumentException("The array was longer than 64 bytes", nameof(id));
        }

        Id = id;

        // displayName
        ArgumentNullException.ThrowIfNull(displayName);
        DisplayName = displayName;
    }

    /// <summary>
    ///     <para>
    ///         A <a href="https://www.w3.org/TR/webauthn-3/#human-palatability">human-palatable</a> identifier for a <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a>. This identifier is the primary value displayed to users by
    ///         <a href="https://www.w3.org/TR/webauthn-3/#client">Clients</a> to help users understand with which <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a> a credential is associated.
    ///     </para>
    ///     <para>The <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> MAY let the user choose this value.</para>
    ///     <para>
    ///         When storing a <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialentity-name">"name"</a> member’s value, the value MAY be truncated as described in <a href="https://www.w3.org/TR/webauthn-3/#sctn-strings-truncation">"String Truncation"</a> using a size
    ///         limit greater than or equal to 64 bytes.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     <para>DOMString</para>
    ///     <para>
    ///         Examples of suitable values for this identifier include:
    ///         <list type="bullet">
    ///             <item>
    ///                 <description>alexm</description>
    ///             </item>
    ///             <item>
    ///                 <description>+14255551234</description>
    ///             </item>
    ///             <item>
    ///                 <description>alex.mueller@example.com</description>
    ///             </item>
    ///             <item>
    ///                 <description>alex.mueller@example.com (prod-env)</description>
    ///             </item>
    ///             <item>
    ///                 <description>alex.mueller@example.com (ОАО Примертех)</description>
    ///             </item>
    ///         </list>
    ///     </para>
    /// </remarks>
    public string Name { get; }

    /// <summary>
    ///     <para>
    ///         The <a href="https://www.w3.org/TR/webauthn-3/#user-handle">user handle</a> of the <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a>. A <a href="https://www.w3.org/TR/webauthn-3/#user-handle">user handle</a> is an opaque
    ///         <a href="https://infra.spec.whatwg.org/#byte-sequence">byte sequence</a> with a maximum size of 64 bytes, and is not meant to be displayed to the user.
    ///     </para>
    ///     <para>
    ///         To ensure secure operation, authentication and authorization decisions MUST be made on the basis of this <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialuserentity-id">"id"</a> member, not the
    ///         <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialuserentity-displayname">"displayName"</a> nor <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialentity-name">"name"</a> members. See
    ///         <a href="https://www.rfc-editor.org/rfc/rfc8266#section-6.1">Section 6.1 of [RFC8266]</a>.
    ///     </para>
    ///     <para>
    ///         The <a href="https://www.w3.org/TR/webauthn-3/#user-handle">user handle</a> MUST NOT contain personally identifying information about the user, such as a username or e-mail address. See
    ///         <a href="https://www.w3.org/TR/webauthn-3/#sctn-user-handle-privacy">"User Handle Contents"</a> for details. The <a href="https://www.w3.org/TR/webauthn-3/#user-handle">user handle</a> MUST NOT be empty.
    ///     </para>
    ///     <para>
    ///         The <a href="https://www.w3.org/TR/webauthn-3/#user-handle">user handle</a> SHOULD NOT be a constant value across different <a href="https://www.w3.org/TR/webauthn-3/#user-account">user accounts</a>, even for
    ///         <a href="https://www.w3.org/TR/webauthn-3/#non-discoverable-credential">non-discoverable credentials</a>, because some authenticators always create <a href="https://www.w3.org/TR/webauthn-3/#discoverable-credential">discoverable credentials</a>. Thus a constant
    ///         <a href="https://www.w3.org/TR/webauthn-3/#user-handle">user handle</a> would prevent a user from using such an authenticator with more than one <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a> at the
    ///         <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a>.
    ///     </para>
    /// </summary>
    public byte[] Id { get; }

    /// <summary>
    ///     <para>
    ///         A <a href="https://www.w3.org/TR/webauthn-3/#human-palatability">human-palatable</a> name for the <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a>, intended only for display. The
    ///         <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> SHOULD let the user choose this, and SHOULD NOT restrict the choice more than necessary. If no suitable or <a href="https://www.w3.org/TR/webauthn-3/#human-palatability">human-palatable</a> name
    ///         is available, the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> SHOULD set this value to an empty string.
    ///     </para>
    ///     <para>
    ///         When storing a <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialuserentity-displayname">"displayName"</a> member’s value, the value MAY be truncated as described in
    ///         <a href="https://www.w3.org/TR/webauthn-3/#sctn-strings-truncation">"String Truncation"</a> using a size limit greater than or equal to 64 bytes.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     <para>DOMString</para>
    ///     <para>
    ///         Examples of suitable values for this identifier include:
    ///         <list type="bullet">
    ///             <item>
    ///                 <description>Alex Müller</description>
    ///             </item>
    ///             <item>
    ///                 <description>Alex Müller (ACME Co.)</description>
    ///             </item>
    ///             <item>
    ///                 <description>田中倫</description>
    ///             </item>
    ///         </list>
    ///     </para>
    /// </remarks>
    public string DisplayName { get; }
}
