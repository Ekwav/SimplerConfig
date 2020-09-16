namespace SimplerConfig
{
    public interface ISimplerConfig
    {
        /// <summary>
        /// Get or set a setting by key
        /// </summary>
        string this[string key] { get; }

        string[] StartArgs { set; }
    }
}