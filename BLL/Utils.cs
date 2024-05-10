using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Drawing.Imaging;

namespace BLL
{
    public class Utils
    {
        private static Utils instance;
        public static Utils Instance
        {
            get
            {
                if (instance == null)
                    instance = new Utils();
                return instance;
            }
        }
        public byte[] ImageToByteArray(string AvartarDirec)
        {
            byte[] imageData = null;
            try
            {
                using (FileStream fs = new FileStream(AvartarDirec, FileMode.Open, FileAccess.Read))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, (int)fs.Length);
                    return imageData;
                }

            }
            catch
            {
                return null;
            }
        }

        public System.Drawing.Image converByteToImage(Byte[] byteArr)
        {
            if (byteArr == null)
                return null;
            using (MemoryStream memoryStream = new MemoryStream(byteArr))
            {
                return System.Drawing.Image.FromStream(memoryStream);
            }
        }
    }
}
