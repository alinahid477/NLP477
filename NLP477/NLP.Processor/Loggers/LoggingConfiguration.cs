﻿using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP.Processor.Loggers
{
    public class LoggingConfigurator : ILoggingConfigurator
    {
        public LoggingConfiguration BuildLoggingConfig()
        {
            String logFileLocation = ConfigurationManager.AppSettings["ErrorLogLocation"];
            // Formatters
            TextFormatter formatter = new TextFormatter("Timestamp: {timestamp}{newline}Message: {message}{newline}Category: {category}{newline}Priority: {priority}{newline}EventId: {eventid}{newline}Severity: {severity}{newline}Title:{title}{newline}Machine: {localMachine}{newline}App Domain: {localAppDomain}{newline}ProcessId: {localProcessId}{newline}Process Name: {localProcessName}{newline}Thread Name: {threadName}{newline}Win32 ThreadId:{win32ThreadId}{newline}Extended Properties: {dictionary({key} - {value}{newline})}");

            // Listeners
            //var flatFileTraceListener = new FlatFileTraceListener(@"C:\Temp\TISOnlineError.log", "----------------------------------------", "----------------------------------------", formatter);

            var rollingFlatFileTraceListener = new RollingFlatFileTraceListener(
              logFileLocation + "TISOnlineError.log",
              "----------------------------------------",
              "----------------------------------------",
              formatter, 2000, "yyyy-MM-dd",
              RollFileExistsBehavior.Increment, RollInterval.Day, 20);
            var eventLog = new EventLog("Application", ".", "Enterprise Library Logging");
            var eventLogTraceListener = new FormattedEventLogTraceListener(eventLog);
            // Build Configuration
            var config = new LoggingConfiguration();
            config.AddLogSource("General", SourceLevels.All, true).AddTraceListener(eventLogTraceListener);
            config.LogSources["General"].AddTraceListener(rollingFlatFileTraceListener);

            // Special Sources Configuration
            config.SpecialSources.LoggingErrorsAndWarnings.AddTraceListener(eventLogTraceListener);

            return config;
        }
    }
}
