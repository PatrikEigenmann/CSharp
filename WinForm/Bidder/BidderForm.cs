namespace Bidder;

public partial class BidderForm : Form
{
    NicheListForm nicheListForm = null;
    
    public BidderForm()
    {
        InitializeComponent();
    }

    private void NicheClick(object sender, EventArgs e)
    {
        if (nicheListForm == null)
        {
            nicheListForm = new NicheListForm();
        }

        nicheListForm.Visible = true;

    }
}
