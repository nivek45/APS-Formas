using System;

namespace AulaAPS
{
    public class TrianguloIsosceles : Triangulo
    {
        private double _ladoBase; 
        public double LadoBase
        {
            get { return _ladoBase; }
            set { _ladoBase = value; }
        }

        private double _altura;

        public double Altura
        {
            get { return _altura; }
            set { _altura = value; }
        }

        public override double CalcularArea()
        {
            return ((_ladoBase * _altura) / 2);
        }

        public override double CalcularPerimetro()
        {
            double ladoIgual = Math.Sqrt(Math.Pow((_ladoBase / 2), 2) + Math.Pow(_altura, 2));
            return (_ladoBase + 2 * ladoIgual);
        }

        public override string ToString()
        {
            return "Triângulo Isósceles";
        }
    }
}
