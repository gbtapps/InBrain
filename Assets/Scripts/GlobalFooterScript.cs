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
        SceneManager.LoadScene("S100Home");        
    }

    public void MoveToAnalysis()
    {
        SceneManager.LoadScene("S500NoticeBrainAnalysis");
    }
    public void MoveToBrainEx()
    {
        SceneManager.LoadScene("S200BrainExMenu");
    }
    public void MoveToInfo()
    {
        SceneManager.LoadScene("S300Info");
    }
    public void MoveToMyPage()
    {
        SceneManager.LoadScene("S400MyPage");
    }




}
