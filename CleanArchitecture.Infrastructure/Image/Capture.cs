using CleanArchitecture.Core.Interfaces;
using System.Drawing;

namespace CleanArchitecture.Infrastructure.Image
{
    public class Capture : ICapture
    {
        public void CaptueImage()
        {

            Bitmap bmp = new Bitmap(1000,1000);
            Graphics gr = Graphics.FromImage(bmp);
            gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);
         //   pictureBox1.Image = bmp;
            bmp.Save("img.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
