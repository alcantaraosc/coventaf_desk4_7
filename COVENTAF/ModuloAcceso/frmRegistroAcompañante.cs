using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.ModuloAcceso
{
    public partial class frmRegistroAcompañante : Form
    {
        public Cs_Bitacora_Visita bitacoraVisita;

        private ServiceCliente serviceCliente = new ServiceCliente();

        public frmRegistroAcompañante()
        {
            InitializeComponent();
        }

        private void frmRegistroAcompañante_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            var listAcompañante = new List<Cs_Acompanante>();

            try
            {
                for (var index = 0; index < this.DgvRegistoAcompañante.RowCount - 1; index++)
                {
                    var _datAcompañante = new Cs_Acompanante()
                    {

                        Visita = index,
                        Cedula = this.DgvRegistoAcompañante.Rows[index].Cells["Cedula"].Value.ToString(),
                        Nombre_Visitar = this.DgvRegistoAcompañante.Rows[index].Cells["Nombre"].Value.ToString(),
                        Observacion = this.DgvRegistoAcompañante.Rows[index].Cells["Comentario"].Value.ToString()
                    };
                    //_datAcompañante.Visita = index;
                    //_datAcompañante.Cedula = this.DgvRegistoAcompañante.Rows[index].Cells["Cedula"].Value.ToString(),
                   


                    listAcompañante.Add(_datAcompañante);                    
                }

                ResponseModel responseModel = new ResponseModel();
                var _dataService = new ServiceCliente();

                responseModel = await  _dataService.GuardarRegistroVisita(bitacoraVisita, listAcompañante, responseModel);

                if (responseModel.Exito == 1)
                {
                    MessageBox.Show(responseModel.Mensaje, "Sistema COVENTAF");                                     
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }
    }
}
