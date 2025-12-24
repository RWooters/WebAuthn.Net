using System;
using System.Security.Cryptography;

namespace WebAuthn.Net.Services.Common.ChallengeGenerator.Implementation;

/// <summary>
///     Default implementation of <see cref="IChallengeGenerator" />.
/// </summary>
public class DefaultChallengeGenerator : IChallengeGenerator
{
    /// <inheritdoc />
    public virtual byte[] GenerateChallenge(int size)
    {
        // https://www.w3.org/TR/webauthn-3/#sctn-cryptographic-challenges
        // In order to prevent replay attacks,
        // the challenges MUST contain enough entropy to make guessing them infeasible.
        // Challenges SHOULD therefore be at least 16 bytes long.
        if (size < 16)
        {
            throw new ArgumentException($"The minimum value of {nameof(size)} is 16.", nameof(size));
        }

        return RandomNumberGenerator.GetBytes(size);
    }
}
