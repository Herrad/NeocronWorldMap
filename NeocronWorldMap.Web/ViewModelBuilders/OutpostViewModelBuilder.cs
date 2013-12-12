using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public class OutpostViewModelBuilder : IBuildOutpostViewModels
    {
        public OutpostViewModel Build(IHaveOutpostData outpost)
        {
            var outpostOwnershipViewModel = new OutpostOwnershipViewModel(outpost.CurrentOwners.Name);

            return new OutpostViewModel(outpost.Name, outpostOwnershipViewModel);
        }
    }
}