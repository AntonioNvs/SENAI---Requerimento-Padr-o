using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI___Requerimento_padrão.CODE.Modulos.Clientes.DTO
{
    class EnderecoDTO
    {
        private int id_endereco;
        private int id_cliente;
        private string logradouro;
        private string numero;
        private string cep;
        private string bairro;
        private string complemento;
        private string cidade;
        private string uf;
        private string categoria_endereco;

        public int IdEndereco { get => id_endereco; set => id_endereco = value; }
        public int IdCliente { get => id_cliente; set => id_cliente = value; }
        public string Logradouro { get => logradouro; set => logradouro = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Complemento { get => complemento; set => complemento = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Uf { get => uf; set => uf = value; }
        public string CategoriaEndereco { get => categoria_endereco; set => categoria_endereco = value; }
    }
}
