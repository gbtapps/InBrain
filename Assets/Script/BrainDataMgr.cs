﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class BrainDataMgr
{
    /** 表示させる脳活性度を更新させるかどうか */
    static bool isupdateActivenesses = false;
    static List<bool> isupdateActivenessesBuffer;

    static public void Start(BrainDataFeedbacker.Type _type)
    {
        if (Hot2gApplication.eMode.Connecting <= Hot2gApplication.Instance.mode)
        {
            Debug.Log("BMBrainMgr.Start()");
            Hot2gApplication.Instance.StartRecieve(_type);
            
        }
        isupdateActivenessesBuffer = new List<bool>();
    }

    static public void End()
    {
        Debug.Log("BMBrainMgr.End()");
        Hot2gApplication.Instance.StopRecieve();
    }

    static public float GetValue()
    {
        Debug.Log("BMBrainMgr.GetValue()");
        return (float)Hot2gApplication.Instance.calcActivenessFromBuffered();
    }

    static public float GetValue(int startIdx)
    {
        Debug.Log("BMBrainMgr.GetValue2()");
        return (float)Hot2gApplication.Instance.calcActivenessFromBuffered(startIdx);
    }
}
