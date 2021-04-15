using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Scheduler;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LoadOnDemand
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.InitializeComboBoxItemSource();
        }

        private void InitializeComboBoxItemSource()
        {
            this.viewtypecombobox.ItemsSource = Enum.GetValues(typeof(SchedulerViewType));
        }
    }
}
