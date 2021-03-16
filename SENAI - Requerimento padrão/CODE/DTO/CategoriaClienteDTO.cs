namespace SENAI___Requerimento_padrão.CODE.DTO
{
    class CategoriaClienteDTO
    {
        private int id_categoria_cliente;
        private string categoria_cliente;

        public int IdCategoriaCliente { get => id_categoria_cliente; set => id_categoria_cliente = value; }
        public string CategoriaCliente { get => categoria_cliente; set => categoria_cliente = value; }
    }
}
