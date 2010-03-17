using System;
using System.Collections.Generic;
using System.Text;
using SourceAFIS.Extraction;
using SourceAFIS.Extraction.Templates;
using SourceAFIS.Visualization;
using SourceAFIS.Tuning.Reports;

namespace SourceAFIS.Tuning
{
    public sealed class ExtractorBenchmark
    {
        public TestDatabase Database = new TestDatabase();
        public Extractor Extractor = new Extractor();
        public int MaxTotalSeconds = 300;

        public ExtractorReport Run()
        {
            ExtractorReport report = new ExtractorReport();
            report.Templates = Database.Clone();

            int count = 0;
            SerializedFormat templateFormat = new SerializedFormat();

            BenchmarkTimer timer = new BenchmarkTimer();
            timer.Start();

            foreach (TestDatabase.View view in report.Templates.AllViews)
            {
                ColorB[,] image = ImageIO.Load(view.Path);
                byte[,] grayscale = PixelFormat.ToByte(image);
                TemplateBuilder builder = Extractor.Extract(grayscale, 500);
                view.Template = templateFormat.Export(builder);

                report.MinutiaCount += view.Template.Minutiae.Length;
                report.TemplateSize += templateFormat.Serialize(view.Template).Length;
                ++count;

                timer.Update();
                if (timer.Elapsed.TotalSeconds > MaxTotalSeconds)
                    throw new Exception("Timeout");
            }

            timer.Stop();
            report.Time = (float)(timer.TotalTime.TotalSeconds / count);

            report.MinutiaCount /= count;
            report.TemplateSize /= count;
            return report;
        }
    }
}