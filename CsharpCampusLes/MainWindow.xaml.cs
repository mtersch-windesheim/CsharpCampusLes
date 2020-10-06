using System.Windows;

namespace CsharpCampusLes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Dialoogscherm en event
        // Variabele om dialoog-window te bevatten
        private SuikerDialoog window;
        private void btnSuikerDialoog_Click(object sender, RoutedEventArgs e)
        {
            // Als knop voor suikerdialoog geklikt: eerst even checken of we al een dialoog-window hadden geinstantieerd
            if(window==null)
            {
                // Zo nee: instantieer een nieuw dialoog-window
                window = new SuikerDialoog();
                // Dit window heeft een 'SuikerChanged'-event (zie SuikerDialoog.xaml.cs); koppel hier onze eventhandler aan
                window.SuikerChanged += SuikerDialoog_ToevoegingChanged;
            }
            // Laat het dialoog-window modeless zien (dus interactie met hoofdscherm blijft mogelijk)
            window.Show();
        }

        // Event handler voor 'SuikerChanged'-event: als dat event wordt afgevuurd, zet dan vinkje 'suiker' aan/uit
        private void SuikerDialoog_ToevoegingChanged(object sender, ToevoegingEventArgs tea)
        {
            // ToevoegingEventArgs bevat properties voor welke toevoeging is gewijzigd (suiker/melk/caramel/kaneel/...)
            // en of toevoeging wel of niet gewenst is
            if(tea.Toevoeging == "suiker")
            {
                cbSuiker.IsChecked = tea.Toevoegen;
            }
        }
        #endregion

        private void btnKoekje_Click(object sender, RoutedEventArgs e)
        {
            // In de properties van dit scherm (MainWindow.xaml -> element 'Window' -> Properties -> Common -> DataContext)
            // hebben we ingesteld dat WPF een instance van class 'KoekieBehoefte' als DataContext moet gebruiken.
            // (Hint als je eigen data-class hier niet zichtbaar is: doe een Build van je project, en kijk dan nog eens.)
            //
            // In de properties van 'cbKoekje' en 'lblSoortKoekje' hebben we ingesteld dat voor IsChecked / Content de inhoud van
            // de properties 'IkWilKoekie' en 'SoortKoekje' worden gebruikt. (Klik vierkantje naast IsChecked / Content, kies
            // 'Set Data Binding...', en selecteer de gewenste property.)
            //
            // Ook als KoekieBehoefte een 'gewone' class is (dus niet : INotifyPropertyChanged) wordt bij de eerste keer tonen
            // van het scherm de data uit properties van dit object gebruikt.
            // De truc met INotifyPropertyChanged is: als je die goed implementeert heeft WPF standaard eventhandlers waardoor
            // bij *elke wijziging* in KoekieBehoefte de gekoppelde velden bijgewerkt. (Dus niet alleen bij de eerste keer tonen.)
            //
            // 'Probleempje': de property MainWindow.DataContext heeft nog steeds type 'object', dus die moeten we voor gebruik
            // nog casten naar type 'KoekieBehoefte'.
            KoekieBehoefte mijnBehoefte = (KoekieBehoefte)DataContext;
            // Nu kunnen we de properties van ons KoekieBehoefte-object aanpassen; als 
            mijnBehoefte.IkWilKoekie = !mijnBehoefte.IkWilKoekie;
            mijnBehoefte.SoortKoekje = "Speculaas";
        }
    }
}
