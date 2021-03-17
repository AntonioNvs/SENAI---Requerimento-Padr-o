using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

using SENAI___Requerimento_padrão.CODE.Modulos.Clientes.DTO;
using SENAI___Requerimento_padrão.CODE.Infra.DAL;

namespace SENAI___Requerimento_padrão.CODE.Modulos.Clientes.BLL
{
    class EnderecoBLL
    {
        AcessoBancoDados bd;
        public void Inserir(EnderecoDTO dto)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();

                string comando = "INSERT INTO ENDERECO(id_cliente, logradouro, numero, cep, bairro, complemento, cidade, uf, categoria_endereco) " +
                    "values ('" + dto.IdCliente + "', '" + dto.Logradouro + "', '" + dto.Numero + "', " +
                    "'" + dto.Cep + "', '" + dto.Bairro + "', '" + dto.Complemento + "', '" + dto.Cidade + "', '" + dto.Uf + "', '" + dto.CategoriaEndereco + "')";

                bd.ExecutarComandoSQL(comando);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar inserir: " + ex);
            }
            finally
            {
                bd = null;
            }
        }

        public void Excluir(EnderecoDTO dto)
        {
            bd = new AcessoBancoDados();
            bd.Conectar();
            string comando = "DELETE FROM ENDERECO " +
                "where id_endereco = '" + dto.IdEndereco + "'";
            bd.ExecutarComandoSQL(comando);
        }

        public DataTable SelecionaTodasCategorias()
        {
            DataTable dt = new DataTable();

            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                dt = bd.RetDataTable("Select * from ENDERECO");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar Selecionar todos os telefones: " + ex);
            }

            return dt;
        }
    }
}
