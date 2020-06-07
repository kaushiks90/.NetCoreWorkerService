using CleanArchitecture.Core.Interfaces;
using System.Drawing;
using System;
using System.Management;
using System.Runtime.InteropServices;
using ScreenShotDemo;
using System.Drawing.Imaging;

namespace CleanArchitecture.Infrastructure.Images
{
    public class Capture : ICapture
    {
        public void CaptueImage()
        {

            //Method 1
            //ScreenCapture sc = new ScreenCapture();
            //Image img = sc.CaptureScreen();
            //img.Save("img.png", System.Drawing.Imaging.ImageFormat.Png);

            //Method 2

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"\root\wmi", @"SELECT * FROM WmiMonitorBasicDisplayParams");

            //Calculate and output size for each monitor
            foreach (ManagementObject managementObject in searcher.Get())
            {
                //Calculate monitor size
                //double width = (byte)managementObject["MaxHorizontalImageSize"] / 2.54;
                //double height = (byte)managementObject["MaxVerticalImageSize"] / 2.54;
                //double diagonal = Math.Sqrt(width * width + height * height);

                double width = (byte)managementObject["MaxHorizontalImageSize"];
                double height = (byte)managementObject["MaxVerticalImageSize"];
                double diagonal = Math.Sqrt(width * width + height * height);


                Bitmap bmp = new Bitmap(Convert.ToInt32(width*width), Convert.ToInt32(height*height));
                Graphics gr = Graphics.FromImage(bmp);
                gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);


                bmp.Save("img.png", System.Drawing.Imaging.ImageFormat.Png);
                //Output monitor size
               // Console.WriteLine("Monitor Size: {0:F1}\"", diagonal);
            }
                                 

        }
    }

  

    
}
