using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class item_controller : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.nScore++;
        scoreText.text = GameManager.nScore.ToString($"Score : {GameManager.nScore}");

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        Destroy(gameObject, 0.4f);
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = $"Score : {GameManager.nScore}";

        Collider2D c;
        if (!GetComponent<Collider2D>())
        {
            c = gameObject.AddComponent<BoxCollider2D>();
        }
        else
        {
            c = GetComponent<Collider2D>();
        }
        c.isTrigger = true;
    }
}

