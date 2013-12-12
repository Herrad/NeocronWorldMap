namespace NeocronWorldMap.Web.ViewModels
{
    public class ClanViewModel
    {
        public ClanViewModel(string factionName)
        {
            FactionName = factionName;
        }

        public string FactionName { get; private set; }
    }
}