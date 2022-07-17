

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// �򵥵�Unity ֱ�ӵ��� Python �ķ���
/// </summary>
public class LoadPython : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string basePath = Application.dataPath + "/Save/";

        UnityEngine.Debug.Log(SceneManager.sceneCount);
        if (SceneManager.sceneCount == 1)
            CallPythonHW(basePath + "UnityLoad.py");
        //CallPythonAddHW(basePath + "AddHelloWorld.py", 3.6f, 5.9f);
    }

    void CallPythonHW(string pyScriptPath)
    {
        CallPythonBase(pyScriptPath);
    }

    void CallPythonAddHW(string pyScriptPath, float a, float b)
    {
        CallPythonBase(pyScriptPath, a.ToString(), b.ToString());
    }

    /// <summary>
    /// Unity ���� Python
    /// </summary>
    /// <param name="pyScriptPath">python �ű�·��</param>
    /// <param name="argvs">python ��������</param>
    public void CallPythonBase(string pyScriptPath, params string[] argvs)
    {
        Process process = new Process();

        // ptython �Ľ�����λ�� python.exe
        process.StartInfo.FileName = @"D:\anaconda3\python.exe";

        // �ж��Ƿ��в�����Ҳ�ɲ����������жϣ�
        if (argvs != null)
        {
            // ��Ӳ��� ����ϳɣ�python xxx/xxx/xxx/test.python param1 param2��
            foreach (string item in argvs)
            {
                pyScriptPath += " " + item;
            }
        }
        UnityEngine.Debug.Log(pyScriptPath);

        process.StartInfo.UseShellExecute = false;
        process.StartInfo.Arguments = pyScriptPath;     // ·��+����
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.CreateNoWindow = true;        // ����ʾִ�д���

        // ��ʼִ�У���ȡִ���������ӽ�����ί��
        process.Start();
        process.BeginOutputReadLine();
        process.OutputDataReceived += new DataReceivedEventHandler(GetData);
        process.WaitForExit();
    }

    /// <summary>
    /// ������ί��
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void GetData(object sender, DataReceivedEventArgs e)
    {

        // �����Ϊ�ղŴ�ӡ�����ڿ����Լ�������Ͳ�ͬ�Ĵ���ί�У�
        if (string.IsNullOrEmpty(e.Data) == false)
        {
            UnityEngine.Debug.Log(e.Data);
        }
    }
}