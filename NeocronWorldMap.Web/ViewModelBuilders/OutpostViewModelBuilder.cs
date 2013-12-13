using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public class OutpostViewModelBuilder : IBuildOutpostViewModels
    {
        public OutpostViewModel Build(IHaveOutpostData outpost)
        {
            var currentOwners = outpost.CurrentOwners;
            var outpostOwnershipViewModel = new OutpostOwnershipViewModel(currentOwners.Name, currentOwners.Faction.Name);

            return new OutpostViewModel(outpost.Name, outpostOwnershipViewModel);
        }
    }
}