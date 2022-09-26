using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace Solar_Power_Lookup_Maui;


public partial class SolarDetailsPage : ContentPage 
{
    static int numberOfLabels = 180;
    static int high = 0;

    public SolarDetailsPage(SolarDetailsViewModel viewModel )
    {
        
        InitializeComponent();
        BindingContext = viewModel;

        //this calls function after page is loaded.  Initially sets the scroll to horizontal.
        Loaded += (s, e) => { SetInitialOrientation(); };

        //Event (screen orientation change) => call DeviceDisplay...Method
        DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged1;

        //determines highest solar availability in a city.  Used to calculate percentages and determine background colors
        Loaded += (s, e) => { DetermineHighCount(); };

        Instructions.Text = "For every 1000 Watts of solar panels you install, you can expect to receive this much power.\nA 2000 Watt system will produce double etc...";

    }
   

    private void SetInitialOrientation()
    {
        if (DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Landscape)
        {
            scrview.Orientation = ScrollOrientation.Vertical;
        }
        else
        {
            scrview.Orientation = ScrollOrientation.Horizontal;
        }
    }

    private void DeviceDisplay_MainDisplayInfoChanged1(object sender, DisplayInfoChangedEventArgs e)
    {
        if (e.DisplayInfo.Orientation == DisplayOrientation.Landscape)
        {
            scrview.Orientation = ScrollOrientation.Vertical;
        }
        else
        {
            scrview.Orientation = ScrollOrientation.Horizontal;
        }
    }


    private void DetermineHighCount()
    {
        high = 0;
        for (int i = 1; i <= numberOfLabels; i++)
        {
            //use textLabel to access each Label
            string textLabel = string.Format($"label{i}");
            Label txtLabel = (Label)this.FindByName(textLabel);

            //Identify the highest recorded power measurement
            if (Convert.ToInt32(txtLabel.Text) > high)
            {
                high = Convert.ToInt32(txtLabel.Text);
            }
        }

        ChangeColor(numberOfLabels, high);
        
    }

    // change background colors of Labels based on the highest recorded power measurement
    //use to frameLabel to access each frame
    private void ChangeColor(int numberOfLabels, int high)
    {
        for (int i = 1; i <= numberOfLabels; i++)
        {
            var frameLabel = string.Format($"data{i}");
            var frame = (Frame)this.FindByName(frameLabel);

            var textLabel = string.Format($"label{i}");
            var txtLabel = (Label)this.FindByName(textLabel);

            //color codes availble from https://www.w3schools.com/colors/colors_picker.asp

            //violet
            if (Convert.ToInt32(txtLabel.Text) == high)
            {
                frame.Background = Color.FromRgba("#cc80ff");
            }

            //light blue
            else if (Convert.ToInt32(txtLabel.Text) >= high * .8)
            {
                frame.Background = Color.FromRgba("#99ccff");
            }

            //light green
            else if (Convert.ToInt32(txtLabel.Text) >= high * .7)
            {
                frame.Background = Color.FromRgba("#66ff33");
            }

            //light orange
            else if (Convert.ToInt32(txtLabel.Text) >= high * .5)
            {
                frame.Background = Color.FromRgba("#ffeb99");
            }

            //light red
            else if (Convert.ToInt32(txtLabel.Text) >= high * .3)
            {
                frame.Background = Color.FromRgba("#ff8080");
            }

            //darker red
            else if (Convert.ToInt32(txtLabel.Text) > 0)
            {
                frame.Background = Color.FromRgba("#ff1a1a");
            }

        }

        CalculatePower();

    }


    public void CalculatePower()
    {
        double panelPercent = 20;
        
        double sizeOfPanelArray = 1000;

        //calculate the hourly averages
        for (int i = 1; i <= numberOfLabels; i++)
        {
            string textLabel = string.Format($"label{i}");
            Label txtLabel = (Label)this.FindByName(textLabel);

            double textLabelValuedouble = Convert.ToInt32(txtLabel.Text);
            textLabelValuedouble = textLabelValuedouble * (panelPercent/100) * 0.7 * 0.8;

            double coefficient = (textLabelValuedouble / 150);
            double usablePower = (sizeOfPanelArray * coefficient);

            int textLabelValueInt = Convert.ToInt32(usablePower);

            txtLabel.Text = textLabelValueInt.ToString();

        }
        
        //calculate the daily averages
        for (int i = 1; i <= 12; i++)
        {
            string textLabel = string.Format($"DayAvg{i}");
            Label txtLabel = (Label)this.FindByName(textLabel);

            double textLabelValuedouble = Convert.ToInt32(txtLabel.Text);
            textLabelValuedouble = textLabelValuedouble * (panelPercent / 100) * 0.7 * 0.8;

            double coefficient = (textLabelValuedouble / 150);
            double usablePower = (sizeOfPanelArray * coefficient);

            int textLabelValueInt = Convert.ToInt32(usablePower);

            txtLabel.Text = textLabelValueInt.ToString();

        }

    }


}