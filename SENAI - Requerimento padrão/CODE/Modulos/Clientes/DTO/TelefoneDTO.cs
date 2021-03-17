namespace SENAI___Requerimento_padrão.CODE.Modulos.Clientes.DTO
{
    class TelefoneDTO
    {
        private int id_telefone;
        private int id_cliente;
        private string numero_telefone;
        private bool whatsapp;
        private string categoria_telefone;

        public int IdTelefone { get => id_telefone; set => id_telefone = value; }
        public int IdCliente { get => id_cliente; set => id_cliente = value; }
        public string NumeroTelefone { get => numero_telefone; set => numero_telefone = value; }
        public bool Whatsapp { get => whatsapp; set => whatsapp = value; }
        public string CategoriaTelefone { get => categoria_telefone; set => categoria_telefone = value; }
    }
}
