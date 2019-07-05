using System;
using System.IO;
using System.Text;

namespace Common.Helper.Exceptions.Logger
{
    public class EventLogger
    {
        public static void Error(Exception ex, string userMessage)
        {
            WriteError(ex, userMessage, null);
        }

        public static void Error(Exception ex, string userMessage, object entityValues)
        {
            WriteError(ex, userMessage, entityValues);
        }

        private static void WriteError(Exception ex, string userMessage, object entityValues)
        {
            string filePath = @"D:\Error.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                Exception temp = ex;
                while (temp.InnerException != null)
                {
                    temp = ex.InnerException;
                }
                StringBuilder sb = new StringBuilder();
                sb.Append(DateTimeOffset.UtcNow.ToString());
                sb.Append(" [");
                sb.Append(DateTime.Now.ToString());
                sb.AppendLine("]");
                sb.AppendLine(temp.Message);
                sb.AppendLine(ex.StackTrace);

                if (entityValues != null)
                {
                    sb.Append("   ");
                    sb.AppendLine(entityValues.ToString());
                }
                sb.Append("-----------------------------------------------------------------------------");
                writer.WriteLine(sb);
            }
        }
    }
}
