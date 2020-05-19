using System.Collections.Generic;

namespace MiniTC
{
    public interface IPanelTC
    {
        string CurrentPath { get; set; }
        string[] Drives { get; set; }
        IEnumerable<object> PathContent { get; set; }
    }
}
