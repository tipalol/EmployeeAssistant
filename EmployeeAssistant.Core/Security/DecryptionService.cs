using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeAssistant.Core.Security
{
    internal class DecryptionService
    {
        private const string DecryptionErrorMessage = "Error during decryption ";
        
        internal static string Decrypt(byte[] encrypted)
        {
            try
            {
                var byteConverter = new UnicodeEncoding();

                using var rsa = new RSACryptoServiceProvider();

                var decryptedData = RsaDecrypt(encrypted, rsa.ExportParameters(true), false);
                var decryptedText = byteConverter.GetString(decryptedData);

                return decryptedText;
            }
            catch (Exception e)
            {
                throw new SecurityException(DecryptionErrorMessage + e.Message, e);
            }
        }

        private static byte[] RsaDecrypt(byte[] dataToDecrypt, RSAParameters rsaKeyInfo, bool doOaepPadding)
        {
            using var rsa = new RSACryptoServiceProvider();

            //Import the RSA Key information. This needs
            //to include the private key information.
            rsa.ImportParameters(rsaKeyInfo);

            //Decrypt the passed byte array and specify OAEP padding.  
            var decryptedData = rsa.Decrypt(dataToDecrypt, doOaepPadding);

            return decryptedData;
        }
    }
}