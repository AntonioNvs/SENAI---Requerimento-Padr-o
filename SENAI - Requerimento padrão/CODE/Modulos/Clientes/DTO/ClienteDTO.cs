namespace SENAI___Requerimento_padrão.CODE.Modulos.Clientes.DTO
{
    class ClienteDTO
    {
        private int id_cliente;
        private int id_categoria_cliente;
        private string url_foto_usuario;
        private string nome_completo;
        private string matricula;
        private string nome_social;
        private string cpf;
        private string rg;
        private string orgao_emissor;
        private string email;
        private string situacao;

        public int IdCliente { get => id_cliente; set => id_cliente = value; }
        public int IdCategoria { get => id_categoria_cliente; set => id_categoria_cliente = value; }
        public string Url { get => url_foto_usuario; set => url_foto_usuario = value; }
        public string NomeCompleto { get => nome_completo; set => nome_completo = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public string NomeSocial { get => nome_social; set => nome_social = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Rg { get => rg; set => rg = value; }
        public string OrgaoEmissor { get => orgao_emissor; set => orgao_emissor = value; }
        public string Email { get => email; set => email = value; }
        public string Situacao { get => situacao; set => situacao = value; }
    }
}
