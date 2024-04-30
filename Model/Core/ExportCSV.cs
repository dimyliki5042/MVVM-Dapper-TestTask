using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TestTask.View;

namespace TestTask.Model.Core
{
    public static class ExportCSV
    {
        public static void Export(List<MainDataModel> data)
        {
            string time = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}-" +
                $"{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}";
            string path = Path.Combine(Environment.CurrentDirectory, $"report_{time}.csv");
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                using (CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.Context.RegisterClassMap<MainDataModelMap>();
                    try
                    {
                        csvWriter.WriteRecords(data);
                    }
                    catch(CsvHelperException ex)
                    {
                        ErrorWindow errorWindow = new ErrorWindow(ex.HResult.ToString(), ex.Message);
                        errorWindow.ShowDialog();
                    }
                }
            }
        }
    }
}
