using NLP.Infrastructure.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Processor.Loggers
{
    public class EventLogger : IEventLogger
    {
        private IEventSerializer eventSerializer;
        private String connectionString;

        public EventLogger(IEventSerializer eventSerializer)
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["EventLogging"].ConnectionString;
            this.eventSerializer = eventSerializer;
        }
        public void LogEvent(IEvent @event)
        {
            String sql = @"insert into EventLog(DateTime,GUID, Event) values(@DateTime, @GUID, @JSON)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@DateTime", System.Data.SqlDbType.DateTime).Value = @event.DateTime;
                    cmd.Parameters.Add("@JSON", System.Data.SqlDbType.VarChar).Value = eventSerializer.SerializeEvent(@event);
                    cmd.Parameters.Add("@GUID", System.Data.SqlDbType.VarChar).Value = @event.EventGUID;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }

        }
    }
}
