using CyrillicFontsApplier.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Tests.UnitTests
{
    public class FontInfoViewModelTests
    {
        private const string TestFilename = "Alegreya-Regular.ttf";
        private const string ExpectedAlias = "AlegreyaRegular";
        private const string ExpectedDisplayedName = "Alegreya";

        [Fact]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Act
            var viewModel = new FontInfoViewModel(TestFilename);

            // Assert
            Assert.Equal(TestFilename, viewModel.Filename);
            Assert.Equal(ExpectedAlias, viewModel.Alias);
            Assert.Equal(ExpectedDisplayedName, viewModel.DisplayedName);
            Assert.False(viewModel.IsFavorite);
        }
    }
}
