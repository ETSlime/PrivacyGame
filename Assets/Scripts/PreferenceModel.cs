#region 
// D:\UnityProjects\PrivacyGame\Assets\Plugins\MathNet.Numerics.dll
#endregion

using UnityEngine;

using MathNet.Numerics.LinearAlgebra;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using MathNet.Numerics.Statistics;
using XCharts;
using System;
using XCharts.Runtime;
using UnityEngine.UI;

public class PreferenceModel : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Result Page" && SceneManager.sceneCount == 1)
        {
            // result context root
            Transform resultRoot = this.transform.parent.Find("ResultContext");

            double[,] data = new double[Player.answers.Count, ScenarioCode.x_dim + ScenarioCode.y_dim];
            for (int row = 0; row < Player.answers.Count; row++)
            {
                PrivacyQuestion item = Player.answers[row];
                string scenarioID = item.scenarioID;
                // copy constructor
                List<double> temp = new List<double>(ScenarioCode.scenarios[scenarioID]);
                temp.Add(item.comfortable);
                temp.Add(item.decision);
                for (int col = 0; col < ScenarioCode.x_dim + ScenarioCode.y_dim; col++)
                {
                    data[row, col] = temp[col];
                }
                 
            }
            //double[][] data2 = new double[ScenarioCode.x_dim + ScenarioCode.y_dim][];
            //for (int idx = 0; idx < ScenarioCode.x_dim + ScenarioCode.y_dim; idx++)
            //{
            //    data2[idx] = new double[Player.answers.Count];
            //}
            //for (int row = 0; row < ScenarioCode.x_dim + ScenarioCode.y_dim; row++)
            //{
            //    data2[row] = dataMatrix.Column(row).ToArray();
            //}

            Matrix<double> dataMatrix = Matrix<double>.Build.DenseOfArray(data);
            double[] location = dataMatrix.Column(0).ToArray();
            double[] device = dataMatrix.Column(1).ToArray();
            double[] purpose = dataMatrix.Column(2).ToArray();
            double[] retention = dataMatrix.Column(3).ToArray();
            double[] shared = dataMatrix.Column(4).ToArray();
            double[] benefit = dataMatrix.Column(5).ToArray();
            double[] comfortable = dataMatrix.Column(6).ToArray();
            double[] decision = dataMatrix.Column(7).ToArray();
            Matrix<double> coefficientMatrix = Correlation.SpearmanMatrix(location, device, purpose, retention, shared, benefit, comfortable, decision);


            int comfortableIdx = 6;
            int decisionIdx = 7;

            // generate importance factors
            Vector<double> comfortableFactors = Vector<double>.Build.Dense(6);
            Vector<double> decisionFactors = Vector<double>.Build.Dense(6);

            // pie chart for comfortabe level and decision
            PieChart pieChartComfortable = resultRoot.Find("PieChartComfortable").GetComponent<PieChart>();
            PieChart pieChartDecision = resultRoot.Find("PieChartDecision").GetComponent<PieChart>();
            pieChartComfortable.ClearData();
            pieChartDecision.ClearData();

            // bar chart for comfortable level and decision
            BarChart barChartComfortable = resultRoot.Find("BarChartComfortable").GetComponent<BarChart>();
            barChartComfortable.ClearData();
            BarChart barChartDecision = resultRoot.Find("BarChartDecision").GetComponent<BarChart>();
            barChartDecision.ClearData();

            // purpose = -purpose
            coefficientMatrix[2, 6] = -coefficientMatrix[2, 6];
            coefficientMatrix[2, 7] = -coefficientMatrix[2, 7];

            for (int idx = 0; idx < coefficientMatrix.RowCount - 2; idx++)
            {
                // add comfortable/decision factor to a vector
                comfortableFactors[idx] = coefficientMatrix[idx, comfortableIdx];
                decisionFactors[idx] = coefficientMatrix[idx, decisionIdx];

                // add pie chart data
                pieChartComfortable.AddData(0, Math.Abs(Math.Round(coefficientMatrix[idx, comfortableIdx], 3)), ScenarioCode.factors[idx]);
                pieChartDecision.AddData(0, Math.Abs(Math.Round(coefficientMatrix[idx, decisionIdx], 3)), ScenarioCode.factors[idx]);

                // add bar chart data
                var serieData = barChartComfortable.AddData(0, Math.Round(coefficientMatrix[idx, comfortableIdx], 3), ScenarioCode.factors[idx]);
                if (Math.Round(coefficientMatrix[idx, comfortableIdx], 3) > 0)
                    serieData.GetOrAddComponent<ItemStyle>().color = Color.green;
                else
                    serieData.GetOrAddComponent<ItemStyle>().color = Color.red;
                barChartComfortable.AddXAxisData(ScenarioCode.factors[idx], 0);

                var serieData2 = barChartDecision.AddData(0, Math.Round(coefficientMatrix[idx, decisionIdx], 3), ScenarioCode.factors[idx]);

                if (Math.Round(coefficientMatrix[idx, decisionIdx], 3) > 0)
                    serieData2.GetOrAddComponent<ItemStyle>().color = Color.green;
                else
                    serieData2.GetOrAddComponent<ItemStyle>().color = Color.red;
                barChartDecision.AddXAxisData(ScenarioCode.factors[idx], 0);
            }


            // calculate the abs. max/min index
            int mostComfortableIdx = comfortableFactors.AbsoluteMaximumIndex();
            int leastComfortableIdx = comfortableFactors.AbsoluteMinimumIndex();
            int mostDecisionIdx = decisionFactors.AbsoluteMaximumIndex();
            int leastDecisionIdx = decisionFactors.AbsoluteMinimumIndex();

            // text of analyzing results
            Text text1 = resultRoot.Find("Text1").GetComponent<Text>();
            text1.text = "The factors that most impacts your <size=65>comfortable level</size> is:\n" + 
                "<color=" + ScenarioCode.colorsString[mostComfortableIdx] + "><size=50>" + ScenarioCode.factors[mostComfortableIdx] +
                " (" + comfortableFactors[mostComfortableIdx].ToString("N03") + ")" + "</size></color>\n" +
                "The factors that least impacts your <size=65>comfortable level</size> is:\n" +
                "<color=" + ScenarioCode.colorsString[leastComfortableIdx] + "><size=50>" + ScenarioCode.factors[leastComfortableIdx] +
                " (" + comfortableFactors[leastComfortableIdx].ToString("N03") + ")" + "</size></color>\n" +
                "The factors that most impacts your <size=65>decision</size> is:\n" +
                "<color=" + ScenarioCode.colorsString[mostDecisionIdx] + "><size=50>" + ScenarioCode.factors[mostDecisionIdx] +
                " (" + decisionFactors[mostDecisionIdx].ToString("N03") + ")" + "</size></color>\n" +
                "The factors that least impacts your <size=65>decision</size> is:\n" +
                "<color=" + ScenarioCode.colorsString[leastDecisionIdx] + "><size=50>" + ScenarioCode.factors[leastDecisionIdx] +
                " (" + decisionFactors[leastDecisionIdx].ToString("N03") + ")" + "</size></color>";

        }
    }
}
