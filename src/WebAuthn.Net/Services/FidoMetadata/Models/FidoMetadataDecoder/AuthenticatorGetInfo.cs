using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WebAuthn.Net.Services.FidoMetadata.Models.FidoMetadataDecoder;

/// <summary>
///     authenticatorGetInfo
/// </summary>
/// <remarks>
///     <para>
///         <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#authenticatorGetInfo">Client to Authenticator Protocol (CTAP) - authenticatorGetInfo (0x04)</a>
///     </para>
/// </remarks>
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class AuthenticatorGetInfo
{
    /// <summary>
    ///     Constructs <see cref="AuthenticatorGetInfo" />.
    /// </summary>
    /// <param name="versions">
    ///     List of supported versions. Supported versions are: "FIDO_2_1" for CTAP2.1 / FIDO2 / Web Authentication authenticators, "FIDO_2_0" for CTAP2.0 / FIDO2 / Web Authentication authenticators, "FIDO_2_1_PRE" for CTAP2.1 Preview features and "U2F_V2" for
    ///     CTAP1/U2F authenticators.
    /// </param>
    /// <param name="extensions">List of supported extensions.</param>
    /// <param name="aaguid">The claimed AAGUID. 16 bytes in length and encoded the same as MakeCredential AuthenticatorData, as specified in <a href="https://www.w3.org/TR/webauthn-3/#aaguid">WebAuthn</a>.</param>
    /// <param name="options">List of supported options.</param>
    /// <param name="maxMsgSize">Maximum message size supported by the authenticator.</param>
    /// <param name="pinUvAuthProtocols">
    ///     List of supported <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#pin-uv-auth-protocol">PIN/UV auth protocols</a> in order of decreasing authenticator preference. MUST NOT contain duplicate values nor
    ///     be empty if present.
    /// </param>
    /// <param name="maxCredentialCountInList">
    ///     Maximum number of credentials supported in <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#credentialid">credentialID</a> list at a time by the authenticator. MUST be greater than zero if present.
    /// </param>
    /// <param name="maxCredentialIdLength">Maximum Credential ID Length supported by the authenticator. MUST be greater than zero if present.</param>
    /// <param name="transports">
    ///     List of supported transports. Values are taken from the <a href="https://www.w3.org/TR/webauthn-3/#enumdef-authenticatortransport">AuthenticatorTransport enum in WebAuthn</a>. The list MUST NOT include duplicate values nor be empty if present. Platforms
    ///     MUST tolerate unknown values.
    /// </param>
    /// <param name="algorithms">
    ///     List of supported algorithms for credential generation, as specified in <a href="https://www.w3.org/TR/webauthn-3/#dictionary-credential-params">WebAuthn</a>. The array is ordered from most preferred to least preferred and MUST NOT include duplicate
    ///     entries nor be empty if present. PublicKeyCredentialParameters' algorithm identifiers are values that SHOULD be registered in the <a href="https://www.iana.org/assignments/cose/cose.xhtml#algorithms">IANA COSE Algorithms registry</a>.
    /// </param>
    /// <param name="maxSerializedLargeBlobArray">
    ///     The maximum size, in bytes, of the <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#serialized-large-blob-array">serialized large-blob array</a> that this authenticator can store. If the
    ///     <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#authenticatorLargeBlobs">authenticatorLargeBlobs</a> command is supported, this MUST be specified. Otherwise it MUST NOT be. If specified, the value MUST
    ///     be ≥ 1024. Thus, 1024 bytes is the least amount of storage an authenticator must make available for per-credential
    ///     <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#serialized-large-blob-array">serialized large-blob arrays</a> if it supports the
    ///     <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#authenticatorLargeBlobs">large, per-credential blobs</a> feature. This value is not specified and not pertinent if the authenticator implements the
    ///     <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#sctn-largeBlob-extension">largeBlob extension</a>.
    /// </param>
    /// <param name="forcePinChange">
    ///     If this member is:
    ///     <list type="table">
    ///         <item>
    ///             <term>
    ///                 present and set to <see langword="true" />
    ///             </term>
    ///             <description>
    ///                 <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#getPinToken">getPinToken</a> and
    ///                 <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#getPinUvAuthTokenUsingPinWithPermissions">getPinUvAuthTokenUsingPinWithPermissions</a> will return errors until after a successful
    ///                 <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#changingExistingPin">PIN Change</a>.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>
    ///                 present and set to <see langword="false" />, or absent
    ///             </term>
    ///             <description>
    ///                 no <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#changingExistingPin">PIN Change</a> is required.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </param>
    /// <param name="minPinLength">
    ///     <para>
    ///         This specifies the current minimum PIN length, in Unicode code points, the authenticator enforces for <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#getinfo-clientpin">ClientPIN</a>. This is
    ///         applicable for ClientPIN only: the <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#getinfo-minpinlength">minPINLength</a> member MUST be absent if the
    ///         <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#getinfo-clientpin">clientPin</a>
    ///         <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#option-id">option ID</a> is absent; it MUST be present if the authenticator supports
    ///         <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#authenticatorClientPIN">authenticatorClientPIN</a>.
    ///     </para>
    ///     <para>
    ///         The default pre-configured minimum PIN length is at least 4 Unicode code points. Authenticators MAY have a pre-configured default minPINLength of more than 4 code points in certain offerings. On
    ///         <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#authenticatorReset">reset</a>, minPINLength reverts to its original pre-configured value. Authenticators MAY also have a pre-configured list of RP
    ///         IDs authorized to receive the <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#current-minimum-pin-length">current minimum PIN length</a> value via the
    ///         <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#sctn-minpinlength-extension">minPinLength</a> extension.
    ///     </para>
    /// </param>
    /// <param name="firmwareVersion">Indicates the firmware version of the authenticator model identified by AAGUID. Whenever releasing any code change to the authenticator firmware, authenticator MUST increase the version.</param>
    /// <param name="maxCredBlobLength">
    ///     Maximum <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#sctn-credBlob-extension">credBlob</a> length in bytes supported by the authenticator. Must be present if, and only if, credBlob is included in
    ///     the supported extensions list. If present, this value MUST be at least 32 bytes.
    /// </param>
    /// <param name="maxRpiDsForSetMinPinLength"></param>
    /// <param name="preferredPlatformUvAttempts"></param>
    /// <param name="uvModality"></param>
    /// <param name="certifications"></param>
    /// <param name="remainingDiscoverableCredentials"></param>
    /// <param name="attestationFormats"></param>
    public AuthenticatorGetInfo(
        string[] versions,
        string[]? extensions,
        Guid aaguid,
        Dictionary<string, bool>? options,
        ulong? maxMsgSize,
        ulong[]? pinUvAuthProtocols,
        ulong? maxCredentialCountInList,
        ulong? maxCredentialIdLength,
        string[]? transports,
        FidoPublicKeyCredentialParameters[]? algorithms,
        ulong? maxSerializedLargeBlobArray,
        bool? forcePinChange,
        ulong? minPinLength,
        ulong? firmwareVersion,
        ulong? maxCredBlobLength,
        ulong? maxRpiDsForSetMinPinLength,
        ulong? preferredPlatformUvAttempts,
        ulong? uvModality,
        Dictionary<string, int>? certifications,
        ulong? remainingDiscoverableCredentials,
        string[]? attestationFormats)
    {
        Versions = versions;
        Extensions = extensions;
        Aaguid = aaguid;
        Options = options;
        MaxMsgSize = maxMsgSize;
        PinUvAuthProtocols = pinUvAuthProtocols;
        MaxCredentialCountInList = maxCredentialCountInList;
        MaxCredentialIdLength = maxCredentialIdLength;
        Transports = transports;
        Algorithms = algorithms;
        MaxSerializedLargeBlobArray = maxSerializedLargeBlobArray;
        ForcePINChange = forcePinChange;
        MinPINLength = minPinLength;
        FirmwareVersion = firmwareVersion;
        MaxCredBlobLength = maxCredBlobLength;
        MaxRPIDsForSetMinPINLength = maxRpiDsForSetMinPinLength;
        PreferredPlatformUvAttempts = preferredPlatformUvAttempts;
        UvModality = uvModality;
        Certifications = certifications;
        RemainingDiscoverableCredentials = remainingDiscoverableCredentials;
        AttestationFormats = attestationFormats;
    }

    /// <summary>
    ///     List of supported versions. Supported versions are: "FIDO_2_1" for CTAP2.1 / FIDO2 / Web Authentication authenticators, "FIDO_2_0" for CTAP2.0 / FIDO2 / Web Authentication authenticators, "FIDO_2_1_PRE" for CTAP2.1 Preview features and "U2F_V2" for CTAP1/U2F authenticators.
    /// </summary>
    public string[] Versions { get; }

    /// <summary>
    ///     List of supported extensions.
    /// </summary>
    public string[]? Extensions { get; }

    /// <summary>
    ///     The claimed AAGUID. 16 bytes in length and encoded the same as MakeCredential AuthenticatorData, as specified in <a href="https://www.w3.org/TR/webauthn-3/#aaguid">WebAuthn</a>.
    /// </summary>
    public Guid Aaguid { get; }

    /// <summary>
    ///     List of supported options.
    /// </summary>
    public Dictionary<string, bool>? Options { get; }

    /// <summary>
    ///     Maximum message size supported by the authenticator.
    /// </summary>
    public ulong? MaxMsgSize { get; }

    /// <summary>
    ///     List of supported <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#pin-uv-auth-protocol">PIN/UV auth protocols</a> in order of decreasing authenticator preference. MUST NOT contain duplicate values nor
    ///     be empty if present.
    /// </summary>
    public ulong[]? PinUvAuthProtocols { get; }

    /// <summary>
    ///     Maximum number of credentials supported in <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#credentialid">credentialID</a> list at a time by the authenticator. MUST be greater than zero if present.
    /// </summary>
    public ulong? MaxCredentialCountInList { get; }

    /// <summary>
    ///     Maximum Credential ID Length supported by the authenticator. MUST be greater than zero if present.
    /// </summary>
    public ulong? MaxCredentialIdLength { get; }

    /// <summary>
    ///     List of supported transports. Values are taken from the <a href="https://www.w3.org/TR/webauthn-3/#enumdef-authenticatortransport">AuthenticatorTransport enum in WebAuthn</a>. The list MUST NOT include duplicate values nor be empty if present. Platforms MUST tolerate unknown
    ///     values.
    /// </summary>
    public string[]? Transports { get; }

    /// <summary>
    ///     List of supported algorithms for credential generation, as specified in <a href="https://www.w3.org/TR/webauthn-3/#dictionary-credential-params">WebAuthn</a>. The array is ordered from most preferred to least preferred and MUST NOT include duplicate entries nor be empty if
    ///     present. PublicKeyCredentialParameters' algorithm identifiers are values that SHOULD be registered in the <a href="https://www.iana.org/assignments/cose/cose.xhtml#algorithms">IANA COSE Algorithms registry</a>.
    /// </summary>
    public FidoPublicKeyCredentialParameters[]? Algorithms { get; }

    /// <summary>
    ///     The maximum size, in bytes, of the <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#serialized-large-blob-array">serialized large-blob array</a> that this authenticator can store. If the
    ///     <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#authenticatorLargeBlobs">authenticatorLargeBlobs</a> command is supported, this MUST be specified. Otherwise it MUST NOT be. If specified, the value MUST
    ///     be ≥ 1024. Thus, 1024 bytes is the least amount of storage an authenticator must make available for per-credential
    ///     <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#serialized-large-blob-array">serialized large-blob arrays</a> if it supports the
    ///     <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#authenticatorLargeBlobs">large, per-credential blobs</a> feature. This value is not specified and not pertinent if the authenticator implements the
    ///     <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#sctn-largeBlob-extension">largeBlob extension</a>.
    /// </summary>
    public ulong? MaxSerializedLargeBlobArray { get; }

    /// <summary>
    ///     If this member is:
    ///     <list type="table">
    ///         <item>
    ///             <term>
    ///                 present and set to <see langword="true" />
    ///             </term>
    ///             <description>
    ///                 <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#getPinToken">getPinToken</a> and
    ///                 <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#getPinUvAuthTokenUsingPinWithPermissions">getPinUvAuthTokenUsingPinWithPermissions</a> will return errors until after a successful
    ///                 <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#changingExistingPin">PIN Change</a>.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>
    ///                 present and set to <see langword="false" />, or absent
    ///             </term>
    ///             <description>
    ///                 no <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#changingExistingPin">PIN Change</a> is required.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </summary>
    public bool? ForcePINChange { get; }

    /// <summary>
    ///     <para>
    ///         This specifies the current minimum PIN length, in Unicode code points, the authenticator enforces for <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#getinfo-clientpin">ClientPIN</a>. This is
    ///         applicable for ClientPIN only: the <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#getinfo-minpinlength">minPINLength</a> member MUST be absent if the
    ///         <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#getinfo-clientpin">clientPin</a>
    ///         <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#option-id">option ID</a> is absent; it MUST be present if the authenticator supports
    ///         <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#authenticatorClientPIN">authenticatorClientPIN</a>.
    ///     </para>
    ///     <para>
    ///         The default pre-configured minimum PIN length is at least 4 Unicode code points. Authenticators MAY have a pre-configured default minPINLength of more than 4 code points in certain offerings. On
    ///         <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#authenticatorReset">reset</a>, minPINLength reverts to its original pre-configured value. Authenticators MAY also have a pre-configured list of RP
    ///         IDs authorized to receive the <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#current-minimum-pin-length">current minimum PIN length</a> value via the
    ///         <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#sctn-minpinlength-extension">minPinLength</a> extension.
    ///     </para>
    /// </summary>
    public ulong? MinPINLength { get; }

    /// <summary>
    ///     Indicates the firmware version of the authenticator model identified by AAGUID. Whenever releasing any code change to the authenticator firmware, authenticator MUST increase the version.
    /// </summary>
    public ulong? FirmwareVersion { get; }

    /// <summary>
    ///     Maximum <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#sctn-credBlob-extension">credBlob</a> length in bytes supported by the authenticator. Must be present if, and only if, credBlob is included in
    ///     the supported extensions list. If present, this value MUST be at least 32 bytes.
    /// </summary>
    public ulong? MaxCredBlobLength { get; }

    /// <summary>
    ///     This specifies the max number of <a href="https://www.w3.org/TR/webauthn-3/#rp-id">RP ID</a> that the authenticator will accept via
    ///     <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#setMinPINLength">setMinPINLength</a> subcommand. The platform MUST NOT send more than this number of
    ///     <a href="https://www.w3.org/TR/webauthn-3/#rp-id">RP ID</a> to the <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#setMinPINLength">setMinPINLength</a> subcommand. This is in addition to pre-configured
    ///     list authenticator may have. If the authenticator does not support adding additional RP IDs, its value is 0. This MUST ONLY be present if, and only if, the authenticator supports the
    ///     <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#setMinPINLength">setMinPINLength</a> subcommand.
    /// </summary>
    public ulong? MaxRPIDsForSetMinPINLength { get; }

    /// <summary>
    ///     This specifies the preferred number of invocations of the getPinUvAuthTokenUsingUvWithPermissions subCommand the platform may attempt before falling back to the getPinUvAuthTokenUsingPinWithPermissions subCommand or displaying an error. MUST be greater than zero. If the
    ///     value is 1 then all <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#uvretries">uvRetries</a> are internal and the platform MUST only invoke the getPinUvAuthTokenUsingUvWithPermissions subCommand a
    ///     single time. If the value is > 1 the authenticator MUST only decrement <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#uvretries">uvRetries</a> by 1 for each iteration.
    /// </summary>
    public ulong? PreferredPlatformUvAttempts { get; }

    /// <summary>
    ///     This specifies the user verification modality supported by the authenticator via <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#authenticatorClientPIN">authenticatorClientPIN’s</a>
    ///     getPinUvAuthTokenUsingUvWithPermissions subcommand. This is a hint to help the platform construct user dialogs. The values are defined in
    ///     <a href="https://fidoalliance.org/specs/common-specs/fido-registry-v2.2-ps-20220523.html#user-verification-methods">FIDO Registry of Predefined Values - "User Verification Methods"</a>. Combining multiple bit-flags from the FIDO Registry of Predefined Values is allowed. If
    ///     <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#getinfo-clientpin">clientPin</a> is supported it MUST NOT be included in the bit-flags, as clientPIN is not a
    ///     <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#built-in-user-verification-method">built-in user verification method</a>.
    /// </summary>
    public ulong? UvModality { get; }

    /// <summary>
    ///     This specifies a list of <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#sctn-feature-descriptions-certifications">authenticator certifications</a>.
    /// </summary>
    public Dictionary<string, int>? Certifications { get; }

    /// <summary>
    ///     <para>
    ///         If this member is present it indicates the estimated number of additional <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#discoverable">discoverable</a> credentials that can be stored. If this
    ///         value is zero then platforms SHOULD create non-discoverable credentials if possible.
    ///     </para>
    ///     <para>
    ///         This estimate SHOULD be based on the assumption that all future <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#discoverable">discoverable</a> credentials will have maximally-sized fields and
    ///         SHOULD be zero whenever an attempt to create a <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#discoverable">discoverable</a> credential may fail due to lack of space, even if it’s possible that
    ///         some specific request might succeed. For example, a specific request might include fields that are smaller than the maximum possible size and thus succeed, but this value should be zero if a request with maximum-sized fields would fail. Also, a specific request might
    ///         have an <a href="https://fidoalliance.org/specs/fido-v2.2-ps-20250714/fido-client-to-authenticator-protocol-v2.2-ps-20250714.html#makecred-rpid">rp.id</a> and <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialuserentity-id">user.id</a> that match an
    ///         existing discoverable credential and thus overwrite it, but this value should be set assuming that will not happen.
    ///     </para>
    /// </summary>
    public ulong? RemainingDiscoverableCredentials { get; }

    /// <summary>
    ///     <para>List of supported attestation formats. Authenticators that support multiple attestation formats, not counting "none", MUST set this field. Otherwise it is optional.</para>
    ///     <para>
    ///         Values are taken from the <a href="https://www.iana.org/assignments/webauthn/webauthn.xhtml#webauthn-attestation-statement-format-ids">"WebAuthn Attestation Statement Format Identifiers" registry</a> established by
    ///         <a href="https://www.rfc-editor.org/rfc/rfc8809">RFC8809</a>. The list MUST NOT include duplicate values nor be empty if present. Platforms MUST tolerate unknown values. Support for "none" attestation is implied and MUST be omitted.
    ///     </para>
    /// </summary>
    public string[]? AttestationFormats { get; }
}
