using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public class OutpostViewModelBuilder : IBuildOutpostViewModels
    {
        private readonly IFormatTimeSpans _timeFormatter;

        public OutpostViewModelBuilder(IFormatTimeSpans timeFormatter)
        {
            _timeFormatter = timeFormatter;
        }

        public OutpostViewModel Build(IHaveOutpostData outpost)
        {
            var ownershipInformation = outpost.CurrentOwners;

            var timeOwnedFor = _timeFormatter.FormatTime(ownershipInformation.TimeOwnedFor);

            var factionClass = FormatFactionNameForCSSClass(ownershipInformation.Faction.Name);
            var outpostOwnershipViewModel = new OutpostOwnershipViewModel(ownershipInformation.Name, ownershipInformation.Faction.Name, factionClass, timeOwnedFor);

            return new OutpostViewModel(outpost.Name, outpostOwnershipViewModel);
        }

        private string FormatFactionNameForCSSClass(string factionName)
        {
            return factionName.ToLower().Replace(' ', '-');
        }
    }
}