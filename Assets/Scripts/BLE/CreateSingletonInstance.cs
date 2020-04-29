using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSingletonInstance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BLEMgr.Create("BLEMgr", transform);
        BluetoothMgr.Create("BluetoothMgr", transform);
        Hot2gApplication.Create("Hot2gApplication", transform);

        DontDestroyOnLoad(this.gameObject);//- シーンマタギ 2020-0126 TK
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
