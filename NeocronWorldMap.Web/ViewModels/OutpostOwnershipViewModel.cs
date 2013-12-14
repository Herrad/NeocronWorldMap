using System;

namespace NeocronWorldMap.Web.ViewModels
{
    public class OutpostOwnershipViewModel
    {
        public OutpostOwnershipViewModel(string clanName, string factionName, string timeOwnedFor)
        {
            TimeOwnedFor = timeOwnedFor;
            FactionName = factionName;
            ClanName = clanName;
        }

        public string ClanName { get; private set; }

        public string FactionName { get; private set; }

        public string TimeOwnedFor { get; private set; }
    }
}