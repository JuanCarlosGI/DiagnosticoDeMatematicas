namespace DiagnosticoDeMatematicas.Helpers
{
    using System.Web;
    using DAL;
    using Models;

    /// <summary>
    /// Class representing a session object.
    /// </summary>
    public static class SessionService
    {
        /// <summary>
        /// Identifier for the User field in the session object.
        /// </summary>
        private static readonly string UserIdentifier = "User";

        /// <summary>
        /// Gets or sets the current user in the session.
        /// </summary>
        public static User User
        {
            get
            {
                HttpContext context = HttpContext.Current;

                SiteContext db = new SiteContext();
                return db.Users.Find(context.Session[UserIdentifier]);
            }

            set
            {
                HttpContext context = HttpContext.Current;
                context.Session[UserIdentifier] = value.Email;
            }
        }

        /// <summary>
        /// Sets the timeout for the current session.
        /// </summary>
        public static int Timeout
        {
            set
            {
                HttpContext context = HttpContext.Current;
                context.Session.Timeout = value;
            }
        }

        /// <summary>
        /// Clears all values from the current session.
        /// </summary>
        public static void Clear()
        {
            HttpContext context = HttpContext.Current;
            context.Session.RemoveAll();
        }
    }
}