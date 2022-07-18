using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class ScenarioCode
{
    // define scenario ID
    static public string cs_ID_1 = "cs_ID_1";
    static public string cs_ID_2 = "cs_ID_2";
    static public string cs_ID_3 = "cs_ID_3";
    static public string cs_ID_4 = "cs_ID_4";
    static public string cs_ID_5 = "cs_ID_5";
    static public string cs_ID_6 = "cs_ID_6";
    static public string cs_ID_7 = "cs_ID_7";
    static public string cs_ID_8 = "cs_ID_8";
    static public string cs_ID_9 = "cs_ID_9";
    static public string cs_ID_10 = "cs_ID_10";
    static public string cs_ID_11 = "cs_ID_11";
    static public string cs_ID_12 = "cs_ID_12";
    static public string cs_ID_13 = "cs_ID_13";
    static public string cs_ID_14 = "cs_ID_14";
    static public string cs_ID_15 = "cs_ID_15";

    static public string lb_ID_1 = "lb_ID_1";
    static public string lb_ID_2 = "lb_ID_2";
    static public string lb_ID_3 = "lb_ID_3";
    static public string lb_ID_4 = "lb_ID_4";
    static public string lb_ID_5 = "lb_ID_5";
    static public string lb_ID_6 = "lb_ID_6";
    static public string lb_ID_7 = "lb_ID_7";
    static public string lb_ID_8 = "lb_ID_8";
    static public string lb_ID_9 = "lb_ID_9";
    static public string lb_ID_10 = "lb_ID_10";
    static public string lb_ID_11 = "lb_ID_11";
    static public string lb_ID_12 = "lb_ID_12";
    static public string lb_ID_13 = "lb_ID_13";
    static public string lb_ID_14 = "lb_ID_14";
    static public string lb_ID_15 = "lb_ID_15";

    static public string hm_ID_1 = "hm_ID_1";
    static public string hm_ID_2 = "hm_ID_2";
    static public string hm_ID_3 = "hm_ID_3";
    static public string hm_ID_4 = "hm_ID_4";
    static public string hm_ID_5 = "hm_ID_5";
    static public string hm_ID_6 = "hm_ID_6";
    static public string hm_ID_7 = "hm_ID_7";
    static public string hm_ID_8 = "hm_ID_8";

    static public string fh_ID_1 = "fh_ID_1";
    static public string fh_ID_2 = "fh_ID_2";
    static public string fh_ID_3 = "fh_ID_3";
    static public string fh_ID_4 = "fh_ID_4";
    static public string fh_ID_5 = "fh_ID_5";
    static public string fh_ID_6 = "fh_ID_6";
    static public string fh_ID_7 = "fh_ID_7";

    static public string wk_ID_1 = "wk_ID_1";
    static public string wk_ID_2 = "wk_ID_2";
    static public string wk_ID_3 = "wk_ID_3";
    static public string wk_ID_4 = "wk_ID_4";
    static public string wk_ID_5 = "wk_ID_5";
    static public string wk_ID_6 = "wk_ID_6";
    static public string wk_ID_7 = "wk_ID_7";
    static public string wk_ID_8 = "wk_ID_8";
    static public string wk_ID_9 = "wk_ID_9";
    static public string wk_ID_10 = "wk_ID_10";
    static public string wk_ID_11 = "wk_ID_11";
    static public string wk_ID_12 = "wk_ID_12";
    static public string wk_ID_13 = "wk_ID_13";
    static public string wk_ID_14 = "wk_ID_14";
    static public string wk_ID_15 = "wk_ID_15";

    static public string pr_ID_1 = "pr_ID_1";
    static public string pr_ID_2 = "pr_ID_2";
    static public string pr_ID_3 = "pr_ID_3";
    static public string pr_ID_4 = "pr_ID_4";
    static public string pr_ID_5 = "pr_ID_5";
    static public string pr_ID_6 = "pr_ID_6";
    static public string pr_ID_7 = "pr_ID_7";
    static public string pr_ID_8 = "pr_ID_8";
    static public string pr_ID_9 = "pr_ID_9";
    static public string pr_ID_10 = "pr_ID_10";
    static public string pr_ID_11 = "pr_ID_11";
    static public string pr_ID_12 = "pr_ID_12";
    static public string pr_ID_13 = "pr_ID_13";
    static public string pr_ID_14 = "pr_ID_14";
    static public string pr_ID_15 = "pr_ID_15";
    
    // define data dimention
    static public int x_dim = 6;
    static public int y_dim = 2;
    // define factor name
    static public string[] factors = {"location", "device type", "purpose", "retention time", "shared", "benefit" };
    // define color
    static public Color purple = new Color(131f/255f, 7f/255f, 131f/255f);
    static public Color[] colors = { Color.red, Color.blue, Color.grey, purple, Color.magenta, Color.yellow};
    static public string[] colorsString = { "red", "blue", "grey", "purple", "magenta", "yellow" };

    // define data code
    static public Dictionary<string, List<double>> scenarios = new Dictionary<string, List<double>>
    {
        // key: scenarioID     value:  location, device, purpose, retention, shared, benefit
        {cs_ID_1, new List<double>{0, 0.5, 0.9, 0, 0, 1}},
        {cs_ID_2, new List<double>{0, 0.5, 0.9, 1, 0, 1}},
        {cs_ID_3, new List<double>{0, 0.5, 0, 0.8, 1, 1}},
        {cs_ID_4, new List<double>{0, 0.5, 0, 0.2, 1, 1}},
        {cs_ID_5, new List<double>{0, 0.5, 0.9, 0, 1, 1}},

        {cs_ID_6, new List<double>{0, 0.9, 0.7, 0.2, 0, 1}},
        {cs_ID_7, new List<double>{0, 0.9, 0.7, 1, 0, 1}},
        {cs_ID_8, new List<double>{0, 0.9, 0, 0.2, 0, 1}},
        {cs_ID_9, new List<double>{0, 0, 1, 0.4, 0, 1}},
        {cs_ID_10, new List<double>{0, 0, 1, 1, 0, 1}},

        {cs_ID_11, new List<double>{0, 0.7, 0.1, 0, 0, 0}},
        {cs_ID_12, new List<double>{0, 0.7, 0.1, 0.4, 0, 0}},
        {cs_ID_13, new List<double>{0, 0.7, 0, 1, 0, 1}},
        {cs_ID_14, new List<double>{0, 0.2, 0.1, 0, 0, 0}},
        {cs_ID_15, new List<double>{0, 0.2, 0.5, 0, 0, 1}},

        {lb_ID_1, new List<double>{0.4, 1, 0.6, 0.8, 0, 1}},
        {lb_ID_2, new List<double>{0.4, 1, 0.6, 1, 0, 1}},
        {lb_ID_3, new List<double>{0.4, 1, 0.6, 0, 0, 1}},
        {lb_ID_4, new List<double>{0.4, 0.9, 0.6, 0, 0, 1}},
        {lb_ID_5, new List<double>{0.4, 0.9, 0.6, 1, 0, 1}},

        {lb_ID_6, new List<double>{0.4, 0, 1, 0.8, 0, 1}},
        {lb_ID_7, new List<double>{0.4, 0, 1, 0.2, 0, 1}},
        {lb_ID_8, new List<double>{0.4, 1, 0, 1, 0, 1}},
        {lb_ID_9, new List<double>{0.4, 1, 0.6, 1, 0, 1}},
        {lb_ID_10, new List<double>{0.4, 1, 0.6, 0, 0, 1}},

        {lb_ID_11, new List<double>{0.4, 0.7, 0.7, 0, 0, 1}},
        {lb_ID_12, new List<double>{0.4, 0.7, 0.7, 0.4, 0, 1}},
        {lb_ID_13, new List<double>{0.4, 0.2, 0.1, 0, 0, 0}},
        {lb_ID_14, new List<double>{0.4, 0.2, 0.5, 0, 0, 1}},
        {lb_ID_15, new List<double>{0.4, 0.2, 0.5, 0.4, 0, 1}},

        {hm_ID_1, new List<double>{1, 0.2, 0.5, 0.8, 0, 1}},
        {hm_ID_2, new List<double>{1, 0.2, 0.5, 0.2, 0, 1}},
        {hm_ID_3, new List<double>{1, 0.2, 0.5, 0.4, 0, 1}},
        {hm_ID_4, new List<double>{1, 0.7, 0.8, 0.8, 1, 1}},
        {hm_ID_5, new List<double>{1, 0.7, 0.8, 0.2, 1, 1}},

        {hm_ID_6, new List<double>{1, 0, 0, 0.2, 1, 1}},
        {hm_ID_7, new List<double>{1, 0, 1, 0.4, 1, 1}},
        {hm_ID_8, new List<double>{1, 0, 1, 1, 1, 1}},

        {fh_ID_1, new List<double>{0.8, 0.2, 0.5, 0, 0, 1}},
        {fh_ID_2, new List<double>{0.8, 0.2, 0.5, 0.4, 0, 1}},
        {fh_ID_3, new List<double>{0.8, 0.7, 0.8, 0.8, 1, 1}},
        {fh_ID_4, new List<double>{0.8, 0.7, 0.8, 0.2, 1, 1}},

        {fh_ID_5, new List<double>{ 0.8, 0, 0, 0.8, 1, 1 }},
        {fh_ID_6, new List<double>{0.8, 0, 1, 0.8, 1, 1}},
        {fh_ID_7, new List<double>{ 0.8, 0, 1, 0.4, 1, 1}},

        {wk_ID_1, new List<double>{0.2, 0.5, 0.9, 0.2, 1, 1}},
        {wk_ID_2, new List<double>{0.2, 0.5, 0.9, 1, 1, 1}},
        {wk_ID_3, new List<double>{0.2, 0.7, 0.2, 0.8, 0, 0}},
        {wk_ID_4, new List<double>{0.2, 0.7, 0.2, 0.4, 0, 0}},
        {wk_ID_5, new List<double>{0.2, 0.7, 0.7, 0.4, 1, 1}},

        {wk_ID_6, new List<double>{0.2, 0.2, 0.7, 0.8, 0, 1}},
        {wk_ID_7, new List<double>{0.2, 0.2, 0.7, 0.4, 0, 1}},
        {wk_ID_8, new List<double>{0.2, 0.2, 0.5, 0.4, 0, 0}},
        {wk_ID_9, new List<double>{0.2, 0.5, 0, 0.4, 0, 1}},
        {wk_ID_10, new List<double>{0.2, 0.5, 0.9, 0.4, 0, 1}},

        {wk_ID_11, new List<double>{0.2, 0, 0, 0.8, 0, 1}},
        {wk_ID_12, new List<double>{0.2, 0, 1, 0.8, 0, 1}},
        {wk_ID_13, new List<double>{0.2, 0, 1, 0.2, 0, 1}},
        {wk_ID_14, new List<double>{0.2, 1, 0.2, 0, 0, 0}},
        {wk_ID_15, new List<double>{0.2, 1, 0.2, 1, 0, 0}},

        {pr_ID_1, new List<double>{0.6, 0.7, 0, 0.8, 1, 1}},
        {pr_ID_2, new List<double>{0.6, 0.7, 0.8, 0.8, 1, 1}},
        {pr_ID_3, new List<double>{0.6, 0.7, 0.8, 1, 1, 1}},
        {pr_ID_4, new List<double>{0.6, 0.2, 0.5, 0.2, 0, 1}},
        {pr_ID_5, new List<double>{0.6, 0.2, 0.5, 1, 0, 1}},

        {pr_ID_6, new List<double>{0.6, 0.2, 0.8, 0.8, 1, 1}},
        {pr_ID_7, new List<double>{0.6, 0.2, 0.8, 0.2, 1, 1}},
        {pr_ID_8, new List<double>{0.6, 0, 0, 0.8, 0, 1}},
        {pr_ID_9, new List<double>{0.6, 0, 0, 1, 0, 1}},
        {pr_ID_10, new List<double>{0.6, 0, 1, 1, 0, 1}},

        {pr_ID_11, new List<double>{0.6, 0.5, 0.9, 0, 0, 1}},
        {pr_ID_12, new List<double>{0.6, 0.5, 0.9, 1, 0, 1}},
        {pr_ID_13, new List<double>{0.6, 0.5, 0, 0.2, 1, 1}},
        {pr_ID_14, new List<double>{0.6, 0.5, 0.9, 0.2, 1, 1}},
        {pr_ID_15, new List<double>{0.6, 0.5, 0.9, 0.4, 1, 1}},
    };
}
