
namespace USJetFuelPrice
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
        }

        private void Chart_TrackballCreated(object sender, Syncfusion.Maui.Charts.TrackballEventArgs e)
        {
            var info = e.TrackballPointsInfo;

            foreach(var item in info)
            {
                var date = ((Model)item.DataItem).Date;
                item.Label = date.ToString("dd-MMM-yyyy") + ": " + item.Label + "$";
            }
        }
    }

}
