using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
                Pessoa pessoa = new Pessoa
                {
                    ID = 12,
                    Nome = "treinaweb"
                };

            Pessoa anderson = new Pessoa
            {
                ID = 44,
                Nome = "anderson"
            };

                Animal animal = new Animal
                {
                    ID = 32,
                    Especie = "Cachorro"
                };

            RepositorioGenerico<Pessoa> repositorioPessoa = new RepositorioGenerico<Pessoa>();
            RepositorioGenerico<Animal> repositorioAnimal = new RepositorioGenerico<Animal>();
            repositorioPessoa.Insert(pessoa);
            repositorioPessoa.Insert(anderson);
            repositorioAnimal.Insert(animal);

            foreach(Pessoa p in repositorioPessoa.Get())
            {
                Console.WriteLine("nome da pessoa : " + p.Nome);
            }
            foreach(Animal ani in repositorioAnimal.Get())
            {
                Console.WriteLine("especie do animal :" + ani.Especie);
            }

            Console.ReadKey();

        }
    }
}
