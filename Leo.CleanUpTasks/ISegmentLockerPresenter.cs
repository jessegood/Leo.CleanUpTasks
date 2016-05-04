namespace Leo.CleanUpTasks
{
    using Contracts;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(ISegmentLockerPresenterContract))]
    public interface ISegmentLockerPresenter
    {
        void Initialize();
        void SaveSettings();
    }
}