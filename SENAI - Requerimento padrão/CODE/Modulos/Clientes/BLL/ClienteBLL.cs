using System;
using System.Data;
using System.Windows.Forms;
using SENAI___Requerimento_padrão.CODE.Modulos.Clientes.DTO;
using SENAI___Requerimento_padrão.CODE.Infra.DAL;

namespace SENAI___Requerimento_padrão.CODE.Modulos.Clientes.BLL
{
	class ClienteBLL
    {
        AcessoBancoDados bd;

		public void Inserir(ClienteDTO clienteDTO)
		{
			try
			{
				bd = new AcessoBancoDados();
				bd.Conectar();
				
				// Verificando se os dados não estão vazios
				if(clienteDTO.IdCategoria == 0 || clienteDTO.NomeCompleto == "" ||
					clienteDTO.Matricula == "" || clienteDTO.Cpf == "" ||
					clienteDTO.Rg == "" || clienteDTO.OrgaoEmissor == "" ||
					clienteDTO.Email == "" || clienteDTO.Situacao == "")
                {
					MessageBox.Show("Falta campos a serem preenchidos!");
					return;
                }

				// Se houver aspas, coloque mais uma para evitar possíveis erros no banco
				string nome = this.TrocarAspas(clienteDTO.NomeCompleto);
				string nome_social = this.TrocarAspas(clienteDTO.NomeSocial);

				string comando = "" +
					"INSERT INTO CLIENTE (id_categoria_cliente, url_foto_usuario, nome_completo, matricula, nome_social, cpf, rg, orgao_emissor, email, situacao) " +
					"values ('" + clienteDTO.IdCategoria +"'," +
					"'" + clienteDTO.Url + "','" + nome + "'," +
					"'" + clienteDTO.Matricula + "'," +
					"'" + nome_social + "'," +
					"'" + clienteDTO.Cpf + "'," +
					"'" + clienteDTO.Rg + "'," +
					"'" + clienteDTO.OrgaoEmissor + "'," +
					"'" + clienteDTO.Email + "'," +
					"'" + clienteDTO.Situacao + "')";
				
				bd.ExecutarComandoSQL(comando);
			}
			catch (Exception excecao)
			{
				MessageBox.Show("Erro ao tentar inserir: " + excecao.ToString());
			}
			finally
			{
				bd = null;
			}
		}

		public void Excluir(ClienteDTO clienteDTO)
		{
			try
			{
				bd = new AcessoBancoDados();
				bd.Conectar();
				string comando = "DELETE FROM CLIENTE where id_cliente = '" + clienteDTO.IdCliente + "'";
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

		public void Alterar(ClienteDTO clienteDTO)
		{
			try
            {
				bd = new AcessoBancoDados();
				bd.Conectar();

				// Verificando se os dados não estão vazios
				if (clienteDTO.IdCategoria == 0 || clienteDTO.NomeCompleto == "" ||
					clienteDTO.Matricula == "" || clienteDTO.Cpf == "" ||
					clienteDTO.Rg == "" || clienteDTO.OrgaoEmissor == "" ||
					clienteDTO.Email == "" || clienteDTO.Situacao == "")
				{
					MessageBox.Show("Falta campos a serem preenchidos!");
					return;
				}

				// Se houver aspas, coloque mais uma para evitar possíveis erros no banco
				string nome = this.TrocarAspas(clienteDTO.NomeCompleto);
				string nome_social = this.TrocarAspas(clienteDTO.NomeSocial);

				string comando =
					"UPDATE CLIENTE set " +
					"id_categoria_cliente = '" + clienteDTO.IdCategoria + "'," +
					" url_foto_usuario = '" + clienteDTO.Url + "'," +
					" nome_completo = '" + nome + "'," +
					" matricula = '" + clienteDTO.Matricula + "'," +
					" nome_social = '" + nome_social + "'," +
					" cpf = '" + clienteDTO.Cpf + "'," +
					" rg = '" + clienteDTO.Rg + "'," +
					" orgao_emissor = '" + clienteDTO.OrgaoEmissor + "'," +
					" email = '" + clienteDTO.Email +
					"' where id = '" + clienteDTO.IdCliente + "'";

				bd.ExecutarComandoSQL(comando);
			} catch(Exception excecao)
            {
				MessageBox.Show("Erro ao alterar: " + excecao);
            } finally
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
				dataTable = bd.RetDataTable("Select * from CLIENTE");
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
				dataTable = bd.RetDataTable("Select * from CLIENTE where " + condicao);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro ao listar com condição" + ex.ToString());
			}
			finally
            {
				bd = null;
            }

			return dataTable;
		}

		public string TrocarAspas(string txt)
		{
			return txt.Replace("'", "''");
		}

	}
}
