namespace Leo.CleanUpTasks
{
    using Contracts;
    using Sdl.Core.Settings;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    [ContractClass(typeof(ISettingsContract))]
    public interface ISettings
    {
        ISettingsGroup Settings { get; set; }
        CultureInfo SourceCulture { get; set; }
    }
}