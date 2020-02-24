using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnalysisResultHeaderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToSummary()
    {
        SceneManager.LoadScene("110.検査結果");        
    }

    public void MoveToSpeed()
    {
        SceneManager.LoadScene("120.詳細1認知速度");
    }
    public void MoveToAttention()
    {
        SceneManager.LoadScene("130.詳細2注意力");
    }
    public void MoveToActivity()
    {
        SceneManager.LoadScene("140.詳細3脳活動");
    }




}
