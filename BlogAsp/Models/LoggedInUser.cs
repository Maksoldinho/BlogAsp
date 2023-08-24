namespace BlogAsp.Models
{
    public static class LoggedInUser
    {
        public static bool IsLoggedIn { get; set; }

        public static bool isAdmin { get; set; }

        public static string UserName { get; set; }

        public static string Password { get; set; }

        public static string Email { get; set; }



        public static void ClearCredentials()
        {
            IsLoggedIn = false;
            UserName = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            isAdmin = false;
        }
    }
}
