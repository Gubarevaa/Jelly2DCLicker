using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoClik : MonoBehaviour
{
    public GameObject jellyClone;
    public JellyScript js;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public IEnumerator AutoClic1LVL()
    {
        while(true)
        {
            Instantiate(jellyClone);
            js.money += 5;
            PlayerPrefs.SetInt("LVL", 1);
            yield return new WaitForSeconds(1);
        }
        
    }
    public IEnumerator AutoClic2LVL()
    {
        while (PlayerPrefs.GetInt("LVL") == 1)
        {
            Instantiate(jellyClone);
            js.money += 10;
            PlayerPrefs.SetInt("LVL", 2);
            yield return new WaitForSeconds(1);
        }

    }
    public IEnumerator AutoClic3LVL()
    {
        while (PlayerPrefs.GetInt("LVL") == 2)
        {
            Instantiate(jellyClone);
            js.money += 15;
            PlayerPrefs.SetInt("LVL", 3);
            yield return new WaitForSeconds(1);
        }

    }
    public IEnumerator AutoClic4LVL()
    {
        while (PlayerPrefs.GetInt("LVL") == 3)
        {
            Instantiate(jellyClone);
            js.money += 20;
            yield return new WaitForSeconds(1);
        }

    }
}
