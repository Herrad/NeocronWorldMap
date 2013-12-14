using System;
using System.Globalization;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.ViewModels;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public class OutpostViewModelBuilder : IBuildOutpostViewModels
    {
        public OutpostViewModel Build(IHaveOutpostData outpost)
        {
            var ownershipInformation = outpost.CurrentOwners;
            
            var outpostOwnershipViewModel = new OutpostOwnershipViewModel(ownershipInformation.Name, ownershipInformation.Faction.Name, FormatTimeOwnedFor(ownershipInformation.TimeOwnedFor));

            return new OutpostViewModel(outpost.Name, outpostOwnershipViewModel);
        }

        private static string FormatTimeOwnedFor(TimeSpan timeOwnedFor)
        {
            var formattedTime = FormatTimeElement(timeOwnedFor.Hours) + ":" + 
                FormatTimeElement(timeOwnedFor.Minutes) + ":" + 
                FormatTimeElement(timeOwnedFor.Seconds);

            var formattedDays = FormatDays(timeOwnedFor);
            
            return formattedDays + " " + formattedTime;
        }

        private static string FormatTimeElement(int elementToFormat)
        {
            if (elementToFormat < 10)
                return "0" + elementToFormat;
            return elementToFormat.ToString(CultureInfo.InvariantCulture);
        }

        private static string FormatDays(TimeSpan timeOwnedFor)
        {
            var formattedDays = timeOwnedFor.Days + " day";

            if (timeOwnedFor.Days != 1)
            {
                formattedDays += "s";
            }
            return formattedDays;
        }
    }
}