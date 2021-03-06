﻿using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public interface IBuildZoneDetailsViewModels
    {
        ZoneDetailsViewModel Build(IHaveOutpostData zone);
    }
}