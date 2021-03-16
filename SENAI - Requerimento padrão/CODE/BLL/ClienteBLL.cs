using System;
using System.Data;
using System.Windows.Forms;
using SENAI___Requerimento_padrão.CODE.DTO;
using SENAI___Requerimento_padrão.CODE.DAL;

namespace SENAI___Requerimento_padrão.CODE.BLL
{
    class ClienteBLL
    {
        AcessoBancoDados bd;

		public void Inserir(ClienteDTO dto)
		{
			try
			{
				bd = new AcessoBancoDados();
				bd.Conectar();

				string nome = this.TrocarAspas(dto.NomeCompleto);
				string nome_social = this.TrocarAspas(dto.NomeSocial);

				string comando = "" +
					"INSERT INTO CLIENTE (id_categoria_cliente, url_foto_usuario, nome_completo, matricula, nome_social, cpf, rg, orgao_emissor, email, situacao) " +
					"values ('" + dto.IdCategoria +"','" + dto.Url + "','" + nome + "','" + dto.Matricula + "','" + nome_social + "','" + dto.Cpf + "','" + dto.Rg + "','" + dto.OrgaoEmissor + "','" + dto.Email + "','" + dto.Situacao + "')";
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

		public void Excluir(ClienteDTO dto)
		{
			bd = new AcessoBancoDados();
			bd.Conectar();
			string comando = "DELETE FROM CLIENTE where id_cliente = '" + dto.IdCliente + "'";
			bd.ExecutarComandoSQL(comando);
		}

		public void Alterar(ClienteDTO dto)
		{
			bd = new AcessoBancoDados();
			bd.Conectar();

			string nome = this.TrocarAspas(dto.NomeCompleto);
			string nome_social = this.TrocarAspas(dto.NomeSocial);

			string comando =
				"UPDATE CLIENTE set " +
				"id_categoria_cliente = '" + dto.IdCategoria + "'," +
				" url_foto_usuario = '" + dto.Url + "'," +
				" nome_completo = '" + nome + "'," +
				" matricula = '" + dto.Matricula + "'," +
				" nome_social = '" + nome_social + "'," +
				" cpf = '" + dto.Cpf + "'," +
				" rg = '" + dto.Rg + "'," +
				" orgao_emissor = '" + dto.OrgaoEmissor + "'," +
				" email = '" + dto.Email +
				"' where id = '" + dto.IdCliente + "'";

			bd.ExecutarComandoSQL(comando);
		}

		//using System.Data
		public DataTable SelecionaTodosClientes()
		{
			DataTable dt = new DataTable();

			try
			{
				bd = new AcessoBancoDados();
				bd.Conectar();
				dt = bd.RetDataTable("Select * from CLIENTE");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro ao tentar Selecionar todos os clientes: " + ex);
			}

			return dt;
		}

		public string TrocarAspas(string txt)
		{
			string novoTxt = txt.Replace("'", "''");
			return novoTxt;
		}

	}
}
