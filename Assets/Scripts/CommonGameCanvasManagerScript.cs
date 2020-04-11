using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class CommonGameCanvasManagerScript : MonoBehaviour
{

    //
    //  ゲーム部分以外を管理するクラスです
    //  以下の機能を持っています
    //  ・開始カウントダウン
    //  ・終了カウントダウン
    //　・サウンド
    //　・一時停止
    //  ・リザルト表示
    //　
    //　ゲームは「ゲーム描画エリア」に描画してください
    //　
    //　
    //　※サウンドは外部クラスからコール可能
    //　
    //　
    //　
    //　※リザルト表示は外部クラスからセッターで書き込む
    //　
    //　
    //　


    //
    //  画面制御
    //


    //ゲーム描画エリア
    public GameObject GameArea;

    //ゲーム説明
    public Text GameDescriptionText;


    //カウントダウンパネル
    public GameObject CountdownPanel;

    //カウントダウンテキスト
    public Text CountdownText;

    //終了時リザルト表示エリア
    public GameObject ResultArea;

    //一時停止パネル
    public GameObject GameInterruptionPanelObj;

    //一時停止フラグ
    private bool GameInterruptionFlg = false;

    //スコアランキングパネル
    public GameObject GameScoreRankingPanel;

    //スコアランキング表示
    public Text GameScoreRank1Text;
    public Text GameScoreRank2Text;
    public Text GameScoreRank3Text;
    public Text GameScoreRank4Text;
    public Text GameScoreRank5Text;

    //スコアランキングハイライト
    public GameObject HighlightImage1;
    public GameObject HighlightImage2;
    public GameObject HighlightImage3;
    public GameObject HighlightImage4;
    public GameObject HighlightImage5;

    //今回ボーナス回数
    public Text ThisTimeBonusCountText;

    //今回スコアメインアクション
    public Text ThisTimeScoreMainActionText;

    //今回スコア
    public Text ThisTimeScoreText;

    //ゲームタイトル表示
    public Text ThisGameTitleText;

    //リアルタイムスコア
    public Text RealTimeScore;

    //加算スコア
    public Text AddRealTimeScore;

    //加算スコア２（ボーナス）
    public Text AddRealTimeBonusScore;

    //加算スコア表示時間
    public float AddRealTimeScoreShowTime;

    //加算スコアサイズ調整
    public float AddRealTimeScoreSizeTuningTime;


    //
    //  サウンドエフェクト
    //

    public AudioClip SoundCorrectAnswer;
    public AudioClip SoundWrongAnswer;

    public AudioClip SoundStartCountdown;
    public AudioClip SoundTimeupCountdown;

    public AudioClip SoundGoodResponse;
    public AudioClip SoundSetQuestions;

    public AudioClip SoundResultOpen;
    public AudioClip SoundResultClose;

    private AudioSource ThisClassAudioSource;


    //
    //  時間管理
    //

    //準備時間
    public double SecondsForReady = 5f;

    //ゲーム時間
    public double GameSeconds = 60f;

    //合計残り時間
    private double TotalRestSeconds = 0f;

    //残り時間表示
    public Text RestTimeText;

    //経過時間コントロール
    public float ElapsedSecondsCount = 0;

    //デルタタイムカウント
    public float DeltaTimeCount = 0f;

    //開始時刻
    private DateTime StartDateTime;

    //終了時刻
    private DateTime LimitDateTime;




    //
    //  リザルト
    //


    //リザルト
    public Text ResultText;

    //リザルト画面に表示されるバックボタンのデフォルト（関数で更新できる）
    private string BackSceneName = "S200BrainExMenu";






    /* ################################
     * 
     *          関数
     *          
     * ##############################*/


    // Start is called before the first frame update
    void Start()
    {

        GameScoreRankingPanel.SetActive(false);


        //サウンド・エフェクトComponentを取得
        ThisClassAudioSource = this.GetComponent<AudioSource>();

        //リザルトの初期値
        ResultText.text="No Play, No Gain.\nYou Can Try Again.\nNo Point\n";


        //結果画面を消しておく
        ResultArea.SetActive(false);

        //カウントダウンパネルを表示する
        CountdownPanel.SetActive(true);

        //カウントダウン初期設定
        CountdownText.text = SecondsForReady.ToString();

        //合計時間の設定
        TotalRestSeconds = GameSeconds + SecondsForReady;

        //スタート時のボタン生成
        //        CreateButtons();

        //スタート時間の記録
        StartDateTime = DateTime.Now;


    }

    // Update is called once per frame
    void Update()
    {

//        AddRealTimeScore.fontSize = 26;


        if (GameInterruptionFlg == false)
        {
            DeltaTimeCount += Time.deltaTime;
            AddRealTimeScoreShowTime += Time.deltaTime;
            AddRealTimeScoreSizeTuningTime += Time.deltaTime;
        }



        if (AddRealTimeScoreShowTime >= 0.05f)
        {
            AddRealTimeScore.fontSize = 25;
            AddRealTimeBonusScore.fontSize = 30;


        }

        if (AddRealTimeScoreShowTime >= 0.1f)
        {
            AddRealTimeScore.fontSize = 24;
            AddRealTimeBonusScore.fontSize = 29;

        }

        if (AddRealTimeScoreShowTime >= 0.15f)
        {

            AddRealTimeScore.fontSize = 23;
            AddRealTimeBonusScore.fontSize = 28;

        }

        if (AddRealTimeScoreShowTime >= 0.2f)
        {
            AddRealTimeScore.fontSize = 22;
            AddRealTimeBonusScore.fontSize = 27;

        }

        if (AddRealTimeScoreShowTime >= 0.25f)
        {
            AddRealTimeScore.fontSize = 21;
            AddRealTimeBonusScore.fontSize = 26;

        }

        if (AddRealTimeScoreShowTime >= 0.3f)
        {
            AddRealTimeScore.fontSize = 20;
            AddRealTimeBonusScore.fontSize = 25;

        }

        if (AddRealTimeScoreShowTime >= 0.35f)
        {
            AddRealTimeScore.fontSize = 19;
            AddRealTimeBonusScore.fontSize = 24;

        }

        if (AddRealTimeScoreShowTime >= 0.4f)
        {
            AddRealTimeScore.fontSize = 18;
            AddRealTimeBonusScore.fontSize = 23;

        }

        if (AddRealTimeScoreShowTime >= 0.45f)
        {
            AddRealTimeScore.fontSize = 17;
            AddRealTimeBonusScore.fontSize = 22;

        }

        if (AddRealTimeScoreShowTime >= 0.5f)
        {
            AddRealTimeScore.text = "";
            AddRealTimeBonusScore.text = "";

        }



        if (DeltaTimeCount >= 1.0f)
        {
            DeltaTimeCount = 0.0f;

//            Debug.Log("1秒おきに処理");
            Debug.Log("経過時間ElapsedSecondsCount: " + ElapsedSecondsCount);

            double countdown = TotalRestSeconds - GameSeconds;

            RestTimeText.text = "Rest Time: " + TotalRestSeconds.ToString();


            if (countdown > 0)
            {
                //ゲームスタートカウントダウン

                //カウントダウン表示
                CountdownText.text = countdown.ToString();

                //残り時間はまだ表示しない
                RestTimeText.text = "Rest Time: ";

                ThisClassAudioSource.PlayOneShot(SoundStartCountdown);



            }
            else if (countdown == 0)
            {
                //ゲームスタートのためパネルを外す
                CountdownPanel.SetActive(false);

            }


            //ゲーム終了カウントダウン

            if (TotalRestSeconds == 5)
            {
                ThisClassAudioSource.PlayOneShot(SoundTimeupCountdown);
                RestTimeText.color = Color.red;

            }
            else if (TotalRestSeconds == 4)
            {
                ThisClassAudioSource.PlayOneShot(SoundTimeupCountdown);

            }
            else if (TotalRestSeconds == 3)
            {
                ThisClassAudioSource.PlayOneShot(SoundTimeupCountdown);

            }
            else if (TotalRestSeconds == 2)
            {
                ThisClassAudioSource.PlayOneShot(SoundTimeupCountdown);

            }
            else if (TotalRestSeconds == 1)
            {
                ThisClassAudioSource.PlayOneShot(SoundTimeupCountdown);

            }

            else if (TotalRestSeconds == 0)
            {

                GameArea.SetActive(false);



            }
            else if (TotalRestSeconds == -1)
            {

                //ゼロになったのでシェードアウト


                //結果を表示するカッコいい音
                ThisClassAudioSource.PlayOneShot(SoundResultOpen);


                //終了時時間の記録
                LimitDateTime = DateTime.Now;


                //結果画面を表示
                ResultArea.SetActive(true);


            }
            else if (TotalRestSeconds == -4)
            {
                //結果画面を消す
                ResultArea.SetActive(false);
                ThisClassAudioSource.PlayOneShot(SoundResultClose);

            }

            else if (TotalRestSeconds == -5f)
            {
                //ランキング画面へ
                GameScoreRankingPanel.SetActive(true);


            }



            if (TotalRestSeconds < 0f)
            {
                //残り時間をゼロ表示
                RestTimeText.text = "Rest Time: 0";

            }



            //経過時間（秒）をカウント
            ElapsedSecondsCount++;

            //残時間（秒）をカウント
            TotalRestSeconds--;

        }
    }


    //
    //一時停止関数
    //


    public void CloseGameInterruptionPanel()
    {
        GameInterruptionPanelObj.SetActive(false);
        GameInterruptionFlg = false;

    }

    public void OpenGameInterruptionPanel()
    {
        GameInterruptionPanelObj.SetActive(true);
        GameInterruptionFlg = true;

    }


    //
    //サウンド関数
    //


    public void DoSoundCorrectAnswer()
    {
        ThisClassAudioSource.PlayOneShot(SoundCorrectAnswer);
        return;

    }

    public void DoSoundWrongAnswer()
    {
        ThisClassAudioSource.PlayOneShot(SoundWrongAnswer);
        return;

    }

    public void DoSoundStartCountdown()
    {
        ThisClassAudioSource.PlayOneShot(SoundStartCountdown);
        return;

    }

    public void DoSoundTimeupCountdown()
    {
        ThisClassAudioSource.PlayOneShot(SoundTimeupCountdown);
        return;

    }

    public void DoSoundGoodResponse()
    {
        ThisClassAudioSource.PlayOneShot(SoundGoodResponse);
        return;

    }

    public void DoSoundSetQuestions()
    {
        ThisClassAudioSource.PlayOneShot(SoundSetQuestions);
        return;

    }

    public void DoSoundResultOpen()
    {
        ThisClassAudioSource.PlayOneShot(SoundResultOpen);
        return;

    }

    public void DoSoundResultClose()
    {
        ThisClassAudioSource.PlayOneShot(SoundResultClose);
        return;

    }


    public void SetGameDescriptionText(string str)
    {
        GameDescriptionText.text = str;
        return;

    }


    //外部から呼ばれるリザルトのセッター
    public void SetResultText(string a) {

//        Debug.Log("SetResultText: "+a);
        ResultText.text = a;

//        Debug.Log("ResultText.Text: " + ResultText.text);

    }

    //リアルタイムスコアのセッター
    public void SetRealTimeScore(string str)
    {
        RealTimeScore.text = "Score: "+str;

    }

    //加算スコアのセッター
    public void SetAddRealTimeScore(int num)
    {
        AddRealTimeScore.text = "+" + num.ToString();
        AddRealTimeScoreShowTime = 0f;

    }

    //加算スコア２（ボーナス）のセッター
    public void SetAddRealTimeBonusScore(int num)
    {
        AddRealTimeBonusScore.text = "+" + num.ToString();
        AddRealTimeScoreShowTime = 0f;

    }


    //残り時間（秒）のゲッター
    public double GetTotalRestSeconds()
    {
        return TotalRestSeconds;

    }


    //リザルト画面のバックボタンの遷移先セッター
    public void SetBackSceneName(string str)
    {
        BackSceneName = str;

    }




    public void MoveToTitle()
    {
//    https://dream-target.jp/2018/12/06/unity_scene/

    } 


    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void MoveToBack()
    {
        SceneManager.LoadScene(BackSceneName);
    }



    //スコアランキングセッター一式
    public void SetGameScoreRank1(int i)
    {
        if (i == -1)
        {
            GameScoreRank1Text.text = "";
            return;
        }
        GameScoreRank1Text.text = "1.     " + i.ToString();

    }


    public void SetGameScoreRank2(int i)
    {
        if (i == -1)
        {
            GameScoreRank2Text.text = "";
            return;
        }
        GameScoreRank2Text.text = "2.     " + i.ToString();
    }


    public void SetGameScoreRank3(int i)
    {
        if (i == -1)
        {
            GameScoreRank3Text.text = "";
            return;
        }
        GameScoreRank3Text.text = "3.     " + i.ToString();

    }


    public void SetGameScoreRank4(int i)
    {
        if (i == -1)
        {
            GameScoreRank4Text.text = "";
            return;
        }
        GameScoreRank4Text.text = "4.     " + i.ToString();

    }


    public void SetGameScoreRank5(int i)
    {
        if (i == -1)
        {
            GameScoreRank5Text.text = "";
            return;
        }
        GameScoreRank5Text.text = "5.     " + i.ToString();

    }


    //スコアアクションセッター
    public void SetThisTimeScoreMainActionText(string str)
    {
        ThisTimeScoreMainActionText.text = str +" button(s) touched";

    }

    //スコアアクションセッター
    public void SetThisTimeBonusCountText(string str)
    {
        ThisTimeBonusCountText.text = str + " extra bonus(es)";

    }


    //スコアセッター
    public void SetThisTimeScoreText(string str)
    {
        ThisTimeScoreText.text = "Score: "+str;

    }

    //ゲームタイトルセッター
    public void SetThisGameTitleText(string str)
    {
        ThisGameTitleText.text = str;
    }



    //引数のランクをハイライト（それ以外をOFF）にする
    public void SetHighlightRank(int i)
    {
        if (i == 1) {
            HighlightImage1.SetActive(true);
            HighlightImage2.SetActive(false);
            HighlightImage3.SetActive(false);
            HighlightImage4.SetActive(false);
            HighlightImage5.SetActive(false);
        }
        else if(i == 2)
        {
            HighlightImage1.SetActive(false);
            HighlightImage2.SetActive(true);
            HighlightImage3.SetActive(false);
            HighlightImage4.SetActive(false);
            HighlightImage5.SetActive(false);
        }
        else if (i == 3)
        {
            HighlightImage1.SetActive(false);
            HighlightImage2.SetActive(false);
            HighlightImage3.SetActive(true);
            HighlightImage4.SetActive(false);
            HighlightImage5.SetActive(false);
        }
        else if (i == 4)
        {
            HighlightImage1.SetActive(false);
            HighlightImage2.SetActive(false);
            HighlightImage3.SetActive(false);
            HighlightImage4.SetActive(true);
            HighlightImage5.SetActive(false);
        }
        else if (i == 5)
        {
            HighlightImage1.SetActive(false);
            HighlightImage2.SetActive(false);
            HighlightImage3.SetActive(false);
            HighlightImage4.SetActive(false);
            HighlightImage5.SetActive(true);
        }
        else
        {
            return;
        }



    }




}
