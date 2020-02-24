using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalFooterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToHome()
    {
        SceneManager.LoadScene("03.Home");        
    }

    public void MoveToAnalysis()
    {
        SceneManager.LoadScene("04.ConnectSensor");
    }
    public void MoveToBrainEx()
    {
        SceneManager.LoadScene("20.BrainExMenu");
    }
    public void MoveToInfo()
    {
        SceneManager.LoadScene("30.Info");
    }
    public void MoveToMyPage()
    {
        SceneManager.LoadScene("40.MyPage");
    }




}
