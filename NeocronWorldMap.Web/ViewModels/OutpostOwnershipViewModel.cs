namespace NeocronWorldMap.Web.ViewModels
{
    public class OutpostOwnershipViewModel
    {
        public OutpostOwnershipViewModel(string clanName)
        {
            ClanName = clanName;
        }

        public string ClanName { get; private set; }
    }
}