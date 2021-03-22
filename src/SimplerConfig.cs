using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SimplerConfig
{
    /// <summary>
    /// Default implementation for ConfigProfider
    /// </summary>
    public class SConfig : ISimplerConfig
    {
        /// <summary>
        /// Arguments passed to `Main` on Startup. Has to be set manually
        /// </summary>
        /// <value></value>
        public string[] StartArgs { get; set; }

        /// <summary>
        /// Name of additonal file containing settings that will overwrite the defaults
        /// </summary>
        public static string CustomConfigName = "custom.conf.json";

        /// <summary>
        /// An Instance of <see cref="ISimplerConfig"/> to be used as Provider
        /// </summary>
        /// <value></value>
        public static ISimplerConfig Instance { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SConfig () { }

        static SConfig()
        {
            Instance = new SConfig();
        }

        /// <summary>
        /// The combined settings for this app
        /// </summary>
        /// <value>The combined settings of this app</value>
        public IConfigurationRoot AppSettings
        {
            get
            {
                var builder = new ConfigurationBuilder ()
                    .SetBasePath (ApplicationExeDirectory)
                    .AddJsonFile ("appsettings.json",true)
                    .AddJsonFile (CustomConfigName, true, true)
                    .AddEnvironmentVariables ();

                if (StartArgs != null)
                    builder = builder.AddCommandLine (StartArgs);

                return builder.Build ();
            }
        }

        /// <summary>
        /// Get or set a setting by key
        /// </summary>
        public string this [string key] => AppSettings[key];

        private static string ApplicationExeDirectory
        {
            get
            {
                var location = System.Reflection.Assembly.GetExecutingAssembly ().Location;
                var appRoot = Path.GetDirectoryName (location);

                return appRoot;
            }
        }
    }

    /// <summary>
    /// Legacy Api consider using <see cref="SConfig"/> wich is less likely to conflict with other namespaces
    /// </summary>
    public class Config : SConfig
    {

    }
}