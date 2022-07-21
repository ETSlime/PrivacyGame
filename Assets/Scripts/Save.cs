using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


/// <summary>
///
/// </summary>
public class Save
{
    
    // playerinfo class, which contains info to be saved
    static private PlayerInfo CreateSave()
    {
        PlayerInfo playerInfo = new PlayerInfo();
        playerInfo.correct = Player.correct;
        playerInfo.userName = Player.userName;
        playerInfo.points = Player.points;
        playerInfo.questionFinished = Player.questionFinished;
        playerInfo.finished = Player.finished;
        playerInfo.getCoins = Player.getCoins;
        playerInfo.tips = Player.tips;
        playerInfo.tipsBought = Player.tipsBought;
        playerInfo.smartwatch = Player.smartwatch;
        playerInfo.smartphone = Player.smartphone;
        playerInfo.tablet = Player.tablet;
        playerInfo.tipStates = Player.tipStates;
        playerInfo.answers = Player.answers;
        playerInfo.mainTutorial = Player.mainTutorial;
        return playerInfo;
    }

    static public void SaveByJSON()
    {
        // create a playerinfo object
        PlayerInfo playerInfo = CreateSave();
        // convert playerinfo to json string
        string JSONString = JsonUtility.ToJson(playerInfo, true);
        // create stream writer object
        if (!Directory.Exists(Application.dataPath + "/Save/"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Save/");
        }
        StreamWriter sw = new StreamWriter(Application.dataPath + "/Save/playerInfo_" + Player.userName + ".json");
        // write json string to stream writer
        sw.Write(JSONString);
        // close the sw
        sw.Close();
    }
    
    static public void deleteSave(string userName)
    {
        string path = Application.dataPath + "/Save/";
        if (File.Exists(path + "playerInfo_" + userName + ".json"))
        {
            File.Delete(path + "playerInfo_" + userName + ".json");
            File.Delete(path + "playerInfo_" + userName + ".json.meta");
        }
    }

    static public PlayerInfo LoadByJSON(string userName)
    {
        if (File.Exists(Application.dataPath + "/Save/playerInfo_" + userName + ".json"))
        //判断文件是否创建
        {
            StreamReader sr = new StreamReader(Application.dataPath + "/Save/playerInfo_" + userName + ".json");
            //从流中读取字符串
            string JsonString = sr.ReadToEnd();
            //ReadToEnd()方法可以读取从流当前位置到结尾的所有字符
            //还有Read()方法，但是只读了一个字符，还有更多方法捏懒得打了
            sr.Close();
            //把流关了
            PlayerInfo playerInfo = JsonUtility.FromJson<PlayerInfo>(JsonString);
            //该方法属于泛型方法T，需要给出明确的类型定义，所以要写<Save>
            //属于是常规方式了

            return playerInfo;
        }
        else
        {
            Debug.LogError("File Not Found.");
        }
        return null;
    }

    static public List<string> GetUserName()
    {
        string path = Application.dataPath + "/Save/";
        if (Directory.Exists(path))
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*", SearchOption.TopDirectoryOnly);
            List<string> userName = new List<string>();
            foreach (var file in files)
            {
                if (file.Name.EndsWith(".json"))
                {
                    
                    string name = file.Name.Replace("playerInfo_", string.Empty).Replace(".json", string.Empty);
                    userName.Add(name);
                }
            }
            return userName;
        }
        return null;
    }
    static public void LoadData(PlayerInfo playerInfo)
    {
        Player.userName = playerInfo.userName;
        Player.correct = playerInfo.correct;
        Player.finished = playerInfo.finished;
        Player.points = playerInfo.points;
        Player.tips = playerInfo.tips;
        Player.tipsBought = playerInfo.tipsBought;
        Player.smartphone = playerInfo.smartphone;
        Player.smartwatch = playerInfo.smartwatch;
        Player.tablet = playerInfo.tablet;
        Player.questionFinished = playerInfo.questionFinished;
        Player.getCoins = playerInfo.getCoins;
        Player.tipStates = playerInfo.tipStates;
        Player.answers = playerInfo.answers;
        Player.mainTutorial = playerInfo.mainTutorial;
    }
}
