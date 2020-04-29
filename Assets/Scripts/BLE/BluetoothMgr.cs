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

    string m_BLEAddress;


    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {

    }

    public void SetButton(Button button)
    {
        m_BlueToothButton = button;
    }

    private void Update()
    {
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
                break;

            case Hot2gApplication.eMode.ScanOK:  

                List<string> DeviceList = Hot2gApplication.Instance.GetScanDeviceList();

                Debug.Log("Found ADR** " + DeviceList[0].ToString() + "--- Target: " + m_BLEAddress+
                    "Is member?? "+DeviceList.IndexOf(m_BLEAddress));

                if (DeviceList.Count > 0)
                {
                    //TextBLEAddress.text = DeviceList.ToString();

                    // 見つかったひとつは登録デバイスと同じ
                    if (DeviceList.IndexOf(m_BLEAddress) != -1)
                    {
                        Hot2gApplication.Instance.Connecting(m_BLEAddress, () => { }, () => { }, () => { });
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

                #region old code
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
                #endregion
        }

        /*
        if (Hot2gApplication.Instance.datastore == null)
        {
            Hot2gApplication.Instance.datastore = new DataStore();
        }*/
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

    public void StartBLE()
    {
        Hot2gApplication.Instance.StartRecieve();
    }

    public void Connect(string BLEAddress)
    {
        m_BLEAddress = BLEAddress;
        Bluetooth();
    }
}
