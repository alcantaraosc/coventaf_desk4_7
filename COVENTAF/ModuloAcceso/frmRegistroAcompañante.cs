using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.DataService;
using COVENTAF.Metodos;
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
        string Transition;

        public Cs_Bitacora_Visita bitacoraVisita;
        public bool result = false;

        private ServiceCliente serviceCliente = new ServiceCliente();

        public frmRegistroAcompañante()
        {
            InitializeComponent();
        }

        private void frmRegistroAcompañante_Load(object sender, EventArgs e)
        {
            Transition = "FadeIn";
            tmTransition.Start();
            this.Top = this.Top + 15;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCerrar_Click(null, null);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //this.Close();
            this.tmTransition.Start();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            var listAcompañante = new List<Cs_Acompanante>();

            try
            {

                if (ValidacionAcompañanteEsCorrecto())
                {
                    for (var index = 0; index < this.DgvRegistoAcompañante.RowCount - 1; index++)
                    {
                                                
                        var _datAcompañante = new Cs_Acompanante()
                        {
                            Visita = index,
                            Cedula = this.DgvRegistoAcompañante.Rows[index].Cells["Cedula"].Value.ToString(),
                            Nombre_Visitar = this.DgvRegistoAcompañante.Rows[index].Cells["Nombre"].Value.ToString(),
                            //comprobar si el comentario esta null entonces asignarle un vacio
                            Observacion =  this.DgvRegistoAcompañante.Rows[index].Cells["comentario"].Value == null ? "" : this.DgvRegistoAcompañante.Rows[index].Cells["Comentario"].Value.ToString()
                        };
                        //_datAcompañante.Visita = index;
                        //_datAcompañante.Cedula = this.DgvRegistoAcompañante.Rows[index].Cells["Cedula"].Value.ToString(),

                        listAcompañante.Add(_datAcompañante);
                    }

                    ResponseModel responseModel = new ResponseModel();
                    var _dataService = new ServiceCliente();

                    responseModel = await _dataService.GuardarRegistroVisita(bitacoraVisita, listAcompañante, responseModel);

                    if (responseModel.Exito == 1)
                    {
                        result = true;
                        btnCerrar_Click(null, null);

                    }
                }              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }


        private bool ValidacionAcompañanteEsCorrecto()
        {
            bool result = false;
            try
            {
                //verificar si existe registro en el datagridview
                if ((this.DgvRegistoAcompañante.RowCount - 1) > 0)
                {
                    for (var index = 0; index < this.DgvRegistoAcompañante.RowCount - 1; index++)
                    {
                        var x = this.DgvRegistoAcompañante.Rows[index].Cells["Nombre"].Value;


                        if (this.DgvRegistoAcompañante.Rows[index].Cells["Cedula"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Debes de registra el numero de identificacion del cliente", "Sistema COVENTAF");
                            break;
                        }
                        else if ( this.DgvRegistoAcompañante.Rows[index].Cells["Nombre"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Debes de registra el nombre del cliente", "Sistema COVENTAF");
                            break;
                        }                       
                        else
                        {
                            result = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debes de registra los datos del cliente", "Sistema COVENTAF");
                }
            }
            catch(Exception ex)
            {
                result = false;
                MessageBox.Show(ex.Message, "Sistema COVENTAF");
            }

            return result;
        }

        private void tmTransition_Tick(object sender, EventArgs e)
        {
            UtilidadesMain.tmTransition_Tick(ref Transition, this.tmTransition, this);
        }

      
    }
}
