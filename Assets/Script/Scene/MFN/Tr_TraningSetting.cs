using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tr_TraningSetting : SceneBase
{
    //実行するトレーニング
    static ConstData.EnumScene playTraining;



    public static void SetPlayTraining(ConstData.EnumScene _playTraining)
    {
        playTraining = _playTraining;

        if(_playTraining == ConstData.EnumScene.Tr_TrainingNeuro)
        {
            CommonData.resultType = (int)R_ResultLog.ContentType.Neuro;
        }


    }


    public static ConstData.EnumScene GetPlaytraining()
    {
        return playTraining;
    }


    ExButton btnStart;



    void Start()
    {
        CommonHeaderMfn.Instance.SetView(true);


        btnStart = gameObject.FindDescendant("Btn_Start").AddComponent<ExButton>();
        

    
    }
    
    


    private void Update()
    {

        if (btnStart.lastHit2)
        {
            //これを呼び出す
            SceneFunc.ChangeScene(playTraining, false);
        }

        //added by moritomi 
        UpdateCountDownAndStartTest();

    }

    /* added by moritomi from here*/
    // Parameters
    int CountTime;
    float SumDeltTime;
    int IntervalSeconds = 5;
    [SerializeField] Text CountDownText;

    // 10 seconds count down and start the function of change scene on the count of zero. 
    private void UpdateCountDownAndStartTest()
    {

        //DeltaTime 
        SumDeltTime += Time.deltaTime;
        if( SumDeltTime > 1)
        {
            Debug.Log(IntervalSeconds);
            CountDownText.text = IntervalSeconds.ToString();

            IntervalSeconds--;
            SumDeltTime = 0;

            if (IntervalSeconds == 0)
            {
                Debug.Log("Zero");
                SceneFunc.ChangeScene(playTraining, false);


            }
        }


        /*
        if(CountTime % 1 == 0)
        {
            Debug.Log(CountTime);

        }
        */


        /*
        for (int i=MAXCOUNT; i>-1; i--)
        {
            
        }
        */


    }

    /* added by moritomi until here*/




}
