using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SENAI___Requerimento_padrão.CODE.DTO;
using SENAI___Requerimento_padrão.CODE.DAL;
using System.Windows.Forms;
using System.Data;

namespace SENAI___Requerimento_padrão.CODE.BLL
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

        public DataTable SelecionaTodasCategorias()
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
    }
}
