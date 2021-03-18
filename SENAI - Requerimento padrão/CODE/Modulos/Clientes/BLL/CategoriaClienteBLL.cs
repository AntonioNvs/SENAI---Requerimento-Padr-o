using System;
using System.Windows.Forms;
using System.Data;
using SENAI___Requerimento_padrão.CODE.Modulos.Clientes.DTO;
using SENAI___Requerimento_padrão.CODE.Infra.DAL;

namespace SENAI___Requerimento_padrão.CODE.Modulos.Clientes.BLL
{
    class CategoriaClienteBLL
    {
        AcessoBancoDados bd;

        public void Inserir(CategoriaClienteDTO categoriaClienteDTO)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                   
                // Verificando se o campo está preenchido
                if(categoriaClienteDTO.CategoriaCliente == "")
                {
                    MessageBox.Show("O campo não foi preenchido!");
                    return;
                }

                // Retirando os espaços e transformando em minúscula, para comparações futuras
                categoriaClienteDTO.CategoriaCliente = categoriaClienteDTO.CategoriaCliente.Trim().ToLower();

                int jaExisteUmaCategoria = this.SelecionarComCondicao("categoria_cliente = '" + categoriaClienteDTO.CategoriaCliente + "'").Rows.Count;

                // Comparando se já existe uma categoria
                if(jaExisteUmaCategoria == 0)
                {
                    string comando = "INSERT INTO CATEGORIA_CLIENTE(categoria_cliente) " +
                    "values ('" + categoriaClienteDTO.CategoriaCliente + "')";

                    bd.ExecutarComandoSQL(comando);
                }
                else
                {
                    MessageBox.Show("Já existe a categoria com o mesmo nome");
                }
                
                
            } catch (Exception excecao){
                MessageBox.Show("Erro ao tentar inserir: " + excecao);
            }
            finally
            {
                bd = null;
            }
        }

        public void Excluir(CategoriaClienteDTO categoriaClienteDTO)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                string comando = "DELETE FROM CATEGORIA_CLIENTE where id_categoria_cliente = '" + categoriaClienteDTO.IdCategoriaCliente + "'";
                bd.ExecutarComandoSQL(comando);
            } catch (Exception excecao)
            {
                MessageBox.Show("Erro ao tentar Excluir: " + excecao.ToString());
            } finally
            {
                bd = null;
            }
            
        }

        public void Alterar(CategoriaClienteDTO categoriaClienteDTO)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();

                // Verificando se o campo está preenchido
                if (categoriaClienteDTO.CategoriaCliente == "")
                {
                    MessageBox.Show("O campo não foi preenchido!");
                    return;
                }

                // Retirando os espaços e transformando em minúscula, para comparações futuras
                categoriaClienteDTO.CategoriaCliente = categoriaClienteDTO.CategoriaCliente.Trim().ToLower();

                int jaExisteUmaCategoria = this.SelecionarComCondicao("categoria_cliente = '" + categoriaClienteDTO.CategoriaCliente + "'").Rows.Count;

                // Comparando se já existe uma categoria
                if (jaExisteUmaCategoria == 0)
                {
                    string comando = "UPDATE CATEGORIA_CLIENTE set " +
                       "categoria_cliente = '" + categoriaClienteDTO.CategoriaCliente + "'" +
                       "where id_categoria_cliente = '" + categoriaClienteDTO.CategoriaCliente + "'";

                    bd.ExecutarComandoSQL(comando);
                }
                else
                {
                    MessageBox.Show("Já existe a categoria com o mesmo nome");
                }
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
                dataTable = bd.RetDataTable("Select * from CATEGORIA_CLIENTE");
            }
            catch (Exception excecao)
            {
                MessageBox.Show("Erro ao tentar Selecionar todos os clientes: " + excecao);
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
                dataTable = bd.RetDataTable("Select * from CATEGORIA_CLIENTE where " + condicao);
            }
            catch (Exception excecao)
            {
                MessageBox.Show("Erro ao listar com condição: " + excecao.ToString());
            }

            return dataTable;
        }
    }
}
