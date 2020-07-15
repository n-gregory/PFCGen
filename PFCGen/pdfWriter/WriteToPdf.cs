using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PdfSharpCore;
using PdfSharpCore.Utils;
using PdfSharpCore.Fonts;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
// using SixLabors.ImageSharp;
// using SixLabors.ImageSharp.Formats.Jpeg;
// using SixLabors.ImageSharp.PixelFormats;
// using MigraDocCore.DocumentObjectModel.MigraDoc.DocumentObjectModel.Shapes;
using DebugTools;

namespace pdfHandler
{
    public static class pdfWriter{
        public static bool resolverUsed = false;
        public static void writeTest()
        {
            DebugHelper.addMessage("Starting writeTest() call");
            if (!resolverUsed){
                DebugHelper.addMessage("Font Resolver is not yet used, making new resolver");
                GlobalFontSettings.FontResolver = new FontResolver();
            } else {
                DebugHelper.addMessage("Font Resolver is used");
            }
            
            // GlobalFontSettings.FontResolver = new FontResolver();

            DebugHelper.addMessage("GlobalFontSettings set, about to set vars");
            var document = new PdfDocument();
            DebugHelper.addMessage("document var created");
            var page = document.AddPage();
            DebugHelper.addMessage("page added to document");
            var gfx = XGraphics.FromPdfPage(page);
            DebugHelper.addMessage("gfx made from page");
            
            var font = new XFont("Cailibri", 20);
            DebugHelper.addMessage("font created");
            DebugHelper.addMessage("Vars set");
                    
            gfx.DrawString("Hello World!", font, XBrushes.Black, new XRect(20, 20, page.Width, page.Height), XStringFormats.Center);
            DebugHelper.addMessage("DrawSrting called successfully");
            document.Save("test.pdf");
            resolverUsed = true;
            DebugHelper.addMessage("Saved document");
        }
    }
}
