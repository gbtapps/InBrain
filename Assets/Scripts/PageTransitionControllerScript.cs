using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageTransitionControllerScript : MonoBehaviour
{

    public string ClassName = "PageTransitionControllerScript";


    public string GetClassName()
    {
        return ClassName;
    }

    public void MoveToBrainExSpeedTouch()
    {
        SceneManager.LoadScene("21.BrainExSpeedTouch");


    }

    public void MoveToBrainExMenu()
    {
        Debug.Log("PageTransitionControllerScript.MoveToBrainExMenu");
        SceneManager.LoadScene("20.BrainExMenu");
  

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
