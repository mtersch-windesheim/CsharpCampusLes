using System;

namespace CsharpCampusLes
{
    // Het event 'SuikerChanged' in SuikerDialoog.xaml.cs moet een (delegate) type hebben.
    // We doen een iets algemener type (met in ToevoegingEventArgs een property voor soort toevoeging) zodat we dit type ook
    // kunnen gebruiken voor bijvoorbeeld een MelkChanged-event, een CaramelChanged-event, etcetera.
    // Daarom staat dit type ook niet in SuikerDialoog.xaml.cs, maar in dit bestand.
    public delegate void ToevoegingChanged(object sender, ToevoegingEventArgs tea);

    // Een zelfgebouwde EventArgs-klasse, waarin we ook kunnen meegeven wat voor toevoeging is gewijzigd,
    // en of deze nou wel of niet moet worden toegevoegd aan onze kop koffie.
    public class ToevoegingEventArgs : EventArgs
    {
        public string Toevoeging { get; }
        public bool Toevoegen { get; }

        public ToevoegingEventArgs(string toevoeging, bool toevoegen)
        {
            Toevoeging = toevoeging;
            Toevoegen = toevoegen;
        }
    }
}