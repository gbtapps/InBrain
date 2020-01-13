using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Page40ManagerScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

        /*
         * 
         * ここにセンサー接続ロジックを書く
         * //    if ( センサー接続に成功 )
         *       {
         *              ChangeScene();
         *       }else if
         *       {
         *              ChangeScene1();
         *       }
         */
        Invoke("ChangeScene", 5.0f);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene1()
    {
        SceneManager.LoadScene("41.センサー接続2");
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("42.センサー接続3");
    }


}
