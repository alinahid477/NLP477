using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Infrastructure.Commands
{
    public class CommandLogger : ICommandLogger
    {
        private ICommandSerializer commandSerializer;
        private String connectionString;

        public CommandLogger(ICommandSerializer commandSerializer)
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["CommandLogging"].ConnectionString;
            this.commandSerializer = commandSerializer;
        }
        public void LogCommand(ICommand command)
        {
            String sql = @"insert into CommandLog(DateTime,GUID,Command,Status) values(@DateTime, @GUID, @JSON, @CommandStatus)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@DateTime", System.Data.SqlDbType.DateTime).Value = command.DateTime;
                    cmd.Parameters.Add("@GUID", System.Data.SqlDbType.VarChar).Value = command.GUID;
                    cmd.Parameters.Add("@JSON", System.Data.SqlDbType.VarChar).Value = commandSerializer.SerializeCommand(command);
                    cmd.Parameters.Add("@CommandStatus", System.Data.SqlDbType.VarChar).Value = command.CommandStatus.ToString();

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }

        }
    }
}
