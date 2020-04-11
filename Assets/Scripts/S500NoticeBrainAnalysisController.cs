using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P05NoticeBrainAnalysisController : MonoBehaviour
{

    public void MoveToXb01Setting()
    {
        SceneManager.LoadScene("40.センサー接続");
    }

    public void MoveToResultAnalysis()
    {
        SceneManager.LoadScene("110.検査結果");

    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
