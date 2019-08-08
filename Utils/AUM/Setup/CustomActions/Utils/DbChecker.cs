namespace CustomActions.Utils
{
  using System;
  using System.Data.SqlClient;
  using System.Globalization;
  using PropertyContainers;


  internal static class DbChecker
  {
    internal static bool TestConnection(IPropertyContainer contaier, string serverProperty, string databaseProperty, string userProperty, string passwordPropety)
    {
      var server = contaier[serverProperty];
      var database = contaier[databaseProperty];
      var user = contaier[userProperty];
      var password = contaier[passwordPropety];

      return TestConnection(server, database, user, password);
    }

    private static bool TestConnection(string server, string database, string user, string password)
    {
      if (!IsCorrect(server, database, user, password))
      {
        return false;
      }

      try
      {
        return TestConnection(ConnectionString(server, database, user, password));
      }
      catch (Exception)
      {
        return false;
      }
    }

    private static bool TestConnection(string connectionString)
    {
      SqlConnection connection = null;

      try
      {
        connection = new SqlConnection(connectionString);
        using (var cmd = new SqlCommand("Select 0", connection))
        {
          cmd.CommandTimeout = 3;
          connection.Open();
          cmd.ExecuteNonQuery();
        }
        return true;
      }
      finally
      {
        if (null != connection)
        {
          connection.Close();
        }
      }
    }

    private static string ConnectionString(string server, string database, string user, string password)
    {
      return string.Format(
        CultureInfo.InvariantCulture,
        "Persist Security Info=False;User ID={0};Password={1};Initial Catalog={2};Data Source={3};Connection timeout = 2",
        user,
        password,
        database,
        server);
    }

    private static bool IsCorrect(string server, string database, string user, string password)
    {
      return !string.IsNullOrEmpty(server) &&
             !string.IsNullOrEmpty(database) &&
             !string.IsNullOrEmpty(user) &&
             !string.IsNullOrEmpty(password);
    }
  }
}