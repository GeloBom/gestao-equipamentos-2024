
namespace Controle_De_Equipamentos.ConsoleApp
{
    internal class Equipamento
    {
        public int Id;
        public string Nome;
        public decimal PrecoAquisicao;
        public string NumeroSerie;
        public DateTime DataFabricacao;
        public string Fabricante;

        public Equipamento(string nome, decimal precoAquisicao, string numeroSerie, DateTime dataFabricacao, string fabricante)
        {
            Id = GeradorId.GerarIdEquipamento();
            Nome = nome;
            PrecoAquisicao = precoAquisicao;
            NumeroSerie = numeroSerie;
            DataFabricacao = dataFabricacao;
            Fabricante = fabricante;
        }
    }
}