using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole1.Controllers
{
    public class Face
    {
        public string Age { get; set; }
        public string Gender { get; set; }
        public double Confidence { get; set; }
        public string FaceId { get; set; }
        public string PersonName { get; set; }
        public int Height { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public string HeadPose { get; set; }
        public string FacialHair { get; set; }
        public string Glasses { get; set; }
        public string Emotion { get; set; }
        public string Hair { get; set; }
        public string Makeup { get; set; }
        public string EyeOcclusion { get; set; }
        public string ForeheadOcclusion { get; set; }
        public string MouthOcclusion { get; set; }
        public string Accessories { get; set; }
        public string Blur { get; set; }
        public string Exposure { get; set; }
        public string Noise { get; set; }
        public string ImageFile { get; set; } // Changed from ImageSource to string (path or base64)
    }
}
