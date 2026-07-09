using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;

namespace FluidtechSmartHub
{
    public partial class MainForm : Form
    {
        private string _baseDir;
        private string _dashboardsDir;
        private string _docsDir;
        
        private readonly List<AssetFile> _curatedAssets = new List<AssetFile>
        {
            // Interactive Dashboards
            new AssetFile { FileName = "fluidtech-rashni-v2-final.html", UserFriendlyName = "DAF Live Performance Dashboard (V2 Final)", Description = "Real-time process telemetry, skimmer cycles, chemical dosing, and compliance alerts.", Category = "Interactive Dashboards", IconChar = "📊" },
            new AssetFile { FileName = "daf-smart-lab-app.html", UserFriendlyName = "DAF Smart Lab & LIMS Application", Description = "Full LIMS portal for jar tests, inlet/outlet log entries, and automated compliance calculations.", Category = "Interactive Dashboards", IconChar = "🧪" },
            new AssetFile { FileName = "Fluidtech_Rashni_DAF_Smart_Toolkit_V2.html", UserFriendlyName = "DAF Process Control Smart Toolkit (V2)", Description = "Engineers' tool for A/S ratio calculations, PAC/PAM optimal dosing rates, and troubleshooting.", Category = "Interactive Dashboards", IconChar = "⚙️" },
            new AssetFile { FileName = "Fluidtech_Rashni_DAF_Smart_Dashboard.html", UserFriendlyName = "DAF Performance Summary Dashboard", Description = "Compact 24-hour summary of TSS, COD, turbidity, and oil/grease removal efficiency.", Category = "Interactive Dashboards", IconChar = "📈" },
            new AssetFile { FileName = "rashni-polyfiber-fluidtech-daf-dashboard.html", UserFriendlyName = "Rashni DAF System Overview", Description = "General layout, component overview, and operation guidelines.", Category = "Interactive Dashboards", IconChar = "🖥️" },

            // Resin Specifications & TDS
            new AssetFile { FileName = "AMBERLITE  IRC100 Na.pdf", UserFriendlyName = "AMBERLITE IRC100 Na TDS", Description = "Technical Data Sheet for Amberlite IRC100 Na high-capacity weak acid cation exchange resin.", Category = "Resin Technical Datasheets", IconChar = "📄" },
            new AssetFile { FileName = "BSR Cation Exchange Resin.pdf", UserFriendlyName = "BSR Cation Exchange Resin TDS", Description = "Technical specifications and operating parameters for BSR cation exchange media.", Category = "Resin Technical Datasheets", IconChar = "📄" },
            new AssetFile { FileName = "GC-120-Strong Acid Cation Exchange Resin-FTE.pdf", UserFriendlyName = "GC-120 Strong Acid Cation TDS", Description = "Premium strong acid cation exchange resin specifications from Fluidtech Engineering.", Category = "Resin Technical Datasheets", IconChar = "📄" },
            new AssetFile { FileName = "Global GA-120C TDS.pdf", UserFriendlyName = "Global GA-120C TDS", Description = "Technical specifications for Global GA-120C resin filtration media.", Category = "Resin Technical Datasheets", IconChar = "📄" },
            new AssetFile { FileName = "RPFIL-14-Bag-Resin-Media-July-26.pdf", UserFriendlyName = "RPFIL-14 Resin Media Catalog (PDF)", Description = "Official product offering and pricing details for RPFIL-14 Bag Resin Media.", Category = "Resin Technical Datasheets", IconChar = "📕" },
            new AssetFile { FileName = "RPFIL-14-Bag-Resin-Media-July-26.docx", UserFriendlyName = "RPFIL-14 Resin Technical Spec (Word)", Description = "Editable Microsoft Word specification file for RPFIL-14 media.", Category = "Resin Technical Datasheets", IconChar = "📝" },
            new AssetFile { FileName = "RPFIL-14-Bag-Resin-Media-July-26.xlsx", UserFriendlyName = "RPFIL-14 Resin Pricing & Quantity (Excel)", Description = "Pricing matrix and quantity calculations for RPFIL-14 Bag Resin Media.", Category = "Resin Technical Datasheets", IconChar = "💚" },

            // Log Sheets & Commercial Bills
            new AssetFile { FileName = "Branded_Smart_Log_Sheet_Rashni_Fluidtech.xlsx", UserFriendlyName = "Branded Smart Log Sheet (Fluidtech)", Description = "Official branded operational log sheet for daily parameter logging.", Category = "Log Sheets & Bills", IconChar = "🟢" },
            new AssetFile { FileName = "DAF_Smart_Log_Sheet.xlsx", UserFriendlyName = "DAF Smart Log Sheet Template", Description = "IoT-enabled smart log sheet with validation for flow rate, pH, and dosing.", Category = "Log Sheets & Bills", IconChar = "📊" },
            new AssetFile { FileName = "Smart_Log_Sheet_25m3h_DAF_Polyfiber.xlsx", UserFriendlyName = "25m3/h DAF System Log Sheet", Description = "Dedicated log sheet tailored for 25m3/h DAF operations at Rashni Polyfiber.", Category = "Log Sheets & Bills", IconChar = "📈" },
            new AssetFile { FileName = "Test_Kit_Instrument_List_Dhaka_Sourcing.xlsx", UserFriendlyName = "Test Kit & Instrument Inventory", Description = "Required lab instruments, chemical reagents, and calibration equipment details.", Category = "Log Sheets & Bills", IconChar = "🧪" },
            new AssetFile { FileName = "Rashni DAF-MGF-ACF-Media- Bill.xlsx", UserFriendlyName = "Media Procurement Bill (Excel)", Description = "Commercial billing and details for DAF, MGF, and ACF filtration media.", Category = "Log Sheets & Bills", IconChar = "💰" },
            new AssetFile { FileName = "Rashni-DAF-Media-Challan.xlsx", UserFriendlyName = "Media Delivery Challan (Excel)", Description = "Delivery challan for media consignment sent to Gazipur plant.", Category = "Log Sheets & Bills", IconChar = "🚚" },
            new AssetFile { FileName = "Fluidtech_Official_Profile_and_References.xlsx", UserFriendlyName = "Fluidtech Engineering Corporate Profile", Description = "Company profile, credentials, reference projects, and commercial references.", Category = "Log Sheets & Bills", IconChar = "🏢" },

            // Guides & SOPs
            new AssetFile { FileName = "DAF_Lab_Setup_Guide_and_SOP.docx", UserFriendlyName = "DAF Lab Setup Guide & SOP (Word)", Description = "Comprehensive standard operating procedure (SOP) for lab setup, jar tests, and chemical preparation.", Category = "Guides & SOPs", IconChar = "📖" }
        };

