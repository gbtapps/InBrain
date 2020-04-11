using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class S222BexSpeedCalculationId2ControllerScript : MonoBehaviour
{

    //----- 画面制御関連 ------

    //画面遷移
    public PageTransitionControllerScript InstancePageTransitionControllerScript;


    //デバッグテキスト文字列
    string DebugStr = "";
    //画面表示テキスト
    public Text DebugText;




    //
    //ゲーム情報
    //

    //ゲームタイトル
    private string GameTitleString = "Speed Calculation";

    //ゲーム説明
    private string GameDescription =
    "【Speed Touch】You top the button to answer correctly as quick as you can within the time limit.";

    //スコアキー
    private string ScoreKeyName = "SpeedCalculationId1";


    //ゲームグループ（リザルト画面バックボタン遷移先で使う等）
    private string GameGroupName = "S220SpeedCalculation";





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







    //-----------  時間管理

    //準備時間
    public double SecondsForReady;

    //ゲーム時間
    public double GameSeconds;

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

    //カウントダウンパネル
    public GameObject CountdownPanel;

    //カウントダウンテキスト
    public Text CountdownText;


    /*
    //総経過時間
    public float TotalTime;
    
    //制限時間
    public float LimitTimeSeconds = 60f;
    */



    //終了パネル
    public GameObject TimeupPanel;







    //----- 回答 ------

    //回答
    public Text AnswerText;

    //数式
    public Text FormulaText;
    
    //回答の桁数
    public int Answerdigit;

    //タッチしたボタンの名称をイベントシステムで取得
    [SerializeField] EventSystem AnswerByButton;

    //設問
    int FirstMember = 0;
    int SecondMember = 0;
    int Answer = 10; //答えを一桁に制限するために初期値10

    //回答数
    int CountButtonTouch = 0;

    //正答数
    int CorrectAnswerCount = 0;

    //誤答数
    int WrongAnswerCount = 0;

    //スコア
    int ScoreInt = 0;

    //結果コメント
    private string ResultCommentText = "Good !";

    //スコア表示テキスト
    public Text Score;

    //ボーナスポイントカウント
    private int BonusPointCount = 0;


    //連続正答数
    private int ConsectiveCorrectAnswers = 0;




    //----- エフェクト ------

    //正誤エフェクト○×
    public GameObject CorrectAnswerMark;
    public GameObject WrongAnswerMark;

    //次の設問がでる時間
    public float NextQuestionTimeMargin = 0.5f;

    //次の設問がでる時間までカウント
    public float NextQuestionCount;




    //
    //共通ゲームキャンバスの関数を使う
    //

    private GameObject CommonGameCanvasManager;
    private CommonGameCanvasManagerScript InstanceCommonGameCanvasManagerScript;


    //共通サウンドオブジェクト
    private GameObject CommonSFXControllerObject;
    private CommonSFXControllerScript InstanceCommonSFXControllerScript;



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


        //本ゲームスタート時のボタン生成
        MakeQuestion();
        Debug.Log("CreateButtons()");
        DebugText.text += ">CreateButtns()";


    }


    //本ゲームの設問生成
    void MakeQuestion()
    {

        //回答結果パネルの初期化
        AnswerText.text = null;

        //最初の設問提示
        MakeOneDigitNumericalQuestion();

        //スタート時間の記録
        StartDateTime = DateTime.Now;

    }





    

    //再生成の条件付き再生成
    void ReMakeQuestion()
    {
  
        if (CorrectAnswerMark.activeSelf || WrongAnswerMark.activeSelf)
        {
            //○秒でマークの色と回答文字を消し新しい設問

            NextQuestionCount += Time.deltaTime;
            if (NextQuestionCount >= NextQuestionTimeMargin)
            {
                NextQuestionCount = 0.0f;
                CorrectAnswerMark.SetActive(false);
                WrongAnswerMark.SetActive(false);
                AnswerText.text = "";
                MakeOneDigitNumericalQuestion();
            }
        }



    }




    // Update is called once per frame
    void Update()
    {
        //次の問題を作る
        ReMakeQuestion();

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


    /*
        // Start is called before the first frame update
        void Start()
        {

            //共通ゲームキャンバスオブジェクト＆インスタンス取得
            CommonGameCanvasManager = GameObject.Find("CommonGameCanvasManager");
            InstanceCommonGameCanvasManagerScript = CommonGameCanvasManager.GetComponent<CommonGameCanvasManagerScript>();

            //共通サウンドオブジェクト＆インスタンス取得
            CommonSFXControllerObject = GameObject.Find("CommonSFXController"); 
             InstanceCommonSFXControllerScript = CommonSFXControllerObject.GetComponent<CommonSFXControllerScript>();


            //画面遷移オブジェクト作成
            InstancePageTransitionControllerScript = new PageTransitionControllerScript();


            //結果画面を消しておく
            //        ResultArea.SetActive(false);


            //設問生成音
    //        InstanceCommonGameCanvasManagerScript.DoSoundSetQuestions();
            InstanceCommonSFXControllerScript.DoSoundSetQuestions();

            //カウントダウンパネルを表示する
            CountdownPanel.SetActive(true);

            //サウンド・エフェクトComponentを取得
            //        Page211AudioSource = this.GetComponent<AudioSource>();

            //カウントダウン初期設定
            CountdownText.text = SecondsForReady.ToString();

            //合計時間の設定
            TotalRestSeconds = GameSeconds + SecondsForReady;

            //NGと注意がでている
            //AddComponentならOKとでていたので調べる
            //      InstancePageTransitionControllerScript = new PageTransitionControllerScript();


            //回答結果パネルの初期化
            AnswerText.text = null;

            //最初の設問提示
            MakeOneDigitNumericalQuestion();

            //スタート時間の記録
            StartDateTime = DateTime.Now;



        }

    */



    // 答えが一桁になる設問提示
    void MakeOneDigitNumericalQuestion()
    {

        //設問生成音
//        InstanceCommonGameCanvasManagerScript.DoSoundSetQuestions();


//        Answerdigit = 1;


        //10以下＝1桁に答えを調整の初期値
        Answer = 10*Answerdigit;

        while (Answer > 10*Answerdigit - 1 || Answer < 0 )
        {
            FirstMember = UnityEngine.Random.Range(0, 10);
            SecondMember = UnityEngine.Random.Range(0, 10);

            if(UnityEngine.Random.Range(0,1) == 0)
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

        }

        /*
        Debug.Log("FirstMember: " + FirstMember);
        Debug.Log("SecondMember: " + SecondMember);
        Debug.Log("FormulaText.text: " + FormulaText.text);
        Debug.Log("Answer: " + Answer);
        */
        
    }


    /*
    void MakeRankAndHighlight()
    {

        if (InstanceCommonGameCanvasManagerScript.GetTotalRestSeconds() < 0f)
        {

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
                //            Debug.Log("ハイライト済み");


                //今回スコアをランキング画面にセット
                InstanceCommonGameCanvasManagerScript.SetThisTimeScoreText(ScoreInt.ToString());
                //            Debug.Log("スコアセット済み");


                //今回スコアに資したアクションをセット
                InstanceCommonGameCanvasManagerScript.SetThisTimeScoreMainActionText(CorrectAnswerCount.ToString());
                //            Debug.Log("アクションセット済み");


                //ボーナスポイント回数をセット
                InstanceCommonGameCanvasManagerScript.SetThisTimeBonusCountText(BonusPointCount.ToString());
                //            Debug.Log("ボーナスポイントセット済み");


                //今回スコアをデータセーブ

                ES3.Save<List<int>>(ScoreKeyName, ScoreList);
                NewScoreDataSavedFlg = true;


            }

        }



    }

    */




    //各ゲームにおける正答処理はそれぞれ作成
    public void AnswerOnClickButton()
    {

        //タッチした時刻の記録
        TouchButtonTime[CountButtonTouch] = DateTime.Now;

        //回答数カウントアップ
        CountButtonTouch++;


        string BtnName = AnswerByButton.currentSelectedGameObject.gameObject.name;


        //解答欄クリア
        AnswerText.text = null;
        CorrectAnswerMark.SetActive(false);
        WrongAnswerMark.SetActive(false);


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

  
        if (Answerdigit == (AnswerText.text).Length)
        {

            if (Answer.ToString() == AnswerText.text)
            {
                //○を表示
                CorrectAnswerMark.SetActive(true);

                //正解音を出す
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



                if (ElapsedTime.Milliseconds < 300)
                {
                    ScoreInt += 300;
                    BonusPointCount++;
                    InstanceCommonGameCanvasManagerScript.SetRealTimeScore(ScoreInt.ToString());
                    InstanceCommonGameCanvasManagerScript.SetAddRealTimeBonusScore(300);
                    DebugText.text += ">SetBonus2";


                }




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
        }



    }






}
