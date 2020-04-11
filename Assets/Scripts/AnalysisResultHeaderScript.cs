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
        SceneManager.LoadScene("S526TestResultSummary");        
    }

    public void MoveToSpeed()
    {
        SceneManager.LoadScene("S527TestResultSpeed");
    }
    public void MoveToAttention()
    {
        SceneManager.LoadScene("S528TestResultAttention");
    }
    public void MoveToActivity()
    {
        SceneManager.LoadScene("S529TestResultBrain");
    }




}