        private AssetFile _selectedAsset;

        public MainForm()
        {
            InitializeComponent();
            LocateDirectories();
            this.Load += MainForm_Load;
        }

        private void LocateDirectories()
        {
            // 1. Check if running in deployed folder structure
            _baseDir = AppDomain.CurrentDomain.BaseDirectory;
            _dashboardsDir = Path.Combine(_baseDir, "Dashboards");
            _docsDir = Path.Combine(_baseDir, "Docs");

            // 2. Fallback to development/workspace folder structure if not found
            if (!Directory.Exists(_dashboardsDir) || !Directory.Exists(_docsDir))
            {
                // Traverse up to find workspace folders
                string tempDir = _baseDir;
                bool found = false;
                for (int i = 0; i < 5; i++)
                {
                    if (string.IsNullOrEmpty(tempDir)) break;
                    string searchPath = Path.Combine(tempDir, "Rashni Lab Setup & Resin");
                    string searchResin = Path.Combine(tempDir, "Resin Offer-07-26");

                    if (Directory.Exists(searchPath) && Directory.Exists(searchResin))
                    {
                        // We found the source folders!
                        // In development, we can point directly to them
                        _dashboardsDir = searchPath;
                        _docsDir = tempDir; // Point base docs dir to the root or subfolders
                        found = true;
                        break;
                    }
                    tempDir = Path.GetDirectoryName(tempDir);
                }

                if (!found)
                {
                    // If still not found, create empty placeholders relative to exe
                    _dashboardsDir = Path.Combine(_baseDir, "Dashboards");
                    _docsDir = Path.Combine(_baseDir, "Docs");
                    Directory.CreateDirectory(_dashboardsDir);
                    Directory.CreateDirectory(_docsDir);
                }
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            PopulateTreeView();
            await InitializeWebViewAsync();
            
            // Auto-select the first dashboard
            if (assetTreeView.Nodes.Count > 0 && assetTreeView.Nodes[0].Nodes.Count > 0)
            {
                assetTreeView.SelectedNode = assetTreeView.Nodes[0].Nodes[0];
            }
        }

        private async Task InitializeWebViewAsync()
        {
            try
            {
                statusLabel.Text = "Initializing WebView2 Chromium Engine...";
                await webView.EnsureCoreWebView2Async(null);
                
                // Map http://dashboards.local/ to the local dashboards directory
                // This eliminates file:// scheme security limitations (CORS/React issues)
                webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                    "dashboards.local",
                    _dashboardsDir,
                    CoreWebView2HostResourceAccessKind.Allow
                );
                
                statusLabel.Text = "Ready";
            }
            catch (Exception ex)
            {
                statusLabel.Text = "WebView2 Initialization Failed!";
                MessageBox.Show($"Could not initialize WebView2: {ex.Message}\nMake sure WebView2 runtime is installed on your computer.", 
                    "WebView2 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateTreeView()
        {
            assetTreeView.BeginUpdate();
            assetTreeView.Nodes.Clear();

            // Group curated assets by Category
            var grouped = new Dictionary<string, List<AssetFile>>();
            foreach (var asset in _curatedAssets)
            {
                if (!grouped.ContainsKey(asset.Category))
                {
                    grouped[asset.Category] = new List<AssetFile>();
                }
                grouped[asset.Category].Add(asset);
            }

            foreach (var category in grouped.Keys)
            {
                TreeNode catNode = new TreeNode(category)
                {
                    ForeColor = Color.FromArgb(0, 180, 171), // Teal color for category header
                    NodeFont = new Font("Segoe UI", 10.5f, FontStyle.Bold)
                };

                foreach (var asset in grouped[category])
                {
                    // Find actual file path
                    string path = ResolveFilePath(asset);
                    if (path != null)
                    {
                        TreeNode assetNode = new TreeNode($"{asset.IconChar} {asset.UserFriendlyName}")
                        {
                            Tag = asset,
                            ForeColor = Color.White,
                            NodeFont = new Font("Segoe UI", 10f, FontStyle.Regular)
                        };
                        catNode.Nodes.Add(assetNode);
                    }
                }

                if (catNode.Nodes.Count > 0)
                {
                    assetTreeView.Nodes.Add(catNode);
                    catNode.Expand();
                }
            }

            assetTreeView.EndUpdate();
        }

        private string ResolveFilePath(AssetFile asset)
        {
            // Search order:
            // 1. Executable-relative subfolders (Dashboards/ or Docs/)
            // 2. Source workspace folder hierarchies

            string filename = asset.FileName;
            
            // Check direct subfolder relative to executable
            string p1 = Path.Combine(_dashboardsDir, filename);
            if (File.Exists(p1)) return p1;

            string p2 = Path.Combine(_docsDir, filename);
            if (File.Exists(p2)) return p2;

            // Search within secondary document folder
            string p3 = Path.Combine(_docsDir, "Docs", filename);
            if (File.Exists(p3)) return p3;

            // Check workspace directories
            // Since we know the directories of interest:
            // "Rashni Lab Setup & Resin" (source)
            // "Resin Offer-07-26" (source)
            // Search inside double nested directory or main directories
            string w1 = Path.Combine(_baseDir, "..", "..", "..", "Rashni Lab Setup & Resin", filename);
            if (File.Exists(w1)) return w1;
            
            string w2 = Path.Combine(_baseDir, "..", "..", "..", "Resin Offer-07-26", filename);
            if (File.Exists(w2)) return w2;

            // Deep search helper for search directories in the base path (like in development mode)
            string rootSearch = Path.Combine(_baseDir, "..");
            for (int i = 0; i < 5; i++)
            {
                if (!Directory.Exists(rootSearch)) break;
                
                string[] files = Directory.GetFiles(rootSearch, filename, SearchOption.AllDirectories);
                if (files.Length > 0) return files[0];
                
                rootSearch = Path.GetDirectoryName(rootSearch);
            }

            return null;
        }

        private void assetTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null)
            {
                // Selected category node
                return;
            }

            var asset = e.Node.Tag as AssetFile;
            if (asset == null) return;

            _selectedAsset = asset;
            string actualPath = ResolveFilePath(asset);
            
            if (string.IsNullOrEmpty(actualPath))
            {
                MessageBox.Show($"File '{asset.FileName}' not found.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            statusLabel.Text = $"Opening: {asset.UserFriendlyName}";

            if (asset.FileName.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
            {
                // Load HTML Dashboard in WebView2
                previewPanel.Visible = false;
                webView.Visible = true;
                
                if (webView.CoreWebView2 != null)
                {
                    // Navigate via the virtual host to prevent security blocks
                    webView.CoreWebView2.Navigate("http://dashboards.local/" + Path.GetFileName(actualPath));
                }
                else
                {
                    webView.Source = new Uri(actualPath);
                }
            }
            else
            {
                // Document file (PDF, Excel, Word)
                webView.Visible = false;
                previewPanel.Visible = true;

                // Update preview details
                lblDocName.Text = asset.UserFriendlyName;
                lblDocDesc.Text = asset.Description;
                lblDocPath.Text = $"File location: {actualPath}";
                
                FileInfo fi = new FileInfo(actualPath);
                lblDocInfo.Text = $"Format: {fi.Extension.ToUpper().TrimStart('.')} Document | Size: {GetFileSizeString(fi.Length)} | Last Modified: {fi.LastWriteTime}";

                // Update preview panel icons
                string ext = fi.Extension.ToLower();
                if (ext == ".xlsx" || ext == ".xls")
                {
                    previewIconLabel.Text = "📊";
                    previewIconLabel.ForeColor = Color.ForestGreen;
                    btnOpenDoc.BackColor = Color.ForestGreen;
                }
                else if (ext == ".pdf")
                {
                    previewIconLabel.Text = "📕";
                    previewIconLabel.ForeColor = Color.Crimson;
                    btnOpenDoc.BackColor = Color.Crimson;
                }
                else if (ext == ".docx" || ext == ".doc")
                {
                    previewIconLabel.Text = "📖";
                    previewIconLabel.ForeColor = Color.DodgerBlue;
                    btnOpenDoc.BackColor = Color.DodgerBlue;
                }
                else
                {
                    previewIconLabel.Text = "📄";
                    previewIconLabel.ForeColor = Color.FromArgb(15, 44, 97);
                    btnOpenDoc.BackColor = Color.FromArgb(0, 180, 171);
                }
            }
        }

        private string GetFileSizeString(long bytes)
        {
            if (bytes >= 1024 * 1024)
                return $"{(double)bytes / (1024 * 1024):F2} MB";
            if (bytes >= 1024)
                return $"{(double)bytes / 1024:F2} KB";
            return $"{bytes} Bytes";
        }

        private void btnOpenDoc_Click(object sender, EventArgs e)
        {
            if (_selectedAsset == null) return;
            
            string path = ResolveFilePath(_selectedAsset);
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                MessageBox.Show("File could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var pInfo = new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                };
                Process.Start(pInfo);
                statusLabel.Text = $"Launched external viewer for: {_selectedAsset.UserFriendlyName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open document: {ex.Message}\nMake sure an application for this file type is installed.", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class AssetFile
    {
        public string FileName { get; set; }
        public string UserFriendlyName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string IconChar { get; set; }
    }
}
