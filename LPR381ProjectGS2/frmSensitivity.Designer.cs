namespace LPR381ProjectGS2.Presentation
{
    partial class frmSensitivity
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
            this.components = new System.ComponentModel.Container();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSolvePrimal = new System.Windows.Forms.Button();
            this.btnBuildDual = new System.Windows.Forms.Button();
            this.btnSolveDual = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.prog = new System.Windows.Forms.ProgressBar();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.Overview = new System.Windows.Forms.TabPage();
            this.grpDual = new System.Windows.Forms.GroupBox();
            this.lblDualObj = new System.Windows.Forms.Label();
            this.gridDualTableau = new System.Windows.Forms.DataGridView();
            this.lblDualityCheck = new System.Windows.Forms.Label();
            this.grpPrimal = new System.Windows.Forms.GroupBox();
            this.lblPrimalObj = new System.Windows.Forms.Label();
            this.lstPrimalIters = new System.Windows.Forms.ListBox();
            this.gridPrimalTableau = new System.Windows.Forms.DataGridView();
            this.ShadowPricesReducedCosts = new System.Windows.Forms.TabPage();
            this.gridReducedCosts = new System.Windows.Forms.DataGridView();
            this.variable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reducedCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridShadowPrices = new System.Windows.Forms.DataGridView();
            this.constraint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yvalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.units = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ranges = new System.Windows.Forms.TabPage();
            this.lblTolerance = new System.Windows.Forms.Label();
            this.grpRhsRanges = new System.Windows.Forms.GroupBox();
            this.gridRhsRanges = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowableIncrease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowableDecrease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numTolerance = new System.Windows.Forms.NumericUpDown();
            this.grpObjRanges = new System.Windows.Forms.GroupBox();
            this.gridObjRanges = new System.Windows.Forms.DataGridView();
            this.variableRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowDecrease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowIncrease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Report = new System.Windows.Forms.TabPage();
            this.btnCopyReport = new System.Windows.Forms.Button();
            this.txtReportPreview = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabMain.SuspendLayout();
            this.Overview.SuspendLayout();
            this.grpDual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDualTableau)).BeginInit();
            this.grpPrimal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrimalTableau)).BeginInit();
            this.ShadowPricesReducedCosts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReducedCosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShadowPrices)).BeginInit();
            this.Ranges.SuspendLayout();
            this.grpRhsRanges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRhsRanges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTolerance)).BeginInit();
            this.grpObjRanges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridObjRanges)).BeginInit();
            this.Report.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(152, 397);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 41);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open LP...";
            this.toolTip1.SetToolTip(this.btnOpen, "Load an LP text file.");
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSolvePrimal
            // 
            this.btnSolvePrimal.Location = new System.Drawing.Point(269, 397);
            this.btnSolvePrimal.Name = "btnSolvePrimal";
            this.btnSolvePrimal.Size = new System.Drawing.Size(100, 41);
            this.btnSolvePrimal.TabIndex = 1;
            this.btnSolvePrimal.Text = "Solve Primal";
            this.toolTip1.SetToolTip(this.btnSolvePrimal, "Solve the primal simplex (must be optimal before analysis).");
            this.btnSolvePrimal.UseVisualStyleBackColor = true;
            this.btnSolvePrimal.Click += new System.EventHandler(this.btnSolvePrimal_Click);
            // 
            // btnBuildDual
            // 
            this.btnBuildDual.Location = new System.Drawing.Point(386, 397);
            this.btnBuildDual.Name = "btnBuildDual";
            this.btnBuildDual.Size = new System.Drawing.Size(100, 41);
            this.btnBuildDual.TabIndex = 2;
            this.btnBuildDual.Text = "Build Dual";
            this.toolTip1.SetToolTip(this.btnBuildDual, "Construct Dual: Transpose A, swap inequality directions, set dual signs from prim" +
        "al.");
            this.btnBuildDual.UseVisualStyleBackColor = true;
            this.btnBuildDual.Click += new System.EventHandler(this.btnBuildDual_Click);
            // 
            // btnSolveDual
            // 
            this.btnSolveDual.Location = new System.Drawing.Point(507, 397);
            this.btnSolveDual.Name = "btnSolveDual";
            this.btnSolveDual.Size = new System.Drawing.Size(100, 41);
            this.btnSolveDual.TabIndex = 3;
            this.btnSolveDual.Text = "Solve Dual";
            this.toolTip1.SetToolTip(this.btnSolveDual, "Solve The Dual Simplex; Verify weak/strong duality.");
            this.btnSolveDual.UseVisualStyleBackColor = true;
            this.btnSolveDual.Click += new System.EventHandler(this.btnSolveDual_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Enabled = false;
            this.btnAnalyze.Location = new System.Drawing.Point(625, 397);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(100, 41);
            this.btnAnalyze.TabIndex = 4;
            this.btnAnalyze.Text = "Analyze Sensitivity ";
            this.toolTip1.SetToolTip(this.btnAnalyze, "Compute Shadow Prices, reduced costs, and allowable ranges from the final basis.");
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(744, 397);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 41);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export Report";
            this.toolTip1.SetToolTip(this.btnExport, "Export full sensitivity report to text.");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(57, 341);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status:";
            // 
            // prog
            // 
            this.prog.Location = new System.Drawing.Point(60, 357);
            this.prog.Name = "prog";
            this.prog.Size = new System.Drawing.Size(275, 23);
            this.prog.TabIndex = 7;
            // 
            // tabMain
            // 
            this.tabMain.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.tabMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabMain.Controls.Add(this.Overview);
            this.tabMain.Controls.Add(this.ShadowPricesReducedCosts);
            this.tabMain.Controls.Add(this.Ranges);
            this.tabMain.Controls.Add(this.Report);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(958, 379);
            this.tabMain.TabIndex = 8;
            // 
            // Overview
            // 
            this.Overview.Controls.Add(this.grpDual);
            this.Overview.Controls.Add(this.grpPrimal);
            this.Overview.Location = new System.Drawing.Point(4, 25);
            this.Overview.Name = "Overview";
            this.Overview.Padding = new System.Windows.Forms.Padding(3);
            this.Overview.Size = new System.Drawing.Size(950, 350);
            this.Overview.TabIndex = 0;
            this.Overview.Text = "Overview";
            this.Overview.UseVisualStyleBackColor = true;
            // 
            // grpDual
            // 
            this.grpDual.Controls.Add(this.lblDualObj);
            this.grpDual.Controls.Add(this.gridDualTableau);
            this.grpDual.Controls.Add(this.lblDualityCheck);
            this.grpDual.Location = new System.Drawing.Point(528, 43);
            this.grpDual.Name = "grpDual";
            this.grpDual.Size = new System.Drawing.Size(311, 237);
            this.grpDual.TabIndex = 4;
            this.grpDual.TabStop = false;
            this.grpDual.Text = "Dual Simplex";
            // 
            // lblDualObj
            // 
            this.lblDualObj.AutoSize = true;
            this.lblDualObj.Location = new System.Drawing.Point(20, 47);
            this.lblDualObj.Name = "lblDualObj";
            this.lblDualObj.Size = new System.Drawing.Size(66, 13);
            this.lblDualObj.TabIndex = 6;
            this.lblDualObj.Text = "w* (dual) = …";
            // 
            // gridDualTableau
            // 
            this.gridDualTableau.AllowUserToAddRows = false;
            this.gridDualTableau.AllowUserToDeleteRows = false;
            this.gridDualTableau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridDualTableau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDualTableau.Location = new System.Drawing.Point(23, 84);
            this.gridDualTableau.Name = "gridDualTableau";
            this.gridDualTableau.ReadOnly = true;
            this.gridDualTableau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDualTableau.Size = new System.Drawing.Size(268, 106);
            this.gridDualTableau.TabIndex = 5;
            // 
            // lblDualityCheck
            // 
            this.lblDualityCheck.AutoSize = true;
            this.lblDualityCheck.Location = new System.Drawing.Point(20, 60);
            this.lblDualityCheck.Name = "lblDualityCheck";
            this.lblDualityCheck.Size = new System.Drawing.Size(196, 13);
            this.lblDualityCheck.TabIndex = 4;
            this.lblDualityCheck.Text = "strong duality: passed/failed (|z*−w*|≤tol)";
            // 
            // grpPrimal
            // 
            this.grpPrimal.Controls.Add(this.lblPrimalObj);
            this.grpPrimal.Controls.Add(this.lstPrimalIters);
            this.grpPrimal.Controls.Add(this.gridPrimalTableau);
            this.grpPrimal.Location = new System.Drawing.Point(122, 43);
            this.grpPrimal.Name = "grpPrimal";
            this.grpPrimal.Size = new System.Drawing.Size(300, 237);
            this.grpPrimal.TabIndex = 0;
            this.grpPrimal.TabStop = false;
            this.grpPrimal.Text = "Primal Simplex";
            // 
            // lblPrimalObj
            // 
            this.lblPrimalObj.AutoSize = true;
            this.lblPrimalObj.Location = new System.Drawing.Point(22, 59);
            this.lblPrimalObj.Name = "lblPrimalObj";
            this.lblPrimalObj.Size = new System.Drawing.Size(70, 13);
            this.lblPrimalObj.TabIndex = 1;
            this.lblPrimalObj.Text = "z* (primal) = …";
            // 
            // lstPrimalIters
            // 
            this.lstPrimalIters.FormattingEnabled = true;
            this.lstPrimalIters.Location = new System.Drawing.Point(154, 19);
            this.lstPrimalIters.Name = "lstPrimalIters";
            this.lstPrimalIters.Size = new System.Drawing.Size(120, 95);
            this.lstPrimalIters.TabIndex = 2;
            this.lstPrimalIters.SelectedIndexChanged += new System.EventHandler(this.lstPrimalIters_SelectedIndexChanged);
            // 
            // gridPrimalTableau
            // 
            this.gridPrimalTableau.AllowUserToAddRows = false;
            this.gridPrimalTableau.AllowUserToDeleteRows = false;
            this.gridPrimalTableau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridPrimalTableau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPrimalTableau.Location = new System.Drawing.Point(15, 125);
            this.gridPrimalTableau.Name = "gridPrimalTableau";
            this.gridPrimalTableau.ReadOnly = true;
            this.gridPrimalTableau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPrimalTableau.Size = new System.Drawing.Size(268, 106);
            this.gridPrimalTableau.TabIndex = 0;
            this.gridPrimalTableau.SelectionChanged += new System.EventHandler(this.gridPrimalTableau_SelectionChanged);
            // 
            // ShadowPricesReducedCosts
            // 
            this.ShadowPricesReducedCosts.Controls.Add(this.gridReducedCosts);
            this.ShadowPricesReducedCosts.Controls.Add(this.gridShadowPrices);
            this.ShadowPricesReducedCosts.Location = new System.Drawing.Point(4, 25);
            this.ShadowPricesReducedCosts.Name = "ShadowPricesReducedCosts";
            this.ShadowPricesReducedCosts.Padding = new System.Windows.Forms.Padding(3);
            this.ShadowPricesReducedCosts.Size = new System.Drawing.Size(950, 350);
            this.ShadowPricesReducedCosts.TabIndex = 1;
            this.ShadowPricesReducedCosts.Text = "Shadow Prices & Reduced Costs";
            this.ShadowPricesReducedCosts.UseVisualStyleBackColor = true;
            // 
            // gridReducedCosts
            // 
            this.gridReducedCosts.AllowUserToAddRows = false;
            this.gridReducedCosts.AllowUserToDeleteRows = false;
            this.gridReducedCosts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridReducedCosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReducedCosts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.variable,
            this.reducedCost,
            this.basic});
            this.gridReducedCosts.Location = new System.Drawing.Point(535, 20);
            this.gridReducedCosts.Name = "gridReducedCosts";
            this.gridReducedCosts.ReadOnly = true;
            this.gridReducedCosts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridReducedCosts.Size = new System.Drawing.Size(346, 255);
            this.gridReducedCosts.TabIndex = 1;
            // 
            // variable
            // 
            this.variable.HeaderText = "Variable";
            this.variable.Name = "variable";
            this.variable.ReadOnly = true;
            this.variable.Width = 70;
            // 
            // reducedCost
            // 
            this.reducedCost.HeaderText = "Reduced Cost";
            this.reducedCost.Name = "reducedCost";
            this.reducedCost.ReadOnly = true;
            this.reducedCost.Width = 92;
            // 
            // basic
            // 
            this.basic.HeaderText = "Basic? Yes/No";
            this.basic.Name = "basic";
            this.basic.ReadOnly = true;
            this.basic.Width = 96;
            // 
            // gridShadowPrices
            // 
            this.gridShadowPrices.AllowUserToAddRows = false;
            this.gridShadowPrices.AllowUserToDeleteRows = false;
            this.gridShadowPrices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridShadowPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridShadowPrices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.constraint,
            this.yvalue,
            this.units});
            this.gridShadowPrices.Location = new System.Drawing.Point(91, 20);
            this.gridShadowPrices.Name = "gridShadowPrices";
            this.gridShadowPrices.ReadOnly = true;
            this.gridShadowPrices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridShadowPrices.Size = new System.Drawing.Size(349, 255);
            this.gridShadowPrices.TabIndex = 0;
            // 
            // constraint
            // 
            this.constraint.HeaderText = "Constraint";
            this.constraint.Name = "constraint";
            this.constraint.ReadOnly = true;
            this.constraint.Width = 79;
            // 
            // yvalue
            // 
            this.yvalue.HeaderText = "Y value (Shadow Price)";
            this.yvalue.Name = "yvalue";
            this.yvalue.ReadOnly = true;
            this.yvalue.Width = 106;
            // 
            // units
            // 
            this.units.HeaderText = "Units";
            this.units.Name = "units";
            this.units.ReadOnly = true;
            this.units.Width = 56;
            // 
            // Ranges
            // 
            this.Ranges.Controls.Add(this.lblTolerance);
            this.Ranges.Controls.Add(this.grpRhsRanges);
            this.Ranges.Controls.Add(this.numTolerance);
            this.Ranges.Controls.Add(this.grpObjRanges);
            this.Ranges.Location = new System.Drawing.Point(4, 25);
            this.Ranges.Name = "Ranges";
            this.Ranges.Size = new System.Drawing.Size(950, 350);
            this.Ranges.TabIndex = 2;
            this.Ranges.Text = "Allowable Ranges";
            this.Ranges.UseVisualStyleBackColor = true;
            // 
            // lblTolerance
            // 
            this.lblTolerance.AutoSize = true;
            this.lblTolerance.Location = new System.Drawing.Point(381, 299);
            this.lblTolerance.Name = "lblTolerance";
            this.lblTolerance.Size = new System.Drawing.Size(84, 13);
            this.lblTolerance.TabIndex = 2;
            this.lblTolerance.Text = "Tolerance (eps):";
            // 
            // grpRhsRanges
            // 
            this.grpRhsRanges.Controls.Add(this.gridRhsRanges);
            this.grpRhsRanges.Location = new System.Drawing.Point(476, 18);
            this.grpRhsRanges.Name = "grpRhsRanges";
            this.grpRhsRanges.Size = new System.Drawing.Size(466, 268);
            this.grpRhsRanges.TabIndex = 1;
            this.grpRhsRanges.TabStop = false;
            this.grpRhsRanges.Text = "RHS Ranges";
            // 
            // gridRhsRanges
            // 
            this.gridRhsRanges.AllowUserToAddRows = false;
            this.gridRhsRanges.AllowUserToDeleteRows = false;
            this.gridRhsRanges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridRhsRanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRhsRanges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.allowableIncrease,
            this.bi,
            this.allowableDecrease});
            this.gridRhsRanges.Location = new System.Drawing.Point(8, 16);
            this.gridRhsRanges.Name = "gridRhsRanges";
            this.gridRhsRanges.ReadOnly = true;
            this.gridRhsRanges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRhsRanges.Size = new System.Drawing.Size(445, 190);
            this.gridRhsRanges.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Constraint";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 79;
            // 
            // allowableIncrease
            // 
            this.allowableIncrease.HeaderText = "Allowable Increase";
            this.allowableIncrease.Name = "allowableIncrease";
            this.allowableIncrease.ReadOnly = true;
            this.allowableIncrease.Width = 111;
            // 
            // bi
            // 
            this.bi.HeaderText = "b_i";
            this.bi.Name = "bi";
            this.bi.ReadOnly = true;
            this.bi.Width = 46;
            // 
            // allowableDecrease
            // 
            this.allowableDecrease.HeaderText = "Allowable Decrease";
            this.allowableDecrease.Name = "allowableDecrease";
            this.allowableDecrease.ReadOnly = true;
            this.allowableDecrease.Width = 115;
            // 
            // numTolerance
            // 
            this.numTolerance.Cursor = System.Windows.Forms.Cursors.Default;
            this.numTolerance.Location = new System.Drawing.Point(471, 297);
            this.numTolerance.Name = "numTolerance";
            this.numTolerance.Size = new System.Drawing.Size(120, 20);
            this.numTolerance.TabIndex = 1;
            this.numTolerance.Value = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            // 
            // grpObjRanges
            // 
            this.grpObjRanges.Controls.Add(this.gridObjRanges);
            this.grpObjRanges.Location = new System.Drawing.Point(3, 18);
            this.grpObjRanges.Name = "grpObjRanges";
            this.grpObjRanges.Size = new System.Drawing.Size(467, 268);
            this.grpObjRanges.TabIndex = 0;
            this.grpObjRanges.TabStop = false;
            this.grpObjRanges.Text = "Objective Coefficient Ranges";
            // 
            // gridObjRanges
            // 
            this.gridObjRanges.AllowUserToAddRows = false;
            this.gridObjRanges.AllowUserToDeleteRows = false;
            this.gridObjRanges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridObjRanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridObjRanges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.variableRange,
            this.cj,
            this.allowDecrease,
            this.allowIncrease});
            this.gridObjRanges.Location = new System.Drawing.Point(8, 20);
            this.gridObjRanges.Name = "gridObjRanges";
            this.gridObjRanges.ReadOnly = true;
            this.gridObjRanges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridObjRanges.Size = new System.Drawing.Size(448, 186);
            this.gridObjRanges.TabIndex = 0;
            this.gridObjRanges.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridObjRanges_CellContentClick);
            // 
            // variableRange
            // 
            this.variableRange.HeaderText = "Variable";
            this.variableRange.Name = "variableRange";
            this.variableRange.ReadOnly = true;
            this.variableRange.Width = 70;
            // 
            // cj
            // 
            this.cj.HeaderText = "c_j";
            this.cj.Name = "cj";
            this.cj.ReadOnly = true;
            this.cj.Width = 46;
            // 
            // allowDecrease
            // 
            this.allowDecrease.HeaderText = "Allowable Decrease";
            this.allowDecrease.Name = "allowDecrease";
            this.allowDecrease.ReadOnly = true;
            this.allowDecrease.Width = 115;
            // 
            // allowIncrease
            // 
            this.allowIncrease.HeaderText = "Allowable Increase";
            this.allowIncrease.Name = "allowIncrease";
            this.allowIncrease.ReadOnly = true;
            this.allowIncrease.Width = 111;
            // 
            // Report
            // 
            this.Report.Controls.Add(this.btnCopyReport);
            this.Report.Controls.Add(this.txtReportPreview);
            this.Report.Location = new System.Drawing.Point(4, 25);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(950, 350);
            this.Report.TabIndex = 3;
            this.Report.Text = "Report";
            this.Report.UseVisualStyleBackColor = true;
            // 
            // btnCopyReport
            // 
            this.btnCopyReport.Location = new System.Drawing.Point(430, 259);
            this.btnCopyReport.Name = "btnCopyReport";
            this.btnCopyReport.Size = new System.Drawing.Size(75, 23);
            this.btnCopyReport.TabIndex = 1;
            this.btnCopyReport.Text = "Copy Report";
            this.btnCopyReport.UseVisualStyleBackColor = true;
            // 
            // txtReportPreview
            // 
            this.txtReportPreview.Location = new System.Drawing.Point(77, 23);
            this.txtReportPreview.Name = "txtReportPreview";
            this.txtReportPreview.ReadOnly = true;
            this.txtReportPreview.Size = new System.Drawing.Size(778, 217);
            this.txtReportPreview.TabIndex = 0;
            this.txtReportPreview.Text = "";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.InitialDelay = 300;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            // 
            // frmSensitivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 470);
            this.Controls.Add(this.prog);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.btnSolveDual);
            this.Controls.Add(this.btnBuildDual);
            this.Controls.Add(this.btnSolvePrimal);
            this.Controls.Add(this.btnOpen);
            this.Name = "frmSensitivity";
            this.Text = "frmSensitivity";
            this.Load += new System.EventHandler(this.frmSensitivity_Load);
            this.tabMain.ResumeLayout(false);
            this.Overview.ResumeLayout(false);
            this.grpDual.ResumeLayout(false);
            this.grpDual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDualTableau)).EndInit();
            this.grpPrimal.ResumeLayout(false);
            this.grpPrimal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrimalTableau)).EndInit();
            this.ShadowPricesReducedCosts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReducedCosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShadowPrices)).EndInit();
            this.Ranges.ResumeLayout(false);
            this.Ranges.PerformLayout();
            this.grpRhsRanges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRhsRanges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTolerance)).EndInit();
            this.grpObjRanges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridObjRanges)).EndInit();
            this.Report.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSolvePrimal;
        private System.Windows.Forms.Button btnBuildDual;
        private System.Windows.Forms.Button btnSolveDual;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar prog;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage Overview;
        private System.Windows.Forms.TabPage ShadowPricesReducedCosts;
        private System.Windows.Forms.TabPage Ranges;
        private System.Windows.Forms.TabPage Report;
        private System.Windows.Forms.GroupBox grpPrimal;
        private System.Windows.Forms.DataGridView gridPrimalTableau;
        private System.Windows.Forms.ListBox lstPrimalIters;
        private System.Windows.Forms.GroupBox grpDual;
        private System.Windows.Forms.Label lblPrimalObj;
        private System.Windows.Forms.Label lblDualityCheck;
        private System.Windows.Forms.DataGridView gridDualTableau;
        private System.Windows.Forms.Label lblDualObj;
        private System.Windows.Forms.DataGridView gridShadowPrices;
        private System.Windows.Forms.DataGridViewTextBoxColumn constraint;
        private System.Windows.Forms.DataGridViewTextBoxColumn yvalue;
        private System.Windows.Forms.DataGridViewTextBoxColumn units;
        private System.Windows.Forms.DataGridView gridReducedCosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn variable;
        private System.Windows.Forms.DataGridViewTextBoxColumn reducedCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn basic;
        private System.Windows.Forms.GroupBox grpObjRanges;
        private System.Windows.Forms.DataGridView gridObjRanges;
        private System.Windows.Forms.DataGridViewTextBoxColumn variableRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn cj;
        private System.Windows.Forms.DataGridViewTextBoxColumn allowDecrease;
        private System.Windows.Forms.DataGridViewTextBoxColumn allowIncrease;
        private System.Windows.Forms.GroupBox grpRhsRanges;
        private System.Windows.Forms.DataGridView gridRhsRanges;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn allowableIncrease;
        private System.Windows.Forms.DataGridViewTextBoxColumn bi;
        private System.Windows.Forms.DataGridViewTextBoxColumn allowableDecrease;
        private System.Windows.Forms.Label lblTolerance;
        private System.Windows.Forms.NumericUpDown numTolerance;
        private System.Windows.Forms.RichTextBox txtReportPreview;
        private System.Windows.Forms.Button btnCopyReport;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}