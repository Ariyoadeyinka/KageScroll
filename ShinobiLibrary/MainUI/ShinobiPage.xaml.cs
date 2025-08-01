using ShinobiLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MainUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShinobiPage : Page
    {
        public ObservableCollection<Shinobi> ShinobiCollection { get; set; }
        public ShinobiPage()
        {
            this.InitializeComponent();
            ShinobiCollection = new ObservableCollection<Shinobi>();
        }
 //           ShinobiCollection.Add(new Genin(
 //    "Naruto",
 //    "Uzumaki",
 //    45,                          // completed
 //    50,                          // assigned
 //    95,                          // chakra level
 //    new DateTime(2002, 10, 10),  // DOB
 //    true,                        // is active
 //    "Ninjutsu",                  // specialty
 //    "Kakashi Hatake",           // assigned sensei
 //    true                         // requires supervision
 //));
        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ManageMissions_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MissionPage));
        }

        private void RenderShinobiList()
        {
            // Clear everything except the header
            ShinobiTablePanel.Children.Clear();
            ShinobiTablePanel.Children.Add(ShinobiTableHeader);

            // Show or hide "No Shinobi" message
            EmptyMessage.Visibility = ShinobiCollection.Count == 0 ? Visibility.Visible : Visibility.Collapsed;

            int id = 1;

            foreach (var shinobi in ShinobiCollection)
            {
                var row = new Grid
                {
                    Padding = new Thickness(8),
                    Margin = new Thickness(0, 2, 0, 2),
                    Background = new SolidColorBrush(Windows.UI.Colors.White),
                    CornerRadius = new CornerRadius(4)
                };

                // Column definitions (must match your header)
                for (int i = 0; i < 12; i++)
                {
                    row.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                }


                // ID
                var idBlock = new TextBlock { Text = id.ToString() , 
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Black),
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                Grid.SetColumn(idBlock, 0);
                row.Children.Add(idBlock);

                // First Name
                var firstNameBlock = new TextBlock { Text = $"{shinobi.FirstName}",
                    Margin = new Thickness(5, 0, 0, 0), 
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Black),
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                Grid.SetColumn(firstNameBlock, 1);
                row.Children.Add(firstNameBlock);
                //Last Name
                var lastNameBlock = new TextBlock { Text = $"{shinobi.LastName}", 
                    Margin = new Thickness(5, 0, 0, 0), 
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Black),
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                Grid.SetColumn(lastNameBlock, 2);
                row.Children.Add(lastNameBlock);
                // Rank
                var rankBlock = new TextBlock { Text = shinobi.GetType().Name, 
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Black),
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                Grid.SetColumn(rankBlock, 3);
                row.Children.Add(rankBlock);
                //Mission Completed
                var missionCompleted = new TextBlock { Text = shinobi.MissionCompleted.ToString(), 
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Black),
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                Grid.SetColumn(missionCompleted, 4);
                row.Children.Add(missionCompleted);
                //Mission Assigned
                var missionAssigned = new TextBlock { Text = shinobi.MissionAssigned.ToString(), 
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Black),
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                Grid.SetColumn(missionAssigned, 5);
                row.Children.Add(missionAssigned);

                // Chakra
                var chakraBlock = new TextBlock {Text = shinobi.ChakraLevel.ToString(), 
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Black), 
                    TextAlignment = TextAlignment.Center, 
                    HorizontalAlignment = HorizontalAlignment.Center };
                Grid.SetColumn(chakraBlock, 6);
                row.Children.Add(chakraBlock);
                // Specialty
                var specBlock = new TextBlock {Text = shinobi.Specialty,
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Black), 
                    TextAlignment = TextAlignment.Center, 
                    HorizontalAlignment = HorizontalAlignment.Center };
                Grid.SetColumn(specBlock, 7);
                row.Children.Add(specBlock);
                // Status
                string status = shinobi.IsActive ? "Active" : "Inactive";
                var statusBlock = new TextBlock {Text = status, 
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Black), 
                    TextAlignment = TextAlignment.Center, 
                    HorizontalAlignment = HorizontalAlignment.Center };
                Grid.SetColumn(statusBlock, 8);
                row.Children.Add(statusBlock);

                // Mentor 
                string mentor = "null";
                if (shinobi is Genin g)
                    mentor = g.AssignedSensei;
                else if (shinobi is Jonin jo)
                    mentor = jo.IsSquadLeader ? "Squad Leader" : "Not A Squad Leader";
                else if (shinobi is Chunin c)
                    mentor = "null";
                var mentorBlock = new TextBlock {Text = mentor, 
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Black),
                    TextAlignment = TextAlignment.Center, 
                    HorizontalAlignment = HorizontalAlignment.Center };
                Grid.SetColumn(mentorBlock, 9);
                row.Children.Add(mentorBlock);

                //Code Name
                string codeName = "null";
                if (shinobi is Anbu a)
                    codeName = a.CodeName;
                var codeBlock = new TextBlock {Text = codeName, 
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Black), 
                    TextAlignment = TextAlignment.Center, 
                    HorizontalAlignment = HorizontalAlignment.Center };
                Grid.SetColumn(codeBlock, 10);
                row.Children.Add(codeBlock);

                //Mission Led
                string missionLedNum = "null";
                if (shinobi is Jonin j)
                {
                    missionLedNum = j.MissionLed.ToString();
                }
                var missionLed = new TextBlock {Text = missionLedNum, 
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Black), 
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center };
                Grid.SetColumn(missionLed, 11);
                row.Children.Add(missionLed);
                // Add completed row to the table
                ShinobiTablePanel.Children.Add(row);
                id++;
            }
        }


        private async void OpenAddShinobiDialog_Click(object sender, RoutedEventArgs e)
        {

            var dialog = new AddShinobiDialog();
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                try
                {
                    string firstName = dialog.FirstName;
                    string lastName = dialog.LastName;
                    int chakraLevel = dialog.ChakraLevel;
                    DateTime dob = dialog.DOB;
                    int missionAssigned = dialog.MissionAssigned;
                    int missionCompleted = dialog.MissionCompleted;
                    bool isActive = dialog.IsActive;
                    string senseiName = dialog.SenseiName;
                    bool needSupervision = dialog.NeedSupervisionToggle;
                    string specialty = dialog.Specialty;
                    string shinobiRank = dialog.Rank;
                    string status = dialog.Status;
                    Shinobi newShinobi = null;
                    switch (shinobiRank)
                    {
                        case "Genin":
                            newShinobi = new Genin(firstName, lastName, missionCompleted, missionAssigned, chakraLevel, dob, isActive, specialty, senseiName, needSupervision);
                            break;

                        case "Chunin":
                            newShinobi = new Chunin(firstName, lastName, missionCompleted, missionAssigned, chakraLevel, dob, isActive, specialty);
                            break;
                        case "Jonin":
                            bool isSquadLeader = dialog.IsSquadLeaader;
                            int missionLed = dialog.MissionLed;
                            newShinobi = new Jonin(firstName, lastName, missionCompleted, missionAssigned, chakraLevel, dob, isActive, specialty, isSquadLeader, missionLed);
                            break;
                        case "Anbu":
                            string codeName = dialog.CodeName;
                            newShinobi = new Anbu(firstName, lastName, missionCompleted, missionAssigned, chakraLevel, dob, isActive, specialty, codeName);
                            break;
                    }
                    if (newShinobi != null)
                    {
                        double missionSuccessRate = newShinobi.MissionSuccessRateValue;
                        ShinobiCollection.Add(newShinobi);
                        RenderShinobiList();
                    }
                }
                catch (FormatException fex)
                {
                    var formatDialog = new MessageDialog(fex.Message, "Invalid Format");
                    await formatDialog.ShowAsync();
                }
                catch (Exception ex)
                {
                    var errorDialog = new MessageDialog(ex.Message);
                    await errorDialog.ShowAsync();
                }

            }
        }

    }
}
