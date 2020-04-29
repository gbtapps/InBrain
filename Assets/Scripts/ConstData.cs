using System.Collections.Generic;
using UnityEngine;


//  固定データを置いておくためのクラス
public class ConstData : MonoBehaviour
{
#if UNITY_EDITOR
    //public const bool DebugMode = false;
    public const bool DebugMode = true;
#else
    public const bool DebugMode = false;
    //public const bool DebugMode = true;
#endif

    public const string BLE_address = "BLE_ADDRESS";

}
