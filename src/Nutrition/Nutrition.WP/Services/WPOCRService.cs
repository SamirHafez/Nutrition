using System;
using System.Threading.Tasks;
using Nutrition.Core.Services.Interfaces;
using Nutrition.Core.Models;
using System.IO;
using WindowsPreview.Media.Ocr;
using System.Linq;
using Windows.UI.Xaml.Media.Imaging;
using System.Text;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Nutrition.WP.Services
{
    public class WPOCRService : IOCRService
    {
        OcrEngine ocrEngine;

        public WPOCRService()
        {
            ocrEngine = new OcrEngine(OcrLanguage.Portuguese);
        }

        public async Task<NutritionTable> GetTableAsync(byte[] picture, uint width, uint height)
        {
            var ocrString = await OCRAsync(picture, width, height);

            await new Windows.UI.Popups.MessageDialog(ocrString).ShowAsync();

            return NutritionTable.Parse(ocrString);
        }

        async Task<string> OCRAsync(byte[] buffer, uint width, uint height)
        {
            var bitmap = new WriteableBitmap((int)width, (int)height);

            var memoryStream = new MemoryStream(buffer);
            await bitmap.SetSourceAsync(memoryStream.AsRandomAccessStream());

            if (bitmap.PixelHeight < 40 ||
                bitmap.PixelHeight > 2600 ||
                bitmap.PixelWidth < 40 ||
                bitmap.PixelWidth > 2600)
                bitmap = await ResizeImage(bitmap, (uint)(bitmap.PixelWidth * .7), (uint)(bitmap.PixelHeight * .7));

            var ocrResult = await ocrEngine.RecognizeAsync((uint)bitmap.PixelHeight, (uint)bitmap.PixelWidth, bitmap.PixelBuffer.ToArray());

            if (ocrResult.Lines != null)
            {
                var extractedText = new StringBuilder();

                foreach (var line in ocrResult.Lines)
                {
                    foreach (var word in line.Words)
                        extractedText.Append(word.Text + " ");
                    extractedText.Append(Environment.NewLine);
                }

                return extractedText.ToString();
            }

            return null;
        }

        async Task<WriteableBitmap> ResizeImage(WriteableBitmap baseWriteBitmap, uint width, uint height)
        {
            Stream stream = baseWriteBitmap.PixelBuffer.AsStream();
            byte[] pixels = new byte[(uint)stream.Length];
            await stream.ReadAsync(pixels, 0, pixels.Length);
            var inMemoryRandomStream = new InMemoryRandomAccessStream();
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, inMemoryRandomStream);
            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)baseWriteBitmap.PixelWidth, (uint)baseWriteBitmap.PixelHeight, 96, 96, pixels);
            await encoder.FlushAsync();
            var transform = new BitmapTransform
            {
                ScaledWidth = width,
                ScaledHeight = height
            };
            inMemoryRandomStream.Seek(0);
            var decoder = await BitmapDecoder.CreateAsync(inMemoryRandomStream);
            var pixelData = await decoder.GetPixelDataAsync(
                            BitmapPixelFormat.Bgra8,
                            BitmapAlphaMode.Straight,
                            transform,
                            ExifOrientationMode.IgnoreExifOrientation,
                            ColorManagementMode.DoNotColorManage);
            var sourceDecodedPixels = pixelData.DetachPixelData();
            var inMemoryRandomStream2 = new InMemoryRandomAccessStream();
            var encoder2 = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, inMemoryRandomStream2);
            encoder2.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, width, height, 96, 96, sourceDecodedPixels);
            await encoder2.FlushAsync();
            inMemoryRandomStream2.Seek(0);
            var bitmap = new WriteableBitmap((int)width, (int)height);
            await bitmap.SetSourceAsync(inMemoryRandomStream2);
            return bitmap;
        }
    }
}