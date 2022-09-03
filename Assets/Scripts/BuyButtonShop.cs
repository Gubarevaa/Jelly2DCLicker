using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonShop : MonoBehaviour
{
    private Button buyB;
    public int price;
    public Sprite jelly;
    public float cofmun;
    private Button jellyB;

    // Start is called before the first frame update
    void Start()
    {
        jellyB = GameObject.Find("Jelly").GetComponent<Button>();
        buyB = GetComponent<Button>();
        buyB.onClick.AddListener(ButtonClic);
    }
    public void ButtonClic()
    {
        if (price <= PlayerPrefs.GetInt("money"))
        {
            jellyB.image.sprite = jelly;
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - price);        
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
