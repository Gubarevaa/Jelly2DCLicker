using System.Collections;
using System.Collections.Generic;
using DB;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JellyScript : MonoBehaviour
{
    public int money;
    public Text moneyText;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject bonus;
    [SerializeField] GameObject pref;
    [SerializeField] GameObject inform1;
    [SerializeField] GameObject inform2;
    [SerializeField] GameObject busyPanel;
    [SerializeField] Button gameShopB;
    [SerializeField] Button cbusyPanel;
    [SerializeField] Button infB1;
    [SerializeField] Button infB2;
    public Button prefB;
    public Sprite shopI;
    public Sprite gameI;
    [SerializeField] Button gameBonusB;
    public Sprite bonusI;
    public Sprite gameB;
    public Animator anim;
    public AudioClip clic;
    public AudioSource source;
    public GameObject jellyPrefab;
    public Button jellyButton;
    public Sprite badJellyButton;
    public Sprite goodJellyButton;
    public float timeStart = 10;
    public InterstitialAds ad;
    public RewardedAds rAd;
    public bool badJelly;
    public Sprite badS;
    public Sprite goodS;
    public BadCopy bc;
    public int moneyAdd;
    public GameObject effectN;
    public GameObject effectPlus;
    public Sound s;
    public Text idT;

    [SerializeField] private Database db;


    // Start is called before the first frame update
    public void ButtonClick()
    {
        GameObject jellyClone = Instantiate(jellyPrefab);
        Sprite jellysprite;
        GameObject effect;
        if (badJelly == false)
        {
            jellyButton.GetComponent<Image>().sprite = goodJellyButton;
            jellysprite = goodS;
            money = money + moneyAdd;
            PlayerPrefs.SetInt("money", money);
            db.SaveData("money", money);
            effect = effectPlus;
        }
        else
        {
            jellyButton.GetComponent<Image>().sprite = badJellyButton;
            jellysprite = badS;
            bc.copy--;
            bc.badCopyT.text = bc.copy.ToString();
            effect = effectN;
        }
        Instantiate(effect, jellyButton.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
        SpriteCloneSet(jellyClone, jellysprite);
        source.PlayOneShot(clic);
        anim.SetTrigger("doTouch");
        
    }

    private void SpriteCloneSet(GameObject jellyClone, Sprite sprite)
    {
        jellyClone.GetComponent<SpriteRenderer>().sprite = sprite;
    }
	
    
    void Start()
    {
        moneyAdd = 1;
        busyPanel.SetActive(false);
        bonus.SetActive(false);
        pref.SetActive(false);
        money = PlayerPrefs.GetInt("money");
    }
   
    public void Inf1()
    {
        inform1.SetActive(true);
    }
    public void PreftGame()
    {
        pref.SetActive(false);
    }
    public void GamePref()
    {
        pref.SetActive(true);
    }
    public void InfBack()
    {
        if (inform1.activeSelf)
        {
            inform1.SetActive(false);
        }
        else if (inform2.activeSelf)
        {
            inform2.SetActive(false);
        }
    }
    public void Inf2()
    {
        inform2.SetActive(true);
    }
    public void BonusShop()
    {
        inform1.SetActive(false);
        inform2.SetActive(false);
        if (bonus.activeSelf)
        {
            bonus.SetActive(false);
            gameBonusB.image.sprite = gameB;
        }
        else
        {
            bonus.SetActive(true);
            gameBonusB.image.sprite = bonusI;
        }

    }
    public void CloseBusyPanel()
    {
        ad.ShowAd();
        busyPanel.SetActive(false);
        timeStart = 10;
    }
    // Update is called once per frame
    void Update()
    {
        if (timeStart > 0)
        {
           timeStart -= Time.deltaTime;
        }
        else 
        {
            busyPanel.SetActive(true);
        }
        moneyText.text = money.ToString();
    }

}
