using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S400MypageControllerScript : MonoBehaviour
{
   



    [SerializeField] GameObject PersonalInformationPanel;
    [SerializeField] GameObject GuidancePanel;
    [SerializeField] GameObject InqueryPanel;
    [SerializeField] GameObject ChangePasswordPanel;
    [SerializeField] GameObject LicensePanel;



    // Start is called before the first frame update
    void Start()
    {

        CloseAllPanel();


    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // PersonalInformationPanel
    public void CloseAllPanel()
    {
        PersonalInformationPanel.SetActive(false);
        GuidancePanel.SetActive(false);
        InqueryPanel.SetActive(false);
        ChangePasswordPanel.SetActive(false);
        LicensePanel.SetActive(false);
    }


    // PersonalInformationPanel
    public void ClosePersonalInformationPanel()
    {
        PersonalInformationPanel.SetActive(false);
    }

    public void OpenPersonalInformationPanel()
    {
        PersonalInformationPanel.SetActive(true);
    }


    // GuidancePanel
    public void CloseGuidancePanel()
    {
        GuidancePanel.SetActive(false);
    }

    public void OpenGuidancePanel()
    {
        GuidancePanel.SetActive(true);
    }


    // InqueryPanel
    public void CloseInqueryPanel()
    {
        InqueryPanel.SetActive(false);
    }

    public void OpenInqueryPanel()
    {
        InqueryPanel.SetActive(true);
    }



    // ChangePasswordPanel
    public void CloseChangePasswordPanel()
    {
        ChangePasswordPanel.SetActive(false);
    }

    public void OpenChangePasswordPanel()
    {
        ChangePasswordPanel.SetActive(true);
    }


    //LicensePanel

    public void CloseLicensePanel()
    {
        LicensePanel.SetActive(false);
    }

    public void OpenLicensePanel()
    {
        LicensePanel.SetActive(true);
    }






}
