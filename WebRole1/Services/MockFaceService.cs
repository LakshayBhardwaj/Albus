using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebRole1.Controllers;

namespace WebRole1.Services
{
    public class MockFaceService : IFaceService
    {
        public async Task<IEnumerable<Face>> DetectFacesAsync(Stream imageStream)
        {
            // Simulate processing time
            await Task.Delay(1000);

            var rng = new Random();
            var faces = new List<Face>();

            // Mock 1 or 2 faces
            int faceCount = rng.Next(1, 3);

            for (int i = 0; i < faceCount; i++)
            {
                faces.Add(new Face
                {
                    FaceId = Guid.NewGuid().ToString(),
                    Age = rng.Next(20, 40).ToString(),
                    Gender = rng.Next(0, 2) == 0 ? "Male" : "Female",
                    Emotion = "Happy",
                    Confidence = 0.95,
                    Left = rng.Next(50, 200),
                    Top = rng.Next(50, 200),
                    Width = rng.Next(100, 200),
                    Height = rng.Next(100, 200),
                    PersonName = "Mock Person " + (i + 1),
                    Glasses = "NoGlasses",
                    Smile = "Yes" // Add Smile property to Face if not exists or map to Emotion
                });
            }

            return faces;
        }
    }
}
