using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class S220BrainExSpeedCalculationControllerScript : MonoBehaviour
{

    public GameObject DifficultyPanel;
    public static string GameId;


    /*
    public void MoveToS200BrainExMenu()
    {
        SceneManager.LoadScene("S200BrainExMenu");

    }


    public void MoveToS221BexSpeedCalculationId1()
    {
        SceneManager.LoadScene("S221BexSpeedCalculationId1");

    }
    */


    /*
    public void MoveToS212Bex()
    {
        SceneManager.LoadScene("S212BexSpeedTouchId2");

    }

    public void MoveToS213Bex()
    {
        SceneManager.LoadScene("S213BexSpeedTouchId3");

    }



    public void MoveToBrainExMenu()
    {

        SceneManager.LoadScene("20.BrainExMenu");

    }

    */



    public void CloseDifficultyPanel()
    {
        DifficultyPanel.SetActive(false);
    }



    public void ShowDifficultyPanel()
    {
        DifficultyPanel.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        //開発中の不注意でパネルがでているとマズイので非表示に
        DifficultyPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
