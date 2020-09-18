namespace SimplerConfig
{
    public interface ISimplerConfig
    {
        /// <summary>
        /// Get or set a setting by key
        /// </summary>
        string this[string key] { get; }

        /// <summary>
        /// CommandLine Arguments passed
        /// </summary>
        /// <value></value>
        string[] StartArgs { set; }
    }
}