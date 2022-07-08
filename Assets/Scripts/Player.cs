using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
[System.Serializable]
public class Player
{
    static public string userName;
    static public float points;
    static public bool finished;
    static public int correct;
    static public int tips;
    static public int tipsBought;
    static public bool smartphone;
    static public bool smartwatch;
    static public bool tablet;
    // question state for each scene
    static public List<QuestionState> questionFinished;
    // correctness for each pop up quiz
    static public List<GetCoins> getCoins;
    // tips bought for each pop up quiz
    static public List<TipState> tipStates;

    static public void AddCorrect()
    {
        correct += 1;
    }

    static public void Init()
    {
        points = 0;
        finished = false;
        correct = 0;
        tips = 0;
        tipsBought = 0;
        smartphone = false;
        smartwatch = false;
        tablet = false;
        questionFinished = new List<QuestionState>();
        getCoins = new List<GetCoins>();
        tipStates = new List<TipState>();

    }
}

[System.Serializable]
public class PlayerInfo
{
    public string userName;
    public float points;
    public bool finished;
    public int correct;
    public int tips;
    public int tipsBought;
    public bool smartphone;
    public bool smartwatch;
    public bool tablet;
    public List<QuestionState> questionFinished;
    public List<GetCoins> getCoins;
    public List<TipState> tipStates;
}

[System.Serializable]
public class QuestionState
{
    public string questionId;
    public bool answered;
}

[System.Serializable]
public class GetCoins
{
    public string questionId;
    public bool get;
}

[System.Serializable]
public class TipState
{
    public string quizID;
    public bool[] tips = new bool[2] { false, false };
}
