using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class AppTheme
    {
        public int Id { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondryColor { get; set; }
        public string StatusBarColor { get; set; }
        public string TertiaryColor { get; set; }
        public string TextColor { get; set; }
        public string CurrencySymbols { get; set; }
        public string AppName { get; set; }
        public string AppLogo { get; set; }
        public string AppId { get; set; }
    }
}
