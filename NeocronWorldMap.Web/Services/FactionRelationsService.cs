using System.Collections.Generic;
using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public class FactionRelationsService : IKnowFactionRelations
    {
        public IEnumerable<Faction> GetFactionsAbleToGenRepToOutpost(Faction faction, int securityCode)
        {
            if(securityCode == 10)
                return new List<Faction>{faction};

            if(securityCode == 15)
                return new List<Faction>{new Faction("Owning Clan")};

            if (securityCode == 5)
            {
                return GetAllies(faction);
            }

            return new List<Faction>{new Faction("Anyone")};
        }

        private static IEnumerable<Faction> GetAllies(Faction faction)
        {
            var cityAdmin = new Faction("CityAdmin");
            var diamondRealEstate = new Faction("Diamond Real Estate");
            var next = new Faction("Next");
            var tangentTechnologies = new Faction("Tangent Technologies");
            var bioTech = new Faction("BioTech");
            var protoPharm = new Faction("ProtoPharm");
            var tsunamiSyndicate = new Faction("Tsunami Syndicate");
            var blackDragon = new Faction("Black Dragon");
            var brotherhoodOfCrahn = new Faction("Brotherhood of Crahn");
            var cityMercs = new Faction("City Mercs");
            var fallenAngels = new Faction("Fallen Angels");
            var twilightGuardian = new Faction("Twilight Guardian");

            switch (faction.Name)
            {
                case ("CityAdmin"): return new List<Faction> { cityAdmin, diamondRealEstate, tangentTechnologies, bioTech, protoPharm };
                case ("Diamond Real Estate"): return new List<Faction> { cityAdmin, diamondRealEstate, next, tangentTechnologies, tsunamiSyndicate, fallenAngels };
                case ("N.E.X.T"): return new List<Faction> { diamondRealEstate, next, tangentTechnologies };
                case ("Tangent Technologies"): return new List<Faction> { cityAdmin, diamondRealEstate, next, cityMercs };
                case ("BioTech"): return new List<Faction> { cityAdmin, bioTech, protoPharm };
                case ("ProtoPharm"): return new List<Faction> { cityAdmin, bioTech, protoPharm, blackDragon };
                case ("Tsunami Syndicate"): return new List<Faction> { diamondRealEstate, tsunamiSyndicate, cityMercs, fallenAngels };
                case ("Black Dragon"): return new List<Faction> { protoPharm, blackDragon, brotherhoodOfCrahn };
                case ("Brotherhood of Crahn"): return new List<Faction> { blackDragon, brotherhoodOfCrahn, twilightGuardian };
                case ("City Mercs"): return new List<Faction> { tangentTechnologies, tsunamiSyndicate, cityMercs };
                case ("The Fallen Angels"): return new List<Faction> { diamondRealEstate, tsunamiSyndicate, fallenAngels,  twilightGuardian };
                case ("Twilight Guardian"): return new List<Faction> { brotherhoodOfCrahn, faction, twilightGuardian };
            }

            return new List<Faction>{new Faction("Could not find allies of " + faction.Name)};
        }
    }
}