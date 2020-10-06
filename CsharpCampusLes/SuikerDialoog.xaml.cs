using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CsharpCampusLes
{
    /// <summary>
    /// Interaction logic for SuikerDialoog.xaml
    /// </summary>
    public partial class SuikerDialoog : Window
    {
        // Dit dialoog-window heeft een event SuikerChanged; in andere woorden: een (delegate-type) variabele waarin het andere window
        // eventhandler-methodes kan plaatsen om uit te voeren als de gebruiker wel (of geen) suiker in de koffie wil.
        // P.S.: (delegate) type 'ToevoegingChanged' is gedefinieerd in bestand 'ToevoegingEventArgs.cs'.
        public event ToevoegingChanged SuikerChanged;
        public SuikerDialoog()
        {
            InitializeComponent();
        }

        // Detail: 1 eventhandler-methode die we voor *beide* buttons in het scherm gebruiken.
        // We moeten nu alleen nog even checken welke button de afzender van het event is.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Toegepaste Luiheid: als we toch geen eventhandler hebben voor SuikerChanged, hoeven we ook niks te doen!
            if (SuikerChanged != null)
            {
                // Welke button was geklikt -> wil de gebruiker nou wel of geen suiker?
                switch (((Control)sender).Name)
                {
                    case "btnIkWil":
                        // Bouw een ToevoegingEventArgs-object dat meldt dat het gaat om suiker en *wel* toevoegen
                        ToevoegingEventArgs tea = new ToevoegingEventArgs("suiker", true);
                        // Vuur het 'SuikerChanged'-event af == voer de eventhandler(s) in event-variabele 'SuikerChanged' uit.
                        SuikerChanged(this, tea);
                        break;
                    case "btnLaatMaar":
                        // Bouw een ToevoegingEventArgs-object dat meldt dat het gaat om suiker en *niet* toevoegen
                        ToevoegingEventArgs notea = new ToevoegingEventArgs("suiker", false);
                        // Vuur het 'SuikerChanged'-event af == voer de eventhandler(s) in event-variabele 'SuikerChanged' uit.
                        // Dit keer in de 'Invoke'-notatie (is eigenlijk hetzelfde als directe aanroep).
                        SuikerChanged.Invoke(this, notea);
                        break;
                    default:
                        throw new Exception("Ja wat nou!?!");
                }
            }
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            ToevoegingEventArgs tea = new ToevoegingEventArgs("suiker", true);
            // Nog een keer de 'Invoke'-notatie, maar hier het stuk 'if (SuikerChanged != null)' verstopt in het vraagtekentje.
            SuikerChanged?.Invoke(this, tea);
        }
    }
}
