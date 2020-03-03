using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class P20BrainExMenuController : MonoBehaviour
{

    public void MoveToSpeedTouch()
    {
        Debug.Log("bbb");

        SceneManager.LoadScene("21.BrainExSpeedTouch");
    }

    public void MoveToSpeedCalculation()
    {
        SceneManager.LoadScene("22.BrainExSpeedCalculation");
    }

    public void MoveToChangePanel()
    {
        SceneManager.LoadScene("23.BrainExChangePanel");
    }

    public void MoveToSymbolSearch()
    {
        SceneManager.LoadScene("24.BrainExSymbolSearch");
    }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("aaaa");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
