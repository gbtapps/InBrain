using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{

    public GameObject menuLeftButtonPanel;
    public GameObject menuRightButtonPanel;
    public GameObject backgroundOnPopupPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
#if UNITY_EDITOR
        //        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
#endif
    }

    public void ChangeStartScene()
    {
        SceneManager.LoadScene("20.性別年齢選択");
    }

    public void OpenMenuLeftButtonPanel()
    {
        backgroundOnPopupPanel.SetActive(true);
        menuLeftButtonPanel.SetActive(true);
        //        Debug.Log("setActive(true)");
    }

    public void CloseMenuLeftButtonPanel()
    {
        backgroundOnPopupPanel.SetActive(false);
        menuLeftButtonPanel.SetActive(false);
        //        Debug.Log("setActive(false)");
    }

    public void OpenMenuRightButtonPanel()
    {
        backgroundOnPopupPanel.SetActive(true);
        menuRightButtonPanel.SetActive(true);
        //        Debug.Log("setActive(true)");
    }

    public void CloseMenuRightButtonPanel()
    {
        backgroundOnPopupPanel.SetActive(false);
        menuRightButtonPanel.SetActive(false);
        //        Debug.Log("setActive(false)");
    }


}
