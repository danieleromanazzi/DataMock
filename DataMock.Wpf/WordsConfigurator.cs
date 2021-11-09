using DataMock.Configuration;
using DataMock.Behaviors;
using System.Windows;

namespace DataMock.Wpf
{
    public class WordsConfigurator
    {
        protected WordsConfigurator()
        {

        }

        public static int GetNumber(DependencyObject obj)
        {
            return (int)obj.GetValue(NumberProperty);
        }

        public static void SetNumber(DependencyObject obj, int value)
        {
            obj.SetValue(NumberProperty, value);
        }

        // Using a DependencyProperty as the backing store for Number.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.RegisterAttached("Number", typeof(int), typeof(WordsConfigurator), new PropertyMetadata(0, OnNumberChanged));

        private static void OnNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!Configure.Current.TryGetBehavior<StringBehavior>(out var behavior))
            {
                Configure.Current.RegisterBehavior<StringBehavior>(new WordsBehavior() { Number = GetNumber(d) });
            }

            if (behavior is WordsBehavior words)
            {
                words.Number = GetNumber(d);
            }
        }

        public static int GetLenght(DependencyObject obj)
        {
            return (int)obj.GetValue(LenghtProperty);
        }

        public static void SetLenght(DependencyObject obj, int value)
        {
            obj.SetValue(LenghtProperty, value);
        }

        // Using a DependencyProperty as the backing store for Lenght.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LenghtProperty =
            DependencyProperty.RegisterAttached("Lenght", typeof(int), typeof(WordsConfigurator), new PropertyMetadata(0, OnLenghtChanged));

        private static void OnLenghtChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!Configure.Current.TryGetBehavior<StringBehavior>(out var behavior))
            {
                Configure.Current.RegisterBehavior<StringBehavior>(new WordsBehavior() { Lenght = GetLenght(d) });
            }
            
            if (behavior is WordsBehavior words)
            {
                words.Lenght = GetLenght(d);
            }
        }
    }
}
