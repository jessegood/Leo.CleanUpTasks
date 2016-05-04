namespace Leo.CleanUpTasks.Tests
{
    using System;
    using Xunit;

    public class TargetCleanUpHandlerTests : IClassFixture<TestUtilities>
    {
        [Fact]
        public void ConstructorThrowsOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => new TargetCleanUpHandler(null, null, null));
        }

        #region Fixture

        private readonly TestUtilities utility = null;

        public TargetCleanUpHandlerTests(TestUtilities utility)
        {
            this.utility = utility;
        }

        #endregion Fixture
    }
}