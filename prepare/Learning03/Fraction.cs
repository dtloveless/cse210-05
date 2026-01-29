using System.Dynamic;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int top)
    {
        _numerator = top;
        _denominator = 1;
    }

    public Fraction(int top, int bottom)
    {
        _numerator = top;
        _denominator = bottom;
    }

    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public void SetNumerator(int top)
    {
        _numerator = top;
    }

    public double GetDecimalValue()
    {
        double decimalValue = (double)_numerator / _denominator;
        return decimalValue;
    }

    public void SetDenominator(int bottom)
    {
        _denominator = bottom;
    }
}