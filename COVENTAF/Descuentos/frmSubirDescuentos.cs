using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVENTAF.Descuentos
{
    public partial class frmSubirDescuentos : Form
    {

        //Un DataSet es un objeto que almacena n número de DataTables, estas tablas puedes estar conectadas dentro del dataset.
        private DataSet dtsTablas = new DataSet();


        public frmSubirDescuentos()
        {
            InitializeComponent();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                cboHojas.Items.Clear();
                dgvDescuentoArticulos.GridControl.DataSource = null;

                txtRuta.Text = oOpenFileDialog.FileName;

                //FileStream nos permite leer, escribir, abrir y cerrar archivos en un sistema de archivos, como matrices de bytes
                FileStream fsSource = new FileStream(oOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);

                //ExcelReaderFactory.CreateBinaryReader = formato XLS
                //ExcelReaderFactory.CreateOpenXmlReader = formato XLSX
                //ExcelReaderFactory.CreateReader = XLS o XLSX
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource);

                //convierte todas las hojas a un DataSet
                dtsTablas = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    cboHojas.Items.Add(tabla.TableName);
                }
                cboHojas.SelectedIndex = 0;

                reader.Close();

                SubirGridArticulosConDescuentos();
            }
        }

        private void SubirGridArticulosConDescuentos()
        {
            dgvDescuentoArticulos.GridControl.DataSource = dtsTablas.Tables[cboHojas.SelectedIndex];

        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
