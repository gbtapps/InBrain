using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class S210BrainExSpeedTouchControllerScript : MonoBehaviour
{

    public GameObject DifficultyPanel;
    public static string GameId;


    public void MoveToBrainExSt()
    {
        SceneManager.LoadScene("S211BexSpeedTouchId1");

    }

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
