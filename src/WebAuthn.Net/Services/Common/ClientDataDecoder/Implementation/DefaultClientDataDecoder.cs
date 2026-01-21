using System;
using Microsoft.Extensions.Logging;
using WebAuthn.Net.Models;
using WebAuthn.Net.Services.Common.ClientDataDecoder.Implementation.Models;
using WebAuthn.Net.Services.Common.ClientDataDecoder.Models;
using WebAuthn.Net.Services.Common.ClientDataDecoder.Models.Enums;
using WebAuthn.Net.Services.Serialization.Json;
using WebAuthn.Net.Services.Static;

namespace WebAuthn.Net.Services.Common.ClientDataDecoder.Implementation;

/// <summary>
///     Default implementation of <see cref="IClientDataDecoder" />.
/// </summary>
public class DefaultClientDataDecoder : IClientDataDecoder
{
    /// <summary>
    ///     Constructs <see cref="DefaultClientDataDecoder" />
    /// </summary>
    /// <param name="safeJsonSerializer">Safe (exceptionless) JSON serializer.</param>
    /// <param name="tokenBindingStatusSerializer">Serializer for the <see cref="TokenBindingStatus" /> enum.</param>
    /// <param name="logger">Logger.</param>
    /// <exception cref="ArgumentNullException">Any of the parameters is <see langword="null" /></exception>
    public DefaultClientDataDecoder(
        ISafeJsonSerializer safeJsonSerializer,
        IEnumMemberAttributeSerializer<TokenBindingStatus> tokenBindingStatusSerializer,
        ILogger<DefaultClientDataDecoder> logger)
    {
        ArgumentNullException.ThrowIfNull(safeJsonSerializer);
        ArgumentNullException.ThrowIfNull(tokenBindingStatusSerializer);
        ArgumentNullException.ThrowIfNull(logger);
        SafeJsonSerializer = safeJsonSerializer;
        TokenBindingStatusSerializer = tokenBindingStatusSerializer;
        Logger = logger;
    }

    /// <summary>
    ///     Safe (exceptionless) JSON serializer.
    /// </summary>
    protected ISafeJsonSerializer SafeJsonSerializer { get; }

    /// <summary>
    ///     Serializer for the <see cref="TokenBindingStatus" /> enum.
    /// </summary>
    protected IEnumMemberAttributeSerializer<TokenBindingStatus> TokenBindingStatusSerializer { get; }

    /// <summary>
    ///     Logger.
    /// </summary>
    protected ILogger<DefaultClientDataDecoder> Logger { get; }

    /// <inheritdoc />
    public virtual Result<CollectedClientData> Decode(string jsonText)
    {
        var clientDataResult = SafeJsonSerializer.DeserializeNonNullable<CollectedClientDataJson>(jsonText);
        if (clientDataResult.HasError)
        {
            Logger.FailedToDeserializeClientData();
            return Result<CollectedClientData>.Fail();
        }

        var clientData = clientDataResult.Ok;
        if (string.IsNullOrEmpty(clientData.Type))
        {
            Logger.ClientDataTypeIsNullOrEmpty();
            return Result<CollectedClientData>.Fail();
        }

        if (string.IsNullOrEmpty(clientData.Challenge))
        {
            Logger.ClientDataChallengeIsNullOrEmpty();
            return Result<CollectedClientData>.Fail();
        }

        if (string.IsNullOrEmpty(clientData.Origin))
        {
            Logger.ClientDataOriginIsNullOrEmpty();
            return Result<CollectedClientData>.Fail();
        }

        TokenBinding? tokenBinding = null;
        if (clientData.TokenBinding is not null)
        {
            if (!TokenBindingStatusSerializer.TryDeserialize(clientData.TokenBinding.Status, out var tokenBindingStatus))
            {
                Logger.FailedToDeserializeTokenBindingStatus();
                return Result<CollectedClientData>.Fail();
            }

            if (tokenBindingStatus == TokenBindingStatus.Present && string.IsNullOrEmpty(clientData.TokenBinding.Id))
            {
                Logger.TokenBindingIdIsRequired();
                return Result<CollectedClientData>.Fail();
            }

            byte[]? tokenBindingId = null;
            if (!string.IsNullOrEmpty(clientData.TokenBinding.Id))
            {
                if (!Base64Url.TryDecode(clientData.TokenBinding.Id, out var decodedTokenBindingId))
                {
                    Logger.FailedToDecodeTokenBindingId();
                    return Result<CollectedClientData>.Fail();
                }

                tokenBindingId = decodedTokenBindingId;
            }

            tokenBinding = new(tokenBindingStatus.Value, tokenBindingId);
        }

        var result = new CollectedClientData(
            clientData.Type,
            clientData.Challenge,
            clientData.Origin,
            clientData.CrossOrigin,
            clientData.TopOrigin,
            tokenBinding);
        return Result<CollectedClientData>.Success(result);
    }
}

/// <summary>
///     Extension methods for logging the 'clientData' decoder.
/// </summary>
public static partial class DefaultClientDataDecoderLoggingExtensions
{
    /// <summary>
    ///     Failed to deserialize 'clientData'
    /// </summary>
    /// <param name="logger">Logger.</param>
    [LoggerMessage(
        Level = LogLevel.Warning,
        Message = "Failed to deserialize 'clientData'")]
    public static partial void FailedToDeserializeClientData(this ILogger logger);

    /// <summary>
    ///     'clientData.type' contains an empty string or null
    /// </summary>
    /// <param name="logger">Logger.</param>
    [LoggerMessage(
        Level = LogLevel.Warning,
        Message = "'clientData.type' contains an empty string or null")]
    public static partial void ClientDataTypeIsNullOrEmpty(this ILogger logger);

    /// <summary>
    ///     'clientData.challenge' contains an empty string or null
    /// </summary>
    /// <param name="logger">Logger.</param>
    [LoggerMessage(
        Level = LogLevel.Warning,
        Message = "'clientData.challenge' contains an empty string or null")]
    public static partial void ClientDataChallengeIsNullOrEmpty(this ILogger logger);

    /// <summary>
    ///     'clientData.origin' contains an empty string or null
    /// </summary>
    /// <param name="logger">Logger.</param>
    [LoggerMessage(
        Level = LogLevel.Warning,
        Message = "'clientData.origin' contains an empty string or null")]
    public static partial void ClientDataOriginIsNullOrEmpty(this ILogger logger);

    /// <summary>
    ///     Failed to deserialize 'clientData.tokenBinding.status'
    /// </summary>
    /// <param name="logger">Logger.</param>
    [LoggerMessage(
        Level = LogLevel.Warning,
        Message = "Failed to deserialize 'clientData.tokenBinding.status'")]
    public static partial void FailedToDeserializeTokenBindingStatus(this ILogger logger);

    /// <summary>
    ///     'clientData.tokenBinding.id' is required when 'clientData.tokenBinding.status' is 'present'
    /// </summary>
    /// <param name="logger">Logger.</param>
    [LoggerMessage(
        Level = LogLevel.Warning,
        Message = "'clientData.tokenBinding.id' is required when 'clientData.tokenBinding.status' is 'present'")]
    public static partial void TokenBindingIdIsRequired(this ILogger logger);

    /// <summary>
    ///     Failed to decode 'clientData.tokenBinding.id' from base64url
    /// </summary>
    /// <param name="logger">Logger.</param>
    [LoggerMessage(
        Level = LogLevel.Warning,
        Message = "Failed to decode 'clientData.tokenBinding.id' from base64url")]
    public static partial void FailedToDecodeTokenBindingId(this ILogger logger);
}
