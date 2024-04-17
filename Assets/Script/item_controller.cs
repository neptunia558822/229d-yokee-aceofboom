using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class item_controller : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        TMP_Text txt;
        txt = GameObject.Find("/Canvas/Text").GetComponent<TMP_Text>();
        GameManager.nScore++;
        txt.text = "" + GameManager.nScore;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Collider2D c;
        if (!GetComponent<Collider2D>())
        {
            c= gameObject.AddComponent<BoxCollider2D>();
        }
        else
        {
            c = GetComponent<Collider2D>();
        }
        c.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
