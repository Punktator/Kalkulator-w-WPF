using System.Windows;

namespace Kalkulator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Dodaj_Klik(object sender, RoutedEventArgs e)
    {

    }

 
}

public static class Logika
{
    public static double Oblicz(string wyrazenie)
    {
        //if (!ZbiorOperatorowArytmetycznych.Any(rzecz => wyrazenie.Contains(rzecz)))
        //    return Convert.ToDouble(wyrazenie);
        if (wyrazenie.Contains('+'))
            return Oblicz('+', wyrazenie.Split('+', 2));
        if (wyrazenie.Contains('-'))
            return Oblicz('-', wyrazenie.Split('-', 2));
        if (wyrazenie.Contains('*'))
            return Oblicz('*', wyrazenie.Split('*', 2));
        if (wyrazenie.Contains("/"))
            return Oblicz('/', wyrazenie.Split('/', 2));
        throw new NotImplementedException();
    }

    private static double Oblicz(char operatorArytmetyczny, string[] operandy)
    {
        if (operandy.Length != 2) throw new FormatException("Funkcja Oblicz()");
        return Oblicz(operatorArytmetyczny, Double.Parse(operandy[0]), Double.Parse(operandy[1]));
    }

    static double Oblicz(char operatorArytmetyczny, double operand1, double operand2) 
    {
        return operatorArytmetyczny switch
        {
            '+' => operand1 + operand2,
            '-' => operand1 - operand2,
            '*' => operand1 * operand2,
            '/' => operand1 / operand2,
            _ => throw new FormatException(),
        };
    }

    static double Oblicz(char operatorArytmetyczny, string operand1, string operand2)
        => Oblicz(operatorArytmetyczny, Double.Parse(operand1), Double.Parse(operand2));

    static readonly HashSet<string> ZbiorOperatorowArytmetycznych = ["+", "-", "*", "/"];   //a może char?
}
