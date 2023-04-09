using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVENTAF.Services
{
    internal class GlobalVar
    {
        public static string ResultDialog;
        
        public static void MessageBox_Show(string Titulo, string Menseaje, bool YesOrNo)
        {
            frmMessageBox frm = new frmMessageBox();
            frm.lblTitle.Text= Titulo;
        }
    }
}
