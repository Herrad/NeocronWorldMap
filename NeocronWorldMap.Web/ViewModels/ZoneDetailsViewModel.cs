namespace NeocronWorldMap.Web.ViewModels
{
    public class ZoneDetailsViewModel
    {
        public ZoneDetailsViewModel(string zoneName, OutpostViewModel outpostViewModel)
        {
            ZoneName = zoneName;
            OutpostViewModel = outpostViewModel;
        }

        public OutpostViewModel OutpostViewModel { get; private set; }

        public string ZoneName { get; private set; }
    }
}