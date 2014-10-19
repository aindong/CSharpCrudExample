using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using CSharpCRUDExample.Models;

namespace CSharpCRUDExample.App
{
    public partial class frm_groups : Form
    {
        List<Group> groups = new List<Group>();

        public frm_groups()
        {
            InitializeComponent();
        }

        private void populateListview()
        {
            Group group = new Group();

            groups.Clear();
            groups = group.Retrieve();

            lstGroup.Items.Clear();
            foreach (Group item in groups)
            {
                lstGroup.Items.Add(item.id.ToString());
                lstGroup.Items[lstGroup.Items.Count - 1].SubItems.Add(item.group_name);
            }
        }

        private void frm_groups_Load(object sender, EventArgs e)
        {
            populateListview();
        }


    }
}
