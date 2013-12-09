namespace NeocronWorldMap.Web.Domain
{
    public class FactionFactory
    {
        public static Faction BuildNext()
        {
            return new Faction("NeXT");
        }
    }
}