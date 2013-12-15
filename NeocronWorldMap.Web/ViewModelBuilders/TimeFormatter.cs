using System;
using System.Globalization;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public class TimeFormatter : IFormatTimeSpans
    {
        public string FormatTime(TimeSpan timeOwnedFor)
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