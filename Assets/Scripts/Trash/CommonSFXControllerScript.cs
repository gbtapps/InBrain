using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSFXControllerScript : MonoBehaviour
{

    //サウンドエフェクト
    public AudioClip SoundCorrectAnswer;
    public AudioClip SoundWrongAnswer;

    public AudioClip SoundStartCountdown;
    public AudioClip SoundTimeupCountdown;

    public AudioClip SoundGoodResponse;
    public AudioClip SoundSetQuestions;

    public AudioClip SoundResultOpen;
    public AudioClip SoundResultClose;

    private AudioSource ThisClassAudioSource;


    //サウンド関数
    public void DoSoundCorrectAnswer()
    {
        ThisClassAudioSource.PlayOneShot(SoundCorrectAnswer);
    }

    public void DoSoundWrongAnswer()
    {
        ThisClassAudioSource.PlayOneShot(SoundWrongAnswer);

    }

    public void DoSoundStartCountdown()
    {
        ThisClassAudioSource.PlayOneShot(SoundStartCountdown);

    }

    public void DoSoundTimeupCountdown()
    {
        ThisClassAudioSource.PlayOneShot(SoundTimeupCountdown);

    }

    public void DoSoundGoodResponse()
    {
        ThisClassAudioSource.PlayOneShot(SoundGoodResponse);

    }

    public void DoSoundSetQuestions()
    {
        ThisClassAudioSource.PlayOneShot(SoundSetQuestions);

    }

    public void DoSoundResultOpen()
    {
        ThisClassAudioSource.PlayOneShot(SoundResultOpen);

    }

    public void DoSoundResultClose()
    {
        ThisClassAudioSource.PlayOneShot(SoundResultClose);


    }







    // Start is called before the first frame update
    void Start()
    {
        //サウンド・エフェクトComponentを取得
        ThisClassAudioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
