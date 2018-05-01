using System;
using Aspose.CAD;
using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadConsts;
using Aspose.CAD.FileFormats.Cad.CadObjects;
using Aspose.CAD.ImageOptions;

namespace DWGToPDFConversionPageSizeIssue
{
    public static class DWGToPDFConverter
    {
        private const String DefaultModelName = "Model";
        private const Double MillimetersToInchesFactor = 0.0393701;

        public static void ConvertDWGToPDF(String inputFileName, String outputFileName)
        {
            using (var image = (CadImage)Image.Load(inputFileName))
            {
                var pdfOptions = new PdfOptions();

                CadLayout layout = image.Layouts[DefaultModelName];

                SizeF pageSize = GetPageSizeFromLayout(layout);

                CadRasterizationOptions options = new CadRasterizationOptions();

                options.PageWidth = pageSize.Width;
                options.PageHeight = pageSize.Height;
                options.UnitType = UnitType.Inch;

                options.Layouts = new String[] { layout.LayoutName };
                options.DrawType = CadDrawTypeMode.UseObjectColor;
                options.AutomaticLayoutsScaling = true;
                options.CenterDrawing = true;
                options.NoScaling = false;

                pdfOptions.VectorRasterizationOptions = options;

                image.Save(outputFileName, pdfOptions);
            }
        }

        private static SizeF GetPageSizeFromLayout(CadLayout layout)
        {
            var isLandscape = IsLayoutLandscape(layout);

            var pageWidth = (Single)MillimetersToInches(layout.PlotPaperSize.Width);
            var pageHeight = (Single)MillimetersToInches(layout.PlotPaperSize.Height);

            if (isLandscape)
            {
                return new SizeF(pageHeight, pageWidth);
            }
            else
            {
                return new SizeF(pageWidth, pageHeight);
            }
        }

        private static Boolean IsLayoutLandscape(CadLayout layout)
        {
            return layout.PlotRotation == CadPlotRotation.Clockwise90Degrees || layout.PlotRotation == CadPlotRotation.Counterclockwise90Degrees;
        }

        private static Double MillimetersToInches(Double millimeters)
        {
            return millimeters * MillimetersToInchesFactor;
        }
    }
}
