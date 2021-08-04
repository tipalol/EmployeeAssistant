using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeAssistant.Core.Security
{
    internal class EncryptionService
    {
        private const string EncryptionErrorMessage = "Error during encryption ";
        
        internal static byte[] Encrypt(string text)
        {
            try
            {
                var byteConverter = new UnicodeEncoding();
                var dataToEncrypt = byteConverter.GetBytes(text);

                using var rsa = new RSACryptoServiceProvider();

                var encryptedData = RsaEncrypt(dataToEncrypt, rsa.ExportParameters(false), false);

                return encryptedData;
            }
            catch (Exception e)
            {
                throw new SecurityException(EncryptionErrorMessage + e.Message, e);
            }
        }
        
        private static byte[] RsaEncrypt(byte[] dataToEncrypt, RSAParameters rsaKeyInfo, bool doOaepPadding)
        {
            using var rsa = new RSACryptoServiceProvider();
                
            //Import the RSA Key information. This only needs
            //to include the public key information.
            rsa.ImportParameters(rsaKeyInfo);

            //Encrypt the passed byte array and specify OAEP padding.  
            var encryptedData = rsa.Encrypt(dataToEncrypt, doOaepPadding);
                
            return encryptedData;
        }
    }
}