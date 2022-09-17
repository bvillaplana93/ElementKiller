using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class options_restart : MonoBehaviour
{
    private GameObject player;
    public GameObject canvasYouDied, canvasYouWin;
    public TextMeshProUGUI vidaTxt;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) || player.transform.position.y < -22)
        {
            //SceneManager.LoadScene("ElementKiller1.2");
            canvasYouDied.SetActive(true);

            Time.timeScale = 0f;
        }

        if (player.transform.position.x >= 149 && player.transform.position.y >= 12f)
        {
            canvasYouWin.SetActive(true);
            vidaTxt.SetText("0");
            Time.timeScale = 0f;

            if (Input.anyKeyDown)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("ElementKiller1.2");
            }
        }
    }
}