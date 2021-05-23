using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Frankensteiner
{
    /// <summary>
    /// Interaction logic for ImportWindow.xaml
    /// </summary>
    public partial class ImportWindow : MetroWindow
    {
        private List<MercenaryItem> mercenaryList = new List<MercenaryItem>();
        private List<MercenaryItem> _invalidMercs = new List<MercenaryItem>();
        private List<string> parsedMercenaries = new List<string>();
        private MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public ImportWindow()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }

        #region Code Validation
        private void BValidate_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbMercenaryCode.Text))
            {
                #region Clear Lists For Next Validation
                mercenaryList.Clear();
                _invalidMercs.Clear();
                parsedMercenaries.Clear();
                #endregion
                Regex profile = new Regex(@"^CharacterProfiles=\(.+\)", RegexOptions.Multiline);
                Regex ws = new Regex(@"^\s+CharacterProfiles=\(.+\)", RegexOptions.Multiline); // We'll also look for any leading whitespace
                Regex horde = new Regex(@"(DefaultCharacterFace=\(.+)");
                foreach (Match match in profile.Matches(tbMercenaryCode.Text))
                {
                    parsedMercenaries.Add(match.Value);
                }
                foreach (Match match in ws.Matches(tbMercenaryCode.Text))
                {
                    parsedMercenaries.Add(match.Value.TrimStart());
                }
                if (horde.IsMatch(tbMercenaryCode.Text))
                {
                    parsedMercenaries.Add(horde.Match(tbMercenaryCode.Text).Value);
                }

                foreach (string parsedMercenary in parsedMercenaries)
                {
                    MercenaryItem mercenary = new MercenaryItem(parsedMercenary);
                    if (mercenary.ValidateMercenaryCode())
                    {
                        mercenaryList.Add(mercenary);
                        bSave.IsEnabled = true;
                    }
                    else
                    {
                        _invalidMercs.Add(mercenary);
                    }
                }
                mercenaryList.Reverse(); // Reverse the list so it appears in the order it was pasted in
                if (mercenaryList.Count == 0 && _invalidMercs.Count == 0)
                {
                    MessageBox.Show("Invalid mercenary code! Make sure you copied the code correctly and try again.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                } else
                {
                    MessageBox.Show(String.Format("{0} mercenaries successfully validated!\n\n{1} mercenaries failed to validate!", mercenaryList.Count, _invalidMercs.Count), "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Cannot validate empty code, you dummy!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Focus();
            this.Close();
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (MercenaryItem mercenary in mercenaryList)
            {
                mercenary.ItemText = String.Format("{0} - Unsaved Imported Mercenary!", mercenary.Name);
                SolidColorBrush newColor = (Properties.Settings.Default.appTheme == "Dark") ? new SolidColorBrush(Color.FromRgb(69, 69, 69)) : new SolidColorBrush(Color.FromRgb(245, 245, 245));
                mercenary.BackgroundColour = newColor;
                mercenary.isOriginal = true;
                mercenary.isImportedMercenary = true;
                mainWindow.AddImportedMercenary(mercenary);
            }
            mainWindow.Focus();
            this.Close();
        }

        // Force revalidation of merc code after editing
        private void tbMercenaryCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox text = sender as TextBox;
            if (string.IsNullOrWhiteSpace(text.Text))
            {
                text.Text = string.Empty;
            }

            if (bSave.IsEnabled)
            {
                bSave.IsEnabled = false;
            }
        }
    }
}
