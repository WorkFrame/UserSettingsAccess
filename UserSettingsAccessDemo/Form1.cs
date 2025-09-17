using NetEti.FileTools;

namespace NetEti.DemoApplications
{
    /// <summary>
    /// Demo
    /// </summary>
    public partial class Form1 : Form
    {
        private UserSettingsAccess? _myConfReader;

        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string?[]? vals = _myConfReader?.GetStringValues("", null);
            if (vals != null)
            {
                foreach (string? val in vals)
                {
                    this.tbxResults.Text += (val + Environment.NewLine);
                }
            }
            //string? testEinstellung = _myConfReader?.GetStringValue("TestEinstellung", null);
            //this.tbxResults.Text += (testEinstellung + Environment.NewLine);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            string? documentPathName = null;

            // .Net 7.0
            string? appName = System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name;
            if (appName != null)
            {
                documentPathName = String.Format($"{appName}.dll.config.user");
                if (!File.Exists(documentPathName))
                {
                    documentPathName = String.Format($"{appName}.exe.config.user");
                }
            }

            // .Net Framework
            // xmlDocPath = "app.config.user";

            if (documentPathName != null)
            {
                try
                {
                    _myConfReader = new UserSettingsAccess(documentPathName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("XML-Kacke: " + ex.Message);
                    this.Close();
                }
            }
        }
    }
}
