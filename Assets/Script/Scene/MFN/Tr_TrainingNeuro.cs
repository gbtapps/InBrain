using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

using System.IO;
using System;

using UnityEngine.SceneManagement;



//ニューロフィードバック
//脳活動を上げ下げするやつ！
public class Tr_TrainingNeuro : SceneBase
{

    //    const float AIR_PLANE_HEIGHT = 100;
    //    const float AREA_HEIGHT = 1920 - AIR_PLANE_HEIGHT;

    //    const float SCREEN_EDGE_DISTANCE = 0.2f; //画面端の位置 脳活動値での距離
    //    const float RING_DISTANCE = 0.05f; //リングの位置 脳活動値での距離(要らないかも)

    enum STATE
    {
        START,
        ADD,
        MOVE,
        FIN
    }

    STATE state;


    /*
    Timer timer;
    */



    int level = 0;
    bool firstStart = true;


    //--------------------------------------------------------
    //脳波関連
    float debugXbValue = 0.2f; //よくわからんので仮脳波
    float avgXbValue = 0.2f;



    /************************************************************************************/
    //added by moritomi from here

    //現在脳血流
    float xbValue;
    //現在脳血流と平均との差分
    float _length;


    //タイムマネジメント
    float cnt = 0;
    [SerializeField] Text SpentTime;
    [SerializeField] Text cntValue;

    //取得データマネジメント
    List<float> Xb01ValueList = new List<float>();

    //デバッグ
    [SerializeField] Text DataCount;
    [SerializeField] Text BrainFlow;
    [SerializeField] Text XbValue;
    [SerializeField] Text AvgXbValue;


    // Chart making
    // CHART_LEFT_MARGIN x2 + BRAIN_VALUES_COUNT = 360
    const int CHART_LEFT_MARGIN = 10;
    const int BRAIN_VALUES_COUNT = 340;
    [SerializeField] GameObject BrainValueBackgroudImage;
    [SerializeField] GameObject target;
    GameObject[] BrainValueColumnArray = new GameObject[BRAIN_VALUES_COUNT];

    float PreviousXbValue = 0;
    float ColumnValue = 100;


    //Values
    List<float> BrainValueList = new List<float>();
    List<float> BrainValueDeviation = new List<float>();


    // Time controll
    float SumDeltatime;
    int p = 0;

    //Countdown
    [SerializeField] GameObject CountdownPanelImage;
    public float DeltaTimeCount = 0f;
    public Text CountdownText;
    public int CountdownInt;

    // Debug
    [SerializeField] Text AdjustBrainValueText;
    [SerializeField] Text BrainValueText;
    [SerializeField] Text TestValueText;
    int DEBUGSTRINGLIMIT = 100;

    [SerializeField] Text EstateText;
    [SerializeField] Text EmodeText;

    // log
//    public int[] logData; // Logデータの宣言 テスト
    public float[] logData; // Logデータの宣言 テスト
    [SerializeField] Text ParmPathText;
    [SerializeField] Text TempPathText;

    // finish process
    public float SumDeltaTimeScene;
    [SerializeField] int SceneLimitTime;
    [SerializeField] string ActiveSceneName;


    //added by moritomi until here
    /**********************************************************************/


    void Start()
    {
        //ログ出力（テスト）
//        logData = new int[] { 1, 3, 5, 7, 9 }; // 仮のLogデータ
//        logData = new float[] { 1.2f, 3.1f, 5.6f, 7.2f, 9.9f }; // 仮のLogデータ
//        LogSave(logData, "logData"); // Logデータをcsv形式で書き出す


        //Get active scene name
        ActiveSceneName = SceneManager.GetActiveScene().name;

        //Add countdown time to scene limit time
        SceneLimitTime += CountdownInt;

        //Start countdown
        CountdownStart();


        CommonHeaderMfn.Instance.SetView(false);

#if !BLUE_DEBUG
        BrainDataMgr.Start(BrainDataFeedbacker.Type.NEURO);
#endif

        level = 9;


        //-------------------------------------
        //開始！
        state = STATE.START;


        firstStart = true;



    }

    private void Update()
    {

        //Show countdown
        CountdownUpdate();

        //Controll behavior
        switch (state)
        {
            case STATE.START:
                UpdateStart();
                break;
            case STATE.ADD:
                //                ringMgr.AddOneSet(level);
                state = STATE.MOVE;
                break;
            case STATE.MOVE:
                UpdateMove();

                //added by moritomi
                UpdateChart();

                break;

            case STATE.FIN:
                break;
        }

        // To try to draw chart instead of removing sensor
        //        UpdateChart();


        //Finish process
        FinishProcess();





    }


    //紙飛行機登場。この隙に5秒間の脳波の平均値を取得
    //↑よくわからん

