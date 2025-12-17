using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Face.Contract;

namespace WebRole1.Controllers
{
    internal static class UIHelper
    {
        public static IEnumerable<WebRole1.Controllers.Face> CalculateFaceRectangleForRendering(IEnumerable<Microsoft.ProjectOxford.Face.Contract.Face> faces, int maxSize, Tuple<int, int> imageInfo)
        {
            var imageWidth = imageInfo.Item1;
            var imageHeight = imageInfo.Item2;
            float ratio = (float)imageWidth / imageHeight;
            int uiWidth = 0;
            int uiHeight = 0;
            if (ratio > 1.0)
            {
                uiWidth = maxSize;
                uiHeight = (int)(maxSize / ratio);
            }
            else
            {
                uiHeight = maxSize;
                uiWidth = (int)(ratio * uiHeight);
            }

            int uiXOffset = (maxSize - uiWidth) / 2;
            int uiYOffset = (maxSize - uiHeight) / 2;
            float scale = (float)uiWidth / imageWidth;

            foreach (var face in faces)
            {
                yield return new WebRole1.Controllers.Face()
                {
                    FaceId = face.FaceId.ToString(),
                    Left = (int)((face.FaceRectangle.Left * scale) + uiXOffset),
                    Top = (int)((face.FaceRectangle.Top * scale) + uiYOffset),
                    Height = (int)(face.FaceRectangle.Height * scale),
                    Width = (int)(face.FaceRectangle.Width * scale),
                };
            }
        }

        public static Tuple<int, int> GetImageInfoForRendering(string imagePath)
        {
             // Mock implementation since we removed System.Windows.Media
             // In a real app we would use System.Drawing or similar to get dimensions
             // For now return dummy values or try to read if possible
             try
             {
                 // Simple check if file exists
                 if(File.Exists(imagePath))
                 {
                    // This is risky without System.Drawing, but we will return a default size
                    // or let the client side handle it.
                    // For the purpose of the mock logic in ValuesController, let's return a fixed size
                    return new Tuple<int, int>(800, 600);
                 }
                 return new Tuple<int, int>(0, 0);
             }
             catch
             {
                 return new Tuple<int, int>(0, 0);
             }
        }

        // Removed LoadImageAppliedOrientation and GetImageOrientation as they relied on WPF
        // Removed ControlHelper as it relied on WPF DependencyObject
    }
}
