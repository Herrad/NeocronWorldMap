using System;
using System.Collections;
using System.Collections.Generic;

namespace NeocronWorldMap.Web.ViewModels
{
    public class OutpostOwnershipViewModel
    {
        public OutpostOwnershipViewModel(string clanName, string factionName, string factionClass, string timeOwnedFor, IEnumerable<string> factionsAbleToGenRep, string securityStatus)
        {
            SecurityStatus = securityStatus;
            FactionsAbleToGenRep = factionsAbleToGenRep;
            FactionClass = factionClass;
            TimeOwnedFor = timeOwnedFor;
            FactionName = factionName;
            ClanName = clanName;
        }

        public string ClanName { get; private set; }

        public string FactionName { get; private set; }

        public string TimeOwnedFor { get; private set; }

        public string FactionClass { get; private set; }
        public IEnumerable<string> FactionsAbleToGenRep { get; private set; }
        public string SecurityStatus { get; private set; }
    }
}