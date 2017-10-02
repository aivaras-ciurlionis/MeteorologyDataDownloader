using SixLabors.ImageSharp;
using SixLabors.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeteorologyDownloader.DataRetrieval
{
    public class ImagesConcater : IImagesConcater
    {
        public void ConcatImagesInDirectory(string directory, string outputFile)
        {
            using (var image = new Image<Rgba32>(256 * 3, 256 * 3))
            {
                var i = 0;
                for (var x = 0; x <= 2; x++)
                {
                    for (var y = 0; y <= 2; y++)
                    {
                        using (var currentImage = Image.Load(Path.Combine(directory, $"{i}.png")))
                        {
                            image.Mutate(
                                  im => im.DrawImage(currentImage, 1, new Size(256), new Point(256 * x, 256 * y))
                            );
                        }
                        i++;
                    }
                }
                image.Save(outputFile);
            }
        }
    }
}
