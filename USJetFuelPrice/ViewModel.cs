using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace USJetFuelPrice
{
    public class ViewModel
    {
        public ObservableCollection<Model> WeeklyPriceData { get; set; }

        public ViewModel()
        {
            WeeklyPriceData = new ObservableCollection<Model>();
            ReadCSV();
        }

        public void ReadCSV()
        {
            Assembly executingAssembly = typeof(App).GetTypeInfo().Assembly;
            Stream? inputStream = executingAssembly.GetManifestResourceStream("USJetFuelPrice.Resources.Raw.data.csv");

            string? line;
            List<string> lines = new List<string>();

            if (inputStream != null)
            {
                using StreamReader reader = new StreamReader(inputStream);
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                lines.RemoveAt(0);

                foreach (var dataPoint in lines)
                {
                    string[] data = dataPoint.Split(',');

                    var dateDetails = data[0].Split("/");
                    var month = int.Parse(dateDetails[0]);
                    var day = int.Parse(dateDetails[1]);
                    var year = int.Parse(dateDetails[2]);

                    var date = new DateTime(year,month,day);
                    var price = Convert.ToDouble(data[1]);

                    WeeklyPriceData.Add(new Model { Date = date, Price = price});
                }
            }
        }

    }

    public class Model
    {
        public DateTime Date {  get; set; }

        public double Price {  get; set; }
    }

}
