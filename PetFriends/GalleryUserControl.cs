using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetFriends
{
    public partial class GalleryUserControl : UserControl
    {
        public GalleryUserControl()
        {
            InitializeComponent();
        }
        private Image _icons1,_icons2,_icons3,_icons4;
        public Image Icons1
        {
            get { return _icons1; }
            set { _icons1 = value; GallPic1.Image = value; }
        }
        public Image Icons2
        {
            get { return _icons2; }
            set { _icons2 = value; GallPic2.Image = value; }
        }
        public Image Icons3
        {
            get { return _icons3; }
            set { _icons3 = value; GallPic3.Image = value; }
        }
        public Image Icons4
        {
            get { return _icons4; }
            set { _icons4 = value; GallPic4.Image = value; }
        }
        private void GalleryUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
