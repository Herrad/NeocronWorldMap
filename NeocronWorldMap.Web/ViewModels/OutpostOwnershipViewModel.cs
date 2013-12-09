namespace NeocronWorldMap.Web.ViewModels
{
    public class OutpostOwnershipViewModel
    {
        public OutpostOwnershipViewModel(string factionName)
        {
            FactionName = factionName;
        }

        public string FactionName { get; private set; }
    }
}