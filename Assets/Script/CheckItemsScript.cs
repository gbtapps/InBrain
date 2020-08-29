using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItemsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        foreach (var key in ES3.GetKeys())
        {
            Debug.Log(key);
//            ES3.DeleteKey(key);
        }





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
