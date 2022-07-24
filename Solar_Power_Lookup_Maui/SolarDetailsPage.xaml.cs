namespace Solar_Power_Lookup_Maui;

public partial class SolarDetailsPage : ContentPage
{

    public SolarDetailsPage(SolarDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

    }

    [Obsolete]
    private void Button_Clicked(object sender, EventArgs e)
    {

        int high = 0;
        int numberOfLabels = 24;
        //data1.Background = Color.FromHex("#FFA000");

        for (int i = 1; i <= numberOfLabels; i++)
        {
            //use textLabel to access each Label
            var textLabel = string.Format($"label{i}");
            var txtLabel = (Label)this.FindByName(textLabel);

            //Identify the highest recorded power measurement
            if (Convert.ToInt32(txtLabel.Text) > high)
            {
                high = Convert.ToInt32(txtLabel.Text);
            }
        }

        ChangeColor(numberOfLabels, high);
    }


    // change background colors of Labels based on the highest recoreded power measurement
    //use to frameLabel to access each frame

    [Obsolete]
    private void ChangeColor(int numberOfLabels, int high)
    {
        for (int i = 1; i <= numberOfLabels; i++)
        {
            var frameLabel = string.Format($"data{i}");
            var frame = (Frame)this.FindByName(frameLabel);

            var textLabel = string.Format($"label{i}");
            var txtLabel = (Label)this.FindByName(textLabel);

            if (Convert.ToInt32(txtLabel.Text) >= high * .9)
            {
                frame.Background = Color.FromHex("#9999ff");
            }

            else if (Convert.ToInt32(txtLabel.Text) >= high * .85)
            {
                frame.Background = Color.FromHex("#cce0ff");
            }

            else if (Convert.ToInt32(txtLabel.Text) >= high * .80)
            {
                frame.Background = Color.FromHex("#4dffb8");
            }

            else if (Convert.ToInt32(txtLabel.Text) >= high * .75)
            {
                frame.Background = Color.FromHex("#d9ffcc");
            }

            else if (Convert.ToInt32(txtLabel.Text) >= high * .70)
            {
                frame.Background = Color.FromHex("#ffe066");
            }

            else if (Convert.ToInt32(txtLabel.Text) >= high * .6)
            {
                frame.Background = Color.FromHex("#ffc299");
            }

            else if (Convert.ToInt32(txtLabel.Text) >= high * .5)
            {
                frame.Background = Color.FromHex("#ff4d94");
            }

            else
            {
                frame.Background = Color.FromHex("#ff6666");
            }
        }

    }
}