﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Parallel_Rep
{
    /// <summary>
    /// 指定のデータ数もしくはスレッド数で、並列処理を行い
    /// その処理時間の結果をグラフに示すフォーム
    /// </summary>
    public partial class MultiThreadForm : Form
    {
        // 処理として[行列変換]を行う
        IThreadProcess Process = new TP_MatrixTransform();  

        // データ固定時のスレッドの最大数
        static readonly int MaxThreadNum = 10;

        // スレッド数固定時のデータの最大数
        static readonly int MaxDataNum = 10000000;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MultiThreadForm()
        {
            InitializeComponent();
            chart.Series.Clear();
        }

        /// <summary>
        /// 「処理開始」ボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_start_Click(object sender, EventArgs e)
        {
            // 処理が終わるまで「処理開始」ボタンを押せないようにする
            button_start.Enabled = false;

            // 試行回数
            var tryNum = (int)numericUpDown_試行回数.Value;

            // 処理結果を格納するリスト
            List<ProcessResult> resultList = new List<ProcessResult>();

            // データ数固定の処理
            if (radioButton_データ数固定.Checked)
            {
                // データ数
                var dataNum = (int)numericUpDown_データ数固定.Value;

                AddLog("データ数： " + dataNum + "、スレッド数 変化 の処理を開始します。");

                // スレッドの数だけループ
                for (int threadNum = 1; threadNum <= MaxThreadNum; threadNum++)
                {
                    // 処理を行い、結果をリストに格納
                    var res = DoThreadProcess(Process, dataNum, threadNum, tryNum);
                    resultList.Add(res);
                    
                    // ログ出力
                    AddLog("スレッド数 " + string.Format("{0}", threadNum) + " の結果： 平均値 " + string.Format("{0:F2}", res.AverageTime.TotalMilliseconds) + "[ms], 中央値 " + string.Format("{0:F2}", res.MedianTime.TotalMilliseconds) + "[ms]");
                }
            }
            // スレッド数固定の処理
            else
            {
                // スレッド数
                var threadNum = (int)numericUpDown_スレッド数固定.Value;

                // 最大データ数
                var maxDataNum = (int)numericUpDown_スレッド数固定_最大値.Value;

                // データ数は最大数まで10分割
                List<int> dataNums = new List<int>();
                for (int i = 1; i <= 10; i++) dataNums.Add((maxDataNum / 10) * i);

                AddLog("スレッド数 " + threadNum + "、データ数 変化 の処理を開始します。");

                for (int i = 0; i < 10; i++)
                {
                    // データ数
                    var dataNum = dataNums[i];

                    // 処理を行い、結果をリストに格納
                    var res = DoThreadProcess(Process, dataNum, threadNum, tryNum);
                    resultList.Add(res);

                    // ログ出力
                    AddLog("データ数 " + dataNum + " の結果： 平均値 " + string.Format("{0:F2}", res.AverageTime.TotalMilliseconds) + "[ms], 中央値 " + string.Format("{0:F2}", res.MedianTime.TotalMilliseconds) + "[ms]");
                }

            }

            AddSeries(
                resultList.ToArray(),
                radioButton_データ数固定.Checked,
                button_グラフ表示切り替え.Text == Properties.Resources.Button_表示切替_平均値);

            AddLog("処理完了！");
            AddLog("");

            button_start.Enabled = true;
        }

        /// <summary>
        /// スレッド処理を試行回数行い、結果を返す
        /// </summary>
        /// <param name="process">スレッド処理の内容</param>
        /// <param name="dataNum">データ数</param>
        /// <param name="threadNum">スレッド数</param>
        /// <param name="tryNum">試行回数</param>
        /// <returns>処理結果</returns>
        private ProcessResult DoThreadProcess(IThreadProcess process, int dataNum, int threadNum, int tryNum)
        {
            // 試行した結果を格納する配列
            TimeSpan[] times = new TimeSpan[tryNum];

            // 試行回数だけループをまわす
            for (int tryNo = 0; tryNo < tryNum; tryNo++)
            {
                // 処理を行う前の初期化、ここは処理時間に含まない
                process.Initialize(dataNum, threadNum);

                // 計測
                Stopwatch timer = new Stopwatch();
                timer.Start();
                process.StartProcess();
                timer.Stop();

                // 試行した結果を格納する
                times[tryNo] = timer.Elapsed;
            }

            // 計測の平均値を計算
            TimeSpan totalTime = new TimeSpan();
            foreach (var time in times) totalTime = totalTime.Add(time);
            long average = totalTime.Ticks / tryNum;
            var averageTime = new TimeSpan(average);

            // 計測の中央値を計算
            Array.Sort(times);
            var medianTime = times[tryNum / 2];

            // 結果を返す
            return new ProcessResult()
            {
                DataNum = dataNum,
                ThreadNum = threadNum,
                AverageTime = averageTime,
                MedianTime = medianTime,
            };
        }

        /// <summary>
        /// チャートにグラフを追加する
        /// データ数固定、スレッド数固定を同じチャートに表示することはできない
        /// </summary>
        /// <param name="results">グラフに追加するデータ</param>
        /// <param name="fixedData">データ数固定か</param>
        private void AddSeries(ProcessResult[] results, bool isFixedData, bool isAverage)
        {
            string strVal = isAverage ? "平均値" : "中央値";
            var ser = new System.Windows.Forms.DataVisualization.Charting.Series();
            ser.Tag = results;
            ser.BorderWidth = 2;
            ser.MarkerSize = 7;
            ser.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            ser.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            string name = null;
            
            // データ数固定
            if (isFixedData)
            {
                if (chart.ChartAreas[0].AxisX.Title != Properties.Resources.AxisX_Title_データ数固定時)
                {
                    chart.Series.Clear();
                    chart.ChartAreas[0].AxisX.Title = Properties.Resources.AxisX_Title_データ数固定時;
                    chart.ChartAreas[0].AxisX.Maximum = MaxThreadNum;
                    chart.Titles[0].Text = Properties.Resources.Title_データ数固定時;
                }

                // 同一データ数のグラフが存在していたら削除
                name = "データ数 " + results[0].DataNum + " の" + strVal;
                System.Windows.Forms.DataVisualization.Charting.Series prev = null;
                try { prev = chart.Series.First((se) => { return se.Name.Contains(results[0].DataNum.ToString()); }); }
                catch { }
                if (prev != null) chart.Series.Remove(prev);

                foreach (var res in results)
                {
                    if (isAverage) ser.Points.AddXY(res.ThreadNum, res.AverageTime.TotalMilliseconds);
                    else ser.Points.AddXY(res.ThreadNum, res.MedianTime.TotalMilliseconds);
                }
                    
            }
            // スレッド数固定
            else
            {
                if (chart.ChartAreas[0].AxisX.Title != Properties.Resources.AxisX_Title_スレッド数固定時)
                {
                    chart.Series.Clear();
                    chart.ChartAreas[0].AxisX.Title = Properties.Resources.AxisX_Title_スレッド数固定時;
                    chart.ChartAreas[0].AxisX.Minimum = results[0].DataNum;
                    chart.ChartAreas[0].AxisX.Maximum = results[9].DataNum;
                    chart.Titles[0].Text = Properties.Resources.Title_スレッド数固定時;
                }

                name = "スレッド数 " + results[0].ThreadNum + " の" + strVal;
                System.Windows.Forms.DataVisualization.Charting.Series prev = null;
                try { prev = chart.Series.First((se) => { return se.Name.Contains(results[0].ThreadNum.ToString()); }); }
                catch { }
                if (prev != null) chart.Series.Remove(prev);

                foreach (var res in results)
                {
                    if (isAverage) ser.Points.AddXY(res.DataNum, res.AverageTime.TotalMilliseconds);
                    else ser.Points.AddXY(res.DataNum, res.MedianTime.TotalMilliseconds);
                }
            }

            ser.Name = name;
            chart.Series.Add(ser);
        }

        /// <summary>
        /// データ数固定が選択されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_データ数固定_CheckedChanged(object sender, EventArgs e)
        {
            var flag = radioButton_データ数固定.Checked;

            label_データ数固定_データ数.Enabled = flag;
            numericUpDown_データ数固定.Enabled = flag;
        }

        /// <summary>
        /// スレッド数固定が選択されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_スレッド数固定_CheckedChanged(object sender, EventArgs e)
        {
            var flag = radioButton_スレッド数固定.Checked;

            label_スレッド数固定_スレッド数.Enabled = flag;
            label2.Enabled = flag;
            numericUpDown_スレッド数固定.Enabled = flag;
            numericUpDown_スレッド数固定_最大値.Enabled = flag;
        }

        /// <summary>
        /// 実行ログに文字列を追加する
        /// </summary>
        /// <param name="str">追加する文字列</param>
        public void AddLog(string str)
        {
            textBox1.AppendText(str + "\r\n");
        }

        /// <summary>
        /// 「ログクリア」ボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ログクリア_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        /// <summary>
        /// 表示切替ボタンが押されたときの処理。
        /// グラフの表示を平均値と中央値とで切り替える
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_グラフ表示切り替え_Click(object sender, EventArgs e)
        {
            if(button_グラフ表示切り替え.Text == Properties.Resources.Button_表示切替_平均値)
                button_グラフ表示切り替え.Text = Properties.Resources.Button_表示切替_中央値;
            else button_グラフ表示切り替え.Text = Properties.Resources.Button_表示切替_平均値;

            bool isFixedData = true;
            try { isFixedData = chart.Series.First((se) => { return se.Name.Contains("データ数"); }) != null; }
            catch { isFixedData = false; }
            var ser = chart.Series.ToArray();
            foreach (var se in ser)
            {
                AddSeries(se.Tag as ProcessResult[], isFixedData, button_グラフ表示切り替え.Text == Properties.Resources.Button_表示切替_平均値);
            }
        }

    }

    /// <summary>
    /// スレッド処理を行った結果を格納するクラス
    /// </summary>
    public class ProcessResult
    {
        /// <summary>
        /// データ数
        /// </summary>
        public int DataNum { get; set; }

        /// <summary>
        /// スレッド数
        /// </summary>
        public int ThreadNum { get; set; }

        /// <summary>
        /// 時間の平均値
        /// </summary>
        public TimeSpan AverageTime { get; set; }

        /// <summary>
        /// 時間の中央値
        /// </summary>
        public TimeSpan MedianTime { get; set; }
    }
}
