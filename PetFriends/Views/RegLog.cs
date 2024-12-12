using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using PetFriends.Controllers;


namespace PetFriends
{
    public partial class RegLog : Form
    {
        private UsuarioController loginController;

        public RegLog()
        {
            InitializeComponent();
            loginController = new UsuarioController(this);
        }


        private void RegLog_Load(object sender, EventArgs e)
        {
            loginController.InitializeForm();
        }


    }

}