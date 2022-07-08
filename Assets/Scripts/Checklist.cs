using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class Checklist : MonoBehaviour
{
    public const string CHECKLIST_UPDATE = "CHECKLIST_UPDATE";
    private Text dataType;
    private Text deviceType;
    private Text retentionTime;
    private Text purpose;
    private void Start()
    {
        dataType = this.transform.GetChild(0).GetComponent<Text>();
        deviceType = this.transform.GetChild(1).GetComponent<Text>();
        retentionTime = this.transform.GetChild(2).GetComponent<Text>();
        purpose = this.transform.GetChild(4).GetComponent<Text>();
        EventDispatcher.instance.Regist(CHECKLIST_UPDATE, UpdateChecklist);

        dataType.text = "Data type: " + "\n<color=green>" + "None" + "</color>";
        deviceType.text = "Device type: " + "\n<color=blue>" + "None" + "</color>";
        retentionTime.text = "Retention time: " + "\n<color=purple>" + "None" + "</color>";
        purpose.text = "Purpose: " + "\n<color=grey>" + "\nNone" + "</color>";
    }


    private void OnDestroy()
    {
        EventDispatcher.instance.UnRegist(CHECKLIST_UPDATE, UpdateChecklist);
    }
    /// <summary>
    /// Update different factors
    /// </summary>
    /// <param name="args"></param>args[0] data type, args[1] device type, args[2] retention time, args[3] purpose
    private void UpdateChecklist(params object[] args)
    {
        if (args.Length >= 1) dataType.text = "Data type: " + "\n<color=green>" + (string)args[0] + "</color>";
        if (args.Length >= 2) deviceType.text = "Device type: " + "\n<color=blue>" + (string)args[1] + "</color>";
        if (args.Length >= 3) retentionTime.text = "Retention time: " + "\n<color=purple>" + (string)args[2] + "</color>";
        if (args.Length >= 4) purpose.text = "Purpose: " + "\n<color=grey>\n" + (string)args[3] + "</color>";
    }
}
