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

        public void Inserir(CategoriaClienteDTO dto)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();

                string comando = "INSERT INTO CATEGORIA_CLIENTE(categoria_cliente) " +
                    "values ('" + dto.CategoriaCliente + "')";

                bd.ExecutarComandoSQL(comando);
                
            } catch (Exception ex){
                MessageBox.Show("Erro ao tentar inserir: " + ex);
            }
            finally
            {
                bd = null;
            }
        }

        public void Excluir(CategoriaClienteDTO dto)
        {
            bd = new AcessoBancoDados();
            bd.Conectar();
            string comando = "DELETE FROM CATEGORIA_CLIENTE " +
                "where id_categoria_cliente = '" + dto.IdCategoriaCliente +"'";
            bd.ExecutarComandoSQL(comando);
        }

        public void Alterar(CategoriaClienteDTO dto)
        {
            bd = new AcessoBancoDados();
            bd.Conectar();

            string comando = "UPDATE CATEGORIA_CLIENTE set " +
                "categoria_cliente = '" + dto.CategoriaCliente + "'" +
                "where id_categoria_cliente = '" + dto.CategoriaCliente + "'";

            bd.ExecutarComandoSQL(comando);
        }

        public DataTable SelecionarTodos()
        {
            DataTable dt = new DataTable();

            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                dt = bd.RetDataTable("Select * from CATEGORIA_CLIENTE");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar Selecionar todos os clientes: " + ex);
            }

            return dt;
        }

        public DataTable SelecionarComCondicao(string condicao)
        {
            DataTable dt = new DataTable();

            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                dt = bd.RetDataTable("Select * from CATEGORA_CLIENTE where " + condicao);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }

            return dt;
        }
    }
}
