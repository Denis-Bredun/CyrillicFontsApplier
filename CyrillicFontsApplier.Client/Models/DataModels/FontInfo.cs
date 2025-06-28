using CyrillicFontsApplier.Client.Models.Enums;

namespace CyrillicFontsApplier.Client.Models.DataModels
{
    public class FontInfo
    {
        public string DisplayedName { get; set; }
        public string Alias { get; set; }
        public string Filename { get; set; }
        public bool IsFavorite { get; set; }

        public FontInfo(string filename)
        {
            Filename = filename;
            Alias = GetAlias(filename);
            DisplayedName = GetDisplayedName(Alias);
        }

        private string GetAlias(string fontFileName)
        {
            var nameWithoutExtension = Path.GetFileNameWithoutExtension(fontFileName);
            var cleanedName = CleanAliasFromTrash(nameWithoutExtension);
            return cleanedName;
        }

        private string CleanAliasFromTrash(string aliasWithTrash) => aliasWithTrash.Replace("-", "").Replace(" ", "");

        private string GetDisplayedName(string alias) => alias.Replace("Regular", "");
    }
}
