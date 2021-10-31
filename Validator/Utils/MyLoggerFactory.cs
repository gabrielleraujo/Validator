namespace Validator.Utils
{
    using Microsoft.Extensions.Logging;


    public static class MyLoggerFactory
    {
        public static ILogger<T> Create<T>()
        {
            using ILoggerFactory loggerFactory =
                    LoggerFactory.Create(builder =>
                        builder.AddSimpleConsole(options =>
                        {
                            options.IncludeScopes = true;
                            options.SingleLine = true;
                            options.TimestampFormat = "hh:mm:ss ";
                        }));

            ILogger<T> logger = loggerFactory.CreateLogger<T>();

            return logger;
        }
    }
}