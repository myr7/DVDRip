using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace DVDRip
{
    class Program
    {
        static void DriveWatcherOnOpticalDiskArrived(object sender, OpticalDiskArrivedEventArgs e)
        {
            Console.WriteLine(e.Drive.Name);            
            while (!e.Drive.IsReady)
            {
                Thread.Sleep(100);
            }
            if (e.Drive.DriveType == System.IO.DriveType.CDRom)
            {
                //If it is CD/DVD 
                Console.WriteLine(e.Drive.DriveFormat.ToString());
                //var mp = new MediaPlayer();
            }
            
        }
        static DriveWatcher dw;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my DVD Rip Program");
            Console.WriteLine("Waiting for DVD...");
            dw = new DriveWatcher();
            dw.OpticalDiskArrived += DriveWatcherOnOpticalDiskArrived;
            dw.Start();
            Console.ReadLine();
        }

    }
}
