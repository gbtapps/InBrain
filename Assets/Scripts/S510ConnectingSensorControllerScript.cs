using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class S510ConnectingSensorControllerScript : MonoBehaviour
{

    public GameObject OnNextBtn;
    public GameObject OffNextBtn;

    public GameObject OnOption1;
    public GameObject OnOption2;

    public GameObject OnSettingPanel;
    public GameObject OffSettingPanel;

    public GameObject ImgBLE;
    public GameObject UnconnectedBLE;
    public GameObject ConnectedBLE;

    public GameObject PutXbOnPanel;

    // Update is called once per frame
    void Update()
    {

        /*
         以下の処理を実装する
         BLE接続関数はGetConnectedBLE()で実装する

        
        // BLEが接続中だったら
        if()
        {

            //BLE接続済みボタン活性化
            ConnectedBLE.SetActive(true);
            ImgBLE.SetActive(false);
            UnconnectedBLE.SetActive(false);

            //次へボタンを活性化
            OnNextBtn.SetActive(true);
            OffNextBtn.SetActive(false);

        }

        // BLEが切断してしまったら
        if()
        {
            //BLE接続済みボタン活性化
            ConnectedBLE.SetActive(false);
            ImgBLE.SetActive(false);
            UnconnectedBLE.SetActive(true);

            //次へボタンを非活性化
            OnNextBtn.SetActive(false);
            OffNextBtn.SetActive(true);
        } 
         
        またOption1を選択した際にBLEを切断する処理を
        関数SelectOption1()に実装する

         */

    }

    public void GetConnectedBLE()
    {

        //BLE接続処理を入れる



        //以下はBLE接続関数を実装したら消す
        //BLE接続済みボタンの表示はUPDATE関数で接続状態を監視する
        ConnectedBLE.SetActive(true);
        OnNextBtn.SetActive(true);
        OffNextBtn.SetActive(false);

    }


    public void SelectOption1()
    {
        OnOption1.SetActive(true);
        OnOption2.SetActive(false);

        OffSettingPanel.SetActive(true);
        OnSettingPanel.SetActive(false);


        //BLEボタンを非活性化
        UnconnectedBLE.SetActive(false);
        ConnectedBLE.SetActive(false);
        ImgBLE.SetActive(true);

        //BLEを切断する処理



        //次へのボタン活性化
        OnNextBtn.SetActive(true);
        OffNextBtn.SetActive(false);

    }

    public void SelectOption2()
    {
        OnOption1.SetActive(false);
        OnOption2.SetActive(true);

        OffSettingPanel.SetActive(false);
        OnSettingPanel.SetActive(true);

        //BLE接続ボタンを活性化
        UnconnectedBLE.SetActive(true);
        ImgBLE.SetActive(false);


        //次へのボタン非活性化（BLE接続済みで再度活性化）
        OnNextBtn.SetActive(false);
        OffNextBtn.SetActive(true);

    }

    public void MoveToTest()
    {
        SceneManager.LoadScene("60.インターバル");
    }

    public void OpenPutXbOnImg()
    {
        PutXbOnPanel.SetActive(true);
    }

    public void ClosePutXbOnImg()
    {
        PutXbOnPanel.SetActive(false);
    }



    // Start is called before the first frame update
    void Start()
    {
        //ログイン状態確認処理
    }


    /*
    public void ChangeScene1()
    {
        SceneManager.LoadScene("41.センサー接続2");
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("42.センサー接続3");
    }
    */


}
