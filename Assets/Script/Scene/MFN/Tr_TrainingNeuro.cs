using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
    List<float> BloodFlows = new List<float>();
    //デバッグ
    [SerializeField] Text DataCount;
    [SerializeField] Text BrainFlow;
    [SerializeField] Text XbValue;
    [SerializeField] Text AvgXbValue;


    // Chart making
    const int BRAIN_VALUES_COUNT = 300;
    [SerializeField] GameObject BrainValueBackgroudImage;
    [SerializeField] GameObject target;
    GameObject[] BrainValueColumnArray = new GameObject[BRAIN_VALUES_COUNT];

    //Values
    List<float> BrainValueList = new List<float>();

    // Time controll
    float SumDeltatime;
    int p = 0;

    // Debug
    [SerializeField] Text BrainValueText;
    [SerializeField] Text TestValueText;
    int DEBUGSTRINGLIMIT = 100;

    [SerializeField] Text EstateText;
    [SerializeField] Text EmodeText;

    //added by moritomi until here
    /**********************************************************************/


    void Start()
    {
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
                break;
            case STATE.FIN:
                break;
        }



        //added by moritomi
        UpdateChart();



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
            EstateText.text = "eState.Onhead: Yes";

            if (Hot2gApplication.Instance.mode == Hot2gApplication.eMode.RecieveData)//- Measureing data in stable status
            {
                cnt += Time.deltaTime;

                SpentTime.text = cnt.ToString();

                //added by moritomi
                //eModeRecieveData
                EstateText.text = "eMode.RecieveData: Yes";

            }
            else
            {
                cnt = 0;//- counter reset because of unstable situation

                
                //added by moritomi
                //eModeRecieveData
                EstateText.text = "eMode.RecieveData: No";
                //ColumnNumberReset
                p = 0;

            }


        }
        else//- NOT On the head
        {


            cnt = 0;//- counter reset because of unstable situation

            //added by moritomi
            //eStateOnHead
            EstateText.text = "eState.Onhead: No";
            //ColumnNumberReset
            p = 0;

        }


        //デルタタイムで5秒経過した処理
        //        if (cnt >= 5)

        //5秒は長いので2秒にした
        if (cnt >= 2)
        {

            cntValue.text = cnt.ToString();


            //着けている時間が5秒越えた以降に5秒毎にavgXBValueの値を更新


            //avgXbValue = GetXBValue();//- Average from 4sec to 5sec in buffer
            avgXbValue = (float)Hot2gApplication.Instance.m_nfb.calcActivenessFromBufferedUsingLastData(10);//- ave last 1 sec (10points)


            //
            cnt = 0;
            state = STATE.ADD;//- 



        }


    }


    public float GetBrainValue()
    {
        return _length;
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

            xbValue = GetXBValue();
            _length = xbValue - avgXbValue;

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


            BloodFlows.Add(_length);
            DataCount.text = BloodFlows.Count.ToString();


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


        //        BrainValueText.text = bvalue.ToString()+"\n"+BrainValueText.text;




        // Do once a second
        SumDeltatime += Time.deltaTime;
        if (SumDeltatime > 0.1f)
        {

            //            float bvalue = _Tr_TrainingNeuro._length;
            //            BrainValueText.text = bvalue.ToString() + "\n" + BrainValueText.text;

            float sin = Mathf.Sin(Time.time);
            //            BrainValueList.Add(sin * 50 + 50);



            //brainbroodflowvalue = bbfvalue
            float bbfvalue = _length;

            if(bbfvalue < 0.1)
            {

            }


            BrainValueList.Add(bbfvalue);
            

            BrainValueText.text = _length.ToString() + "\n" + BrainValueText.text;
            TestValueText.text = (sin * 50 + 50).ToString() + "\n" + TestValueText.text;


/*
            if(TestValueText.text.Length > DEBUGSTRINGLIMIT)
            {
                BrainValueText.text = BrainValueText.text.Substring(0, DEBUGSTRINGLIMIT);
                TestValueText.text = TestValueText.text.Substring(0, DEBUGSTRINGLIMIT);
            }
            */




            if (p < BRAIN_VALUES_COUNT)
            {

                BrainValueColumnArray[p] = Instantiate(target, new Vector3(p + 30, 0, 0), Quaternion.identity);
                BrainValueColumnArray[p].GetComponent<RectTransform>().sizeDelta = new Vector2(1, BrainValueList[p]);
                BrainValueColumnArray[p].transform.SetParent(BrainValueBackgroudImage.transform, false);
            }
            else
            {

                for (int i = 0; i < BRAIN_VALUES_COUNT - 1; i++)
                {
                    BrainValueColumnArray[i].GetComponent<RectTransform>().sizeDelta = BrainValueColumnArray[i + 1].GetComponent<RectTransform>().sizeDelta;
                }
                BrainValueColumnArray[BRAIN_VALUES_COUNT - 1].GetComponent<RectTransform>().sizeDelta = new Vector2(1, BrainValueList[p]);

                //                Debug.Log(BrainValueArray);


            }




            SumDeltatime = 0;
            p++;

            Debug.Log(p + " :p");

        }


    }




}
