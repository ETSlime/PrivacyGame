//#region 
//// D:\UnityProjects\PrivacyGame\Assets\Plugins\MathNet.Numerics.dll
//#endregion

//using UnityEngine;

//using MathNet.Numerics.LinearAlgebra;
//using MathNet.Numerics.LinearAlgebra.Double;

//public class PythonExample : MonoBehaviour {

//    // Use this for initialization
//    void Start()
//    {
//        var engine = Python.CreateEngine();

//        ICollection<string> searchPaths = engine.GetSearchPaths();

//        //Path to the folder of greeter.py
//        searchPaths.Add(Application.dataPath);
//        //Path to the Python standard library
//        //searchPaths.Add(Application.dataPath + @"\Python\Lib\");
//        searchPaths.Add(@"D:\anaconda3\envs\game\Lib");
//        engine.SetSearchPaths(searchPaths);

//        dynamic py = engine.ExecuteFile(Application.dataPath + @"\Python\greeter.py");
//        dynamic greeter = py.Greeter("Mika");
//        Debug.Log(py.main());

//    //verify: the following should be approximately(0, 0, 0)
//        Player.results = (A * (2 * nullspace[0] - 3 * nullspace[1])).ToString();
//        Debug.Log(ScenarioCode.scenarios["a"]);
//        ScenarioCode.Print(ScenarioCode.scenarios["a"]);
//    }

//    // Update is called once per frame
//    void Update () 
//    {
		
//	}
//}