    void UpdateStart()
    {


        //OnHead状態で5秒間に変更
        if (Hot2gApplication.Instance.state2 == Hot2gApplication.eState.OnHead)
        {
            //added by moritomi
            //eStateOnHead
            EstateText.text = "Onhead: Yes";

            if (Hot2gApplication.Instance.mode == Hot2gApplication.eMode.RecieveData)//- Measureing data in stable status
            {
                cnt += Time.deltaTime;

                SpentTime.text = cnt.ToString();

                //added by moritomi
                //eModeRecieveData
                EmodeText.text = "RecieveData: Yes";

            }
            else
            {
                cnt = 0;//- counter reset because of unstable situation

                
                //added by moritomi
                //eModeRecieveData
                EmodeText.text = "RecieveData: No";
                //ColumnNumberReset

            }


        }
        else//- NOT On the head
        {


            cnt = 0;//- counter reset because of unstable situation

            //added by moritomi
            //eStateOnHead
            EstateText.text = "Onhead: No";
            //ColumnNumberReset

        }


        //デルタタイムで5秒経過　
        //        if (cnt >= 1)


        //5秒経過は飛行機が出てくるまでの溜め
        //タメがないなら1秒でOK、1秒でavgXBvalue obtainしている
        if (cnt >= 1)
        {
            cntValue.text = cnt.ToString();

            //前の1秒で平均値をとってる
            //avgXbValue = GetXBValue();//- Average from 4sec to 5sec in buffer
            avgXbValue = (float)Hot2gApplication.Instance.m_nfb.calcActivenessFromBufferedUsingLastData(10);//- ave last 1 sec (10points)


            //
            cnt = 0;
            state = STATE.ADD;//- 



        }


    }


    

    void UpdateMove()
    {


        //- Height of the air plane
        cnt += Time.deltaTime;
        if (cnt > 0.01f)
        {
            cnt = 0;

            //他の関数で変数値を使用したいためフィールド変数にした
            //            float xbValue = GetXBValue();
            //            float _length = xbValue - avgXbValue;

            //実測値
            xbValue = GetXBValue();

            //Add measured values to List
            Xb01ValueList.Add(xbValue);

            //偏差
            _length = xbValue - avgXbValue;




            // for debug from here **************************************************************

            //見せ方変更
            XbValue.text = xbValue.ToString() + "\n"+ XbValue.text;
            AvgXbValue.text = avgXbValue.ToString() + "\n"+ AvgXbValue.text;
            BrainFlow.text = _length + "\n"+ BrainFlow.text;


            if (XbValue.text.Length > DEBUGSTRINGLIMIT)
            {
                XbValue.text = XbValue.text.Substring(0, DEBUGSTRINGLIMIT);
                AvgXbValue.text = AvgXbValue.text.Substring(0, DEBUGSTRINGLIMIT);
                BrainFlow.text = BrainFlow.text.Substring(0, DEBUGSTRINGLIMIT);
            }

            
            
            DataCount.text = Xb01ValueList.Count.ToString();

            // for debug from here **************************************************************





            if (xbValue == 0.0f)
            {
                //実測値がゼロのためセンサー外れとみなし繋ぐところから
                state = STATE.START;

                //Show Error dialog and return to Previous scence.



            }




        }

        /*
        if (timer.time <= 0)
        {
            BrainDataMgr.End();


        }
        */


    }





    float GetXBValue()
    {
#if !BLUE_DEBUG

        float _value = BrainDataMgr.GetValue();
#else
        float _value = debugXbValue;
#endif

        return _value;
    }


    float GetXBValue(int startIdx)
    {
#if !BLUE_DEBUG

        float _value = BrainDataMgr.GetValue(startIdx);
#else
        float _value = debugXbValue;
#endif

        return _value;
    }



    void UpdateChart()
    {
        // It only acts on STATE.MOVE to be synced getting values and chart action.


        // Do once a second
        SumDeltatime += Time.deltaTime;
        if (SumDeltatime > 0.1f)
        {

            //            float bvalue = _Tr_TrainingNeuro._length;
            //            BrainValueText.text = bvalue.ToString() + "\n" + BrainValueText.text;

            float sin = Mathf.Sin(Time.time);


            //show chart

            //set size value


            if(PreviousXbValue < xbValue)
            {
                ColumnValue += 1.0f;
                if (ColumnValue > 200f)
                {
                    ColumnValue = 200;
                }
            }
            else if (PreviousXbValue > xbValue)
            {
                ColumnValue -= 1.0f;
                if(ColumnValue < 0f)
                {
                    ColumnValue = 0;
                }
            }

            PreviousXbValue = xbValue;


            //create, give position, give size, attach parent
            if (p < BRAIN_VALUES_COUNT)
            {
                // comment out for y-axis from 0 to -100 
                //                BrainValueColumnArray[p] = Instantiate(target, new Vector3(p + 30, 0, 0), Quaternion.identity);
                BrainValueColumnArray[p] = Instantiate(target, new Vector3(p + CHART_LEFT_MARGIN, -100, 0), Quaternion.identity);

                //                BrainValueColumnArray[p].GetComponent<RectTransform>().sizeDelta = new Vector2(1, BrainValueList[p]);
                BrainValueColumnArray[p].GetComponent<RectTransform>().sizeDelta = new Vector2(1, ColumnValue);
                BrainValueColumnArray[p].transform.SetParent(BrainValueBackgroudImage.transform, false);
            }
            else
            {
                //Move chart from right to left
                for (int i = 0; i < BRAIN_VALUES_COUNT - 1; i++)
                {
                    BrainValueColumnArray[i].GetComponent<RectTransform>().sizeDelta = BrainValueColumnArray[i + 1].GetComponent<RectTransform>().sizeDelta;
                }
//                BrainValueColumnArray[BRAIN_VALUES_COUNT - 1].GetComponent<RectTransform>().sizeDelta = new Vector2(1, BrainValueList[p]);
                BrainValueColumnArray[BRAIN_VALUES_COUNT - 1].GetComponent<RectTransform>().sizeDelta = new Vector2(1, ColumnValue);

                //  Debug.Log(BrainValueArray);


            }




            SumDeltatime = 0;
            p++;

            Debug.Log(p + " :p");


        }


    }


