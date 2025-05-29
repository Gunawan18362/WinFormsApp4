using System;

namespace WinFormsApp4
{
    public static class User
    {
        public static int Id { get; set; }
        public static string Username { get; set; }

        public static void UpdateUsername(string newUsername)
        {
            Username = newUsername;
        }

    }
}
