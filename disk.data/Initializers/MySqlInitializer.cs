using System;
using System.Data.Entity;
using System.IO;
using MySql.Data.MySqlClient;

namespace disk.Data.Initializers
{
    public abstract class MySqlInitializer<T> : IDatabaseInitializer<T> where T : DbContext
    {
        public abstract void InitializeDatabase(T context);

        #region Helpers

        /// <summary>
        /// Returns a new DbContext with the same SqlCe connection string, but with the |DataDirectory| expanded
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected static DbContext ReplaceMySqlConnection(DbContext context)
        {
            if (context.Database.Connection is MySqlConnection)
            {
                var builder = new MySqlConnectionStringBuilder(context.Database.Connection.ConnectionString);
                if (!String.IsNullOrWhiteSpace(builder.Database))
                {
                    builder.Database = ReplaceDataDirectory(builder.Database);
                    return new DbContext(builder.ConnectionString);
                }
            }
            return context;
        }

        private static string ReplaceDataDirectory(string inputString)
        {
            string str = inputString.Trim();
            if (string.IsNullOrEmpty(inputString) || !inputString.StartsWith("|DataDirectory|", StringComparison.InvariantCultureIgnoreCase))
            {
                return str;
            }
            var data = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
            if (string.IsNullOrEmpty(data))
            {
                data = AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory;
            }
            if (string.IsNullOrEmpty(data))
            {
                data = string.Empty;
            }
            int length = "|DataDirectory|".Length;
            if ((inputString.Length > "|DataDirectory|".Length) && ('\\' == inputString["|DataDirectory|".Length]))
            {
                length++;
            }
            return Path.Combine(data, inputString.Substring(length));
        }

        #endregion
    }

}
