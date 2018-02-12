using System.Collections.Generic;

namespace Knjiznice.Models.Clan
{
    public class ClanIndexModel
    {
        public IEnumerable<ClanDetailModel> Clanovi { get; set; } //ovaj model vraćamo Index View-u
    }
}
