using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Page90ManagerScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
//        Invoke("ChangeScene", 45.0f);
        Invoke("ChangeScene", 15.0f);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("100.インターバル");
    }



}
