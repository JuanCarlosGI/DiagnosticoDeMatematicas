namespace DiagnosticoDeMatematicas.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    /// <summary>
    /// Class serving as a container for all extension methods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Random object used throughout all execution.
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// Returns HTML markup for each property in the object that is represented by the <see cref="Expression"/> expression.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <returns>The HTML markup for each property in the object that is represented by the expression, including line breaks.</returns>
        public static MvcHtmlString DisplayWithBreaksFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var model = html.Encode(metadata.Model).Replace("\n", "<br />");

            if (string.IsNullOrEmpty(model))
            {
                return MvcHtmlString.Empty;
            }

            return MvcHtmlString.Create(model);
        }

        /// <summary>
        /// Shuffles the IEnumerable using the Fisher-Yates algorithm.
        /// </summary>
        /// <typeparam name="T">The type of IEnumerable.</typeparam>
        /// <param name="source">The IEnumerable that this method is extending.</param>
        /// <returns>The shuffled IEnumerator.</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.Shuffle(Random);
        }

        /// <summary>
        /// Shuffles the IEnumerable using the Fisher-Yates algorithm.
        /// </summary>
        /// <typeparam name="T">The type of IEnumerable.</typeparam>
        /// <param name="source">The IEnumerable that this method is extending.</param>
        /// <param name="rng">The <see cref="Random"/> object to be used</param>
        /// <returns>The shuffled IEnumerator.</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (rng == null)
            {
                throw new ArgumentNullException(nameof(rng));
            }

            return source.ShuffleIterator(rng);
        }

        /// <summary>
        /// Shuffles the IEnumerable using the Fisher-Yates algorithm. For more information, 
        /// see <a href="https://github.com/plasma-umass/DataDebug/blob/master/UserSimulation/EnumerableExtensions.cs">this link</a>.
        /// </summary>
        /// <typeparam name="T">The type of IEnumerable.</typeparam>
        /// <param name="source">The IEnumerable that this method is extending.</param>
        /// <param name="rng">The <see cref="Random"/> object to be used</param>
        /// <returns>The shuffled IEnumerator.</returns>
        private static IEnumerable<T> ShuffleIterator<T>(
            this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}