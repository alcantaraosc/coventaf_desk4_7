using System;
using System.Windows.Forms;

namespace COVENTAF.Security
{
    public partial class frmRoles : Form
    {
        public frmRoles()
        {
            InitializeComponent();
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {

        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            //var roles = new Roles()
            //{
            //    NombreRol = txtNombreRol.Text,
            //    Descripcion = txtDescripcionRol.Text,
            //    Activo = this.chkActivo.Checked,
            //    Monto = Convert.ToDecimal( this.txtMonto.Text)
            //};
            //var responseModel = new ResponseModel();


            //if (MessageBox.Show("¿ Estas seguro de guardar ?", "Sistema COVENTAF", MessageBoxButtons.YesNo)== DialogResult.Yes)
            //{
            //    var result = await new ServiceRoles().InsertOrUpdateRoles(roles, responseModel);               
            //}

            //var conexion = new Conexion()
            //{
            //    Cajero = "OSCAR",
            //    Caja = "CJG3",
            //    Conexiones = 1,
            //    NoteExistsFlag=0,
            //    RecordDate = DateTime.Now,
            //    CreateDate =DateTime.Now,
            //    CreatedBy="oscar",
            //    UpdatedBy="oscar",
            //    RowPointer = Guid.NewGuid()

            //};
            //var responseModel = new ResponseModel();


            //if (MessageBox.Show("¿ Estas seguro de guardar ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    var result = await new ServiceRoles().InsertOrUpdateConexion(conexion, responseModel);
            //}

            //var denominacion = new Denominacion()
            //{
            //    Tipo = "C",
            //    Denom_Monto = 14.2534M,                
            //    NoteExistsFlag = 0,
            //    RecordDate = DateTime.Now,
            //    CreateDate = DateTime.Now,
            //    CreatedBy = "oscar",
            //    UpdatedBy = "oscar",
            //    RowPointer = Guid.NewGuid()

            //};
            //var responseModel = new ResponseModel();


            //if (MessageBox.Show("¿ Estas seguro de guardar ?", "Sistema COVENTAF", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    var result = await new ServiceRoles().InsertOrUpdateDenominacion(denominacion, responseModel);
            //}
        }
    }
}
