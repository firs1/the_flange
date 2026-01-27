using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Wrapper;
using Models;

namespace StressTesting
{
    internal static class Program
    {
        /// <summary>
        /// Точка входа в приложение нагрузочного тестирования.
        /// Запускает бесконечный цикл построения модели и логирует время построения,
        /// загрузку ОЗУ системы, загрузку CPU процесса и Working Set процесса.
        /// </summary>
        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            var wrapper = new Wrapper.Wrapper();
            var builder = new Builder(wrapper);
            var parameters = new Parameters();

            parameters.OuterDiameter_a = 200;
            parameters.ProtrusionDiameter_b = 150;
            parameters.Height_d = 100;
            parameters.Thickness_c = 50;
            parameters.DiameterHoles_e = 15;
            parameters.NumberOfHoles_n = 6; 
            parameters.HoleStep = 0;        

            var stopWatch = new Stopwatch();
            var currentProcess = Process.GetCurrentProcess();

            const double bytesToMegabytes = 1.0 / (1024.0 * 1024.0);

            string logPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "log.txt");

            using var writer = new StreamWriter(logPath)
            {
                AutoFlush = true
            };

            writer.WriteLine(
                "Iteration\tBuildTimeMs\tCpuProcessPercent\tWorkingSetMb");

            int iteration = 0;

            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                Environment.Exit(0);
            };

            while (iteration < 8000) 
            {
                iteration++;

                currentProcess.Refresh();
                TimeSpan cpuStart = currentProcess.TotalProcessorTime;

                stopWatch.Restart();
                builder.BuildModel(parameters, closeDocumentAfterBuild: true);
                stopWatch.Stop();

                currentProcess.Refresh();
                TimeSpan cpuEnd = currentProcess.TotalProcessorTime;

                long elapsedMs = stopWatch.ElapsedMilliseconds;
                if (elapsedMs == 0)
                    elapsedMs = 1;

                double cpuPercent =
                    (cpuEnd - cpuStart).TotalMilliseconds /
                    (elapsedMs * Environment.ProcessorCount) * 100.0;

                double workingSetMb =
                    currentProcess.WorkingSet64 * bytesToMegabytes;

                writer.WriteLine(
                    $"{iteration}\t" +
                    $"{elapsedMs}\t" +
                    $"{cpuPercent:F2}\t" +
                    $"{workingSetMb:F2}");
            }
        }
    }
}


