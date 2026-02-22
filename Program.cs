using System;
using System.Collections.Generic;

namespace JogoDeCarros
{
    // 1. INTERFACE (Habilidade)
    public interface IEletrico 
    {
        void CarregarBateria();
    }

    // 2. CLASSE ABSTRATA (O Molde Pai)
    public abstract class Veiculo 
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public virtual void Acelerar() 
        {
            Console.WriteLine($"{Modelo} está acelerando de forma padrão.");
        }

        public abstract void Parar(); // Obrigatório implementar
    }

    // 3. CLASSES DERIVADAS (Filhos)
    public class Carro : Veiculo 
    {
        public override void Parar() => Console.WriteLine($"{Modelo} parou usando freios a disco.");
    }

    public class Tesla : Veiculo, IEletrico 
    {
        public override void Acelerar() => Console.WriteLine($"{Modelo} (Elétrico) disparou instantaneamente!");
        public override void Parar() => Console.WriteLine($"{Modelo} parou com frenagem regenerativa.");
        public void CarregarBateria() => Console.WriteLine($"{Modelo} conectado ao Supercharger.");
    }

    // 4. PROGRAMA PRINCIPAL
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Simulador de Jogo de Carros ---");

            var meuCarro = new Carro { Marca = "Toyota", Modelo = "Corolla" };
            var meuTesla = new Tesla { Marca = "Tesla", Modelo = "Model S" };

            meuCarro.Acelerar();
            meuCarro.Parar();

            Console.WriteLine();

            meuTesla.Acelerar();
            meuTesla.CarregarBateria();
            meuTesla.Parar();
        }
    }
}
