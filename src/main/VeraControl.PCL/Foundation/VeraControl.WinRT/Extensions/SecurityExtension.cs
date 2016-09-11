using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;

namespace VeraControl.Extensions
{
    internal static class SecurityExtension
    {

        internal static string Sha1Hash(this String value)
        {

            HashAlgorithmProvider hashProvider = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha1);
            var buffUft8Msg = CryptographicBuffer.ConvertStringToBinary(value, BinaryStringEncoding.Utf8);

            var buffHash = hashProvider.HashData(buffUft8Msg);

            if (buffHash.Length != hashProvider.HashLength)
            {
                throw new Exception("There was an error creating the hash");
            }

            var strHashBase64 = CryptographicBuffer.EncodeToHexString(buffHash);

            return strHashBase64;
        }
    }
}
