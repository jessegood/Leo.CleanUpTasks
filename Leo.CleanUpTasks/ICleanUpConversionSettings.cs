namespace Leo.CleanUpTasks
{
    using Contracts;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(ICleanUpConversionSettingsContract))]
    public interface ICleanUpConversionSettings : ISettings
    {
        Dictionary<string, bool> ConversionFiles { get; set; }
        string LastFileDirectory { get; set; }
        bool UseConversionSettings { get; set; }
    }
}