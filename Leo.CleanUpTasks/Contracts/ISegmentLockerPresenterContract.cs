namespace Leo.CleanUpTasks.Contracts
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClassFor(typeof(ISegmentLockerPresenter))]
    internal abstract class ISegmentLockerPresenterContract : ISegmentLockerPresenter
    {
        public void Initialize()
        {
        }

        public void SaveSettings()
        {
        }
    }
}
