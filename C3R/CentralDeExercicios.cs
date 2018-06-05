using System;
using System.Collections.Generic;
namespace C3R
{
    public class CentralDeExercicios
    {
        public List<object> ListaDeExercicios;
        string Listagem = "";
        public CentralDeExercicios()
        {
            ListaDeExercicios = new List<object>();
        }

        public void AdicionarExercicio(object exercicio, string titulo)
        {
            ListaDeExercicios.Add(exercicio);
            Listagem += string.Format("{0} - {1}\n", ListaDeExercicios.Count, titulo);
        }
        public void ListarExercicios()
        {
            string entrada = "";
            int id = 0;
            Console.WriteLine(Listagem);

            Console.WriteLine("Digite o id do exercicio ou pressione ENTER para executar o ultimo exercicio:");
            entrada = Console.ReadLine();
            int.TryParse(entrada, out id);
            if (id == 0)
            {
                ExecutarExercicio(ListaDeExercicios.Count - 1);
            }
            else
            {
                ExecutarExercicio(id - 1);
            }
        }

        public void ExecutarExercicio(int id)
        {
            var type = ListaDeExercicios[id].GetType();

            var Executar = type.GetMethod("Executar");
            object classInstance = Activator.CreateInstance(type, null);
            Executar.Invoke(classInstance, null);
        }
    }
}
