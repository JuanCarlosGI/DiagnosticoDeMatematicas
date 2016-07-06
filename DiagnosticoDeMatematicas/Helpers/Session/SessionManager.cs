namespace DiagnosticoDeMatematicas.Helpers
{
    using DAL;

    /// <summary>
    /// Class in charge of signing in and out of the site.
    /// </summary>
    public static class SessionManager
    {
        /// <summary>
        /// Default timeout.
        /// </summary>
        private const int Timeout = 30;

        /// <summary>
        /// Context for the database.
        /// </summary>
        private static SiteContext db = new SiteContext();

        /// <summary>
        /// Tries to sign in to the site.
        /// </summary>
        /// <param name="email">Email of the user to be signed in.</param>
        /// <param name="password">Password for the user.</param>
        /// <returns>Value indicating whether the user was successfully signed in.</returns>
        public static bool TrySignIn(string email, string password)
        {
            if (email == null || password == null)
            {
                return false;
            }

            var user = db.Users.Find(email);

            if (user == null)
            {
                return false;
            }

            IEncoder encoder = new EncoderSHA256();
            var encodedPassword = encoder.Encode(password);

            if (encodedPassword != user.Password)
            {
                return false;
            }

            SessionService.User = user;
            SessionService.Timeout = Timeout;
            return true;
        }

        /// <summary>
        /// Signs out of the site. Clears all the session object.
        /// </summary>
        public static void SignOut()
        {
            SessionService.Clear();
        }
    }
}