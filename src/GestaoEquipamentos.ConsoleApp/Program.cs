namespace Controle_De_Equipamentos.ConsoleApp
{
    internal class Program
    {
        static Equipamento[] equipamentos = new Equipamento[100];
        private static int contadorEquipamentosCadastrados = 0;

        static void Main(string[] args)
        {
            equipamentos[contadorEquipamentosCadastrados++] = new("Fritadeira", 1300, "1", DateTime.Now, "Acer");

            bool opcaoSairEscolhida = false;
            while (!opcaoSairEscolhida)
            {
                Console.Clear();

                Console.WriteLine("===================================");
                Console.WriteLine("    Gestão De Equipamentos");
                Console.WriteLine("===================================");

                Console.WriteLine();

                Console.WriteLine("1. Controle de Equipamentos");
                Console.WriteLine("2. Controle de Chamados");
                Console.WriteLine("5. Sair");

                Console.WriteLine();

                Console.WriteLine("===================================");

                Console.WriteLine();

                Console.Write("Escolha uma opção: ");
                char escolhaMenu = Console.ReadLine()[0];

                switch (escolhaMenu)
                {
                    case '1': MenuEquipamentos(); break;

                    //case '2': MenuChamados(); break;

                    default: opcaoSairEscolhida = true; break;
                }

            }
        }
        private static void MenuEquipamentos()
        {
            Console.Clear();

            Console.WriteLine("===================================");
            Console.WriteLine("    Controle De Equipamentos");
            Console.WriteLine("===================================");

            Console.WriteLine();

            Console.WriteLine("1. Cadastrar Equipamentos");
            Console.WriteLine("2. Visualizar Equipamento");
            Console.WriteLine("3. Editar Equipamento");
            Console.WriteLine("4. Remover Equipamento");
            Console.WriteLine("5. Sair");

            Console.WriteLine();

            Console.WriteLine("===================================");

            Console.WriteLine();

            Console.Write("Escolha uma opção: ");
            char escolha = Console.ReadLine()[0];

            switch (escolha)
            {
                case '1':
                    CadastrarEquipamento();
                    break;

                case '2':
                    VisualizarEquipamento(true);
                    break;

                case '3':
                    EditarEquipamento();
                    break;

                case '4':
                    RemoverEquipamento();
                    break;

                default: break;
            }

            static void CadastrarEquipamento()
            {
                Console.Clear();

                Console.WriteLine("===================================");
                Console.WriteLine("    Controle De Equipamentos");
                Console.WriteLine("===================================");

                Console.WriteLine();

                Console.WriteLine("Digite o Nome do Equipamento:");
                string nome = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Digite o preço de aquisição do Equipamento:");
                decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Digite o número de série do Equipamento:");
                string numeroSerie = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Digite a data de fabricação do Equipamento (dd - MM - aaaa):");
                DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Digite o Fabricante do Equipamento:");
                string fabricante = Console.ReadLine();
                Console.WriteLine();

                Equipamento novoEquipamento = new(nome, precoAquisicao, numeroSerie, dataFabricacao, fabricante);

                equipamentos[contadorEquipamentosCadastrados++] = novoEquipamento;

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine();

                Console.WriteLine("O equipamento foi cadastrado com sucesso!");

                Console.ResetColor();

                Console.ReadLine();

            }
        }

        private static void VisualizarEquipamento(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();

                Console.WriteLine("===================================");
                Console.WriteLine("    Controle De Equipamentos");
                Console.WriteLine("===================================");

                Console.WriteLine();

                Console.WriteLine("Visualizando equipamentos...");
            }

            Console.WriteLine();

            Console.WriteLine("{0, -10} | {1, -15} | {2, -10} | {3, -15} | {4, -15}",
                "ID", "Nome", "Preço", "Fabricante", "Data");


            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;

                Console.WriteLine("{0, -10} | {1, -15} | {2, -10} | {3, -15} | {4, -15}",
                    e.Id, e.Nome, e.PrecoAquisicao, e.Fabricante, e.DataFabricacao.ToShortDateString());
            }

            Console.ReadLine();
        }

        private static void EditarEquipamento()
        {
            VisualizarEquipamento(false);

            Console.Write("Digite o ID do equipamento a ser editado: ");
            int equipamentoSelecionado = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoEncontrado = SelecionarEquipamentoPorId(equipamentoSelecionado);

            Console.WriteLine();

            Console.Write("Digite o Nome do Equipamento: ");
            equipamentoEncontrado.Nome = Console.ReadLine();

            Console.Write("Digite o preço de aquisição do Equipamento: ");
            equipamentoEncontrado.PrecoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite o número de série do Equipamento: ");
            equipamentoEncontrado.NumeroSerie = Console.ReadLine();

            Console.Write("Digite a data de fabricação do Equipamento (dd - MM - aaaa): ");

            equipamentoEncontrado.DataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite o Fabricante do Equipamento: ");
            equipamentoEncontrado.Fabricante = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();

            Console.WriteLine("O equipamento foi Editado com sucesso!");

            Console.ResetColor();

            Console.ReadLine();
        }

        public static Equipamento SelecionarEquipamentoPorId(int idSelecionado)
        {
            for (int i = 0; i < equipamentos.Length; ++i)
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;

                if (e.Id == idSelecionado)
                    return e;
            }
            return null;
        }

        private static void RemoverEquipamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Equipamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Excluindo Equipamento...");

            Console.WriteLine();

            VisualizarEquipamento(false);

            Console.Write("Digite o ID do equipamento a ser excluido: ");
            int equipamentoSelecionado = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoEncontrado = SelecionarEquipamentoPorId(equipamentoSelecionado);

            for (int i = 0; i < equipamentos.Length; ++i)
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;

                else if (equipamentos[i].Id == equipamentoSelecionado)
                {
                    equipamentos[i] = null;
                    return;
                }
            }
        }
    }
}
