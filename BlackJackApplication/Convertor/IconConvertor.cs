using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using static BlackJackDomain.GameUtilities.PublicEnums;

namespace BlackJackApplication.CardDisplay
{
    public class IconConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (System.Convert.ToBoolean(value))
            //{
            //    return new BitmapImage(new Uri(TruePath));
            //}
            //return new BitmapImage(new Uri(FalsePath));

            Suit suit = (Suit)value;

            switch (suit)
            {
                case Suit.Diamond:
                    return "SuitDiamonds";
                case Suit.Club:
                    return "SuitClubs";
                case Suit.Heart:
                    return "SuitHearts";
                case Suit.Spade:
                    return "SuitSpades";
                default:
                    return "";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
