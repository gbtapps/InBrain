using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class BrainExSpeedCalculationManagerScript : MonoBehaviour
{


    //デバッグテキスト文字列
    string DebugStr = "";
    //画面表示テキスト
    public Text DebugText;




    //
    //ゲーム情報
    //

    //ゲームタイトル
    [SerializeField] string GameTitleString = "Game Title";

    //ゲーム説明
    [SerializeField] string GameDescription =
    "【Game Title】Game Description included how to play simply.";

    //スコアキー
    [SerializeField] string ScoreKeyName = "SpeedCalculationId1";


    //ゲームグループ（リザルト画面バックボタン遷移先で使う等）
    [SerializeField] string GameGroupName = "S220SpeedCalculation";


    //----- Additional Function ------
    [SerializeField] bool ChangePanel = false;


    //----- Answering ------


    //回答のMax桁数の指定
    [SerializeField] int Answerdigit;

    //回答の実際の桁数
    private int RealAnswerdigit;

    //設問第一項および第二項の最大値
    [SerializeField] int FirstMemberMaxValue;
    [SerializeField] int SecondMemberMaxValue;










    //-----------  時間管理

    //準備時間
    [SerializeField] double SecondsForReady;

    //ゲーム時間
    [SerializeField] double GameSeconds;

    //次の設問がでる時間
    [SerializeField] float NextQuestionTimeMargin = 0.5f;

    //次の設問がでる時間までカウント
    float NextQuestionCount;

    //即答ボーナス時間
    [SerializeField] float QuickResponseBonusTime = 2f;



    //合計残り時間
    private double TotalRestSeconds;

    //残り時間表示
    public Text RestTimeText;

    //経過時間コントロール
    public float ElapsedSecondsCount = 0;

    //デルタタイムカウント
    public float DeltaTimeCount;

    //開始時刻
    private DateTime StartDateTime;

    //終了時刻
    private DateTime LimitDateTime;

    //タッチ時刻
    public static DateTime[] TouchButtonTime = new DateTime[500];

    //正答タッチ時刻
    public static DateTime[] CorrectTouchButtonTime = new DateTime[500];

    //誤答タッチ時刻
    public static DateTime[] WrongTouchButtonTime = new DateTime[500];

    //回答平均タイム
    private static double AverageTimeTouch;

    //正答平均タイム
    private static double AverageTimeCorrectTouch;

    //誤答平均タイム（＝集中力？）
    private static double AverageTimeWrongTouch;


    //
    //表示系
    //

    //カウントダウンパネル
    public GameObject CountdownPanel;

    //カウントダウンテキスト
    public Text CountdownText;


    //終了パネル
    public GameObject TimeupPanel;

    
    //タッチしたボタンの名称をイベントシステムで取得
    [SerializeField] EventSystem AnswerByButton;


    //結果コメント
    private string ResultCommentText = "Good !";


    //スコア表示テキスト
    [SerializeField] Text Score;

    //回答オブジェクト
    [SerializeField] Text AnswerText;

    //数式オブジェクト
    [SerializeField] Text FormulaText;


    //正誤エフェクト○×
    [SerializeField] GameObject CorrectAnswerMark;
    [SerializeField] GameObject WrongAnswerMark;


    //
    //中間変数
    //

    //設問
    int FirstMember = 0;
    int SecondMember = 0;
    int AnswerRange = 1;

    //正答
    int Answer = -1;  //答えを一桁に制限するために初期値-1（エラー値）

    //回答数
    int CountButtonTouch = 0;

    //正答数
    int CorrectAnswerCount = 0;

    //誤答数
    int WrongAnswerCount = 0;

    //スコア
    int ScoreInt = 0;

    //ボーナスポイントカウント
    private int BonusPointCount = 0;


    //連続正答数
    private int ConsectiveCorrectAnswers = 0;



    //
    //セーブ＆ロード＆ランキング
    //

    //保存スコアリスト
    List<int> SaveScoreList;


    //保存スコアロードリスト
    private List<int> ScoreList;


    //旧トップ５
    private int[] OldScoreRanking = new int[5];

    //新トップ５
    private int[] NewScoreRanking = new int[5];

    //スコアデータカウント、ES3変数名のサフィックス（keyname0が1つ目のデータ）としても使う
    int ScoreDataCount = 0;

    //新スコアデータインデックス
    int NewScoreDataIndex = 0;

    //新スコア格納キー
    string NewScoreDataKey = "";

    //新スコアデータ保存済フラグ
    bool NewScoreDataSavedFlg = false;


    //ランク（10は初期値でランク外）
    private int RankInt = 10;




    //
    //共通ゲームキャンバスの関数を使う
    //

    private GameObject CommonGameCanvasManager;
    private CommonGameCanvasManagerScript InstanceCommonGameCanvasManagerScript;


    //共通サウンドオブジェクト
    private GameObject CommonSFXControllerObject;
    private CommonSFXControllerScript InstanceCommonSFXControllerScript;

    //ChangePanel Script & Object
    private GameObject BrainExChangePanelManagerObject;
    private BrainExChangePanelManagerScript InstanceBrainExChangePanelManagerScript;


    // Start is called before the first frame update
    void Start()
    {

        //スマホデバック用
        DebugText.text = ">Start";


        //共通ゲームキャンバスオブジェクト＆インスタンス取得
        CommonGameCanvasManager = GameObject.Find("CommonGameCanvasManager");
        InstanceCommonGameCanvasManagerScript = CommonGameCanvasManager.GetComponent<CommonGameCanvasManagerScript>();


        //共通サウンドオブジェクト＆インスタンス取得
        CommonSFXControllerObject = GameObject.Find("CommonSFXController");
        InstanceCommonSFXControllerScript = CommonSFXControllerObject.GetComponent<CommonSFXControllerScript>();


        if (ChangePanel == true)
        {
            //共通サウンドオブジェクト＆インスタンス取得
            BrainExChangePanelManagerObject = GameObject.Find("BrainExChangePanelManager");
            InstanceBrainExChangePanelManagerScript = BrainExChangePanelManagerObject.GetComponent<BrainExChangePanelManagerScript>();
        }

        //ゲームタイトルをランキングにセット
        InstanceCommonGameCanvasManagerScript.SetThisGameTitleText(GameTitleString);


        //ゲーム説明をセット
        InstanceCommonGameCanvasManagerScript.SetGameDescriptionText(GameDescription);


        bool existsKey = ES3.KeyExists(ScoreKeyName);
        Debug.Log("existsKey: " + existsKey);



        if (existsKey == true)
        {
            DebugText.text += ">Exists:True";
            Debug.Log(DebugText.text);
            SaveScoreList = ES3.Load<List<int>>(ScoreKeyName);

        }
        else
        {
            DebugText.text += ">Exists:false";
            Debug.Log(DebugText.text);
            SaveScoreList = new List<int> { };

        }



        //セーブスコアリストをカレントスコアリストにロード
        ScoreList = SaveScoreList;
        Debug.Log("ScoreList =　SaveScoreList");
        DebugText.text += ">ScoreList =　SaveScoreList";


        //セーブスコアを昇順にソートしておく
        ScoreList.Sort();
        Debug.Log("ScoreList.Sort()");
        DebugText.text += ">ScoreList.Sort()";


        //セーブスコアを得点の高い順に逆ソートしておく
        ScoreList.Reverse();
        Debug.Log("ScoreList.Reverse()");
        DebugText.text += ">ScoreList.Reverse()";


        //セーブスコアトップ5をランキングしておく（データない場合は-1）
        if (ScoreList.Count > 4)
        {
            OldScoreRanking[0] = ScoreList[0];
            OldScoreRanking[1] = ScoreList[1];
            OldScoreRanking[2] = ScoreList[2];
            OldScoreRanking[3] = ScoreList[3];
            OldScoreRanking[4] = ScoreList[4];

        }
        else if (ScoreList.Count == 4)
        {
            OldScoreRanking[0] = ScoreList[0];
            OldScoreRanking[1] = ScoreList[1];
            OldScoreRanking[2] = ScoreList[2];
            OldScoreRanking[3] = ScoreList[3];
            OldScoreRanking[4] = -1;

        }
        else if (ScoreList.Count == 3)
        {
            OldScoreRanking[0] = ScoreList[0];
            OldScoreRanking[1] = ScoreList[1];
            OldScoreRanking[2] = ScoreList[2];
            OldScoreRanking[3] = -1;
            OldScoreRanking[4] = -1;

        }
        else if (ScoreList.Count == 2)
        {
            OldScoreRanking[0] = ScoreList[0];
            OldScoreRanking[1] = ScoreList[1];
            OldScoreRanking[2] = -1;
            OldScoreRanking[3] = -1;
            OldScoreRanking[4] = -1;

        }
        else if (ScoreList.Count == 1)
        {
            OldScoreRanking[0] = ScoreList[0];
            OldScoreRanking[1] = -1;
            OldScoreRanking[2] = -1;
            OldScoreRanking[3] = -1;
            OldScoreRanking[4] = -1;

        }
        else if (ScoreList.Count == 0)
        {
            OldScoreRanking[0] = -1;
            OldScoreRanking[1] = -1;
            OldScoreRanking[2] = -1;
            OldScoreRanking[3] = -1;
            OldScoreRanking[4] = -1;

        }



        //新規スコア追加用の要素を用意する
        ScoreList.Add(99999);
        NewScoreDataIndex = ScoreList.IndexOf(99999);
        ScoreList[NewScoreDataIndex] = 0;
        DebugText.text += ">NewScoreDataIndex Added";


        //ゲームスタート時の音
        //        InstanceCommonSFXControllerScript.DoSoundSetQuestions();


        //スタート時間の記録
        StartDateTime = DateTime.Now;


        //本ゲームスタート時のボタン生成
        MakeQuestion();
        Debug.Log("MakeQuestion()");
        DebugText.text += ">MakeQuestion()";


    }

    



    //本ゲームの設問生成
    void MakeQuestion()
    {


        Debug.Log("MakeQuestion()");


        //回答結果パネルの初期化
        AnswerText.text = null;

        //最初の設問提示
        MakeOneDigitNumericalQuestion();

        if (ChangePanel == true)
        {
            //This changes buttons position.
            InstanceBrainExChangePanelManagerScript.ChangeBtnPositionFunc();
        }

    }


        



    void ReMakeQuestion()
    {




        if (CorrectAnswerMark.activeSelf || WrongAnswerMark.activeSelf)
        {

            Debug.Log("CorrectAnswerMark.activeSelf || WrongAnswerMark.activeSelf == True");


            //○秒でマークの色と回答文字を消し新しい設問
            NextQuestionCount += Time.deltaTime;

            if (NextQuestionCount >= NextQuestionTimeMargin)
            {

                Debug.Log("NextQuestionCount >= NextQuestionTimeMargin == true");

                NextQuestionCount = 0.0f;
                CorrectAnswerMark.SetActive(false);
                WrongAnswerMark.SetActive(false);
                AnswerText.text = "";

//                MakeOneDigitNumericalQuestion();

                MakeQuestion();

            }
        }





    }





    // Update is called once per frame
    void Update()
    {
        
        //次の問題を作る
        ReMakeQuestion();


        //経過時間カウンター
        DeltaTimeCount += Time.deltaTime;

        /*
        if (DeltaTimeCount >= 0.5f)
        {
            DeltaTimeCount = 0.0f;
//            Debug.Log("0.5秒おきに処理");

        }
        */



            //ゲーム終了処理：残り時間0で動く
            if (InstanceCommonGameCanvasManagerScript.GetTotalRestSeconds() < 0f)
        {

            //何回も動くと処理が重くなるので新スコアセーブ済みフラグFalseの場合のみ動く
            if (NewScoreDataSavedFlg == false)
            {


                //ランキングを計算
                if (ScoreInt < OldScoreRanking[4])
                {
                    NewScoreRanking[0] = OldScoreRanking[0];
                    NewScoreRanking[1] = OldScoreRanking[1];
                    NewScoreRanking[2] = OldScoreRanking[2];
                    NewScoreRanking[3] = OldScoreRanking[3];
                    NewScoreRanking[4] = OldScoreRanking[4];

                }

                if (ScoreInt > OldScoreRanking[4])
                {
                    RankInt = 5;
                    NewScoreRanking[0] = OldScoreRanking[0];
                    NewScoreRanking[1] = OldScoreRanking[1];
                    NewScoreRanking[2] = OldScoreRanking[2];
                    NewScoreRanking[3] = OldScoreRanking[3];
                    NewScoreRanking[4] = ScoreInt;
                }

                if (ScoreInt > OldScoreRanking[3])
                {
                    RankInt = 4;
                    NewScoreRanking[0] = OldScoreRanking[0];
                    NewScoreRanking[1] = OldScoreRanking[1];
                    NewScoreRanking[2] = OldScoreRanking[2];
                    NewScoreRanking[3] = ScoreInt;
                    NewScoreRanking[4] = OldScoreRanking[3];
                }

                if (ScoreInt > OldScoreRanking[2])
                {
                    RankInt = 3;
                    NewScoreRanking[0] = OldScoreRanking[0];
                    NewScoreRanking[1] = OldScoreRanking[1];
                    NewScoreRanking[2] = ScoreInt;
                    NewScoreRanking[3] = OldScoreRanking[2];
                    NewScoreRanking[4] = OldScoreRanking[3];
                }

                if (ScoreInt > OldScoreRanking[1])
                {
                    RankInt = 2;
                    NewScoreRanking[0] = OldScoreRanking[0];
                    NewScoreRanking[1] = ScoreInt;
                    NewScoreRanking[2] = OldScoreRanking[1];
                    NewScoreRanking[3] = OldScoreRanking[2];
                    NewScoreRanking[4] = OldScoreRanking[3];
                }

                if (ScoreInt > OldScoreRanking[0])
                {
                    RankInt = 1;
                    NewScoreRanking[0] = ScoreInt;
                    NewScoreRanking[1] = OldScoreRanking[0];
                    NewScoreRanking[2] = OldScoreRanking[1];
                    NewScoreRanking[3] = OldScoreRanking[2];
                    NewScoreRanking[4] = OldScoreRanking[3];
                }

                //ランキングへの書込み（-1で書き込むとランキング表示なし）
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank1(NewScoreRanking[0]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank2(NewScoreRanking[1]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank3(NewScoreRanking[2]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank4(NewScoreRanking[3]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank5(NewScoreRanking[4]);

                //ランクに入っていればハイライト
                InstanceCommonGameCanvasManagerScript.SetHighlightRank(RankInt);
                Debug.Log("ハイライト済み");


                //今回スコアをランキング画面にセット
                InstanceCommonGameCanvasManagerScript.SetThisTimeScoreText(ScoreInt.ToString());
                Debug.Log("ランキングセット済み");


                //今回スコアに資したアクションをセット
                InstanceCommonGameCanvasManagerScript.SetThisTimeScoreMainActionText(CorrectAnswerCount.ToString());
                Debug.Log("アクション回数セット済み");


                //ボーナスポイント回数をセット
                InstanceCommonGameCanvasManagerScript.SetThisTimeBonusCountText(BonusPointCount.ToString());
                Debug.Log("ボーナスポイントセット済み");


                //バックボタンの遷移先を設定
                InstanceCommonGameCanvasManagerScript.SetBackSceneName(GameGroupName);


                //今回スコアをデータセーブ
                ES3.Save<List<int>>(ScoreKeyName, ScoreList);
                NewScoreDataSavedFlg = true;
                


            }

        }






    }





    // 答えが一桁になる設問提示
    void MakeOneDigitNumericalQuestion()
    {

        Debug.Log("MakeOneDigitNumericalQuestion");


        //設問生成音
        //        InstanceCommonGameCanvasManagerScript.DoSoundSetQuestions();

        // In case of Answer Degit = 2,
        // This means xx answer.
        // 




        AnswerRange = 1;

        //AnswerRangeの作成
        //Answerdigit=1の場合は10、2の場合は100、3の場合は1000
        for( int i=0; i<Answerdigit; i++)
        {
            AnswerRange = AnswerRange * 10;
            Debug.Log("AnswerRange: "+AnswerRange);

        }





        //正答値が正答範囲外の間は繰り返し
        //Answerを-1（エラー値）に設定してLoopに入れる

        Answer = -1;
        while (Answer > AnswerRange - 1 || Answer < 0 )
        {

            if (FirstMemberMaxValue == 0 || SecondMemberMaxValue == 0)
            {

                Debug.Log("FirstMemberMaxValue == 0 || SecondMemberMaxValue == 0 is true");
                FirstMember = UnityEngine.Random.Range(0, AnswerRange);
                SecondMember = UnityEngine.Random.Range(0, AnswerRange);

            }
            else
            {
                Debug.Log("FirstMemberMaxValue == 0 || SecondMemberMaxValue == 0 is false");
                FirstMember = UnityEngine.Random.Range(0, FirstMemberMaxValue);
                SecondMember = UnityEngine.Random.Range(0, SecondMemberMaxValue);

            }


            int plusorminus = UnityEngine.Random.Range(0, 10);
            Debug.Log("plusorminus: " + plusorminus);
            plusorminus %= 2; 
            Debug.Log("plusorminus %=2: " + plusorminus);

//            if (UnityEngine.Random.Range(0,1) == 0)
            if (plusorminus == 0)
            {
                //引算
                FormulaText.text = FirstMember + " - " + SecondMember + " = □";                
                Answer = FirstMember - SecondMember;

            }
            else
            {
                //足し算
                FormulaText.text = FirstMember + " + " + SecondMember + " = □";
                Answer = FirstMember + SecondMember;
            }

            Debug.Log(FormulaText.text);


        }


        Debug.Log("FormulaText.text: " + FormulaText.text);
        Debug.Log("Answer: " + Answer);

        RealAnswerdigit = Answer.ToString().Length;
        Debug.Log("RealAnswerdigit: " + RealAnswerdigit);


    }






    //各ゲームにおける正答処理はそれぞれ作成
    public void AnswerOnClickButton()
    {



        string BtnName = AnswerByButton.currentSelectedGameObject.gameObject.name;


        /*
        //回答した時刻の記録
        TouchButtonTime[CountButtonTouch] = DateTime.Now;
        //回答数カウントアップ
        CountButtonTouch++;

        //解答欄クリア
        AnswerText.text = null;
        CorrectAnswerMark.SetActive(false);
        WrongAnswerMark.SetActive(false);
        */


        //ボタン押下
        if (BtnName == "Btn1") AnswerText.text += "1";
        else if (BtnName == "Btn2") AnswerText.text += "2";
        else if (BtnName == "Btn3") AnswerText.text += "3";
        else if (BtnName == "Btn4") AnswerText.text += "4";
        else if (BtnName == "Btn5") AnswerText.text += "5";
        else if (BtnName == "Btn6") AnswerText.text += "6";
        else if (BtnName == "Btn7") AnswerText.text += "7";
        else if (BtnName == "Btn8") AnswerText.text += "8";
        else if (BtnName == "Btn9") AnswerText.text += "9";
        else if (BtnName == "Btn0") AnswerText.text += "0";
        if (BtnName == "BtnDlt") AnswerText.text = "";

        Debug.Log("AnswerText.text: " + AnswerText.text);

        //        Debug.Log("Answerdigit: "+Answerdigit);
        //        Debug.Log("(AnswerText.text).Length: " + (AnswerText.text).Length);

        if (RealAnswerdigit == (AnswerText.text).Length)

//            if (Answerdigit == (AnswerText.text).Length)
        {

            //回答した時刻の記録
            TouchButtonTime[CountButtonTouch] = DateTime.Now;

            //回答数カウントアップ
            CountButtonTouch++;

            /*
            //解答欄クリア
//            AnswerText.text = null;
            CorrectAnswerMark.SetActive(false);
            WrongAnswerMark.SetActive(false);
            */


            if (Answer.ToString() == AnswerText.text)
            {
                //○を表示
                CorrectAnswerMark.SetActive(true);

                //正解音を出す
                //                InstanceCommonSFXControllerScript.DoSoundCorrectAnswer();
                InstanceCommonSFXControllerScript.DoSoundCorrectAnswer();

                                //点数をつける
                                //正答時刻の記録
                                CorrectTouchButtonTime[CorrectAnswerCount] = DateTime.Now;

                //平均正答時間の更新
                //ゲーム終了時に時間をタッチボタン数で割ってやれば良いので
                //ここでは記載しない


                //連続正答数カウントアップ
                ConsectiveCorrectAnswers++;


                //スコア加算１（単純累積）
                ScoreInt += 200;
                InstanceCommonGameCanvasManagerScript.SetRealTimeScore(ScoreInt.ToString());
                InstanceCommonGameCanvasManagerScript.SetAddRealTimeScore(200);

                DebugText.text += ">SetScore1";

                //スコア加算２（ボーナス１：10連続ミスなし）
                if (ConsectiveCorrectAnswers == 10)
                {
                    ScoreInt += 400;
                    ConsectiveCorrectAnswers = 0;
                    BonusPointCount++;
                    InstanceCommonGameCanvasManagerScript.SetRealTimeScore(ScoreInt.ToString());
                    InstanceCommonGameCanvasManagerScript.SetAddRealTimeBonusScore(400);
                    DebugText.text += ">SetBonus1";

                }


                TimeSpan ElapsedTime;

                //スコア加算３（ボーナス２：即反応0.3秒以内）
                if (CorrectAnswerCount > 0)
                {
                    ElapsedTime = CorrectTouchButtonTime[CorrectAnswerCount] - CorrectTouchButtonTime[CorrectAnswerCount - 1];

                    Debug.Log("CorrectTouchButtonTime[CorrectAnswerCount]: "+ CorrectTouchButtonTime[CorrectAnswerCount]);
                    Debug.Log("CorrectTouchButtonTime[CorrectAnswerCount - 1]: "+ CorrectTouchButtonTime[CorrectAnswerCount - 1]);
                    Debug.Log("ElapsedTime.Milliseconds: " + ElapsedTime.Milliseconds);
                    Debug.Log("DateTime.Now: " + DateTime.Now);


                }

                //正解カウントアップ
                CorrectAnswerCount++;
                Debug.Log("CorrectAnswerCount: " + CorrectAnswerCount);



                if (DeltaTimeCount <= QuickResponseBonusTime )
                {
                    ScoreInt += 300;
                    BonusPointCount++;
                    InstanceCommonGameCanvasManagerScript.SetRealTimeScore(ScoreInt.ToString());
                    InstanceCommonGameCanvasManagerScript.SetAddRealTimeBonusScore(300);
                    DebugText.text += ">SetBonus2";


                }


                DeltaTimeCount = 0f;


                /*
                    if (ElapsedTime.Milliseconds < 300)
                {
                    ScoreInt += 300;
                    BonusPointCount++;
                    InstanceCommonGameCanvasManagerScript.SetRealTimeScore(ScoreInt.ToString());
                    InstanceCommonGameCanvasManagerScript.SetAddRealTimeBonusScore(300);
                    DebugText.text += ">SetBonus2";


                }
                */





                //コメントプレフィックス１
                string comment1 = "Great Responce!";

                //コメントサフィックス２
                string comment2 = "You Can Do Better Next Time!";


                //リザルトをテキストに変換
                string ScoreText = ScoreInt.ToString() + "pt!";
                string ResultText = comment1 + "\n" + ScoreText + "\n" + comment2;


                //リザルトへ書込み
                InstanceCommonGameCanvasManagerScript.SetResultText(ResultText);

                DebugText.text += ">SetResult";



                //過去スコアリストに今回スコアを追加するため過去スコア要素数＋１のインデックスを
                //Start()で準備して使う
                ScoreList[NewScoreDataIndex] = ScoreInt;


         

            }
            else
            {
                //×を表示
                WrongAnswerMark.SetActive(true);
                //不正解音を出す
//                InstanceCommonGameCanvasManagerScript.DoSoundWrongAnswer();
                InstanceCommonSFXControllerScript.DoSoundWrongAnswer();

            }


            //正解でも不正解でも次の問題を作る
//            ReMakeQuestion();

            //ReMakeQuestion();


        }



    }






}
