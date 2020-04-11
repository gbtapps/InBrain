using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Page30ManagerScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("40.センサー接続");
    }

    public void ChangeBackScene()
    {
        SceneManager.LoadScene("20.性別年齢選択");
    }


}
