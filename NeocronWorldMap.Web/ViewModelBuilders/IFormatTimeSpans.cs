using System;

namespace NeocronWorldMap.Web.ViewModelBuilders
{
    public interface IFormatTimeSpans
    {
        string FormatTime(TimeSpan timeOwnedFor);
    }
}