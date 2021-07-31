using System;
using System.Data;
using DbUp.Engine;

namespace DbUp.Infrastructure.Persistence.Scripts
{
    public class Scripts0002_CreateTagsTable : IScript
    {
        public string ProvideScript(Func<IDbCommand> commandFactory)
        {
            var command = commandFactory();

            command.CommandText = "CREATE TABLE [dbo].[Tags]([Id] [nvarchar](3) NOT NULL,[Name] [nvarchar](255) NULL) ON [PRIMARY]";
            command.ExecuteNonQuery();

            return "";
        }
    }
}
