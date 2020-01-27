using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class BluetoothMgr : SingletonMonoBehaviour<BluetoothMgr>
{
    string permission = "android.permission.ACCESS_COARSE_LOCATION";
    string permission2 = "android.permission.WRITE_EXTERNAL_STORAGE";
    public const string cLastConnectSaveKey = "BM_LastConnect";
    Sprite[] m_BlueToothButtonSprite = new Sprite[3];
    Button m_BlueToothButton;
        
    //  自動再接続のタイマー
    float m_timer = 0;
    bool m_on = false;

    string textMessage1 = "脳センサーと接続する";//- Scan OK
    string textMessage2 = "脳センサーを探してしています・・・";//- Others
    string textMessage3 = "脳センサーを確認する";//- Waiting


    private void Start()
    {
        //m_BlueToothButtonSprite[0] = Resources.Load("Texture/btn_connect01", typeof(Sprite)) as Sprite;
        //m_BlueToothButtonSprite[1] = Resources.Load("Texture/btn_connect02", typeof(Sprite)) as Sprite;
        //m_BlueToothButtonSprite[2] = Resources.Load("Texture/BtnLOFF", typeof(Sprite)) as Sprite;        

        TextBLEAddress.text = PlayerPrefs.GetString(ConstData.BLE_address);               

    }

    public void SetButton(Button button)
    {
        m_BlueToothButton = button;
    }

    private void Update()
    {
        UpdateTextMessage(Hot2gApplication.Instance.mode.ToString());// +(testtimer+=Time.deltaTime).ToString());

 
        switch (Hot2gApplication.Instance.mode)
        {            
            case Hot2gApplication.eMode.None:
            case Hot2gApplication.eMode.ConnectError:
            case Hot2gApplication.eMode.ScanError:
                if(m_BlueToothButton != null) {
                    //m_BlueToothButton.GetComponent<Image>().sprite = m_BlueToothButtonSprite[0];
                    m_BlueToothButton.GetComponentInChildren<Text>().text = textMessage1;
                    m_BlueToothButton.interactable = true;
                }
                if (m_on)
                {
                    m_timer += Time.deltaTime;
                    if(m_timer > 7.0f)
                    {
                        Hot2gApplication.Instance.Scan(() => { }, () => { });
                        m_timer = 0;
                    }
                }
                break;

            case Hot2gApplication.eMode.Waiting:
                ButtonStart.interactable = true;
                break;

            case Hot2gApplication.eMode.ScanOK:  

                List<string> DeviceList = Hot2gApplication.Instance.GetScanDeviceList();

                Debug.Log("Found ADR** " + DeviceList[0].ToString() + "--- Target: " + PlayerPrefs.GetString(ConstData.BLE_address)+
                    "Is member?? "+DeviceList.IndexOf(PlayerPrefs.GetString(ConstData.BLE_address)));

                if (DeviceList.Count > 0)
                {
                    //TextBLEAddress.text = DeviceList.ToString();

                    // 見つかったひとつは登録デバイスと同じ
                    if (DeviceList.IndexOf(PlayerPrefs.GetString(ConstData.BLE_address)) != -1)
                    {
                        Hot2gApplication.Instance.Connecting(PlayerPrefs.GetString(ConstData.BLE_address), () => { }, () => { }, () => { });
                    }
                    // 見つかったひとつは前回と違う
                    else
                    {
                        //BtDialog.OpenDialog(LastConncetAddress, DeviceList);
                    }
                }
                // 複数のデバイスが見つかったぞ
                /*
                else
                {
                    //BtDialog.OpenDialog(LastConncetAddress, DeviceList);

                    bool ConnectLast = false;
                    if (!Hot2gApplication.Instance.isConnect1st)
                    {
                        for (int i = 0; i < DeviceList.Count; i++)
                        {
                            if (DeviceList[i] == LastConncetAddress)
                            {
                                ConnectLast = true;
                            }
                        }
                    }

                    // 2回目以降の接続で前回のデバイスがあれば即接続
                    if (ConnectLast)
                    {
                        Hot2gApplication.Instance.Connecting(LastConncetAddress, ()=> { } , () => { }, () => { });
                    }
                    else
                    {
                        BtDialog.OpenDialog(LastConncetAddress, DeviceList);
                    }
                }
                */
                break;
                
                
                /*
                // Bletooth接続ボタンの制御
            case Hot2gApplication.eMode.Scan:            
            case Hot2gApplication.eMode.Connecting:
            case Hot2gApplication.eMode.InitSetting:
                if(m_BlueToothButton != null)
                {
                    //m_BlueToothButton.GetComponent<Image>().sprite = m_BlueToothButtonSprite[1];
                    m_BlueToothButton.GetComponentInChildren<Text>().text = textMessage2;
                    m_BlueToothButton.interactable = false;
                }
                break;

            case Hot2gApplication.eMode.Waiting:
                if (m_BlueToothButton != null)
                {
                    //m_BlueToothButton.GetComponent<Image>().sprite = m_BlueToothButtonSprite[1];
                    m_BlueToothButton.GetComponentInChildren<Text>().text = textMessage3;
                    m_BlueToothButton.interactable = true;                    
                }
                break;

            default:
                if (m_BlueToothButton != null)
                {
                    //m_BlueToothButton.GetComponent<Image>().sprite = m_BlueToothButtonSprite[2];
                    m_BlueToothButton.GetComponent<Text>().text = textMessage3;
                    m_BlueToothButton.interactable = true;
                }
                m_timer = 0;
                break;
                */
        }

        /*
        if (Hot2gApplication.Instance.datastore == null)
        {
            Hot2gApplication.Instance.datastore = new DataStore();
        }*/

        if (Hot2gApplication.Instance.datastore.stability.Count > 1)
        {
            TextLoggingWindow.text = "Ac1chRec: [ " + Hot2gApplication.Instance.mode.ToString() +
            " ]/[ " + Hot2gApplication.Instance.datastore.stability[Hot2gApplication.Instance.datastore.stability.Count - 1] +
            " ]/[: " + Hot2gApplication.Instance.state2.ToString() +
            " ]/[Raw 1: " + Hot2gApplication.Instance.datastore.l1Ac[Hot2gApplication.Instance.datastore.l1Ac.Count - 1] +
            " ]/[Raw 3: " + Hot2gApplication.Instance.datastore.l3Ac[Hot2gApplication.Instance.datastore.l3Ac.Count - 1] +
            " ]/ after MGC: " + Hot2gApplication.Instance.afterMGC_counter.ToString()
            ;
        }
    }

    public void Bluetooth()
    {
        #region get permissions
#if UNITY_ANDROID && !UNITY_EDITOR
        LocationService l = new LocationService();
        if (!l.isEnabledByUser)
        {
            if (RuntimePermissionHelper.HasPermission(permission))
            {
                //Debug.Log("permission 位置情報サービスはオフでパーミッションがある");

                Debug.Log("CallIntent");
                // 位置情報サービスをオンにするのを促す
                RuntimePermissionHelper.CallIntent();
            }
            else
            {
                //Debug.Log("permission 位置情報サービスは謎だがとりあえずパーミッションがない");

                Debug.Log("OpenPermission");
                // パーミッションをONにするのを促す
                RuntimePermissionHelper.RequestPermission(new string[] { permission });
            }
        }
        else
        {
            //Debug.Log("permission 位置情報サービスがオンでパーミッションも許諾済み");
            //            SetMode(eMode.AutoConnect);
            BLEConnect();
        }

        if (!l.isEnabledByUser)
        {
            if (RuntimePermissionHelper.HasPermission(permission2))
            {
                RuntimePermissionHelper.CallIntent();
            }
            else
            {
                RuntimePermissionHelper.RequestPermission(new string[] { permission2 });
            }
        }        
#else
        BLEConnect();
#endif
        #endregion
    }

    public void BTDisconnect()
    {
        Hot2gApplication.Instance.DisConnect();
        m_on = false;
    }

    public void BLEConnect()
    {
        Debug.Log("Top: Tying BLEConnection at Hot2gApplication status=" + Hot2gApplication.Instance.ToString());
        Debug.Log("Top: Tying BLEConnection at Hot2gApplication status=" + Hot2gApplication.Instance.mode.ToString());

        if (m_on && Hot2gApplication.Instance.mode >= Hot2gApplication.eMode.Connecting)
        {
            Hot2gApplication.Instance.DisConnect();
            m_on = false;
        }
        else
        {
            // 接続されていないなら接続する
            if (Hot2gApplication.Instance.mode <= Hot2gApplication.eMode.None)
            {
                Hot2gApplication.Instance.Scan(() => { }, () => { });
                //            Hot2gApplication.Instance.Connecting(IconUpdate, IconUpdate);
            }
            m_on = true;
            m_timer = 0;
        }

#if false    //  ダイアログの動作テスト
        List<string> DeviceList = new List<string>();
        //        string LastConncetAddress = "None";
        string LastConncetAddress = "Dummy5";
        DeviceList.Add("Dummy");
        DeviceList.Add("Dummy2");
        DeviceList.Add("Dummy3");
        DeviceList.Add("Dummy4");
        DeviceList.Add("Dummy5");
        DeviceList.Add("Dummy6");
        DeviceList.Add("Dummy7");
        DeviceList.Add("Dummy8");
        DeviceList.Add("Dummy9");
        BtDialog.OpenDialog(LastConncetAddress, DeviceList);
#endif
    }

    //-------------------------------------------------------------------
    public Text TextBLEAddress;
    public Text TextMesseges;
    public Text TextLoggingWindow;
    public Button ButtonStart;

    private void UpdateTextMessage(string str)
    {
        TextMesseges.text = str;
    }
    public void OnBLEAddressInputChanged(string value)
    {        
    }

    public void OnStartButton()
    {
        Hot2gApplication.Instance.StartRecieve();
    }

    public void OnConnectButton()
    {
        Bluetooth();
        PlayerPrefs.SetString(ConstData.BLE_address, TextBLEAddress.text);
        PlayerPrefs.Save();
    }
}
