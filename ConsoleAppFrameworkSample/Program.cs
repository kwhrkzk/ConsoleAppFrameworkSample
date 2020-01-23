using ConsoleAppFramework;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleAppFrameworkSample
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            try
            {
                await Host
                    .CreateDefaultBuilder()
                    .ConfigureLogging(ConfigureLogging)
                    .RunConsoleAppFrameworkAsync<ParamTestApp>(args);

                return Environment.ExitCode;
            }
            catch (Exception ex) when ((ex is ArgumentException) || (ex is ArgumentNullException))
            {
                return 1;
            }
            catch (Exception)
            {
                return 9;
            }
        }

        private static void ConfigureLogging(HostBuilderContext hostingContext, ILoggingBuilder logging)
        {
            // logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            logging.AddConsole();
            logging.AddDebug();
            logging.AddEventSourceLogger();
        }
    }
}
