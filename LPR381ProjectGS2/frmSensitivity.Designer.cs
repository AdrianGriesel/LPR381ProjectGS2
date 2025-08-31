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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.Overview = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpPrimal = new System.Windows.Forms.GroupBox();
            this.lblPrimalObj = new System.Windows.Forms.Label();
            this.lstPrimalIters = new System.Windows.Forms.ListBox();
            this.gridPrimalTableau = new System.Windows.Forms.DataGridView();
            this.grpDual = new System.Windows.Forms.GroupBox();
            this.lstDualIters = new System.Windows.Forms.ListBox();
            this.lblDualObj = new System.Windows.Forms.Label();
            this.gridDualTableau = new System.Windows.Forms.DataGridView();
            this.lblDualityCheck = new System.Windows.Forms.Label();
            this.ShadowPricesReducedCosts = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridShadowPrices = new System.Windows.Forms.DataGridView();
            this.constraint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yvalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.units = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridReducedCosts = new System.Windows.Forms.DataGridView();
            this.variable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reducedCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ranges = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numNewValue = new System.Windows.Forms.NumericUpDown();
            this.lblNewValue = new System.Windows.Forms.Label();
            this.grpObjRanges = new System.Windows.Forms.GroupBox();
            this.btnAddConstraint = new System.Windows.Forms.Button();
            this.btnAddActivity = new System.Windows.Forms.Button();
            this.btnApplyVarChange = new System.Windows.Forms.Button();
            this.gridObjRanges = new System.Windows.Forms.DataGridView();
            this.variableRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowDecrease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowIncrease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpRhsRanges = new System.Windows.Forms.GroupBox();
            this.btnApplyRhsChange = new System.Windows.Forms.Button();
            this.gridRhsRanges = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowableIncrease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowableDecrease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Report = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCopyReport = new System.Windows.Forms.Button();
            this.txtReportPreview = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblStatus1 = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.Overview.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpPrimal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrimalTableau)).BeginInit();
            this.grpDual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDualTableau)).BeginInit();
            this.ShadowPricesReducedCosts.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShadowPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridReducedCosts)).BeginInit();
            this.Ranges.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNewValue)).BeginInit();
            this.grpObjRanges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridObjRanges)).BeginInit();
            this.grpRhsRanges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRhsRanges)).BeginInit();
            this.Report.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(15, 394);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(101, 41);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open LP...";
            this.toolTip1.SetToolTip(this.btnOpen, "Load an LP text file.");
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSolvePrimal
            // 
            this.btnSolvePrimal.Location = new System.Drawing.Point(141, 394);
            this.btnSolvePrimal.Name = "btnSolvePrimal";
            this.btnSolvePrimal.Size = new System.Drawing.Size(101, 41);
            this.btnSolvePrimal.TabIndex = 1;
            this.btnSolvePrimal.Text = "Solve Primal";
            this.toolTip1.SetToolTip(this.btnSolvePrimal, "Solve the primal simplex (must be optimal before analysis).");
            this.btnSolvePrimal.UseVisualStyleBackColor = true;
            this.btnSolvePrimal.Click += new System.EventHandler(this.btnSolvePrimal_Click);
            // 
            // btnBuildDual
            // 
            this.btnBuildDual.Location = new System.Drawing.Point(266, 394);
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
            this.btnSolveDual.Location = new System.Drawing.Point(387, 394);
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
            this.btnAnalyze.Location = new System.Drawing.Point(513, 394);
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
            this.btnExport.Location = new System.Drawing.Point(644, 394);
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
            this.lblStatus.Location = new System.Drawing.Point(22, 274);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status:";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
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
            this.tabMain.Size = new System.Drawing.Size(735, 379);
            this.tabMain.TabIndex = 8;
            // 
            // Overview
            // 
            this.Overview.BackColor = System.Drawing.SystemColors.Menu;
            this.Overview.Controls.Add(this.panel1);
            this.Overview.Location = new System.Drawing.Point(4, 25);
            this.Overview.Name = "Overview";
            this.Overview.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Overview.Size = new System.Drawing.Size(727, 350);
            this.Overview.TabIndex = 0;
            this.Overview.Text = "Overview";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.grpPrimal);
            this.panel1.Controls.Add(this.grpDual);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Location = new System.Drawing.Point(20, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 307);
            this.panel1.TabIndex = 7;
            // 
            // grpPrimal
            // 
            this.grpPrimal.Controls.Add(this.lblPrimalObj);
            this.grpPrimal.Controls.Add(this.lstPrimalIters);
            this.grpPrimal.Controls.Add(this.gridPrimalTableau);
            this.grpPrimal.Location = new System.Drawing.Point(25, 15);
            this.grpPrimal.Name = "grpPrimal";
            this.grpPrimal.Size = new System.Drawing.Size(300, 237);
            this.grpPrimal.TabIndex = 0;
            this.grpPrimal.TabStop = false;
            this.grpPrimal.Text = "Primal Simplex";
            this.grpPrimal.Enter += new System.EventHandler(this.grpPrimal_Enter);
            // 
            // lblPrimalObj
            // 
            this.lblPrimalObj.AutoSize = true;
            this.lblPrimalObj.Location = new System.Drawing.Point(13, 19);
            this.lblPrimalObj.Name = "lblPrimalObj";
            this.lblPrimalObj.Size = new System.Drawing.Size(70, 13);
            this.lblPrimalObj.TabIndex = 1;
            this.lblPrimalObj.Text = "z* (primal) = …";
            this.lblPrimalObj.Click += new System.EventHandler(this.lblPrimalObj_Click);
            // 
            // lstPrimalIters
            // 
            this.lstPrimalIters.FormattingEnabled = true;
            this.lstPrimalIters.Location = new System.Drawing.Point(154, 19);
            this.lstPrimalIters.Name = "lstPrimalIters";
            this.lstPrimalIters.Size = new System.Drawing.Size(130, 95);
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
            this.gridPrimalTableau.RowHeadersWidth = 51;
            this.gridPrimalTableau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPrimalTableau.Size = new System.Drawing.Size(268, 106);
            this.gridPrimalTableau.TabIndex = 0;
            this.gridPrimalTableau.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPrimalTableau_CellContentClick);
            // 
            // grpDual
            // 
            this.grpDual.Controls.Add(this.lstDualIters);
            this.grpDual.Controls.Add(this.lblDualObj);
            this.grpDual.Controls.Add(this.gridDualTableau);
            this.grpDual.Controls.Add(this.lblDualityCheck);
            this.grpDual.Location = new System.Drawing.Point(351, 15);
            this.grpDual.Name = "grpDual";
            this.grpDual.Size = new System.Drawing.Size(311, 237);
            this.grpDual.TabIndex = 4;
            this.grpDual.TabStop = false;
            this.grpDual.Text = "Dual Simplex";
            // 
            // lstDualIters
            // 
            this.lstDualIters.FormattingEnabled = true;
            this.lstDualIters.Location = new System.Drawing.Point(196, 19);
            this.lstDualIters.Name = "lstDualIters";
            this.lstDualIters.Size = new System.Drawing.Size(104, 95);
            this.lstDualIters.TabIndex = 7;
            this.lstDualIters.SelectedIndexChanged += new System.EventHandler(this.lstDualIters_SelectedIndexChanged);
            // 
            // lblDualObj
            // 
            this.lblDualObj.AutoSize = true;
            this.lblDualObj.Location = new System.Drawing.Point(6, 19);
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
            this.gridDualTableau.Location = new System.Drawing.Point(6, 125);
            this.gridDualTableau.Name = "gridDualTableau";
            this.gridDualTableau.ReadOnly = true;
            this.gridDualTableau.RowHeadersWidth = 51;
            this.gridDualTableau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDualTableau.Size = new System.Drawing.Size(292, 106);
            this.gridDualTableau.TabIndex = 5;
            // 
            // lblDualityCheck
            // 
            this.lblDualityCheck.AutoSize = true;
            this.lblDualityCheck.Location = new System.Drawing.Point(6, 32);
            this.lblDualityCheck.Name = "lblDualityCheck";
            this.lblDualityCheck.Size = new System.Drawing.Size(196, 13);
            this.lblDualityCheck.TabIndex = 4;
            this.lblDualityCheck.Text = "strong duality: passed/failed (|z*−w*|≤tol)";
            // 
            // ShadowPricesReducedCosts
            // 
            this.ShadowPricesReducedCosts.Controls.Add(this.panel2);
            this.ShadowPricesReducedCosts.Location = new System.Drawing.Point(4, 25);
            this.ShadowPricesReducedCosts.Name = "ShadowPricesReducedCosts";
            this.ShadowPricesReducedCosts.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.ShadowPricesReducedCosts.Size = new System.Drawing.Size(727, 350);
            this.ShadowPricesReducedCosts.TabIndex = 1;
            this.ShadowPricesReducedCosts.Text = "Shadow Prices & Reduced Costs";
            this.ShadowPricesReducedCosts.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.gridShadowPrices);
            this.panel2.Controls.Add(this.gridReducedCosts);
            this.panel2.Location = new System.Drawing.Point(16, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(693, 322);
            this.panel2.TabIndex = 9;
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
            this.gridShadowPrices.Location = new System.Drawing.Point(20, 20);
            this.gridShadowPrices.Name = "gridShadowPrices";
            this.gridShadowPrices.ReadOnly = true;
            this.gridShadowPrices.RowHeadersWidth = 51;
            this.gridShadowPrices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridShadowPrices.Size = new System.Drawing.Size(314, 277);
            this.gridShadowPrices.TabIndex = 0;
            // 
            // constraint
            // 
            this.constraint.HeaderText = "Constraint";
            this.constraint.MinimumWidth = 6;
            this.constraint.Name = "constraint";
            this.constraint.ReadOnly = true;
            this.constraint.Width = 79;
            // 
            // yvalue
            // 
            this.yvalue.HeaderText = "Y value (Shadow Price)";
            this.yvalue.MinimumWidth = 6;
            this.yvalue.Name = "yvalue";
            this.yvalue.ReadOnly = true;
            this.yvalue.Width = 106;
            // 
            // units
            // 
            this.units.HeaderText = "Units";
            this.units.MinimumWidth = 6;
            this.units.Name = "units";
            this.units.ReadOnly = true;
            this.units.Width = 56;
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
            this.gridReducedCosts.Location = new System.Drawing.Point(361, 20);
            this.gridReducedCosts.Name = "gridReducedCosts";
            this.gridReducedCosts.ReadOnly = true;
            this.gridReducedCosts.RowHeadersWidth = 51;
            this.gridReducedCosts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridReducedCosts.Size = new System.Drawing.Size(310, 277);
            this.gridReducedCosts.TabIndex = 1;
            // 
            // variable
            // 
            this.variable.HeaderText = "Variable";
            this.variable.MinimumWidth = 6;
            this.variable.Name = "variable";
            this.variable.ReadOnly = true;
            this.variable.Width = 70;
            // 
            // reducedCost
            // 
            this.reducedCost.HeaderText = "Reduced Cost";
            this.reducedCost.MinimumWidth = 6;
            this.reducedCost.Name = "reducedCost";
            this.reducedCost.ReadOnly = true;
            this.reducedCost.Width = 92;
            // 
            // basic
            // 
            this.basic.HeaderText = "Basic? Yes/No";
            this.basic.MinimumWidth = 6;
            this.basic.Name = "basic";
            this.basic.ReadOnly = true;
            this.basic.Width = 96;
            // 
            // Ranges
            // 
            this.Ranges.Controls.Add(this.panel3);
            this.Ranges.Location = new System.Drawing.Point(4, 25);
            this.Ranges.Name = "Ranges";
            this.Ranges.Size = new System.Drawing.Size(727, 350);
            this.Ranges.TabIndex = 2;
            this.Ranges.Text = "Allowable Ranges";
            this.Ranges.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.lblStatus1);
            this.panel3.Controls.Add(this.numNewValue);
            this.panel3.Controls.Add(this.lblNewValue);
            this.panel3.Controls.Add(this.grpObjRanges);
            this.panel3.Controls.Add(this.grpRhsRanges);
            this.panel3.Location = new System.Drawing.Point(6, 11);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(716, 333);
            this.panel3.TabIndex = 10;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // numNewValue
            // 
            this.numNewValue.Cursor = System.Windows.Forms.Cursors.Default;
            this.numNewValue.Location = new System.Drawing.Point(390, 298);
            this.numNewValue.Name = "numNewValue";
            this.numNewValue.Size = new System.Drawing.Size(120, 20);
            this.numNewValue.TabIndex = 1;
            this.numNewValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNewValue
            // 
            this.lblNewValue.AutoSize = true;
            this.lblNewValue.Location = new System.Drawing.Point(271, 300);
            this.lblNewValue.Name = "lblNewValue";
            this.lblNewValue.Size = new System.Drawing.Size(70, 13);
            this.lblNewValue.TabIndex = 2;
            this.lblNewValue.Text = "New Variable";
            // 
            // grpObjRanges
            // 
            this.grpObjRanges.Controls.Add(this.btnAddConstraint);
            this.grpObjRanges.Controls.Add(this.btnAddActivity);
            this.grpObjRanges.Controls.Add(this.btnApplyVarChange);
            this.grpObjRanges.Controls.Add(this.gridObjRanges);
            this.grpObjRanges.Location = new System.Drawing.Point(9, 10);
            this.grpObjRanges.Name = "grpObjRanges";
            this.grpObjRanges.Size = new System.Drawing.Size(375, 268);
            this.grpObjRanges.TabIndex = 0;
            this.grpObjRanges.TabStop = false;
            this.grpObjRanges.Text = "Objective Coefficient Ranges";
            // 
            // btnAddConstraint
            // 
            this.btnAddConstraint.Location = new System.Drawing.Point(264, 215);
            this.btnAddConstraint.Name = "btnAddConstraint";
            this.btnAddConstraint.Size = new System.Drawing.Size(101, 41);
            this.btnAddConstraint.TabIndex = 6;
            this.btnAddConstraint.Text = "Add Constraint";
            this.btnAddConstraint.UseVisualStyleBackColor = true;
            this.btnAddConstraint.Click += new System.EventHandler(this.btnAddConstraint_Click);
            // 
            // btnAddActivity
            // 
            this.btnAddActivity.Location = new System.Drawing.Point(136, 215);
            this.btnAddActivity.Name = "btnAddActivity";
            this.btnAddActivity.Size = new System.Drawing.Size(101, 41);
            this.btnAddActivity.TabIndex = 5;
            this.btnAddActivity.Text = "Add Activity";
            this.btnAddActivity.UseVisualStyleBackColor = true;
            this.btnAddActivity.Click += new System.EventHandler(this.btnAddActivity_Click);
            // 
            // btnApplyVarChange
            // 
            this.btnApplyVarChange.Location = new System.Drawing.Point(8, 215);
            this.btnApplyVarChange.Name = "btnApplyVarChange";
            this.btnApplyVarChange.Size = new System.Drawing.Size(101, 41);
            this.btnApplyVarChange.TabIndex = 3;
            this.btnApplyVarChange.Text = "Variable Change";
            this.btnApplyVarChange.UseVisualStyleBackColor = true;
            this.btnApplyVarChange.Click += new System.EventHandler(this.btnApplyVarChange_Click);
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
            this.gridObjRanges.RowHeadersWidth = 51;
            this.gridObjRanges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridObjRanges.Size = new System.Drawing.Size(357, 186);
            this.gridObjRanges.TabIndex = 0;
            this.gridObjRanges.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridObjRanges_CellContentClick);
            // 
            // variableRange
            // 
            this.variableRange.HeaderText = "Variable";
            this.variableRange.MinimumWidth = 6;
            this.variableRange.Name = "variableRange";
            this.variableRange.ReadOnly = true;
            this.variableRange.Width = 70;
            // 
            // cj
            // 
            this.cj.HeaderText = "c_j";
            this.cj.MinimumWidth = 6;
            this.cj.Name = "cj";
            this.cj.ReadOnly = true;
            this.cj.Width = 46;
            // 
            // allowDecrease
            // 
            this.allowDecrease.HeaderText = "Allowable Decrease";
            this.allowDecrease.MinimumWidth = 6;
            this.allowDecrease.Name = "allowDecrease";
            this.allowDecrease.ReadOnly = true;
            this.allowDecrease.Width = 115;
            // 
            // allowIncrease
            // 
            this.allowIncrease.HeaderText = "Allowable Increase";
            this.allowIncrease.MinimumWidth = 6;
            this.allowIncrease.Name = "allowIncrease";
            this.allowIncrease.ReadOnly = true;
            this.allowIncrease.Width = 111;
            // 
            // grpRhsRanges
            // 
            this.grpRhsRanges.Controls.Add(this.btnApplyRhsChange);
            this.grpRhsRanges.Controls.Add(this.gridRhsRanges);
            this.grpRhsRanges.Location = new System.Drawing.Point(392, 10);
            this.grpRhsRanges.Name = "grpRhsRanges";
            this.grpRhsRanges.Size = new System.Drawing.Size(316, 268);
            this.grpRhsRanges.TabIndex = 1;
            this.grpRhsRanges.TabStop = false;
            this.grpRhsRanges.Text = "RHS Ranges";
            // 
            // btnApplyRhsChange
            // 
            this.btnApplyRhsChange.Location = new System.Drawing.Point(8, 213);
            this.btnApplyRhsChange.Name = "btnApplyRhsChange";
            this.btnApplyRhsChange.Size = new System.Drawing.Size(302, 41);
            this.btnApplyRhsChange.TabIndex = 4;
            this.btnApplyRhsChange.Text = "Apply RHS Change";
            this.btnApplyRhsChange.UseVisualStyleBackColor = true;
            this.btnApplyRhsChange.Click += new System.EventHandler(this.btnApplyRhsChange_Click);
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
            this.gridRhsRanges.RowHeadersWidth = 51;
            this.gridRhsRanges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRhsRanges.Size = new System.Drawing.Size(302, 190);
            this.gridRhsRanges.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Constraint";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 79;
            // 
            // allowableIncrease
            // 
            this.allowableIncrease.HeaderText = "Allowable Increase";
            this.allowableIncrease.MinimumWidth = 6;
            this.allowableIncrease.Name = "allowableIncrease";
            this.allowableIncrease.ReadOnly = true;
            this.allowableIncrease.Width = 111;
            // 
            // bi
            // 
            this.bi.HeaderText = "b_i";
            this.bi.MinimumWidth = 6;
            this.bi.Name = "bi";
            this.bi.ReadOnly = true;
            this.bi.Width = 46;
            // 
            // allowableDecrease
            // 
            this.allowableDecrease.HeaderText = "Allowable Decrease";
            this.allowableDecrease.MinimumWidth = 6;
            this.allowableDecrease.Name = "allowableDecrease";
            this.allowableDecrease.ReadOnly = true;
            this.allowableDecrease.Width = 115;
            // 
            // Report
            // 
            this.Report.Controls.Add(this.panel4);
            this.Report.Location = new System.Drawing.Point(4, 25);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(727, 350);
            this.Report.TabIndex = 3;
            this.Report.Text = "Report";
            this.Report.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.btnCopyReport);
            this.panel4.Controls.Add(this.txtReportPreview);
            this.panel4.Location = new System.Drawing.Point(15, 9);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(704, 334);
            this.panel4.TabIndex = 10;
            // 
            // btnCopyReport
            // 
            this.btnCopyReport.Location = new System.Drawing.Point(10, 281);
            this.btnCopyReport.Name = "btnCopyReport";
            this.btnCopyReport.Size = new System.Drawing.Size(679, 41);
            this.btnCopyReport.TabIndex = 1;
            this.btnCopyReport.Text = "Copy Report";
            this.btnCopyReport.UseVisualStyleBackColor = true;
            this.btnCopyReport.Click += new System.EventHandler(this.btnCopyReport_Click);
            // 
            // txtReportPreview
            // 
            this.txtReportPreview.Location = new System.Drawing.Point(10, 11);
            this.txtReportPreview.Name = "txtReportPreview";
            this.txtReportPreview.ReadOnly = true;
            this.txtReportPreview.Size = new System.Drawing.Size(680, 264);
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
            // lblStatus1
            // 
            this.lblStatus1.AutoSize = true;
            this.lblStatus1.Location = new System.Drawing.Point(14, 298);
            this.lblStatus1.Name = "lblStatus1";
            this.lblStatus1.Size = new System.Drawing.Size(40, 13);
            this.lblStatus1.TabIndex = 7;
            this.lblStatus1.Text = "Status:";
            // 
            // frmSensitivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 443);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpPrimal.ResumeLayout(false);
            this.grpPrimal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrimalTableau)).EndInit();
            this.grpDual.ResumeLayout(false);
            this.grpDual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDualTableau)).EndInit();
            this.ShadowPricesReducedCosts.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridShadowPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridReducedCosts)).EndInit();
            this.Ranges.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNewValue)).EndInit();
            this.grpObjRanges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridObjRanges)).EndInit();
            this.grpRhsRanges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRhsRanges)).EndInit();
            this.Report.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSolvePrimal;
        private System.Windows.Forms.Button btnBuildDual;
        private System.Windows.Forms.Button btnSolveDual;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblStatus;
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
        private System.Windows.Forms.Label lblNewValue;
        private System.Windows.Forms.NumericUpDown numNewValue;
        private System.Windows.Forms.RichTextBox txtReportPreview;
        private System.Windows.Forms.Button btnCopyReport;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnApplyRhsChange;
        private System.Windows.Forms.Button btnApplyVarChange;
        private System.Windows.Forms.Button btnAddConstraint;
        private System.Windows.Forms.Button btnAddActivity;
        private System.Windows.Forms.ListBox lstDualIters;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblStatus1;
    }
}