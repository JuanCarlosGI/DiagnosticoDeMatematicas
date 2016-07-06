namespace DiagnosticoDeMatematicas.Helpers
{
    using Models;

    /// <summary>
    /// Class in charge of determining certain states of the current session.
    /// </summary>
    public static class SessionValidator
    {
        /// <summary>
        /// Gets a value indicating whether a user is currently signed in.
        /// </summary>
        public static bool IsSignedIn
        {
            get
            {
                return SessionService.User != null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether an administrator is signed in.
        /// </summary>
        public static bool IsAdminSignedIn
        {
            get
            {
                return IsSignedIn && SessionService.User.Role == Role.Administrador;
            }
        }
    }
}