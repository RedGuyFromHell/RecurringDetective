using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Teleport : MonoBehaviour
{
    [SerializeField]
    private GameObject rainGenerator;

    [Header("Scene fade in/out")]
    public GameObject fadeOut;
    public GameObject fadeIn;

    /*
    [Header("UI Display")]
    public GameObject UIDisplay;
    public TMP_Text TextDisplay;
    public string InteractibleNameText;
    private RectTransform UiDisplayRectTransform;
    */

    public GameObject toTeleport;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FadeInScene()
    {
        LeanTween.alpha(fadeIn.GetComponent<RectTransform>(), 0f, 1f).setOnComplete(DisablePanel =>
        {
            fadeIn.SetActive(false);
        });
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            fadeOut.SetActive(true);
            
            LeanTween.alpha(fadeOut.GetComponent<RectTransform>(), 1f, 1f).setOnComplete(resetScene =>
            {
                fadeOut.GetComponent<RectTransform>().LeanAlpha(0f, 0f);
                fadeOut.SetActive(false);
                fadeIn.SetActive(true);
                fadeIn.GetComponent<RectTransform>().LeanAlpha(1f, 0f);
                rainGenerator.SetActive(!rainGenerator.activeSelf);

                other.transform.position = toTeleport.transform.position;

                FadeInScene();
            });

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}