using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrillicFontsApplier.Client.ViewModels
{
    public partial class FontInfoViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isFavorite;

        public string DisplayedName { get; set; }
        public string Alias { get; set; }
        public string Filename { get; set; }        

        public FontInfoViewModel(string filename)
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

        private string CleanAliasFromTrash(string aliasWithTrash)
            => aliasWithTrash.Replace("-", "").Replace(" ", "");

        private string GetDisplayedName(string alias)
            => alias.Replace("Regular", "");
    }
}
