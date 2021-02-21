using System;
using SeriesRegistration.Classes;

namespace SeriesRegistration
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();

        static void Main(string[] args)
        {
            string userOption = GetUserOption();
            
            while (userOption.ToUpper() != "X")
            {
                switch(userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ViewSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listar séries");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in list)
            {
                var deleted = serie.returnDeleted();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.returnId(), serie.returnTitle(), (deleted ? "*Excluido*" : ""));
            }
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            
            Console.Write("Digite o gênero entre as opções acima: ");
            int enterGenre = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string enterTitle = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int enterYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string enterDescription = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.NextId(),
                genre: (Genre)enterGenre,
                title: enterTitle,
                year: enterYear,
                description: enterDescription);

            repository.Insert(newSerie);
            //continuar no minuto 12
        }

        private static void UpdateSerie()
        {
            Console.Write("Digite o id da série: ");
            int indexSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int enterGenre = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string enterTitle = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int enterYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string enterDescription = Console.ReadLine();

            Serie updateSerie = new Serie(id: indexSerie,
                genre: (Genre)enterGenre,
                title: enterTitle,
                year: enterYear,
                description: enterDescription);

            repository.Update(indexSerie, updateSerie);

        }

        public static void DeleteSerie()
        {
            Console.Write("Digite o id da série: ");
            int indexSerie = int.Parse(Console.ReadLine());

            repository.Delete(indexSerie);
        }

        public static void ViewSerie()
        {
            Console.Write("Digite o id da série: ");
            int indexSerie = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(indexSerie);

            Console.WriteLine(serie);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
