using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataMining.NaiveBayesClassifier;

namespace NaiveBayesClassifierWindow
{
    public partial class NaiveBayesClassifierWindow : Form
    {
        private readonly static char[] SplitChars = new char[] { ' ', ',' };

        public NaiveBayesClassifierWindow()
        {
            InitializeComponent();
            this.ImeMode = ImeMode.Alpha;
            TextTrainingData.ImeMode = ImeMode.OnHalf;
            TextTestData.ImeMode = ImeMode.OnHalf;
            SelectTestOption.SelectedIndex = 1;
            TextFold.ImeMode = ImeMode.Alpha;
            TextPercentage.ImeMode = ImeMode.Alpha;
            TextOutput.ImeMode = ImeMode.Alpha;
            OpenFileDialog.InitialDirectory = Application.StartupPath;
        }

        private void NaiveBayesClassifierWindow_Load(object sender, EventArgs e)
        {

        }

        private async void ButtonImportTrainingData_ClickAsync(object sender, EventArgs e)
        {
            OpenFileDialog.Title = "Import Training Data";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var reader = new StreamReader(OpenFileDialog.FileName))
                {
                    TextTrainingData.Text = await reader.ReadToEndAsync();
                }
                ButtonSettingTrainingData_Click(sender, e);
            }
        }

        private void ButtonSettingTrainingData_Click(object sender, EventArgs e)
        {
            classifier = new NaiveBayesClassifier();
            var allLines = TextTrainingData.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.TrimEnd('\n'));
            SelectClass.Enabled = true;
            classifier.LoadAttribute(
                allLines.Where(x => x.StartsWith("@attribute"))
                        .Select(x =>
                        {
                            var name = x.Split(' ')[1].Trim();
                            int ia = x.LastIndexOf('{');
                            int ib = x.IndexOf('}', ia);
                            return new NaiveBayesClassifier.AttributeData
                            {
                                AttributeName = name,
                                NominalOption = x.Substring(ia + 1, ib - ia - 1)
                                                 .Split(SplitChars, StringSplitOptions.RemoveEmptyEntries),
                            };
                        }));
            foreach (var o in allLines.Where(x => x.StartsWith("@attribute")))
            {
                var name = o.Split(' ')[1].Trim();
                SelectClass.Items.Add(name);
            }
            SelectClass.SelectedIndex = SelectClass.Items.Count - 1;
            data = allLines.SkipWhile(x => !x.StartsWith("@data")).Skip(1)
                               .Select(x => x.Split(SplitChars, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(y => y.Trim(SplitChars)));
        }

        private async void ButtonImportTestData_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Title = "Import Test Data";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var reader = new StreamReader(OpenFileDialog.FileName))
                {
                    TextTestData.Text = await reader.ReadToEndAsync();
                }
            }
        }

        private void SelectTestOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelFold.Enabled = false;
            TextFold.Enabled = false;
            LabelPercentage.Enabled = false;
            TextPercentage.Enabled = false;
            switch (SelectTestOption.SelectedIndex)
            {
                //Cross-Validation
                case 1:
                    LabelFold.Enabled = true;
                    TextFold.Enabled = true;
                    break;
                //Percentage Split
                case 2:
                    LabelPercentage.Enabled = true;
                    TextPercentage.Enabled = true;
                    break;
            }
        }

        private void ButtonGenerateModel_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now;
            classifier.SetClass(SelectClass.SelectedItem.ToString());
            int[][] confusionMatrix = null;
            int dataCount = data.Count();
            switch (SelectTestOption.SelectedIndex)
            {
                //Use Test Set
                case 0:
                    classifier.LoadData(data);
                    classifier.TrainModel();
                    confusionMatrix = classifier.GetConfusionMatrix(TextTestData.Text);
                    break;
                //Cross-Validation
                case 1:
                    int fold = int.Parse(TextFold.Text);
                    int foldCount = dataCount / fold;
                    for (int j = 0; j < fold; j++)
                    {
                        int c = foldCount * j;
                        classifier.LoadData(data.Take(c).Concat(data.Skip(c + foldCount)));
                        classifier.TrainModel();
                        confusionMatrix = AddMatrix(confusionMatrix,
                            classifier.GetConfusionMatrix(data.Skip(c).Take(foldCount)));
                    }
                    break;
                //Percentage Split
                case 2:
                    dataCount = dataCount * int.Parse(TextPercentage.Text) / 100;
                    classifier.LoadData(data.Take(dataCount));
                    classifier.TrainModel();
                    confusionMatrix = classifier.GetConfusionMatrix(data.Skip(dataCount));
                    break;
                default:
                    confusionMatrix = new int[0][];
                    break;
            }
            TextOutput.ResetText();
            var itor = Enumerable.Range(0, confusionMatrix.Length);
            decimal testCount = confusionMatrix.SelectMany(x => x).Sum();
            TextOutput.AppendText($"Accuracy:{(itor.Select(x => confusionMatrix[x][x]).Sum() / testCount).ToString()}\n\n");
            int i = 0;
            decimal d;
            foreach (var o in classifier.ClassInfo.NominalOption)
            {
                TextOutput.AppendText($"{o}：\n");
                TextOutput.AppendText("Precision:\t");
                d = itor.Select(x => confusionMatrix[x][i]).Sum();
                TextOutput.AppendText(d == 0m ? "∞" : (confusionMatrix[i][i] / d).ToString());
                TextOutput.AppendText("\n");
                d = itor.Select(x => confusionMatrix[i][x]).Sum();
                TextOutput.AppendText("Recall:\t");
                TextOutput.AppendText(d == 0m ? "∞" : (confusionMatrix[i][i] / d).ToString());
                TextOutput.AppendText("\n");
                d = itor.Select(x => confusionMatrix[i][x]).Concat(
                    itor.Select(x => confusionMatrix[x][i])).Sum();
                TextOutput.AppendText("F1-measure:\t");
                TextOutput.AppendText(d == 0m ? "∞" : (confusionMatrix[i][i] * 2 / d).ToString());
                TextOutput.AppendText("\n\n");
                i++;
            }
            TextOutput.AppendText($"Execute time:\t{new TimeSpan(DateTime.Now.Ticks - start.Ticks).TotalSeconds.ToString()}s\n");
        }

        private int[][] AddMatrix(int[][] a, int[][] b)
        {
            if (a == null)
                return b;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    a[i][j] += b[i][j];
                }
            }
            return a;
        }

        private void ButtonClassify_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now;
            classifier.SetClass(SelectClass.SelectedItem.ToString());
            classifier.LoadData(data);
            classifier.TrainModel();
            TextOutput.ResetText();
            foreach (var row in TextTestData.Text.Split('\n'))
            {
                TextOutput.AppendText($"{row}\t=> {classifier.TrainedModel.GetEstimatedClass(row)}\n");
            }
            TextOutput.AppendText($"\nExecute time:\t{new TimeSpan(DateTime.Now.Ticks - start.Ticks).TotalSeconds.ToString()}s\n");
        }

        private NaiveBayesClassifier classifier;

        private IEnumerable<IEnumerable<string>> data;
    }
}
