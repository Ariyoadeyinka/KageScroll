using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MainUI
{
    public sealed partial class AddShinobiDialog : ContentDialog
    {
        public AddShinobiDialog()
        {
            this.InitializeComponent();

        }

        public string FirstName => FirstNameBox.Text;
        public string LastName => LastNameBox.Text;
        public string Specialty => SpecialtyBox.Text;
        public int ChakraLevel => (int)ChakraSlider.Value;
        public string Rank => (RankBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
        public DateTime DOB => DobPicker.Date.Date;
        public bool IsActive => ActiveToggle.IsOn;
        public string Status => IsActive ? "Active" : "Inactive";
        public string SenseiName=> SenseiBox.Text;
        public int MissionAssigned => int.Parse(MissionsAssignedBox.Text);
        public int MissionCompleted => int.Parse(MissionsCompletedBox.Text);
        public bool NeedSupervisionToggle => SupervisionToggle.IsOn;
        public bool IsSquadLeaader => SquadLeaderToggle.IsOn;
        public int MissionLed => int.Parse(MissionsLedBox.Text);
        public string CodeName => CodenameBox.Text;

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
        private void RankBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedRank = (RankBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

            // Example: Toggle visibility of fields depending on the selected rank
            if (selectedRank == "Genin")
            {
                SupervisionToggle.Visibility = Visibility.Visible;
                SenseiBox.Visibility = Visibility.Visible;
                SquadLeaderToggle.Visibility = Visibility.Collapsed;
                MissionsLedBox.Visibility = Visibility.Collapsed;
                CodenameBox.Visibility = Visibility.Collapsed;
            }
            else if (selectedRank == "Jonin")
            {
                SquadLeaderToggle.Visibility = Visibility.Visible;
                MissionsLedBox.Visibility = Visibility.Visible;
                SupervisionToggle.Visibility = Visibility.Collapsed;
                CodenameBox.Visibility = Visibility.Collapsed;
            }
            else if (selectedRank == "Anbu")
            {
                CodenameBox.Visibility = Visibility.Visible;

                SupervisionToggle.Visibility = Visibility.Collapsed;
                SquadLeaderToggle.Visibility = Visibility.Collapsed;
                MissionsLedBox.Visibility = Visibility.Collapsed;
            }
            else // Chunin or fallback
            {
                SupervisionToggle.Visibility = Visibility.Collapsed;
                SquadLeaderToggle.Visibility = Visibility.Collapsed;
                MissionsLedBox.Visibility = Visibility.Collapsed;
                CodenameBox.Visibility = Visibility.Collapsed;
            }
        }

    }
}
