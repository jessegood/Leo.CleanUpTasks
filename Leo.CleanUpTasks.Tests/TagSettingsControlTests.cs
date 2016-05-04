namespace Leo.CleanUpTasks.Tests
{
    using System;
    using Xunit;

    public class TagSettingsControlTests
    {
        [Fact]
        public void SetSettingsThrowsOnNull()
        {
            var control = new TagsSettingsControl();
            Assert.Throws<ArgumentNullException>(() => control.SetSettings(null));
        }
    }
}