using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace Front.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class RootPage : Page
    {
        public RootPage(Frame frame) {
            this.InitializeComponent();
            this.MySplitView.Content = frame;
            (MySplitView.Content as Frame).Navigate(typeof(HomePage));
        }

        private void OnBackClicked(object sender, RoutedEventArgs e)
        {
            Frame myFrame = this.MySplitView.Content as Frame;
            if (myFrame.CanGoBack) {
                myFrame.GoBack();
            }
       
        }

        private void OnBurgerClicked(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void OnHomeClicked(object sender, RoutedEventArgs e)
        {
            (MySplitView.Content as Frame).Navigate(typeof(HomePage));

        }

        private void OnFilmsClicked(object sender, RoutedEventArgs e)
        {
           

        }

        private void OnCompteClicked(object sender, RoutedEventArgs e)
        {
            (MySplitView.Content as Frame).Navigate(typeof(ComptePage));
        }

        private void OnParamsClicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
