﻿namespace Leo.CleanUpTasks.Tests
{
    using System;
    using Xunit;
    using NSubstitute;
    using Utilities;
    using Models;

    public class NonTranslatableHandlerTests : IClassFixture<TestUtilities>
    {
        [Fact]
        public void ConstructorThrowsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new NonTranslatableHandler(null, null, null));
        }

        [Fact]
        public void VisitTextUpdatesText()
        {
            // Arrange
            var settings = Substitute.For<ISettings>();
            var conversionItems = utility.CreateConversionItemLists(@"\s\s",
                                                                    replacementText: " ",
                                                                    useRegex: true);
            var reportGenerator = Substitute.For<IXmlReportGenerator>();

            var text = utility.CreateText("  ");
            var handler = new NonTranslatableHandler(settings, conversionItems, reportGenerator);

            // Act
            handler.VisitText(text);
            handler.ProcessText();

            Assert.Equal(1, text.Properties.Text.Length);
        }

        #region Fixture

        private readonly TestUtilities utility = null;

        public NonTranslatableHandlerTests(TestUtilities utility)
        {
            this.utility = utility;
        }

        #endregion Fixture
    }
}