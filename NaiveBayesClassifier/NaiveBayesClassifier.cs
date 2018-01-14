using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining.NaiveBayesClassifier
{
    public class NaiveBayesClassifier
    {
        public void LoadAttribute(IEnumerable<AttributeData> attributes)
        {
            Attributes = attributes;
        }

        public void LoadData(IEnumerable<IEnumerable<string>> data)
        {
            Data = data;
        }

        public void SetClass(string attributeName)
        {
            Attributes = Attributes.Select(x =>
            {
                if (x.AttributeName == attributeName)
                {
                    x.AsClass();
                }
                return x;
            });
            int i = 0;
            foreach (var o in Attributes)
            {
                if (o.IsClass)
                {
                    ClassInfo = o;
                    ClassIndex = i;
                    break;
                }
                i++;
            }
        }

        public void Load(IEnumerable<AttributeData> attributes,
            IEnumerable<IEnumerable<string>> data, string className)
        {
            LoadAttribute(attributes);
            LoadData(data);
            SetClass(className);
        }

        public ClassifierModel TrainModel()
        {
            var attributes = Attributes.Where(x => !x.IsClass);
            //[ClassValue][Attribute][AttributeValue]
            int[][][] countMatrix = new int[ClassInfo.NominalOptionCount][][];
            decimal[][][] modelMatrix = new decimal[countMatrix.Length][][];
            for (int i = 0; i < countMatrix.Length; i++)
            {
                countMatrix[i] = new int[attributes.Count()][];
                modelMatrix[i] = new decimal[countMatrix[i].Length][];
                int j = 0;
                foreach (var attr in attributes)
                {
                    countMatrix[i][j] = new int[attr.NominalOptionCount];
                    modelMatrix[i][j] = new decimal[attr.NominalOptionCount];
                    j++;
                }
            }
            foreach (var row in Data)
            {
                var data = GetRowData(row, Attributes);
                var classValue = data.ElementAt(ClassIndex);
                int i = 0, j = 0;
                foreach (var o in data)
                {
                    if (i != ClassIndex)
                    {
                        countMatrix[classValue][j][o]++;
                        j++;
                    }
                    i++;
                }
            }
            for (int i = 0; i < countMatrix.Length; i++)
            {
                var countBase = (decimal)countMatrix[i][0].Sum();
                if (countBase != 0)
                {
                    for (int j = 0; j < countMatrix[i].Length; j++)
                    {
                        for (int k = 0; k < countMatrix[i][j].Length; k++)
                        {
                            modelMatrix[i][j][k] = countMatrix[i][j][k] / countBase;
                        }
                    }
                }
            }
            _TrainedModel = new ClassifierModel(ClassInfo, attributes, modelMatrix);
            return _TrainedModel;
        }

        public int[][] GetConfusionMatrix(IEnumerable<IEnumerable<string>> testData)
        {
            var confusionMatrix = new int[ClassInfo.NominalOptionCount][];
            for (int i = 0; i < ClassInfo.NominalOptionCount; i++)
            {
                confusionMatrix[i] = new int[ClassInfo.NominalOptionCount];
            }
            foreach (var row in testData)
            {
                var data = GetRowData(row, Attributes);
                var originClass = data.ElementAt(ClassIndex);
                var test = data.Where((x, i) => i != ClassIndex);
                var estimatedClass =
                    ClassInfo.GetNominalOptionIndex(TrainedModel.GetEstimatedClass(test));
                confusionMatrix[originClass][estimatedClass]++;
            }
            return confusionMatrix;
        }

        public int[][] GetConfusionMatrix(IEnumerable<string> testData)
        {
            return GetConfusionMatrix(
                testData.Select(x => x.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(y => y.Trim(' ', ','))));
        }

        public int[][] GetConfusionMatrix(string testData)
        {
            return GetConfusionMatrix(
                testData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim('\n')));
        }

        public IEnumerable<AttributeData> Attributes { get; private set; }

        private AttributeData ClassInfo;

        private int ClassIndex;

        public IEnumerable<IEnumerable<string>> Data { get; private set; }

        private ClassifierModel _TrainedModel;

        public ClassifierModel TrainedModel => _TrainedModel ?? TrainModel();

        private static IEnumerable<int> GetRowData(string row, IEnumerable<AttributeData> attributes)
        {
            return GetRowData(row.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(x => x.Trim(new char[] { ' ', ',' })), attributes);
        }

        private static IEnumerable<int> GetRowData(IEnumerable<string> row, IEnumerable<AttributeData> attributes)
        {
            var attrIterator = attributes.GetEnumerator();
            foreach (var o in row)
            {
                attrIterator.MoveNext();
                yield return attrIterator.Current.GetNominalOptionIndex(o);
            }
        }

        public class AttributeData
        {
            public string AttributeName { get; set; }

            private IEnumerable<string> _NominalOption;

            public IEnumerable<string> NominalOption
            {
                get
                {
                    return _NominalOption;
                }
                set
                {
                    _NominalOption = value;
                    NominalOptionCount = _NominalOption.Count();
                }
            }

            public int NominalOptionCount { get; private set; }

            public bool IsClass { get; set; } = false;

            public void AsClass()
            {
                IsClass = true;
            }

            public int GetNominalOptionIndex(string value)
            {
                int i = 0;
                foreach (var o in NominalOption)
                {
                    if (o == value)
                        return i;
                    i++;
                }
                return -1;
            }
        }

        public class ClassifierModel
        {
            public ClassifierModel(
                AttributeData classInfo,
                IEnumerable<AttributeData> attributes,
                decimal[][][] model)
            {
                ClassInfo = classInfo;
                Attributes = attributes;
                Model = model;
            }

            public string GetEstimatedClass(IEnumerable<int> data)
            {
                return ClassInfo.NominalOption
                    .Select((className, classIndex) =>
                    (
                        value: data.Select((attrValue, attrIndex) =>
                                        Model[classIndex][attrIndex][attrValue])
                                   .Aggregate(1m, (result, d) => result * d),
                        name: className
                    ))
                    .Aggregate((a, b) => a.value > b.value ? a : b)
                    .name;
            }

            public string GetEstimatedClass(IEnumerable<string> row)
            {
                return GetEstimatedClass(GetRowData(row, Attributes));
            }

            public string GetEstimatedClass(string row)
            {
                return GetEstimatedClass(GetRowData(row, Attributes));
            }

            private AttributeData ClassInfo;

            private IEnumerable<AttributeData> Attributes;

            // Conditional Probability = [ClassValue][Attribute][AttributeValue]
            private decimal[][][] Model;
        }
    }
}
