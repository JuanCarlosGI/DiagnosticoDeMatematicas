namespace DiagnosticoDeMatematicas.Helpers.IEncoder
{
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Class in charge of encoding string using SHA256.
    /// </summary>
    public class EncoderSHA256 : IEncoder
    {
        /// <summary>
        /// Encodes a string using SHA256.
        /// </summary>
        /// <param name="text">String to be encoded.</param>
        /// <returns>Encoded string.</returns>
        public string Encode(string text)
        {
            HashAlgorithm hashAlgo = new SHA256Managed();
            byte[] plainTextBytes = Encoding.Unicode.GetBytes(text);
            byte[] hash = hashAlgo.ComputeHash(plainTextBytes);
            return Encoding.Unicode.GetString(hash);
        }
    }
}