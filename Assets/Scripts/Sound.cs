using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Sound : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Button button;
    public GameObject soU;
    public GameObject soG;
    public GameObject soB;
    private void Start()
    {
        soB.SetActive(false);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }
    public void SoundS()
    {
        AudioListener.pause = !AudioListener.pause;
        button.GetComponent<RectTransform>().localScale = new Vector3(0.9f, 0.9f, 0f);
        if (!AudioListener.pause)
        {
            soG.SetActive(true);
            soB.SetActive(false);
            soU.SetActive(true);
        }
        else
        {
            soB.SetActive(true);
            soG.SetActive(false);
            soU.SetActive(false);
         }
    }
    public void OnClicUp()
    {
        button.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 0f);
    }
}
