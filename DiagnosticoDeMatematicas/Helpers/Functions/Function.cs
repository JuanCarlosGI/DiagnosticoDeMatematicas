namespace DiagnosticoDeMatematicas.Helpers.Functions
{
    /// <summary>
    /// Abstract class representing a function.
    /// </summary>
    public abstract class Function
    {
        /// <summary>
        /// Evaluates the function.
        /// </summary>
        /// <param name="x">Value of 'x' to be evaluated.</param>
        /// <returns>The evaluated value.</returns>
        public abstract double Evaluate(double x);

        /// <summary>
        /// Gets the derivate of the function.
        /// </summary>
        /// <returns>The derivate of the function.</returns>
        public abstract Function Derivate();
    }
}