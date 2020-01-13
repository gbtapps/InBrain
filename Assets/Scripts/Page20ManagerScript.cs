using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // 追加


public class Page20ManagerScript : MonoBehaviour
{

    public GameObject chk_gender_object = null; // Textオブジェクト
    public GameObject chk_input_object = null; // Textオブジェクト

    public static int genderInt;

    public static int GetGenderInt()
    {
        Debug.Log("GetGenderInt: " + genderInt);
        return genderInt;
    }

    public static void SetGenderInt(int a)
    {
        //1＝男性、2＝女性
        genderInt = a;
        Debug.Log("SetGenderInt: " + genderInt);
        return;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        Text chk_gender_text = chk_gender_object.GetComponent<Text>();
        Text chk_age_text = chk_input_object.GetComponent<Text>();

        if (chk_gender_text.text == "" || chk_age_text.text == "")
        {
            Debug.Log("未入力項目あり");
            return;

        }

        SceneManager.LoadScene("30.センサー接続説明");
    }



}
