using System.Timers;
using System.IO;

//TimerSample();
FileSystemWatcherSample();

static void FileSystemWatcherSample() {
    // create instance
    using var watcher = new FileSystemWatcher(@"C:\");

    watcher.NotifyFilter = NotifyFilters.Attributes
        | NotifyFilters.CreationTime
        | NotifyFilters.DirectoryName;





    watcher.Changed += (s, arg) => Console.WriteLine($"{arg.Name} modified {DateTime.Now}");
    watcher.Created += (s, arg) => Console.WriteLine($"{arg.Name} created {DateTime.Now}");
    watcher.Deleted += (s, arg) => Console.WriteLine($"{arg.Name} deleted {DateTime.Now}");
    watcher.Renamed += (s, arg) => Console.WriteLine($"{arg.Name} renamed {DateTime.Now}");

    watcher.EnableRaisingEvents = true;

    Console.ReadLine();

}

static void TimerSample() {
    System.Timers.Timer aTimer = new System.Timers.Timer();
    aTimer.Interval = 2000;

    aTimer.Elapsed += (s, arg) => Console.WriteLine($"{(s as System.Timers.Timer).Enabled} last fired at {arg.SignalTime}");

    aTimer.AutoReset = true;

    aTimer.Enabled = true;

    Console.ReadLine();
}