    void CountdownStart()
    {
        CountdownPanelImage.SetActive(true);
    }



    // Update is called once per frame
    void CountdownUpdate()
    {

        DeltaTimeCount += Time.deltaTime;


        if (DeltaTimeCount >= 1.0f)
        {

            DeltaTimeCount = 0.0f;


            if (CountdownInt > 0)
            {
                //カウントダウン表示
                CountdownText.text = CountdownInt.ToString();

            }
            else
            {

                CountdownPanelImage.SetActive(false);



            }

            //1秒たったのでカウントをダウンする
            CountdownInt--;

        }

    }

//    public void LogSave(int[] x, string fileName)

    public void LogSave(float[] x, string fileName)
    {
        StreamWriter sw; // これがキモらしい
        FileInfo fi;

        //日付をYYYYMMDD24hmmssで表示する文字列作成 
        DateTime now = DateTime.Now;
        string tempdatestring = now.Year.ToString() + now.Month.ToString() + now.Day.ToString()
            + now.Hour.ToString() + now.Minute.ToString() + now.Second.ToString();
        //        Debug.Log(tempdatestring);


        //ファイルを出力するパス
//        string temppathstring = Application.dataPath + "/Resources/";
        string temppathstring = UnityEngine.Application.persistentDataPath;


        //出力先ファイルパス
        // Aplication.dataPath で プロジェクトファイルがある絶対パスが取り込める
        //        fi = new FileInfo(Application.dataPath + "/Resources/" + fileName +tempdatestring+ ".csv");

        fi = new FileInfo(temppathstring + fileName + tempdatestring + ".csv");

        
  
        //パス情報
        //        UnityEngine.Application.persistentDataPath(永続性のある情報向け)
        //        UnityEngine.Application.temporaryCachePath(一時的な情報向け)


        Debug.Log("UnityEngine.Application.persistentDataPath: " + UnityEngine.Application.persistentDataPath);
        Debug.Log("UnityEngine.Application.temporaryCachePath: " + UnityEngine.Application.temporaryCachePath);
        ParmPathText.text = UnityEngine.Application.persistentDataPath;
        TempPathText.text = UnityEngine.Application.temporaryCachePath;

        sw = fi.AppendText();
        for (int i = 0; i < x.Length; i++)
        {
            sw.WriteLine(x[i].ToString());
        }
        sw.Flush();
        sw.Close();

    }


    // Update is called once per frame
    void FinishProcess()
    {

        ////////////////////////////
        //1秒毎に処理させるここから
        //
        SumDeltaTimeScene += Time.deltaTime;
        //        Debug.Log(DeltaTimeCount + " =DeltaTimeCount");

        if (SumDeltaTimeScene >= 1.0f)
        {

            SumDeltaTimeScene = 0.0f;

            //1秒たったのでカウントをダウンする
            SceneLimitTime--;

            if (SceneLimitTime == 0)
            {


                //                logData = new float[] { 1.2f, 3.1f, 5.6f, 7.2f, 9.9f }; // 仮のLogデータ

                logData = Xb01ValueList.ToArray();
                LogSave(logData, "logData"); // Logデータをcsv形式で書き出す
//                LogSave(Xb01ValueList, "logDataList"); // Logデータをcsv形式で書き出す

               




                Debug.Log(SceneLimitTime + " :SceneLimitTime");


                if (ActiveSceneName == "Tr_TrainingNeuro")
                {
                    Debug.Log("SceneManager.LoadScene>Tr_TraningSetting2nd");
                    SceneManager.LoadScene("Tr_TraningSetting2nd");

                }
                else if (ActiveSceneName == "Tr_TrainingNeuro2nd")
                {
                    Debug.Log("SceneManager.LoadScene>Tr_TraningSetting2nd");
                    SceneManager.LoadScene("Tr_TraningSetting3rd");

                }
                else if (ActiveSceneName == "Tr_TrainingNeuroTest")
                {
                    Debug.Log("SceneManager.LoadScene>T_TitleSelect");
                    SceneManager.LoadScene("T_TitleSelect");

                }
                else
                {
                    SceneManager.LoadScene("T_TitleSelect");

                }



            }


        }
        //
        //1秒毎に処理させるここまで
        ///////////////////////////////////

    }


}
