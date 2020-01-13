using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Page150ManagerScript : MonoBehaviour
{





    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("=====   page150 start() start   =====================");
        Debug.Log("=====   page150 start() end   =====================");

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("160.終了ページ");
    }

    public void ChangeBackScene()
    {
        SceneManager.LoadScene("140.詳細3－脳活動");
    }



}
