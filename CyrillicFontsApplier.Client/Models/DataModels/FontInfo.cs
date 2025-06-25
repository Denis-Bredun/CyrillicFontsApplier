using CyrillicFontsApplier.Client.Models.Enums;

namespace CyrillicFontsApplier.Client.Models.DataModels
{
    public class FontInfo
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public string LocalPath { get; set; }
        public FontOrigin Origin { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime? LastUsed { get; set; }
        public DateTime? DownloadedAt { get; set; }
    }
}
