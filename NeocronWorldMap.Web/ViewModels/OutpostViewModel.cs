namespace NeocronWorldMap.Web.ViewModels
{
    public class OutpostViewModel
    {
        public string Name { get; private set; }
        public OutpostOwnershipViewModel OutpostOwnershipViewModel { get; private set; }

        public OutpostViewModel(string name, OutpostOwnershipViewModel outpostOwnershipViewModel)
        {
            Name = name;
            OutpostOwnershipViewModel = outpostOwnershipViewModel;
        }
    }
}