using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class menuDied : MonoBehaviour
{
    //public GameObject canvasYouDied;

    // Update is called once per frame

    public TextMeshProUGUI vidaTxt;

    public AudioSource audioData;
    public AudioSource audioData2;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData2 = GetComponent<AudioSource>();
        audioData.Play(0);
        audioData2.Play(0);
    }

    private void Update()
    {
       // vidaTxt.SetText("0");
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("ElementKiller1.2");
        }
    }
}