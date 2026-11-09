namespace Problema1_Figuras;

public class Rectangulo : Figura
{
    private double _base;
    private double _altura;

    public Rectangulo(double baseRect, double altura)
    {
        _base = baseRect;
        _altura = altura;
    }

    public override double CalcularArea()
    {
        return _base * _altura;
    }

    public override double CalcularPerimetro()
    {
        return 2 * (_base + _altura);
    }
}
