namespace DiagnosticoDeMatematicas.Helpers.Functions.FunctionTypes
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class representing a polynomial function.
    /// </summary>
    public class Polynomial : Function
    {
        /// <summary>
        /// List of coefficients representing the polynomial function.
        /// </summary>
        private readonly List<double> coefficients;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coefficients">Array of coefficients representing the polynomial.</param>
        public Polynomial(params double[] coefficients)
        {
            this.coefficients = new List<double>();
            foreach (var coefficient in coefficients)
            {
                this.coefficients.Add(coefficient);
            }
        }

        /// <summary>
        /// Gets the degree of the polynomial function.
        /// </summary>
        public int Degree
        {
            get
            {
                return Coefficients.Length - 1;
            }
        }

        /// <summary>
        /// Gets the array of coefficients representing the polynomial.
        /// </summary>
        public double[] Coefficients
        {
            get
            {
                return coefficients.ToArray();
            }
        }

        /// <summary>
        /// Evaluates the polynomial function.
        /// </summary>
        /// <param name="x">Value for 'x'</param>
        /// <returns>The evaluated value.</returns>
        public override double Evaluate(double x)
        {
            double result = 0;
            for (int degree = Degree; degree >= 0; degree--)
            {
                result += Math.Pow(x, degree) * Coefficients[Degree - degree];
            }

            return result;
        }

        /// <summary>
        /// Gets the derivate of the function.
        /// </summary>
        /// <returns>The derivate of the function.</returns>
        public override Function Derivate()
        {
            if (Degree <= 0)
            {
                return new Polynomial(new double[] { 0 });
            }

            List<double> newCoefficients = new List<double>();
            for (int degree = Degree; degree > 0; degree--)
            {
                newCoefficients.Add(degree * Coefficients[Degree - degree]);
            }

            return new Polynomial(newCoefficients.ToArray());
        }
    }
}