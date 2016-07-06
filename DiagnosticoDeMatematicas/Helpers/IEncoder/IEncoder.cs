namespace DiagnosticoDeMatematicas.Helpers.IEncoder
{
    /// <summary>
    /// Interface for a class that will be able to encode a string.
    /// </summary>
    public interface IEncoder
    {
        /// <summary>
        /// Encodes a string.
        /// </summary>
        /// <param name="text">String to be encoded.</param>
        /// <returns>Encoded string.</returns>
        string Encode(string text);
    }
}
