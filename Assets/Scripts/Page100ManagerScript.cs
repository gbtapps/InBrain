using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Page100ManagerScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeScene", 5.0f);
        Debug.Log("Page100");

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("110.検査結果");
    }



}
