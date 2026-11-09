namespace Problema1_Figuras;

public class Program
{
    public static void Main(string[] args)
    {
        // Arreglo de tipo padre
        Figura[] figuras = new Figura[3];
        figuras[0] = new Rectangulo(5, 3);
        figuras[1] = new Cuadrado(4);
        figuras[2] = new Triangulo(3, 4, 5);

        Console.WriteLine("---Polimorfismo con Figuras---");
        Console.WriteLine();

        // Recorrido polimórfico
        for (int i = 0; i < figuras.Length; i++)
        {
            Figura f = figuras[i];

            Console.WriteLine($"Figura   : {f.GetType().Name}");
            Console.WriteLine($"Área     : {f.CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {f.CalcularPerimetro():F2}");
            Console.WriteLine("---");
        }

        Console.WriteLine("Presione Enter para salir");
        Console.ReadLine();
    }
}
