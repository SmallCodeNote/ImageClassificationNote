using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

using WinFormStringCnvClass;

using Tensorflow;
using Tensorflow.Keras;

using SciSharp.Models.ImageClassification;
using SciSharp.Models.ImageClassification.Zoo;

namespace ImageClassificationNote
{
    public partial class Form1 : Form
    {


        private IModelZoo createModel(string modelName)
        {
            IModelZoo model = null;

            if (modelName == "AlexNet") model = new AlexNet();
            else if (modelName == "DenseNet") model = new DenseNet();
            else if (modelName == "GoogLeNet") model = new GoogLeNet();
            else if (modelName == "MobilenetV2") model = new MobilenetV2();
            else if (modelName == "NiN") model = new NiN();
            else if (modelName == "ResNet") model = new ResNet();
            else if (modelName == "VGG") model = new VGG();

            return model;

        }


        private FolderClassificationConfig createConfig(string BaseFolderPath, int img_width, int img_height, int img_channel)
        {
            var config = new FolderClassificationConfig();
            config.BaseFolder = BaseFolderPath;
            config.DataDir = "";
            config.InputShape = (img_width, img_height);
            config.BatchSize = 8;
            config.ValidationStep = 5;
            config.Epoch = 20;
            config.Channel = img_channel;

            return config;
        }


        private void addChartSeries(Chart chart, string chart_SeriesName, SeriesChartType type = SeriesChartType.Line)
        {
            if (chart.InvokeRequired)
            {
                chart.Invoke((MethodInvoker)delegate
                {
                    chart.Series.Add(chart_SeriesName);
                    chart.Series[chart_SeriesName].ChartType = type;
                    chart.Series[chart_SeriesName].MarkerStyle = MarkerStyle.Circle;
                    //chart.Series[chart_SeriesName].IsValueShownAsLabel = true;
                    chart.Series[chart_SeriesName].LegendText = "";

                });
            }
        }
        private void chartInitialize()
        {
            chart_AccuracyValue.Series.Clear();
            chart_AccuracyValue.Legends[0].Position.X = 75;
            chart_AccuracyValue.Legends[0].Position.Y = 50;
            chart_AccuracyValue.Legends[0].Position.Height = 50;
            chart_AccuracyValue.ChartAreas[0].Position.Width = 70;
            chart_AccuracyValue.ChartAreas[0].AxisY.Minimum = 0;
            chart_AccuracyValue.ChartAreas[0].AxisY.Maximum = 100;
            chart_AccuracyValue.ChartAreas[0].AxisY.Title = "AccuracyValue(%)";
            chart_AccuracyValue.ChartAreas[0].AxisX.Title = "Epoch x Batch";


            chart_BatchSize_AccuracyValue.Series.Clear();
            chart_BatchSize_AccuracyValue.Legends[0].Position.X = 75;
            chart_BatchSize_AccuracyValue.Legends[0].Position.Y = 50;
            chart_BatchSize_AccuracyValue.Legends[0].Position.Height = 50;
            chart_BatchSize_AccuracyValue.ChartAreas[0].Position.Width = 70;
            chart_BatchSize_AccuracyValue.ChartAreas[0].AxisY.Minimum = 0;
            chart_BatchSize_AccuracyValue.ChartAreas[0].AxisY.Maximum = 100;
            chart_BatchSize_AccuracyValue.ChartAreas[0].AxisY.Title = "AccuracyValue(%)";
            chart_BatchSize_AccuracyValue.ChartAreas[0].AxisX.Title = "BatchSize";


            chart_LossValue.Series.Clear();
            chart_LossValue.Legends[0].Position.X = 75;
            chart_LossValue.Legends[0].Position.Y = 50;
            chart_LossValue.Legends[0].Position.Height = 50;
            chart_LossValue.ChartAreas[0].Position.Width = 70;
            chart_LossValue.ChartAreas[0].AxisY.Minimum = 0;
            //chart_LossValue.ChartAreas[0].AxisY.Maximum = 100;
            chart_LossValue.ChartAreas[0].AxisY.Title = "LossValue";
            chart_LossValue.ChartAreas[0].AxisX.Title = "Epoch x Batch";

        }


    }
}
