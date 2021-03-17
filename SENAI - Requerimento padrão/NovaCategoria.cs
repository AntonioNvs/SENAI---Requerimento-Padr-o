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
    public partial class NovaCategoria : Form
    {
        CategoriaClienteBLL bll = new CategoriaClienteBLL();
        CategoriaClienteDTO dto = new CategoriaClienteDTO();
        Inicio telaInicio;

        public NovaCategoria(Inicio telaInicio)
        {
            InitializeComponent();
            this.telaInicio = telaInicio;
        }

        private void carregarElementos(object sender, EventArgs e)
        {
            carregarGrid();
        }

        private void carregarGrid()
        {
            gridCategorias.DataSource = bll.SelecionaTodasCategorias();
        }

        private void InserirCategoria(object sender, EventArgs e)
        {
            dto.CategoriaCliente = txtCategoria.Text;

            bll.Inserir(dto);

            carregarGrid();
        }

        private void excluirCategoria(object sender, EventArgs e)
        {
            DataGridViewRow linhaAtual = gridCategorias.CurrentRow;

            int indice = linhaAtual.Index;
            dto.IdCategoriaCliente = Int32.Parse(gridCategorias.Rows[indice].Cells[0].Value.ToString());

            bll.Excluir(dto);

            carregarGrid();
        }

        private void sairTela(object sender, EventArgs e)
        {
            this.telaInicio.carregarSelecaoDeCategoria();
            this.Close();
        }
    }
}
