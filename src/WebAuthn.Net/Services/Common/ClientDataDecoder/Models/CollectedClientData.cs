namespace WebAuthn.Net.Services.Common.ClientDataDecoder.Models;

/// <summary>
///     Client Data Used in <a href="https://www.w3.org/TR/webauthn-3/#webauthn-signature">WebAuthn Signatures</a> (dictionary CollectedClientData)
/// </summary>
/// <remarks>
///     <a href="https://www.w3.org/TR/webauthn-3/#dictionary-client-data">Web Authentication: An API for accessing Public Key Credentials Level 3 - Client Data Used in WebAuthn Signatures (dictionary CollectedClientData)</a>
/// </remarks>
public class CollectedClientData
{
    /// <summary>
    ///     Constructs <see cref="CollectedClientData" />.
    /// </summary>
    /// <param name="type">
    ///     This member contains the string "webauthn.create" when creating new credentials, and "webauthn.get" when getting an assertion from an existing credential. The purpose of this member is to prevent certain types of signature confusion attacks (where an attacker
    ///     substitutes one legitimate signature for another).
    /// </param>
    /// <param name="challenge">
    ///     This member contains the base64url encoding of the challenge provided by the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a>. See the
    ///     <a href="https://www.w3.org/TR/webauthn-3/#sctn-cryptographic-challenges">"Cryptographic Challenges"</a> security consideration.
    /// </param>
    /// <param name="origin">
    ///     This member contains the fully qualified <a href="https://html.spec.whatwg.org/multipage/origin.html#concept-origin">origin</a> of the requester, as provided to the authenticator by the client, in the syntax defined by
    ///     <a href="https://www.rfc-editor.org/rfc/rfc6454.html">[RFC6454]</a>.
    /// </param>
    /// <param name="crossOrigin">This OPTIONAL member contains the inverse of the "sameOriginWithAncestors" argument value that was passed into the <a href="https://tc39.github.io/ecma262/#sec-object-internal-methods-and-internal-slots">internal method</a>.</param>
    /// <param name="topOrigin">
    ///     This OPTIONAL member contains the fully qualified <a href="https://html.spec.whatwg.org/multipage/webappapis.html#concept-environment-top-level-origin">top-level origin</a> of the requester, in the syntax defined by
    ///     <a href="https://www.rfc-editor.org/rfc/rfc6454.html">[RFC6454]</a>. It is set only if the call was made from context that is not <a href="https://www.w3.org/TR/credential-management-1/#same-origin-with-its-ancestors">same-origin with its ancestors</a>, i.e. if
    ///     <a href="https://www.w3.org/TR/webauthn-3/#dom-collectedclientdata-crossorigin">crossOrigin</a> is <see langword="true" />.
    /// </param>
    public CollectedClientData(string type, string challenge, string origin, bool? crossOrigin, string? topOrigin)
    {
        Type = type;
        Challenge = challenge;
        Origin = origin;
        CrossOrigin = crossOrigin;
        TopOrigin = topOrigin;
    }

    /// <summary>
    ///     This member contains the string "webauthn.create" when creating new credentials, and "webauthn.get" when getting an assertion from an existing credential. The purpose of this member is to prevent certain types of signature confusion attacks (where an attacker substitutes one
    ///     legitimate signature for another).
    /// </summary>
    public string Type { get; }

    /// <summary>
    ///     This member contains the base64url encoding of the challenge provided by the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a>. See the <a href="https://www.w3.org/TR/webauthn-3/#sctn-cryptographic-challenges">"Cryptographic Challenges"</a> security
    ///     consideration.
    /// </summary>
    public string Challenge { get; }

    /// <summary>
    ///     This member contains the fully qualified <a href="https://html.spec.whatwg.org/multipage/origin.html#concept-origin">origin</a> of the requester, as provided to the authenticator by the client, in the syntax defined by
    ///     <a href="https://www.rfc-editor.org/rfc/rfc6454.html">[RFC6454]</a>.
    /// </summary>
    public string Origin { get; }

    /// <summary>
    ///     This OPTIONAL member contains the inverse of the "sameOriginWithAncestors" argument value that was passed into the <a href="https://tc39.github.io/ecma262/#sec-object-internal-methods-and-internal-slots">internal method</a>.
    /// </summary>
    public bool? CrossOrigin { get; }

    /// <summary>
    ///     This OPTIONAL member contains the fully qualified <a href="https://html.spec.whatwg.org/multipage/webappapis.html#concept-environment-top-level-origin">top-level origin</a> of the requester, in the syntax defined by
    ///     <a href="https://www.rfc-editor.org/rfc/rfc6454.html">[RFC6454]</a>. It is set only if the call was made from context that is not <a href="https://www.w3.org/TR/credential-management-1/#same-origin-with-its-ancestors">same-origin with its ancestors</a>, i.e. if
    ///     <a href="https://www.w3.org/TR/webauthn-3/#dom-collectedclientdata-crossorigin">crossOrigin</a> is <see langword="true" />.
    /// </summary>
    public string? TopOrigin { get; }
}
