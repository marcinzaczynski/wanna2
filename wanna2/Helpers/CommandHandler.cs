using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wanna2.Helpers
{
    public static class CommandHandler
    {
        public static readonly RoutedUICommand OtworzAnalizaBadania = new RoutedUICommand
            (
                "OtwórzAnalizaBadania",
                "OtworzAnalizaBadania",
                typeof(CommandHandler),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.B, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand OtworzParametry = new RoutedUICommand
            (
                "OtwórzParametry",
                "OtworzParametry",
                typeof(CommandHandler),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.F12)
                }
            );

        public static readonly RoutedUICommand ZapiszBadanieWBazie = new RoutedUICommand
            (
                "ZapiszBadanieWBazie",
                "ZapiszBadanieWBazie",
                typeof(CommandHandler),
                new InputGestureCollection()
                {
                    
                }
            );

        public static readonly RoutedUICommand PokazRaport = new RoutedUICommand
    (
        "PokażRaport",
        "PokazRaport",
        typeof(CommandHandler),
        new InputGestureCollection()
        {

        }
    );

        public static readonly RoutedUICommand Zamknij = new RoutedUICommand
           (
               "Zamknij",
               "Zamknij",
               typeof(CommandHandler),
               new InputGestureCollection()
               {
                    new KeyGesture(Key.F4, ModifierKeys.Alt)
               }
           );

        public static readonly RoutedUICommand Ok = new RoutedUICommand
            (
                "OK",
                "Ok",
                typeof(CommandHandler),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.F1)
                }
            );

        public static readonly RoutedUICommand Anuluj = new RoutedUICommand
            (
                "Anuluj",
                "Anuluj",
                typeof(CommandHandler),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.Escape)
                }
            );
    }
}
