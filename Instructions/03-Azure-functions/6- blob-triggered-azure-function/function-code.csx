using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.WebJobs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

public static void Run(Stream myBlob, string name, Stream imageMedium, Stream imageSmall, Stream imageExtraSmall, ILogger log)
{
    log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {image.Length} Bytes");

    IImageFormat format;

    using (Image<Rgba32> input = Image.Load<Rgba32>(myBlob, out format))
    {
        ResizeImage(input, imageSmall, ImageSize.Small, format);
    }

    image.Position = 0;
    using (Image<Rgba32> input = Image.Load<Rgba32>(myBlob, out format))
    {
        ResizeImage(input, imageMedium, ImageSize.Medium, format);
    }

    image.Position = 0;
    using (Image<Rgba32> input = Image.Load<Rgba32>(myBlob, out format))
    {
        ResizeImage(input, imageExtraSmall, ImageSize.ExtraSmall, format);
    }
}

public static void ResizeImage(Image<Rgba32> input, Stream output, ImageSize size, IImageFormat format)
{
    var dimensions = imageDimensionsTable[size];
    input.Mutate(x => x.Resize(dimensions.Item1, dimensions.Item2));
    input.Save(output, format);
}

public enum ImageSize { ExtraSmall, Small, Medium }

private static Dictionary<ImageSize, (int, int)> imageDimensionsTable = new Dictionary<ImageSize, (int, int)>() {
    { ImageSize.ExtraSmall, (320, 200) },
    { ImageSize.Small,      (640, 400) },
    { ImageSize.Medium,     (800, 600) }
};
