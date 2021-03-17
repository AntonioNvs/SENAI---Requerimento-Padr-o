using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SENAI___Requerimento_padrão.CODE.Modulos.Clientes.DTO;
using SENAI___Requerimento_padrão.CODE.Modulos.Clientes.BLL;

namespace SENAI___Requerimento_padrão
{
    public partial class Inicio : Form
    {
        ClienteBLL bll = new ClienteBLL();
        ClienteDTO dto = new ClienteDTO();
        CategoriaClienteBLL bllCategoria = new CategoriaClienteBLL();
        List<CategoriaClienteDTO> listaCategorias = new List<CategoriaClienteDTO>();

        public Inicio()

        {
            InitializeComponent();
        }

        private void carregarElementos(object sender, EventArgs e)
        {
            carregarGrid();

            carregarSelecaoDeCategoria();

            //personalizarGrid();
        }

        public void carregarSelecaoDeCategoria()
        {
            DataTable dt = bllCategoria.SelecionaTodasCategorias();
            listaCategorias.Clear();
            boxCategoria.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string categoria = row["categoria_cliente"].ToString();
                boxCategoria.Items.Add(categoria);

                CategoriaClienteDTO cat = new CategoriaClienteDTO();
                cat.IdCategoriaCliente = Int32.Parse(row["id_categoria_cliente"].ToString());
                listaCategorias.Add(cat);
            }
        }

        private void personalizarGrid()
        {
            // Coluna Exc e Att
            DataGridViewImageColumn exc = new DataGridViewImageColumn();
            DataGridViewImageColumn att = new DataGridViewImageColumn();

            exc.HeaderText = "Excluir";
            exc.Name = "editar";

            att.HeaderText = "Editar";
            att.Name = "editar";

            // att.ce = Image.FromFile("C:\\Users\\tonim\\Desktop\\SENAI - Requerimento Padrão\\icone-salvar.png");
            gridClientes.Columns.Add(exc);
            gridClientes.Columns.Add(att);
            gridClientes.Columns["editar"].DisplayIndex = 0;
            gridClientes.Columns["excluir"].DisplayIndex = 1;
            gridClientes.Columns["id_cliente"].DisplayIndex = 2;
            gridClientes.Columns["nome_completo"].DisplayIndex = 3;
            gridClientes.Columns["cpf"].DisplayIndex = 4;
        }

        private void inserir(object sender, EventArgs e)
        {
            dto.Url = "https://www.oversodoinverso.com.br/wp-content/uploads/2020/01/4.jpg";
            dto.NomeCompleto = txtNomeCompleto.Text;
            dto.Matricula = txtMatricula.Text;
            dto.NomeSocial = txtNomeSocial.Text;
            dto.Cpf = txtCpf.Text;
            dto.Rg = txtRg.Text;
            dto.OrgaoEmissor = txtOrgaoEmissor.Text;
            dto.Email = txtEmail.Text;
            dto.Situacao = "Ativo";

            if (dto.Url == "" || dto.NomeCompleto == "" || dto.Matricula == "" ||
                dto.Cpf == "" || dto.Rg == "" || dto.OrgaoEmissor == "" || 
                dto.Email == "" || dto.Situacao == "" || dto.IdCategoria == null)
            {
                MessageBox.Show("Falta campos a serem preenchidos");
            }

            bll.Inserir(dto);
            limpar();
            carregarGrid();
        }

        public void limpar()
        {
            txtNomeCompleto.Text = "";
            txtMatricula.Text = "";
            txtNomeSocial.Text = "";
            txtCpf.Text = "";
            txtRg.Text = "";
            txtOrgaoEmissor.Text = "";
            txtEmail.Text = "";
        }

        private void carregarGrid()
        {
            gridClientes.DataSource = bll.SelecionaTodosClientes();
        }

        private void carregarTelaNovaCategoria(object sender, EventArgs e)
        {
            NovaCategoria telaCategoria = new NovaCategoria(this);
            telaCategoria.Show();
        }

        private void selecionandoCategoria(object sender, EventArgs e)
        {
            int index = boxCategoria.SelectedIndex;
            dto.IdCategoria = listaCategorias[index].IdCategoriaCliente;
        }

        private void excluirCliente(object sender, EventArgs e)
        {
            DataGridViewRow linhaAtual = gridClientes.CurrentRow;

            int indice = linhaAtual.Index;
            dto.IdCliente = Int32.Parse(gridClientes.Rows[indice].Cells[0].Value.ToString());

            bll.Excluir(dto);

            carregarGrid();
        }
    }
}
