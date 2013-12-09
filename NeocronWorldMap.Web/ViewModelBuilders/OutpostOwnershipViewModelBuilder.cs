using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public class OutpostOwnershipViewModelBuilder : IBuildOutpostOwnershipViewModels
    {
        public OutpostOwnershipViewModel Build(IHaveInformationAboutOutpostOwnership outpostOwnershipProfile)
        {
            var factionName = outpostOwnershipProfile.Faction.Name;

            return new OutpostOwnershipViewModel(factionName);
        }
    }
}