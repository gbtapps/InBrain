using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//added by moritomi
using UnityEngine.SceneManagement;


public class Tr_TraningSetting : SceneBase
{
    //実行するトレーニング
    static ConstData.EnumScene playTraining;



    public static void SetPlayTraining(ConstData.EnumScene _playTraining)
    {

        Debug.Log("SetPlayTraining");

        playTraining = _playTraining;

        if(_playTraining == ConstData.EnumScene.Tr_TrainingNeuro)
        {
            CommonData.resultType = (int)R_ResultLog.ContentType.Neuro;
        }

    }


    public static ConstData.EnumScene GetPlaytraining()
    {
        Debug.Log("GetPlayTraining");

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
    [SerializeField] int IntervalSeconds = 5;
    [SerializeField] Text CountDownText;
    string ActiveSceneName;

    //実行するトレーニング追加
    static ConstData.EnumScene playTraining2nd;

    private void Awake()
    {
        ActiveSceneName = SceneManager.GetActiveScene().name;

    }

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

                if (ActiveSceneName== "Tr_TraningSetting")
                {

                    Tr_TraningSetting.SetPlayTraining(ConstData.EnumScene.Tr_TrainingNeuro);
                    SceneFunc.ChangeScene(playTraining, false);


                }
                else if (ActiveSceneName == "Tr_TraningSetting2nd")
                {
                    Debug.Log("ActiveSceneName == Tr_TraningSetting2nd");
                    Tr_TraningSetting.SetPlayTraining2nd(ConstData.EnumScene.Tr_TrainingNeuro2nd);

                    Debug.Log("Before SceneFunc.ChangeScene(playTraining2nd, false)");
                    SceneFunc.ChangeScene(playTraining2nd, false);

                }
                else if (ActiveSceneName == "Tr_TraningSetting3rd")
                {

                    SceneManager.LoadScene("S526TestResultSummary");

                }

            }
        }

    }


    public static void SetPlayTraining2nd(ConstData.EnumScene _playTraining2nd)
    {

        Debug.Log("Called SetPlayTraining2nd");
        playTraining2nd = _playTraining2nd;

        Debug.Log("Before _playTraining2nd == ConstData.EnumScene.Tr_TrainingNeuro2nd");

        if (_playTraining2nd == ConstData.EnumScene.Tr_TrainingNeuro2nd)
        {
            Debug.Log("_playTraining2nd == ConstData.EnumScene.Tr_TrainingNeuro2nd");

            CommonData.resultType = (int)R_ResultLog.ContentType.Neuro;
        }


        Debug.Log("_playTraining2nd == ConstData.EnumScene.Tr_TrainingNeuro2nd is false");


    }






    public static ConstData.EnumScene GetPlaytraining2nd()
    {
        Debug.Log("GetPlayTraining2nd");

        return playTraining2nd;
    }


    /* added by moritomi until here*/




}
