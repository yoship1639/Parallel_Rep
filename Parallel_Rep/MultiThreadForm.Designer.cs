namespace Parallel_Rep
{
    partial class MultiThreadForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_データ数固定_データ数 = new System.Windows.Forms.Label();
            this.radioButton_データ数固定 = new System.Windows.Forms.RadioButton();
            this.radioButton_スレッド数固定 = new System.Windows.Forms.RadioButton();
            this.label_スレッド数固定_スレッド数 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_試行回数 = new System.Windows.Forms.Label();
            this.numericUpDown_データ数固定 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_スレッド数固定 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_試行回数 = new System.Windows.Forms.NumericUpDown();
            this.button_ログクリア = new System.Windows.Forms.Button();
            this.numericUpDown_スレッド数固定_最大値 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button_グラフ表示切り替え = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_データ数固定)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_スレッド数固定)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_試行回数)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_スレッド数固定_最大値)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.Maximum = 7D;
            chartArea2.AxisX.Minimum = 1D;
            chartArea2.AxisX.Title = "データの数 n (10のn乗)";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            chartArea2.AxisY.Title = "処理に掛かった時間 [ms]";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(14, 265);
            this.chart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart.Name = "chart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Series2";
            this.chart.Series.Add(series3);
            this.chart.Series.Add(series4);
            this.chart.Size = new System.Drawing.Size(756, 319);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            title2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            this.chart.Titles.Add(title2);
            // 
            // label_データ数固定_データ数
            // 
            this.label_データ数固定_データ数.AutoSize = true;
            this.label_データ数固定_データ数.Location = new System.Drawing.Point(21, 52);
            this.label_データ数固定_データ数.Name = "label_データ数固定_データ数";
            this.label_データ数固定_データ数.Size = new System.Drawing.Size(56, 18);
            this.label_データ数固定_データ数.TabIndex = 4;
            this.label_データ数固定_データ数.Text = "データ数";
            // 
            // radioButton_データ数固定
            // 
            this.radioButton_データ数固定.AutoSize = true;
            this.radioButton_データ数固定.Checked = true;
            this.radioButton_データ数固定.Location = new System.Drawing.Point(24, 27);
            this.radioButton_データ数固定.Name = "radioButton_データ数固定";
            this.radioButton_データ数固定.Size = new System.Drawing.Size(98, 22);
            this.radioButton_データ数固定.TabIndex = 5;
            this.radioButton_データ数固定.TabStop = true;
            this.radioButton_データ数固定.Text = "データ数固定";
            this.radioButton_データ数固定.UseVisualStyleBackColor = true;
            this.radioButton_データ数固定.CheckedChanged += new System.EventHandler(this.radioButton_データ数固定_CheckedChanged);
            // 
            // radioButton_スレッド数固定
            // 
            this.radioButton_スレッド数固定.AutoSize = true;
            this.radioButton_スレッド数固定.Location = new System.Drawing.Point(248, 27);
            this.radioButton_スレッド数固定.Name = "radioButton_スレッド数固定";
            this.radioButton_スレッド数固定.Size = new System.Drawing.Size(110, 22);
            this.radioButton_スレッド数固定.TabIndex = 6;
            this.radioButton_スレッド数固定.TabStop = true;
            this.radioButton_スレッド数固定.Text = "スレッド数固定";
            this.radioButton_スレッド数固定.UseVisualStyleBackColor = true;
            this.radioButton_スレッド数固定.CheckedChanged += new System.EventHandler(this.radioButton_スレッド数固定_CheckedChanged);
            // 
            // label_スレッド数固定_スレッド数
            // 
            this.label_スレッド数固定_スレッド数.AutoSize = true;
            this.label_スレッド数固定_スレッド数.Enabled = false;
            this.label_スレッド数固定_スレッド数.Location = new System.Drawing.Point(245, 52);
            this.label_スレッド数固定_スレッド数.Name = "label_スレッド数固定_スレッド数";
            this.label_スレッド数固定_スレッド数.Size = new System.Drawing.Size(68, 18);
            this.label_スレッド数固定_スレッド数.TabIndex = 8;
            this.label_スレッド数固定_スレッド数.Text = "スレッド数";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(24, 204);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(106, 28);
            this.button_start.TabIndex = 11;
            this.button_start.Text = "処理開始";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(393, 30);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(377, 228);
            this.textBox1.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "実行ログ";
            // 
            // label_試行回数
            // 
            this.label_試行回数.AutoSize = true;
            this.label_試行回数.Location = new System.Drawing.Point(21, 175);
            this.label_試行回数.Name = "label_試行回数";
            this.label_試行回数.Size = new System.Drawing.Size(56, 18);
            this.label_試行回数.TabIndex = 14;
            this.label_試行回数.Text = "試行回数";
            // 
            // numericUpDown_データ数固定
            // 
            this.numericUpDown_データ数固定.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_データ数固定.Location = new System.Drawing.Point(81, 50);
            this.numericUpDown_データ数固定.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_データ数固定.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_データ数固定.Name = "numericUpDown_データ数固定";
            this.numericUpDown_データ数固定.Size = new System.Drawing.Size(80, 25);
            this.numericUpDown_データ数固定.TabIndex = 16;
            this.numericUpDown_データ数固定.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // numericUpDown_スレッド数固定
            // 
            this.numericUpDown_スレッド数固定.Enabled = false;
            this.numericUpDown_スレッド数固定.Location = new System.Drawing.Point(319, 50);
            this.numericUpDown_スレッド数固定.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_スレッド数固定.Name = "numericUpDown_スレッド数固定";
            this.numericUpDown_スレッド数固定.Size = new System.Drawing.Size(39, 25);
            this.numericUpDown_スレッド数固定.TabIndex = 17;
            this.numericUpDown_スレッド数固定.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_試行回数
            // 
            this.numericUpDown_試行回数.Location = new System.Drawing.Point(83, 173);
            this.numericUpDown_試行回数.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_試行回数.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_試行回数.Name = "numericUpDown_試行回数";
            this.numericUpDown_試行回数.Size = new System.Drawing.Size(41, 25);
            this.numericUpDown_試行回数.TabIndex = 18;
            this.numericUpDown_試行回数.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // button_ログクリア
            // 
            this.button_ログクリア.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ログクリア.Location = new System.Drawing.Point(692, 7);
            this.button_ログクリア.Name = "button_ログクリア";
            this.button_ログクリア.Size = new System.Drawing.Size(78, 23);
            this.button_ログクリア.TabIndex = 19;
            this.button_ログクリア.Text = "ログクリア";
            this.button_ログクリア.UseVisualStyleBackColor = true;
            this.button_ログクリア.Click += new System.EventHandler(this.button_ログクリア_Click);
            // 
            // numericUpDown_スレッド数固定_最大値
            // 
            this.numericUpDown_スレッド数固定_最大値.Enabled = false;
            this.numericUpDown_スレッド数固定_最大値.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_スレッド数固定_最大値.Location = new System.Drawing.Point(278, 81);
            this.numericUpDown_スレッド数固定_最大値.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_スレッド数固定_最大値.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_スレッド数固定_最大値.Name = "numericUpDown_スレッド数固定_最大値";
            this.numericUpDown_スレッド数固定_最大値.Size = new System.Drawing.Size(80, 25);
            this.numericUpDown_スレッド数固定_最大値.TabIndex = 21;
            this.numericUpDown_スレッド数固定_最大値.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(192, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "最大データ数";
            // 
            // button_グラフ表示切り替え
            // 
            this.button_グラフ表示切り替え.Location = new System.Drawing.Point(290, 231);
            this.button_グラフ表示切り替え.Name = "button_グラフ表示切り替え";
            this.button_グラフ表示切り替え.Size = new System.Drawing.Size(97, 27);
            this.button_グラフ表示切り替え.TabIndex = 24;
            this.button_グラフ表示切り替え.Text = "表示：平均値";
            this.button_グラフ表示切り替え.UseVisualStyleBackColor = true;
            this.button_グラフ表示切り替え.Click += new System.EventHandler(this.button_グラフ表示切り替え_Click);
            // 
            // MultiThreadForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 602);
            this.Controls.Add(this.button_グラフ表示切り替え);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_スレッド数固定_最大値);
            this.Controls.Add(this.button_ログクリア);
            this.Controls.Add(this.numericUpDown_試行回数);
            this.Controls.Add(this.numericUpDown_スレッド数固定);
            this.Controls.Add(this.numericUpDown_データ数固定);
            this.Controls.Add(this.label_試行回数);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label_スレッド数固定_スレッド数);
            this.Controls.Add(this.label_データ数固定_データ数);
            this.Controls.Add(this.radioButton_スレッド数固定);
            this.Controls.Add(this.radioButton_データ数固定);
            this.Controls.Add(this.chart);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(800, 640);
            this.Name = "MultiThreadForm";
            this.Text = "並列分散処理特論　レポート課題";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_データ数固定)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_スレッド数固定)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_試行回数)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_スレッド数固定_最大値)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label label_データ数固定_データ数;
        private System.Windows.Forms.RadioButton radioButton_データ数固定;
        private System.Windows.Forms.RadioButton radioButton_スレッド数固定;
        private System.Windows.Forms.Label label_スレッド数固定_スレッド数;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_試行回数;
        private System.Windows.Forms.NumericUpDown numericUpDown_データ数固定;
        private System.Windows.Forms.NumericUpDown numericUpDown_スレッド数固定;
        private System.Windows.Forms.NumericUpDown numericUpDown_試行回数;
        private System.Windows.Forms.Button button_ログクリア;
        private System.Windows.Forms.NumericUpDown numericUpDown_スレッド数固定_最大値;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_グラフ表示切り替え;
    }
}

