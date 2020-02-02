using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BtDialog : MonoBehaviour
{
    public Text TextAddress;
    public Text TextStatus;
    public Text TextBLELog;

    public Button BtnConnect;
    public Button BtnStart;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public float test = 0;
    private void Start()
    {

        test = Random.value;
    }

    private void Update()
    {
        
        Debug.Log("BTDLG: 1"+ Hot2gApplication.Instance.mode.ToString());
        TextStatus.text=Hot2gApplication.Instance.mode.ToString();// +(testtimer+=Time.deltaTime).ToString());
        Debug.Log("BTDLG: 2");
        if (Hot2gApplication.Instance.mode == Hot2gApplication.eMode.Waiting && BtnStart.interactable == false) BtnStart.interactable = true;//- Enable Start button
        Debug.Log("BTDLG: 3");
        if (Hot2gApplication.Instance.datastore.stability.Count > 1)
        {
            TextBLELog.text = "Ac1chRec: [ " + Hot2gApplication.Instance.mode.ToString() +
            " ]/[ " + Hot2gApplication.Instance.datastore.stability[Hot2gApplication.Instance.datastore.stability.Count - 1] +
            " ]/[: " + Hot2gApplication.Instance.state2.ToString() +
            " ]/[Raw 1: " + Hot2gApplication.Instance.datastore.l1Ac[Hot2gApplication.Instance.datastore.l1Ac.Count - 1] +
            " ]/[Raw 3: " + Hot2gApplication.Instance.datastore.l3Ac[Hot2gApplication.Instance.datastore.l3Ac.Count - 1] +
            " ]/ after MGC: " + Hot2gApplication.Instance.afterMGC_counter.ToString()
            ;
        }
        Debug.Log("BTDLG: 4");
        
    }

    public void BLEStart()
    {
        BluetoothMgr.Instance.StartBLE();
    }

    public void BLEConnect()
    {
        if (TextAddress.text != "")
            BluetoothMgr.Instance.Connect(TextAddress.text);        
    }

    #region old code
    /*
    List<Toggle> m_toggleList = new List<Toggle>();

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            m_instance = this;
        }
    }

    //  生成用
    static BtDialog instance;
    //  表示用
    static BtDialog m_instance;

    static public void OpenDialog(string last,List<string> list)
    {
        if(m_instance != null)
        {
            return;
        }
        
        m_instance = Instantiate(instance,instance.transform.parent,false);

        list = list.Distinct().ToList<string>();
        m_instance.transform.Find("ConnectBG").gameObject.SetActive(true);

        var baseTransform = m_instance.transform.Find("ConnectBG").Find("ConnectDialog");
        //baseTransform.Find("Text").GetComponent<Text>().text = "Last connect:\n" + last;
        var content = baseTransform.Find("Scroll View").Find("Viewport").Find("Content");
        var toggle = content.Find("Toggle").GetComponent<Toggle>();
        content.GetComponent<ToggleGroup>().allowSwitchOff = true;
        bool isOn = false;
        bool first = true;
        foreach (var dev in list)
        {
            Toggle newToggle = toggle;
            if (first)
            {
                //  一個目はある奴を使う
                first = false;
            }
            else
            {
                newToggle = Instantiate(toggle, content, false);
                m_instance.m_toggleList.Add(newToggle);
            }
            newToggle.transform.Find("Label").GetComponent<Text>().text = dev;

            //  最後につないでたのをOnに
            if(dev == last)
            {
                newToggle.isOn = true;
                isOn = true;
            }
            else
            {
                newToggle.isOn = false;
            }
        }
        if (!isOn)
        {
            toggle.isOn = true;
        }

        content.GetComponent<ToggleGroup>().allowSwitchOff = false;

        var button = baseTransform.Find("Ok").GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            string dev = null;
            foreach(var t in content.GetComponent<ToggleGroup>().ActiveToggles())
            {
                if( t.isOn)
                {
                    dev = t.transform.Find("Label").GetComponent<Text>().text;
                }
            }
            if (dev != null)
            {
                Hot2gApplication.Instance.Connecting(dev, () => { }, () => { }, () => { });
                //PlayerPrefs.SetString(BluetoothMgr.cLastConnectSaveKey, dev);
                PlayerPrefs.SetString(ConstData.BLE_address , dev);
                PlayerPrefs.Save();
            }
            Destroy(m_instance.gameObject);
            m_instance = null;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    #endregion
}
