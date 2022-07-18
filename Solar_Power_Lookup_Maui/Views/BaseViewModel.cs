
namespace Solar_Power_Lookup_Maui.Views
{
    public partial class BaseViewModel: ObservableObject
    {
        [ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;


    }
}
