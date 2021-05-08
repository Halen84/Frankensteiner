﻿using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private MercenaryItem testMerc;

        public ImportWindow()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }

        #region Code Validation
        private void BValidate_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(tbMercenaryCode.Text))
            {
                testMerc = new MercenaryItem(tbMercenaryCode.Text);
                if(testMerc.ValidateMercenaryCode())
                {
                    if(testMerc.isHordeMercenary)
                    {
                        MessageBox.Show("Successfully validated Horde mercenary!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        bSave.IsEnabled = true;
                    } else {
                        MessageBox.Show(String.Format("Successfully validated \"{0}\"!", testMerc.Name), "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        bSave.IsEnabled = true;
                    }
                } else {
                    MessageBox.Show("Invalid mercenary code! Make sure you copied the code correctly and try again.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } else {
                MessageBox.Show("Cannot validate empty code, you dummy!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            testMerc.ItemText = String.Format("{0} - Unsaved Imported Mercenary!", testMerc.Name);
            SolidColorBrush newColor = (Properties.Settings.Default.appTheme == "Dark") ? new SolidColorBrush(Color.FromRgb(69, 69, 69)) : new SolidColorBrush(Color.FromRgb(245, 245, 245));
            testMerc.BackgroundColour = newColor;
            testMerc.isOriginal = true;
            testMerc.isImportedMercenary = true;
            mainWindow.AddImportedMercenary(testMerc);
            this.DialogResult = true;
        }

        // Force revalidation of merc code after editing
        private void tbMercenaryCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(bSave.IsEnabled)
            {
                bSave.IsEnabled = false;
            }
        }
    }
}
