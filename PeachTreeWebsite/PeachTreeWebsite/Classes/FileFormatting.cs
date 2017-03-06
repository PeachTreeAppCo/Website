//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.IO.Compression;
//using System.Linq;
//using System.Web;

//namespace PeachTreeWebsite.Classes
//{
//    public class FileFormatting
//    {
//        public static Image byteArrayToImage(byte[] byteArrayIn)
//        {
//            var ms = new MemoryStream(byteArrayIn);
//            var returnImage = Image.FromStream(ms);
//            return returnImage;
//        }

        

//        public static downloadZip()
//{
//            using (ZipFile zip = new ZipFile())
//            {
//                // add this map file into the "images" directory in the zip archive
//                zip.AddFile("c:\\images\\personal\\7440-N49th.png", "images");
//                // add the report into a different directory in the archive
//                zip.AddFile("c:\\Reports\\2008-Regional-Sales-Report.pdf", "files");
//                zip.AddFile("ReadMe.txt");
//                zip.Save("MyZipFile.zip");
//            }
//        }
//    }
//}