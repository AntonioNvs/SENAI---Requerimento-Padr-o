using System;
using SENAI___Requerimento_padrão.CODE.Modulos.Clientes.DTO;
using SENAI___Requerimento_padrão.CODE.Infra.DAL;
using System.Windows.Forms;
using System.Data;

namespace SENAI___Requerimento_padrão.CODE.Modulos.Clientes.BLL
{
    class TelefoneBLL
    {
        AcessoBancoDados bd;

        public void Inserir(TelefoneDTO dto)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();

                string comando = "INSERT INTO TELEFONE(id_cliente, numero_telefone, whatsapp, categoria_telefone) " +
                    "values ('" + dto.IdCliente + "', '" + dto.NumeroTelefone+ "', '" + dto.Whatsapp+ "', " +
                    "'" + dto.CategoriaTelefone + "')";

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

        public void Excluir(TelefoneDTO dto)
        {
            bd = new AcessoBancoDados();
            bd.Conectar();
            string comando = "DELETE FROM TELEFONE " +
                "where id_telefone = '" + dto.IdTelefone + "'";
            bd.ExecutarComandoSQL(comando);
        }

        public DataTable SelecionaTodasCategorias()
        {
            DataTable dt = new DataTable();

            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                dt = bd.RetDataTable("Select * from TELEFONE");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar Selecionar todos os telefones: " + ex);
            }

            return dt;
        }
    }
}
