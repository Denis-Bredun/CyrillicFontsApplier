using CyrillicFontsApplier.Client.Constants;
using CyrillicFontsApplier.Client.Interfaces;
using CyrillicFontsApplier.Client.Services;
using CyrillicFontsApplier.Client.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Tests.UnitTests
{
    public class FontFavoriteStatePersistenceServiceTests
    {
        private const string PreferencesKey = "FontFavourite";
        private const string DefaultJson = "{}";

        private const string Font1Filename = "Alegreya-Regular.ttf";
        private const string Font2Filename = "AlegreyaSansSC-Regular.ttf";
        private const string Font3Filename = "AlegreyaSC-Regular.ttf";

        private const string Font1Alias = "AlegreyaRegular";
        private const string Font2Alias = "AlegreyaSansSCRegular";
        private const string Font3Alias = "AlegreyaSCRegular";

        private const string StoredJson = """
        {
            "AlegreyaRegular": false,
            "AlegreyaSansSCRegular": true,
            "AlegreyaSCRegular": true
        }
        """;

        [Fact]
        public void Save_ShouldStoreSerializedDictionaryInPreferences()
        {
            // Arrange
            var preferenceServiceMock = new Mock<IPreferenceService<string, string>>();
            var jsonConverter = new FontFavoritesJsonConverter();
            var service = new FontFavoriteStatePersistenceService(preferenceServiceMock.Object, jsonConverter);

            var fonts = new ObservableCollection<FontInfoViewModel>()
            {
                new(Font1Filename),
                new(Font2Filename) { IsFavorite = true },
                new(Font3Filename) { IsFavorite = true }
            };

            // Act
            service.Save(fonts);

            // Assert
            preferenceServiceMock.Verify(p => p.SetPreference(
                PreferencesKey,
                It.Is<string>(json =>
                    json.Contains($"\"{Font1Alias}\": false") &&
                    json.Contains($"\"{Font2Alias}\": true") &&
                    json.Contains($"\"{Font3Alias}\": true"))
            ), Times.Once);
        }

        [Fact]
        public void Load_ShouldApplyFavoritesFromStoredJson()
        {
            // Arrange
            var preferenceServiceMock = new Mock<IPreferenceService<string, string>>();
            preferenceServiceMock
                .Setup(p => p.GetPreference(PreferencesKey, DefaultJson))
                .Returns(StoredJson);

            var jsonConverter = new FontFavoritesJsonConverter();
            var service = new FontFavoriteStatePersistenceService(preferenceServiceMock.Object, jsonConverter);

            var fonts = new ObservableCollection<FontInfoViewModel>()
            {
                new(Font1Filename) { IsFavorite = true },
                new(Font2Filename),
                new(Font3Filename)
            };

            // Act
            service.Load(fonts);

            // Assert
            Assert.False(fonts.First(f => f.Alias == Font1Alias).IsFavorite);
            Assert.True(fonts.First(f => f.Alias == Font2Alias).IsFavorite);
            Assert.True(fonts.First(f => f.Alias == Font3Alias).IsFavorite);
        }

        [Fact]
        public void Load_ShouldThrow_WhenNoDataPresent()
        {
            // Arrange
            var preferenceServiceMock = new Mock<IPreferenceService<string, string>>();
            preferenceServiceMock
                .Setup(p => p.GetPreference(PreferencesKey, DefaultJson))
                .Returns(DefaultJson);

            var jsonConverter = new FontFavoritesJsonConverter();
            var service = new FontFavoriteStatePersistenceService(preferenceServiceMock.Object, jsonConverter);

            var fonts = new ObservableCollection<FontInfoViewModel>();

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => service.Load(fonts));
            Assert.Equal(Exceptions.FontFavoritesNotFound, exception.Message);
        }
    }
}
