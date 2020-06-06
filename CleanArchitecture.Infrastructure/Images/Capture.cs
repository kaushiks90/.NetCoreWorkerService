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

            /*
            Bitmap bmp = null;
            //pictureBox1.Image = bmp;
            // window.screen.width
            //float height = SystemInformation.VirtualScreen.Height;
            //float width = SystemInformation.VirtualScreen.Width;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"\root\wmi", @"SELECT * FROM WmiMonitorBasicDisplayParams");

            //Calculate and output size for each monitor
            foreach (ManagementObject managementObject in searcher.Get())
            {
                //Calculate monitor size
                double width = (byte)managementObject["MaxHorizontalImageSize"] / 2.54;
                double height = (byte)managementObject["MaxVerticalImageSize"] / 2.54;
                double diagonal = Math.Sqrt(width * width + height * height);

                bmp = new Bitmap(Convert.ToInt32(width * width), Convert.ToInt32(height * height));
                Graphics gr = Graphics.FromImage(bmp);
                gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);


                bmp.Save("img.png", System.Drawing.Imaging.ImageFormat.Png);
                //Output monitor size
                Console.WriteLine("Monitor Size: {0:F1}\"", diagonal);
            }
            */
            ScreenCapture sc = new ScreenCapture();
            // capture entire screen, and save it to a file
            Image img = sc.CaptureScreen();
            // display image in a Picture control named imageDisplay

            // capture this window, and save it
            // sc.CaptureWindowToFile(this.Handle, "C:\\temp2.gif", ImageFormat.Gif);

            //Bitmap bmp = new Bitmap(width, 1000);
            //Graphics gr = Graphics.FromImage(bmp);
            //gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);

            img.Save("img.png", System.Drawing.Imaging.ImageFormat.Png);


        }
    }

  

    
}
