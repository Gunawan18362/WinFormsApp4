using System;
using Npgsql;

namespace WinFormsApp4
{
    internal class UserRepository
    {
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=daffa21122005;Database=coba";

        public bool UpdateUsername(int userId, string newUsername)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "UPDATE users SET username = @username WHERE user_id = @user_id";


                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", newUsername);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    var affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows > 0;
                }
            }
        }
    }
}
