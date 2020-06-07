using CleanArchitecture.Core.Interfaces;
using System.Drawing;
using System;
using System.Management;
using System.Runtime.InteropServices;
using ScreenShotDemo;
using System.Drawing.Imaging;
using CleanArchitecture.Core.Settings;

namespace CleanArchitecture.Infrastructure.Images
{
    public class Capture : ICapture
    {
        public void CaptueImage(EntryPointSettings entryPoint)
        {

            //Method 1
            //ScreenCapture sc = new ScreenCapture();
            //Image img = sc.CaptureScreen();
            //string imageName = $"{entryPoint.UserID}-{DateTime.Now.ToFileTime()}.png";
            //img.Save("img.png", System.Drawing.Imaging.ImageFormat.Png);

            //Method 2
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"\root\wmi", @"SELECT * FROM WmiMonitorBasicDisplayParams");
            //Calculate and output size for each monitor
            foreach (ManagementObject managementObject in searcher.Get())
            {                
                string imageName = $"{entryPoint.UserID}-{DateTime.Now.ToFileTime()}.png";
                double width = (byte)managementObject["MaxHorizontalImageSize"];
                double height = (byte)managementObject["MaxVerticalImageSize"];
                Bitmap bmp = new Bitmap(Convert.ToInt32(width*width), Convert.ToInt32(height*height));
                Graphics gr = Graphics.FromImage(bmp);
                gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);
                bmp.Save(imageName, System.Drawing.Imaging.ImageFormat.Png);
            }                              

        }
   }  
}
