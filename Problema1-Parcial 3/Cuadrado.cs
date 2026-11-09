namespace Problema1_Figuras;

public class Cuadrado : Figura
{
    private double _lado;

    public Cuadrado(double lado)
    {
        _lado = lado;
    }

    public override double CalcularArea()
    {
        return _lado * _lado;
    }

    public override double CalcularPerimetro()
    {
        return 4 * _lado;
    }
}
