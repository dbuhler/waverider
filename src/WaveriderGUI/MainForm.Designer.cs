namespace WaveriderGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemZoomFit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemZoomMax = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAudio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemPlayPause = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSamplingRate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDFT = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFFT = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemWindowRectangular = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemWindowTriangular = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemWindowHanning = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemWindowHamming = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.buttonNew = new System.Windows.Forms.ToolStripButton();
            this.buttonOpen = new System.Windows.Forms.ToolStripButton();
            this.buttonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonCut = new System.Windows.Forms.ToolStripButton();
            this.buttonCopy = new System.Windows.Forms.ToolStripButton();
            this.buttonPaste = new System.Windows.Forms.ToolStripButton();
            this.buttonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.buttonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.buttonZoomFit = new System.Windows.Forms.ToolStripButton();
            this.buttonZoomMax = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonRecord = new System.Windows.Forms.ToolStripButton();
            this.buttonPlayPause = new System.Windows.Forms.ToolStripSplitButton();
            this.buttonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonFourier = new System.Windows.Forms.ToolStripSplitButton();
            this.buttonDFT = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonFFT = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.labelResolution = new System.Windows.Forms.ToolStripLabel();
            this.textBoxResolution = new System.Windows.Forms.ToolStripTextBox();
            this.buttonWindow = new System.Windows.Forms.ToolStripDropDownButton();
            this.buttonWindowRectangular = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonWindowTriangular = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonWindowHanning = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonWindowHamming = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.timeDomain = new WaveriderGUI.Panels.TimeDomain();
            this.freqDomain = new WaveriderGUI.Panels.FreqDomain();
            this.labelLoading = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabelSignalInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelSelection = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.freqDomain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemEdit,
            this.menuItemView,
            this.menuItemAudio,
            this.menuItemTools});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNew,
            this.menuItemOpen,
            this.menuItemSave,
            this.menuItemSaveAs,
            this.menuStripSeparator1,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "&File";
            // 
            // menuItemNew
            // 
            this.menuItemNew.Image = global::WaveriderGUI.Properties.Resources.IconNew16;
            this.menuItemNew.Name = "menuItemNew";
            this.menuItemNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuItemNew.Size = new System.Drawing.Size(155, 22);
            this.menuItemNew.Text = "&New";
            this.menuItemNew.Click += new System.EventHandler(this.menuItemNew_Click);
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Image = global::WaveriderGUI.Properties.Resources.IconOpen16;
            this.menuItemOpen.Name = "menuItemOpen";
            this.menuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuItemOpen.Size = new System.Drawing.Size(155, 22);
            this.menuItemOpen.Text = "&Open...";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Enabled = false;
            this.menuItemSave.Image = global::WaveriderGUI.Properties.Resources.IconSave16;
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuItemSave.Size = new System.Drawing.Size(155, 22);
            this.menuItemSave.Text = "&Save";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // menuItemSaveAs
            // 
            this.menuItemSaveAs.Enabled = false;
            this.menuItemSaveAs.Name = "menuItemSaveAs";
            this.menuItemSaveAs.Size = new System.Drawing.Size(155, 22);
            this.menuItemSaveAs.Text = "Save &As...";
            this.menuItemSaveAs.Click += new System.EventHandler(this.menuItemSaveAs_Click);
            // 
            // menuStripSeparator1
            // 
            this.menuStripSeparator1.Name = "menuStripSeparator1";
            this.menuStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuItemExit.Size = new System.Drawing.Size(155, 22);
            this.menuItemExit.Text = "&Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCut,
            this.menuItemCopy,
            this.menuItemPaste,
            this.menuItemDelete});
            this.menuItemEdit.Name = "menuItemEdit";
            this.menuItemEdit.Size = new System.Drawing.Size(39, 20);
            this.menuItemEdit.Text = "&Edit";
            // 
            // menuItemCut
            // 
            this.menuItemCut.Enabled = false;
            this.menuItemCut.Image = global::WaveriderGUI.Properties.Resources.IconCut16;
            this.menuItemCut.Name = "menuItemCut";
            this.menuItemCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuItemCut.Size = new System.Drawing.Size(144, 22);
            this.menuItemCut.Text = "Cu&t";
            this.menuItemCut.Click += new System.EventHandler(this.menuItemCut_Click);
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Enabled = false;
            this.menuItemCopy.Image = global::WaveriderGUI.Properties.Resources.IconCopy16;
            this.menuItemCopy.Name = "menuItemCopy";
            this.menuItemCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuItemCopy.Size = new System.Drawing.Size(144, 22);
            this.menuItemCopy.Text = "&Copy";
            this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // menuItemPaste
            // 
            this.menuItemPaste.Enabled = false;
            this.menuItemPaste.Image = global::WaveriderGUI.Properties.Resources.IconPaste16;
            this.menuItemPaste.Name = "menuItemPaste";
            this.menuItemPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.menuItemPaste.Size = new System.Drawing.Size(144, 22);
            this.menuItemPaste.Text = "&Paste";
            this.menuItemPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Enabled = false;
            this.menuItemDelete.Image = global::WaveriderGUI.Properties.Resources.IconDelete16;
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuItemDelete.Size = new System.Drawing.Size(144, 22);
            this.menuItemDelete.Text = "&Delete";
            this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemZoomOut,
            this.menuItemZoomIn,
            this.menuItemZoomFit,
            this.menuItemZoomMax});
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new System.Drawing.Size(44, 20);
            this.menuItemView.Text = "&View";
            // 
            // menuItemZoomOut
            // 
            this.menuItemZoomOut.Enabled = false;
            this.menuItemZoomOut.Image = global::WaveriderGUI.Properties.Resources.IconZoonOut16;
            this.menuItemZoomOut.Name = "menuItemZoomOut";
            this.menuItemZoomOut.Size = new System.Drawing.Size(163, 22);
            this.menuItemZoomOut.Text = "Zoom &Out";
            this.menuItemZoomOut.Click += new System.EventHandler(this.menuItemZoomOut_Click);
            // 
            // menuItemZoomIn
            // 
            this.menuItemZoomIn.Enabled = false;
            this.menuItemZoomIn.Image = global::WaveriderGUI.Properties.Resources.IconZoomIn16;
            this.menuItemZoomIn.Name = "menuItemZoomIn";
            this.menuItemZoomIn.Size = new System.Drawing.Size(163, 22);
            this.menuItemZoomIn.Text = "Zoom &In";
            this.menuItemZoomIn.Click += new System.EventHandler(this.menuItemZoomIn_Click);
            // 
            // menuItemZoomFit
            // 
            this.menuItemZoomFit.Enabled = false;
            this.menuItemZoomFit.Image = global::WaveriderGUI.Properties.Resources.IconZoomFit16;
            this.menuItemZoomFit.Name = "menuItemZoomFit";
            this.menuItemZoomFit.Size = new System.Drawing.Size(163, 22);
            this.menuItemZoomFit.Text = "Zoom to &Fit";
            this.menuItemZoomFit.Click += new System.EventHandler(this.menuItemZoomFit_Click);
            // 
            // menuItemZoomMax
            // 
            this.menuItemZoomMax.Enabled = false;
            this.menuItemZoomMax.Image = global::WaveriderGUI.Properties.Resources.IconZoomMax16;
            this.menuItemZoomMax.Name = "menuItemZoomMax";
            this.menuItemZoomMax.Size = new System.Drawing.Size(163, 22);
            this.menuItemZoomMax.Text = "&Maximum Zoom";
            this.menuItemZoomMax.Click += new System.EventHandler(this.menuItemZoomMax_Click);
            // 
            // menuItemAudio
            // 
            this.menuItemAudio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRecord,
            this.menuStripSeparator2,
            this.menuItemPlayPause,
            this.menuItemStop,
            this.menuItemSamplingRate});
            this.menuItemAudio.Name = "menuItemAudio";
            this.menuItemAudio.Size = new System.Drawing.Size(51, 20);
            this.menuItemAudio.Text = "&Audio";
            // 
            // menuItemRecord
            // 
            this.menuItemRecord.Image = global::WaveriderGUI.Properties.Resources.IconRecord16;
            this.menuItemRecord.Name = "menuItemRecord";
            this.menuItemRecord.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.menuItemRecord.Size = new System.Drawing.Size(161, 22);
            this.menuItemRecord.Text = "&Record...";
            this.menuItemRecord.Click += new System.EventHandler(this.menuItemRecord_Click);
            // 
            // menuStripSeparator2
            // 
            this.menuStripSeparator2.Name = "menuStripSeparator2";
            this.menuStripSeparator2.Size = new System.Drawing.Size(158, 6);
            // 
            // menuItemPlayPause
            // 
            this.menuItemPlayPause.Enabled = false;
            this.menuItemPlayPause.Image = global::WaveriderGUI.Properties.Resources.IconPlay24;
            this.menuItemPlayPause.Name = "menuItemPlayPause";
            this.menuItemPlayPause.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menuItemPlayPause.Size = new System.Drawing.Size(161, 22);
            this.menuItemPlayPause.Text = "&Play";
            this.menuItemPlayPause.Click += new System.EventHandler(this.menuItemPlayPause_Click);
            // 
            // menuItemStop
            // 
            this.menuItemStop.Enabled = false;
            this.menuItemStop.Image = global::WaveriderGUI.Properties.Resources.IconStop24;
            this.menuItemStop.Name = "menuItemStop";
            this.menuItemStop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.menuItemStop.Size = new System.Drawing.Size(161, 22);
            this.menuItemStop.Text = "&Stop";
            this.menuItemStop.Click += new System.EventHandler(this.menuItemStop_Click);
            // 
            // menuItemSamplingRate
            // 
            this.menuItemSamplingRate.Enabled = false;
            this.menuItemSamplingRate.Name = "menuItemSamplingRate";
            this.menuItemSamplingRate.Size = new System.Drawing.Size(161, 22);
            this.menuItemSamplingRate.Text = "Sa&mpling Rate";
            this.menuItemSamplingRate.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuItemSamplingRate_DropDownItemClicked);
            // 
            // menuItemTools
            // 
            this.menuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDFT,
            this.menuItemFFT,
            this.menuItemFilter,
            this.menuStripSeparator3,
            this.menuItemWindow});
            this.menuItemTools.Name = "menuItemTools";
            this.menuItemTools.Size = new System.Drawing.Size(48, 20);
            this.menuItemTools.Text = "&Tools";
            // 
            // menuItemDFT
            // 
            this.menuItemDFT.Enabled = false;
            this.menuItemDFT.Name = "menuItemDFT";
            this.menuItemDFT.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.menuItemDFT.Size = new System.Drawing.Size(171, 22);
            this.menuItemDFT.Text = "Apply &DFT";
            // 
            // menuItemFFT
            // 
            this.menuItemFFT.Enabled = false;
            this.menuItemFFT.Name = "menuItemFFT";
            this.menuItemFFT.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.menuItemFFT.Size = new System.Drawing.Size(171, 22);
            this.menuItemFFT.Text = "Apply &FFT";
            // 
            // menuItemFilter
            // 
            this.menuItemFilter.Enabled = false;
            this.menuItemFilter.Name = "menuItemFilter";
            this.menuItemFilter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.menuItemFilter.Size = new System.Drawing.Size(171, 22);
            this.menuItemFilter.Text = "Apply F&ilter";
            // 
            // menuStripSeparator3
            // 
            this.menuStripSeparator3.Name = "menuStripSeparator3";
            this.menuStripSeparator3.Size = new System.Drawing.Size(168, 6);
            // 
            // menuItemWindow
            // 
            this.menuItemWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemWindowRectangular,
            this.menuItemWindowTriangular,
            this.menuItemWindowHanning,
            this.menuItemWindowHamming});
            this.menuItemWindow.Enabled = false;
            this.menuItemWindow.Name = "menuItemWindow";
            this.menuItemWindow.Size = new System.Drawing.Size(171, 22);
            this.menuItemWindow.Text = "&Windowing";
            this.menuItemWindow.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuItemWindow_DropDownItemClicked);
            // 
            // menuItemWindowRectangular
            // 
            this.menuItemWindowRectangular.Checked = true;
            this.menuItemWindowRectangular.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemWindowRectangular.Name = "menuItemWindowRectangular";
            this.menuItemWindowRectangular.Size = new System.Drawing.Size(137, 22);
            this.menuItemWindowRectangular.Tag = "0";
            this.menuItemWindowRectangular.Text = "&Rectangular";
            // 
            // menuItemWindowTriangular
            // 
            this.menuItemWindowTriangular.Name = "menuItemWindowTriangular";
            this.menuItemWindowTriangular.Size = new System.Drawing.Size(137, 22);
            this.menuItemWindowTriangular.Tag = "1";
            this.menuItemWindowTriangular.Text = "&Triangular";
            // 
            // menuItemWindowHanning
            // 
            this.menuItemWindowHanning.Name = "menuItemWindowHanning";
            this.menuItemWindowHanning.Size = new System.Drawing.Size(137, 22);
            this.menuItemWindowHanning.Tag = "2";
            this.menuItemWindowHanning.Text = "Ha&nning";
            // 
            // menuItemWindowHamming
            // 
            this.menuItemWindowHamming.Name = "menuItemWindowHamming";
            this.menuItemWindowHamming.Size = new System.Drawing.Size(137, 22);
            this.menuItemWindowHamming.Tag = "3";
            this.menuItemWindowHamming.Text = "Ha&mming";
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonNew,
            this.buttonOpen,
            this.buttonSave,
            this.toolStripSeparator1,
            this.buttonCut,
            this.buttonCopy,
            this.buttonPaste,
            this.buttonDelete,
            this.toolStripSeparator2,
            this.buttonZoomOut,
            this.buttonZoomIn,
            this.buttonZoomFit,
            this.buttonZoomMax,
            this.toolStripSeparator3,
            this.buttonRecord,
            this.buttonPlayPause,
            this.buttonStop,
            this.toolStripSeparator4,
            this.buttonFourier,
            this.buttonFilter,
            this.toolStripSeparator5,
            this.labelResolution,
            this.textBoxResolution,
            this.buttonWindow});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(784, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "Toolbar";
            // 
            // buttonNew
            // 
            this.buttonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonNew.Image = global::WaveriderGUI.Properties.Resources.IconNew16;
            this.buttonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(23, 22);
            this.buttonNew.Text = "New";
            this.buttonNew.Click += new System.EventHandler(this.menuItemNew_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonOpen.Image = global::WaveriderGUI.Properties.Resources.IconOpen16;
            this.buttonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(23, 22);
            this.buttonOpen.Text = "Open";
            this.buttonOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSave.Enabled = false;
            this.buttonSave.Image = global::WaveriderGUI.Properties.Resources.IconSave16;
            this.buttonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(23, 22);
            this.buttonSave.Text = "Save";
            this.buttonSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonCut
            // 
            this.buttonCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCut.Enabled = false;
            this.buttonCut.Image = global::WaveriderGUI.Properties.Resources.IconCut16;
            this.buttonCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCut.Name = "buttonCut";
            this.buttonCut.Size = new System.Drawing.Size(23, 22);
            this.buttonCut.Text = "Cut";
            this.buttonCut.Click += new System.EventHandler(this.menuItemCut_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCopy.Enabled = false;
            this.buttonCopy.Image = global::WaveriderGUI.Properties.Resources.IconCopy16;
            this.buttonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(23, 22);
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // buttonPaste
            // 
            this.buttonPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPaste.Enabled = false;
            this.buttonPaste.Image = global::WaveriderGUI.Properties.Resources.IconPaste16;
            this.buttonPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPaste.Name = "buttonPaste";
            this.buttonPaste.Size = new System.Drawing.Size(23, 22);
            this.buttonPaste.Text = "Paste";
            this.buttonPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Image = global::WaveriderGUI.Properties.Resources.IconDelete16;
            this.buttonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(23, 22);
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonZoomOut.Enabled = false;
            this.buttonZoomOut.Image = global::WaveriderGUI.Properties.Resources.IconZoonOut16;
            this.buttonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(23, 22);
            this.buttonZoomOut.Text = "Zoom Out";
            this.buttonZoomOut.Click += new System.EventHandler(this.menuItemZoomOut_Click);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonZoomIn.Enabled = false;
            this.buttonZoomIn.Image = global::WaveriderGUI.Properties.Resources.IconZoomIn16;
            this.buttonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(23, 22);
            this.buttonZoomIn.Text = "Zoom In";
            this.buttonZoomIn.Click += new System.EventHandler(this.menuItemZoomIn_Click);
            // 
            // buttonZoomFit
            // 
            this.buttonZoomFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonZoomFit.Enabled = false;
            this.buttonZoomFit.Image = global::WaveriderGUI.Properties.Resources.IconZoomFit16;
            this.buttonZoomFit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonZoomFit.Name = "buttonZoomFit";
            this.buttonZoomFit.Size = new System.Drawing.Size(23, 22);
            this.buttonZoomFit.Text = "Zoom to Fit";
            this.buttonZoomFit.Click += new System.EventHandler(this.menuItemZoomFit_Click);
            // 
            // buttonZoomMax
            // 
            this.buttonZoomMax.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonZoomMax.Enabled = false;
            this.buttonZoomMax.Image = global::WaveriderGUI.Properties.Resources.IconZoomMax16;
            this.buttonZoomMax.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonZoomMax.Name = "buttonZoomMax";
            this.buttonZoomMax.Size = new System.Drawing.Size(23, 22);
            this.buttonZoomMax.Text = "Maximum Zoom";
            this.buttonZoomMax.Click += new System.EventHandler(this.menuItemZoomMax_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonRecord
            // 
            this.buttonRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRecord.Image = global::WaveriderGUI.Properties.Resources.IconRecord16;
            this.buttonRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(23, 22);
            this.buttonRecord.Text = "Record";
            this.buttonRecord.Click += new System.EventHandler(this.menuItemRecord_Click);
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonPlayPause.Enabled = false;
            this.buttonPlayPause.Image = global::WaveriderGUI.Properties.Resources.IconPlay24;
            this.buttonPlayPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(32, 22);
            this.buttonPlayPause.Text = "Play";
            this.buttonPlayPause.ButtonClick += new System.EventHandler(this.menuItemPlayPause_Click);
            this.buttonPlayPause.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuItemSamplingRate_DropDownItemClicked);
            // 
            // buttonStop
            // 
            this.buttonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonStop.Enabled = false;
            this.buttonStop.Image = global::WaveriderGUI.Properties.Resources.IconStop24;
            this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(23, 22);
            this.buttonStop.Text = "Stop";
            this.buttonStop.Click += new System.EventHandler(this.menuItemStop_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonFourier
            // 
            this.buttonFourier.AutoSize = false;
            this.buttonFourier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonDFT,
            this.buttonFFT});
            this.buttonFourier.Enabled = false;
            this.buttonFourier.Image = global::WaveriderGUI.Properties.Resources.IconFourier16;
            this.buttonFourier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFourier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonFourier.Name = "buttonFourier";
            this.buttonFourier.Size = new System.Drawing.Size(110, 22);
            this.buttonFourier.Tag = "DFT";
            this.buttonFourier.Text = "Fourier (DFT)";
            this.buttonFourier.ButtonClick += new System.EventHandler(this.buttonFourier_ButtonClick);
            this.buttonFourier.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.buttonFourier_DropDownItemClicked);
            // 
            // buttonDFT
            // 
            this.buttonDFT.Name = "buttonDFT";
            this.buttonDFT.Size = new System.Drawing.Size(143, 22);
            this.buttonDFT.Tag = "DFT";
            this.buttonDFT.Text = "Fourier (DFT)";
            // 
            // buttonFFT
            // 
            this.buttonFFT.Name = "buttonFFT";
            this.buttonFFT.Size = new System.Drawing.Size(143, 22);
            this.buttonFFT.Tag = "FFT";
            this.buttonFFT.Text = "Fourier (FFT)";
            // 
            // buttonFilter
            // 
            this.buttonFilter.Enabled = false;
            this.buttonFilter.Image = global::WaveriderGUI.Properties.Resources.IconFilter16;
            this.buttonFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(53, 22);
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.Click += new System.EventHandler(this.menuItemFilter_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // labelResolution
            // 
            this.labelResolution.Enabled = false;
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(66, 22);
            this.labelResolution.Text = "Resolution:";
            // 
            // textBoxResolution
            // 
            this.textBoxResolution.Enabled = false;
            this.textBoxResolution.MaxLength = 5;
            this.textBoxResolution.Name = "textBoxResolution";
            this.textBoxResolution.Size = new System.Drawing.Size(40, 25);
            this.textBoxResolution.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxResolution.ToolTipText = "Resolution";
            this.textBoxResolution.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxResolution_KeyDown);
            // 
            // buttonWindow
            // 
            this.buttonWindow.AutoSize = false;
            this.buttonWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonWindowRectangular,
            this.buttonWindowTriangular,
            this.buttonWindowHanning,
            this.buttonWindowHamming});
            this.buttonWindow.Enabled = false;
            this.buttonWindow.Image = global::WaveriderGUI.Properties.Resources.IconWindow16;
            this.buttonWindow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonWindow.Name = "buttonWindow";
            this.buttonWindow.Size = new System.Drawing.Size(100, 22);
            this.buttonWindow.Tag = "";
            this.buttonWindow.Text = "Rectangular";
            this.buttonWindow.ToolTipText = "Windowing";
            this.buttonWindow.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuItemWindow_DropDownItemClicked);
            // 
            // buttonWindowRectangular
            // 
            this.buttonWindowRectangular.Checked = true;
            this.buttonWindowRectangular.CheckState = System.Windows.Forms.CheckState.Checked;
            this.buttonWindowRectangular.Name = "buttonWindowRectangular";
            this.buttonWindowRectangular.Size = new System.Drawing.Size(137, 22);
            this.buttonWindowRectangular.Tag = "0";
            this.buttonWindowRectangular.Text = "Rectangular";
            // 
            // buttonWindowTriangular
            // 
            this.buttonWindowTriangular.Name = "buttonWindowTriangular";
            this.buttonWindowTriangular.Size = new System.Drawing.Size(137, 22);
            this.buttonWindowTriangular.Tag = "1";
            this.buttonWindowTriangular.Text = "Triangular";
            // 
            // buttonWindowHanning
            // 
            this.buttonWindowHanning.Name = "buttonWindowHanning";
            this.buttonWindowHanning.Size = new System.Drawing.Size(137, 22);
            this.buttonWindowHanning.Tag = "2";
            this.buttonWindowHanning.Text = "Hanning";
            // 
            // buttonWindowHamming
            // 
            this.buttonWindowHamming.Name = "buttonWindowHamming";
            this.buttonWindowHamming.Size = new System.Drawing.Size(137, 22);
            this.buttonWindowHamming.Tag = "3";
            this.buttonWindowHamming.Text = "Hamming";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 49);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.timeDomain);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.freqDomain);
            this.splitContainer.Panel2MinSize = 100;
            this.splitContainer.Size = new System.Drawing.Size(784, 341);
            this.splitContainer.SplitterDistance = 216;
            this.splitContainer.SplitterWidth = 6;
            this.splitContainer.TabIndex = 2;
            this.splitContainer.TabStop = false;
            this.splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            // 
            // timeDomain
            // 
            this.timeDomain.BackColor = System.Drawing.Color.Black;
            this.timeDomain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeDomain.Location = new System.Drawing.Point(0, 0);
            this.timeDomain.Name = "timeDomain";
            this.timeDomain.Size = new System.Drawing.Size(784, 216);
            this.timeDomain.TabIndex = 0;
            this.timeDomain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTimeDomain_MouseDown);
            this.timeDomain.MouseLeave += new System.EventHandler(this.panelTimeDomain_MouseLeave);
            this.timeDomain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTimeDomain_MouseMove);
            // 
            // freqDomain
            // 
            this.freqDomain.AutoScroll = true;
            this.freqDomain.BackColor = System.Drawing.Color.Black;
            this.freqDomain.Controls.Add(this.labelLoading);
            this.freqDomain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.freqDomain.Frequencies = null;
            this.freqDomain.Location = new System.Drawing.Point(0, 0);
            this.freqDomain.Name = "freqDomain";
            this.freqDomain.Size = new System.Drawing.Size(784, 119);
            this.freqDomain.TabIndex = 0;
            this.freqDomain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.freqDomain_MouseDown);
            this.freqDomain.MouseLeave += new System.EventHandler(this.freqDomain_MouseLeave);
            this.freqDomain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.freqDomain_MouseMove);
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoading.ForeColor = System.Drawing.Color.White;
            this.labelLoading.Location = new System.Drawing.Point(12, 12);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(107, 26);
            this.labelLoading.TabIndex = 0;
            this.labelLoading.Text = "Loading...";
            this.labelLoading.Visible = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelSignalInfo,
            this.statusLabelNum,
            this.statusLabelValue,
            this.statusLabelSelection});
            this.statusStrip.Location = new System.Drawing.Point(0, 390);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabelSignalInfo
            // 
            this.statusLabelSignalInfo.Name = "statusLabelSignalInfo";
            this.statusLabelSignalInfo.Size = new System.Drawing.Size(299, 17);
            this.statusLabelSignalInfo.Spring = true;
            this.statusLabelSignalInfo.Text = "<signal info>";
            this.statusLabelSignalInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabelNum
            // 
            this.statusLabelNum.AutoSize = false;
            this.statusLabelNum.Name = "statusLabelNum";
            this.statusLabelNum.Size = new System.Drawing.Size(150, 17);
            this.statusLabelNum.Text = "<num>";
            this.statusLabelNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabelValue
            // 
            this.statusLabelValue.AutoSize = false;
            this.statusLabelValue.Name = "statusLabelValue";
            this.statusLabelValue.Size = new System.Drawing.Size(120, 17);
            this.statusLabelValue.Text = "<value>";
            this.statusLabelValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabelSelection
            // 
            this.statusLabelSelection.AutoSize = false;
            this.statusLabelSelection.Name = "statusLabelSelection";
            this.statusLabelSelection.Size = new System.Drawing.Size(200, 17);
            this.statusLabelSelection.Text = "<selection>";
            this.statusLabelSelection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 412);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "MainForm";
            this.Text = "<title>";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.freqDomain.ResumeLayout(false);
            this.freqDomain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemNew;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem menuItemSave;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem menuItemCut;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaste;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuItemTools;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton buttonNew;
        private System.Windows.Forms.ToolStripButton buttonOpen;
        private System.Windows.Forms.ToolStripButton buttonSave;
        private System.Windows.Forms.ToolStripButton buttonCut;
        private System.Windows.Forms.ToolStripButton buttonCopy;
        private System.Windows.Forms.ToolStripButton buttonPaste;
        private System.Windows.Forms.ToolStripSeparator menuStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton buttonStop;
        private System.Windows.Forms.ToolStripButton buttonRecord;
        private System.Windows.Forms.SplitContainer splitContainer;
        private WaveriderGUI.Panels.FreqDomain freqDomain;
        private System.Windows.Forms.ToolStripButton buttonZoomOut;
        private System.Windows.Forms.ToolStripButton buttonZoomIn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton buttonZoomFit;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemZoomOut;
        private System.Windows.Forms.ToolStripMenuItem menuItemZoomIn;
        private System.Windows.Forms.ToolStripMenuItem menuItemZoomFit;
        private WaveriderGUI.Panels.TimeDomain timeDomain;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelSignalInfo;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelNum;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelSelection;
        private System.Windows.Forms.ToolStripButton buttonZoomMax;
        private System.Windows.Forms.ToolStripMenuItem menuItemZoomMax;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox textBoxResolution;
        private System.Windows.Forms.ToolStripLabel labelResolution;
        private System.Windows.Forms.ToolStripMenuItem menuItemAudio;
        private System.Windows.Forms.ToolStripMenuItem menuItemRecord;
        private System.Windows.Forms.ToolStripMenuItem menuItemPlayPause;
        private System.Windows.Forms.ToolStripMenuItem menuItemStop;
        private System.Windows.Forms.ToolStripMenuItem menuItemSamplingRate;
        private System.Windows.Forms.ToolStripSeparator menuStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton buttonPlayPause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripDropDownButton buttonWindow;
        private System.Windows.Forms.ToolStripMenuItem buttonWindowRectangular;
        private System.Windows.Forms.ToolStripMenuItem buttonWindowTriangular;
        private System.Windows.Forms.ToolStripMenuItem buttonWindowHanning;
        private System.Windows.Forms.ToolStripMenuItem buttonWindowHamming;
        private System.Windows.Forms.ToolStripSplitButton buttonFourier;
        private System.Windows.Forms.ToolStripMenuItem buttonDFT;
        private System.Windows.Forms.ToolStripMenuItem buttonFFT;
        private System.Windows.Forms.ToolStripButton buttonFilter;
        private System.Windows.Forms.ToolStripMenuItem menuItemWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemWindowRectangular;
        private System.Windows.Forms.ToolStripMenuItem menuItemWindowTriangular;
        private System.Windows.Forms.ToolStripMenuItem menuItemWindowHanning;
        private System.Windows.Forms.ToolStripMenuItem menuItemWindowHamming;
        private System.Windows.Forms.ToolStripSeparator menuStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuItemDFT;
        private System.Windows.Forms.ToolStripMenuItem menuItemFFT;
        private System.Windows.Forms.ToolStripMenuItem menuItemFilter;
        private System.Windows.Forms.Label labelLoading;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelValue;
    }
}

