using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Rooms
{
    public partial class frmShowRoomInfo : Form
    {
        private int _RoomID = -1;
        public frmShowRoomInfo(int roomID)
        {
            InitializeComponent();
            _RoomID = roomID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowRoomInfo_Load(object sender, EventArgs e)
        {
            ctrlRoomCardInfo1.LoadRoomInfoByID(_RoomID);
        }
    }
}
