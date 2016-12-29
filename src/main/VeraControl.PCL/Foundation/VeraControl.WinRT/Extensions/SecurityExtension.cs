using System;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;

namespace VeraControl.Extensions
{
    internal static class SecurityExtension
    {
        internal static string Sha1Hash(this string value)
        {
            var hashProvider = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha1);
            var buffUft8Msg = CryptographicBuffer.ConvertStringToBinary(value, BinaryStringEncoding.Utf8);

            var buffHash = hashProvider.HashData(buffUft8Msg);

            if (buffHash.Length != hashProvider.HashLength)
            {
                throw new Exception("Unable to create Hash");
            }

            var strHashBase64 = CryptographicBuffer.EncodeToHexString(buffHash);

            return strHashBase64;
        }
    }
}
