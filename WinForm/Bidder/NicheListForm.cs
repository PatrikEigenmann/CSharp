using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Bidder
{
    public partial class NicheListForm : Form
    {
        private DataGridView nicheDataGridView;
        private Button newButton;
        private Button editButton;

        public NicheListForm()
        {
            InitializeComponent();
            LoadNicheData();
        }

        private void LoadNicheData()
        {
            // Simulating data load with FetchAll
            var niches = Niche.FetchAll(); // Assuming the Niche.FetchAll() method is implemented
            this.nicheDataGridView.DataSource = niches;
        }
    }

}
