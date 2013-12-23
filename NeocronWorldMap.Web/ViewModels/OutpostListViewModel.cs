using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.ViewModels
{
    public class OutpostListViewModel
    {
        public string Name { get; private set; }
        public Coordinates Coordinates { get; private set; }
        public Faction Faction { get; private set; }

        public OutpostListViewModel(string name, Coordinates coordinates, Faction faction)
        {
            Name = name;
            Coordinates = coordinates;
            Faction = faction;
        }
    }
}