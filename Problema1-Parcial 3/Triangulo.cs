namespace Problema1_Figuras;

public class Triangulo : Figura
{
    private double _ladoA;
    private double _ladoB;
    private double _ladoC;

    public Triangulo(double ladoA, double ladoB, double ladoC)
    {
        _ladoA = ladoA;
        _ladoB = ladoB;
        _ladoC = ladoC;
    }

    public override double CalcularArea()
    {
        double s = CalcularPerimetro() / 2;
        return Math.Sqrt(s * (s - _ladoA) * (s - _ladoB) * (s - _ladoC));
    }

    public override double CalcularPerimetro()
    {
        return _ladoA + _ladoB + _ladoC;
    }
}
