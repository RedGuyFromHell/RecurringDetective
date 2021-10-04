using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessScript : MonoBehaviour
{

    SpriteRenderer sr;
    bool isTriggered = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Color color = sr.color;
            if (color.a > 0)
            {
                color.a -= Time.deltaTime;
                sr.color = color;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //LeanTween.alpha(sr.gameObject, 1, 1);
        if (collision.gameObject.tag == "Player")
            isTriggered = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            isTriggered = true;
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(isTriggered == true)
        {
            Color color = sr.color;
            if (color.a <= 200)
            {
                color.a += Time.deltaTime;
                sr.color = color;
            }
        }
    }
}
