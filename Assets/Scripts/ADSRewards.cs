using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ADSRewards : MonoBehaviour
{
    private int percent;
    [SerializeField] private AutoClik au;
    [SerializeField] Text klicT;
    [SerializeField] JellyScript js;

    private void Start()
    {
        percent = PlayerPrefs.GetInt("percent");
        percent = 19;
        klicT.text = percent + "/20";
    }
    public void MoreCoinsClic()
    {
        StartCoroutine(MoreSeconds());
    }
    IEnumerator MoreSeconds()
    {
        js.moneyAdd = 10;
        yield return new WaitForSeconds(30);
        js.moneyAdd = 1;
    }
    public void AutoClickBonus()
    {
        percent++;
        PlayerPrefs.SetInt("percent", percent);
        if (percent == 20)
        {
            StartCoroutine(au.AutoClic1LVL());
            PlayerPrefs.SetInt("percent", 0);
        }
        else if (percent == 20 & PlayerPrefs.GetInt("LVL") == 1)
        {
            StartCoroutine(au.AutoClic2LVL());
            PlayerPrefs.SetInt("percent", 0);
        }
        else if (percent == 20 & PlayerPrefs.GetInt("LVL") == 2)
        {
            StartCoroutine(au.AutoClic3LVL());
            PlayerPrefs.SetInt("percent", 0);
        }
        else if (percent == 20 & PlayerPrefs.GetInt("LVL") == 3)
        {
            StartCoroutine(au.AutoClic4LVL());
        }
        percent = PlayerPrefs.GetInt("percent");
        klicT.text = percent + "/20";
    }
}
