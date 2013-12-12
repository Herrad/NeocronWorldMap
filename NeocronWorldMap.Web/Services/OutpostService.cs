using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public class OutpostService : IRetrieveOutpostInformation
    {
        private readonly OutpostLocations _outpostLocations;

        public OutpostService(OutpostLocations outpostLocations)
        {
            _outpostLocations = outpostLocations;
        }

        public IHaveOutpostData GetOutpostDataAt(Coordinates coordinates)
        {
            var neocronZone = new NeocronZone(coordinates);

            if(!_outpostLocations.HasNameAt(coordinates))
            {
                return new Outpost("No outpost found", neocronZone);
            }
            var name = _outpostLocations.NamesAt[coordinates];

            return new Outpost(name, neocronZone);
        }
    }
}

