using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using LE07_03_Altenburger.LoginWindow_;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;

namespace LE07_03_Altenburger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
        }
        
        private void AskForLogin()
        {
            
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void exitApp(object sender, RoutedEventArgs routedEventArgs)
        {
            Application.Current.Shutdown();
        }
        private void Theme_Toggle_OnClick(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark )
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        

        private void getBoxContent()
        {
            List<string> lsList = new List<string>();
            lsList.Add(BestellübersichtLiefernummer.GetLineText(0)); 
            lsList.Add(BestellübersichtVersanddatum.GetLineText(0));
            lsList.Add(BestellübersichtKundennummer.GetLineText(0));
            lsList.Add(BestellübersichtKundenreferenz.GetLineText(0));
            lsList.Add(VersanddienstleisterAnschrift.GetLineText(0));
            lsList.Add(EmpfängerAnschrift.GetLineText(0));
            lsList.Add(EmpfängerLieferung.GetLineText(0));
            lsList.Add(KäuferAnschrift.GetLineText(0));
            lsList.Add(KäuferBuchhaltung.GetLineText(0));
            lsList.Add(KäuferEinkauf.GetLineText(0));
            lsList.Add(VerkäuferAnschrift.GetLineText(0));
            lsList.Add(VerkäuferAnsprechpartner.GetLineText(0));
            lsList.Add(VerkäuferBuchhaltung.GetLineText(0));
            lsList.Add(VerkäuferBuchhaltung.GetLineText(0));
            lsList.Add(VerkäuferBuchhaltung.GetLineText(0));
            lsList.Add(VersandArtikel.GetLineText(0));
            lsList.Add(VersandArtikelnummer.GetLineText(0));
            lsList.Add(VersandBezeichnung.GetLineText(0));
            lsList.Add(VersandLiefermenge.GetLineText(0));
            saveFileDIalog(lsList);

        }

        private void saveFileDIalog(List<string> lsList)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();      
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.DefaultExt = "txt";      
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";      
            saveFileDialog1.FilterIndex = 2;      
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.ShowDialog() == true)
            {
                foreach (string temp in lsList)
                {
                    File.WriteAllText(saveFileDialog1.FileName, temp);
                }
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getBoxContent();
        }
        
    }
}