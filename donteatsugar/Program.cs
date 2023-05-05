// See https://aka.ms/new-console-template for more information

using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
Log.Information("Hello, World!");
