using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace LE07_03_Altenburger.LoginWindow_
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            
        }
        protected void LoginWindow_Closed(object sender, EventArgs e)
        { 
            MainWindow mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
            
        }
        
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
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

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void Login_btn_OnClick(object sender, RoutedEventArgs e)
        {
            if (authenticateUser())
            {
                Close();
            }
            else
            {
                txtUsername.Foreground = Brushes.Red;
                txtPassword.Foreground = Brushes.Red;
                txtPassword.ToolTip = "Please check your Login's again!";
                txtUsername.ToolTip = "Please check your Login's again!";
            }
            
        }

        public bool authenticateUser()
        {
            Object pass = txtPassword.Password.Clone();
            if (Object.Equals(txtUsername.GetLineText(0), "admin") && Object.Equals(pass, "admin") )
            {
                bool authenticated = true;
                return authenticated;
            }
            else
            {
                return false;
                
            }

            return false;
        }

        private void TxtUsername_OnKeyDown(object sender, KeyEventArgs e)
        {
            txtUsername.Foreground = Brushes.Black;
            txtPassword.Foreground = Brushes.Black;
            txtPassword.ToolTip = "Please check your Login's again!";
            txtUsername.ToolTip = "Please check your Login's again!";
        }
    }
}