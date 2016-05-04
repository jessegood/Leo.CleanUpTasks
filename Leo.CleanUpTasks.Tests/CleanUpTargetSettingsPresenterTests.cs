namespace Leo.CleanUpTasks.Tests
{
    using System;
    using Xunit;

    public class CleanUpTargetSettingsPresenterTests
    {
        [Fact]
        public void ConstructorThrowsOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => new CleanUpTargetSettingsPresenter(null, null));
        }
    }
}