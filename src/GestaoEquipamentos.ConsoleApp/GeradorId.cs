namespace Controle_De_Equipamentos.ConsoleApp
{
    internal class GeradorId
    {
        private static int IdEquipamentos = 0;

        public static int GerarIdEquipamento()
        {
            return ++IdEquipamentos;
        }
    }
}
