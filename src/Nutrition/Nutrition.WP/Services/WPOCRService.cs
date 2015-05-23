using System;
using System.Threading.Tasks;
using Nutrition.Core.Services.Interfaces;
using Nutrition.Core.Models;
using System.IO;
using WindowsPreview.Media.Ocr;
using System.Linq;

namespace Nutrition.WP.Services
{
    public class WPOCRService : IOCRService
    {
        OcrEngine engine;

        public WPOCRService()
        {
            engine = new OcrEngine(OcrLanguage.English);
        }

        public async Task<NutritionTable> GetTableAsync(byte[] picture, uint width, uint height)
        {
            var result = await engine.RecognizeAsync(height, width, picture);

            if (result.Lines == null)
                throw new Exception("OCR Failed.");

            foreach (var line in result.Lines)
                await new Windows.UI.Popups.MessageDialog(string.Join(" - ", line.Words.Select(w => w.Text).ToArray())).ShowAsync();

            return null;
        }
    }
}
