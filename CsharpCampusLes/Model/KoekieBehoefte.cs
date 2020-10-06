using System.ComponentModel;

namespace CsharpCampusLes
{
    // Class KoekieBehoefte wordt gebruikt als DataContext voor MainWindow.
    // Deze class bevat de properties waaruit de waarden voor lblSoortKoekje.Content en cbKoekje.IsChecked worden gehaald.
    //
    // Dit werkt ook *zonder* INotifyPropertyChanged (en PropertyChanged-event), maar dan alleen bij de eerste keer openen van het scherm,
    // wijzigingen in de properties worden dan *niet doorgegeven*.
    public class KoekieBehoefte : INotifyPropertyChanged
    {
        // We definieren een event 'PropertyChanged' -> WPF koppelt hier automatisch eventhandlers aan die de waarden aanpassen
        // in de controls die door databinding gevuld worden. (Dat scheelt ons weer eventhandlers schrijven.)
        // P.S.: Omdat we INotifyPropertyChanged implementeren, zijn we verplicht dit event te definieren.
        public event PropertyChangedEventHandler PropertyChanged;

        public KoekieBehoefte()
        {
            IkWilKoekie = true;
        }
        // Even de propertie 'IkWilKoekie' uitgeschreven, zodat ik in de code een regel kan toevoegen.
        // (Dat gaat wat moeilijk in 'public bool IkWilKoekie{get;set;}'...)
        private bool ikWilKoekie;
        public bool IkWilKoekie
        {
            get => ikWilKoekie;
            set
            {
                ikWilKoekie = value;
                // Als de waarde van IkWilKoekie wijzigt, vuur dan event 'PropertyChanged' af.
                // (Met andere woorden: voer de eventhandlers in event-variabele 'PropertyChanged' uit.)
                // In het PropertyChangedEventArgs-object melden we dat property 'IkWilKoekie' is gewijzigd;
                // anders weet de eventhandler alleen dat 'een of andere property van een instance van KoekieBehoefte' is gewijzigd.
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IkWilKoekie"));
            }
        }
        private string soortKoekje;
        public string SoortKoekje
        {
            get => soortKoekje;
            set { soortKoekje = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SoortKoekje")); }
        }
    }
}
