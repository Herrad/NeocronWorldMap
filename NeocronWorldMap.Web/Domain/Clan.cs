﻿namespace NeocronWorldMap.Web.Domain
{
    public class Clan : IHaveOwnershipInformation
    {
        public Clan(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}