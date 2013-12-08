using System.Collections.Generic;
using NeocronWorldMap.Web.Domain;

namespace NeocronWorldMap.Web.Services
{
    public class OutpostLocations
    {
        public OutpostLocations()
        {
            SetupNames();
        }

        private void SetupNames()
        {
            NamesAt = new Dictionary<Coordinates, string>
                          {
                              {new Coordinates("04", 'k'), "Rockshore Factory"},
                              {new Coordinates("05", 'k'), "Drakhan Fortress"},
                              {new Coordinates("07", 'k'), "Northstar Uplink"},
                              {new Coordinates("12", 'k'), "Tescom Uplink"},
                              {new Coordinates("09", 'j'), "Yutano Mine"},
                              {new Coordinates("14", 'j'), "Syncon Lab"},
                              {new Coordinates("04", 'i'), "Sieger Uplink"},
                              {new Coordinates("05", 'i'), "Chester Lab"},
                              {new Coordinates("07", 'i'), "Emmerson Factory"},
                              {new Coordinates("08", 'i'), "Avenger Mine"},
                              {new Coordinates("11", 'i'), "Tristar Uplink"},
                              {new Coordinates("15", 'i'), "Cajun Uplink"},
                              {new Coordinates("03", 'h'), "Jankins Lab"},
                              {new Coordinates("07", 'h'), "Hawkins Uplink"},
                              {new Coordinates("09", 'h'), "Malstrond Factory"},
                              {new Coordinates("11", 'h'), "Blackhill Fortress"},
                              {new Coordinates("13", 'h'), "Nemesis Lab"},
                              {new Coordinates("15", 'h'), "Soliko Lab"},
                              {new Coordinates("16", 'h'), "Eastgate Factory"},
                              {new Coordinates("08", 'g'), "Gabanium Mine"},
                              {new Coordinates("12", 'g'), "Tezla Factory"},
                              {new Coordinates("05", 'f'), "Regant Fortress"},
                              {new Coordinates("11", 'f'), "Devereaux Fortress"},
                              {new Coordinates("12", 'f'), "Cycrow Lab"},
                              {new Coordinates("10", 'e'), "Shirkan Fortress"},
                              {new Coordinates("06", 'd'), "Gravis Uplink"},
                              {new Coordinates("07", 'd'), "Redrock Mine"},
                              {new Coordinates("09", 'd'), "Crest Uplink"},
                              {new Coordinates("11", 'd'), "Foster Uplink"},
                              {new Coordinates("13", 'd'), "Grant Mine"},
                              {new Coordinates("07", 'c'), "Tyron Factory"},
                              {new Coordinates("09", 'c'), "Krupp Factory"},
                              {new Coordinates("12", 'c'), "Ceres Mine"},
                              {new Coordinates("08", 'b'), "Jeriko Fortress"},
                              {new Coordinates("11", 'b'), "McPherson Factory"},
                              {new Coordinates("06", 'a'), "Simmons Factory"}
                          };
        }

        public Dictionary<Coordinates, string> NamesAt { get; private set; }

        public bool HasNameAt(Coordinates coordinates)
        {
            return NamesAt.ContainsKey(coordinates);
        }
    }
}