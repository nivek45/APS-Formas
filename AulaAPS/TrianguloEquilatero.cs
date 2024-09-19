using System;

namespace AulaAPS
{
    public class TrianguloEquilatero : Triangulo
    {
        private double _lado;
        public double Lado
        {
            get { return _lado; }
            set { _lado = value; }
        }

        public override double CalcularArea()
        {
            return (Math.Sqrt(3) / 4) * Math.Pow(_lado, 2);
        }

        public override double CalcularPerimetro()
        {
            return 3 * _lado;
        }

        public override string ToString()
        {
            return "Triângulo Equilátero";
        }
    }

}
