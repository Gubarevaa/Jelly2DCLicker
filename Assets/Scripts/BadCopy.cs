using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadCopy : MonoBehaviour
{
    public Text badCopyT;
    public int copy;
    private float badTime;
    [SerializeField] JellyScript js;
    private bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        badTime = Random.Range(80, 300);
        isStart = false;
    }
    private void BadCopyCount()
    {
        copy = Random.Range(150, 200);
        badCopyT.text = copy.ToString();
    }
    private void BadCopyStop()
    {
        Start();
        js.badJelly = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart)
        {
            if (badTime > 0)
            {
                badTime -= Time.deltaTime;
            }
            else
            {
                BadCopyStart();
            }
        }
        else if (copy <= 0)
        {
            BadCopyStop();
        }   
        
    }
    private void BadCopyStart()
    {
        isStart = true;
        BadCopyCount();
        js.badJelly = true;
    }
}
