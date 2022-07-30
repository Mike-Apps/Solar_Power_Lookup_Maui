namespace Solar_Power_Lookup_Maui;

public partial class SolarDetailsPage : ContentPage
{


    public SolarDetailsPage(SolarDetailsViewModel viewModel)
    {

        InitializeComponent();
        BindingContext = viewModel;

        //this calls function after page is loaded.
        // Loaded += (s, e) => { But(); };
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        int high = 0;
        int numberOfLabels = 180;

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

    }
}