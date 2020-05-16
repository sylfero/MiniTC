using System.Management;

namespace MiniTC.DataOperations
{
    class Watcher
    {
        private readonly ManagementEventWatcher insertWatcher;
        private readonly ManagementEventWatcher removeWatcher;

        public Watcher(EventArrivedEventHandler insert, EventArrivedEventHandler remove)
        {
            WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");
            insertWatcher = new ManagementEventWatcher(insertQuery);
            insertWatcher.EventArrived += new EventArrivedEventHandler(insert);
            insertWatcher.Start();

            WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 3");
            removeWatcher = new ManagementEventWatcher(removeQuery);
            removeWatcher.EventArrived += new EventArrivedEventHandler(remove);
            removeWatcher.Start();
        }
    }
}
