using System;
using System.Data;
using System.Windows.Forms;

using SENAI___Requerimento_padrão.CODE.Modulos.Clientes.DTO;
using SENAI___Requerimento_padrão.CODE.Infra.DAL;

namespace SENAI___Requerimento_padrão.CODE.Modulos.Clientes.BLL
{
    class EnderecoBLL
    {
        AcessoBancoDados bd;
        public void Inserir(EnderecoDTO enderecoDTO)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();

                // Verificando se o campo está preenchido
                if (enderecoDTO.IdCliente == 0 || enderecoDTO.Logradouro == "" ||
                    enderecoDTO.Numero == "" || enderecoDTO.Cep == "" ||
                    enderecoDTO.Bairro == "" || enderecoDTO.Cidade == "" || 
                    enderecoDTO.Uf == "" || enderecoDTO.CategoriaEndereco == "")
                {
                    MessageBox.Show("Falta campos a serem preenchidos!");
                    return;
                }

                string comando = "INSERT INTO ENDERECO (id_cliente, logradouro, numero, cep, bairro, complemento, cidade, uf, categoria_endereco) " +
                    "values ('" + enderecoDTO.IdCliente + "', " +
                    "'" + enderecoDTO.Logradouro + "', " +
                    "'" + enderecoDTO.Numero + "', " +
                    "'" + enderecoDTO.Cep + "', " +
                    "'" + enderecoDTO.Bairro + "', " +
                    "'" + enderecoDTO.Complemento + "', " +
                    "'" + enderecoDTO.Cidade + "', " +
                    "'" + enderecoDTO.Uf + "', " +
                    "'" + enderecoDTO.CategoriaEndereco + "', " + 
                ")";

                bd.ExecutarComandoSQL(comando);
            }
            catch (Exception excecao)
            {
                MessageBox.Show("Erro ao tentar inserir: " + excecao);
            }
            finally
            {
                bd = null;
            }
        }

        public void Excluir(EnderecoDTO enderecoDTO)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                string comando = "DELETE FROM ENDERECO where id_endereco = '" + enderecoDTO.IdEndereco + "'";
                bd.ExecutarComandoSQL(comando);
            }
            catch (Exception excecao)
            {
                MessageBox.Show("Erro ao tentar Excluir: " + excecao.ToString());
            }
            finally
            {
                bd = null;
            }

        }

        public void Alterar(EnderecoDTO enderecoDTO)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();

                // Verificando se o campo está preenchido
                if (enderecoDTO.IdCliente == 0 || enderecoDTO.Logradouro == "" ||
                    enderecoDTO.Numero == "" || enderecoDTO.Cep == "" ||
                    enderecoDTO.Bairro == "" || enderecoDTO.Cidade == "" ||
                    enderecoDTO.Uf == "" || enderecoDTO.CategoriaEndereco == "")
                {
                    MessageBox.Show("Falta campos a serem preenchidos!");
                    return;
                }

                string comando = "UPDATE ENDERECO set " +
                    "id_cliente = '" + enderecoDTO.IdCliente + "', " +
                    "logradouro = '" + enderecoDTO.Logradouro + "', " +
                    "numero = '" + enderecoDTO.Numero + "', " +
                    "cep = '" + enderecoDTO.Cep + "', " +
                    "bairro = '" + enderecoDTO.Bairro + "', " +
                    "complemento = '" + enderecoDTO.Complemento + "', " +
                    "cidade = '" + enderecoDTO.Cidade+ "', " +
                    "uf = '" + enderecoDTO.Uf + "'" +
                    "categoria_endereco = '" + enderecoDTO.CategoriaEndereco+ "', " +
                    "where id_endereco = '" + enderecoDTO.IdEndereco + "'";

                bd.ExecutarComandoSQL(comando);
            }
            catch (Exception excecao)
            {
                MessageBox.Show("Erro ao alterar: " + excecao.ToString());
            }
            finally
            {
                bd = null;
            }

        }

        public DataTable SelecionarTodos()
        {
            DataTable dataTable = new DataTable();

            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                dataTable = bd.RetDataTable("Select * from ENDERECO");
            }
            catch (Exception excecao)
            {
                MessageBox.Show("Erro ao tentar Selecionar todos os endereços: " + excecao);
            }
            finally
            {
                bd = null;
            }

            return dataTable;
        }

        public DataTable SelecionarComCondicao(string condicao)
        {
            DataTable dataTable = new DataTable();

            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                dataTable = bd.RetDataTable("Select * from ENDERECO where " + condicao);
            }
            catch (Exception excecao)
            {
                MessageBox.Show("Erro ao selecionar com condição: " + excecao.ToString());
            }

            return dataTable;
        }
    }
}
