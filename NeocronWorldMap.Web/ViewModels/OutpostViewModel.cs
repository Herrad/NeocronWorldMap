namespace NeocronWorldMap.Web.ViewModels
{
    public class OutpostViewModel
    {
        public string Name { get; private set; }

        public OutpostViewModel(string name)
        {
            Name = name;
        }
    }
}