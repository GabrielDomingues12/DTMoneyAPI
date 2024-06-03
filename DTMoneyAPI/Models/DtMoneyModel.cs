namespace DTMoneyAPI.Models
{
    public enum TipoMovimentacao
    {
        Entrada = 0,
        Saida = 1,
    }

    public class DtMoneyModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
        public TipoMovimentacao Tipo { get; set; }
    }
}
