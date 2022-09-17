using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class player_vida : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;
    private GameObject player;
    public GameObject canvasYouDied;
    private Animator animacio;
    public int vida = 5;
    public TextMeshProUGUI vidaTxt;

    public Material material;

    public Image uiImage;

    //public AudioClip sound;
    //public AudioClip sound2;
    //public AudioClip sound3;

    public AudioSource audioData;
    public AudioSource audioData2;
    public AudioSource audioData3;

    // Start is called before the first frame update
    private void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        animacio = GetComponent<Animator>();

        material.SetColor("_ToColor", Color.black);

        vidaTxt.SetText("" + vida);

        uiImage = GameObject.Find("imgElement").GetComponent<Image>();

        uiImage.sprite = Resources.Load<Sprite>("dn");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject element = GameObject.Find("Shoot");
        player_shoot tipusElement = element.GetComponent<player_shoot>();

        if (collision.gameObject.tag == "Enemic" || collision.gameObject.tag == "Enemic_2" || collision.gameObject.tag == "Enemic_3")
        {
            //m_SpriteRenderer.sprite = Resources.Load<Sprite>("player_base");
            animacio.SetInteger("color", 0);

            tipusElement.element = 0;

            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);

            vida--;
            audioData3.Play(0);

            uiImage.sprite = Resources.Load<Sprite>("dn");

            vidaTxt.SetText("" + vida);

            material.SetColor("_ToColor", Color.black);

            if (vida == 0)
            {
                Debug.Log("Has mort!");
                canvasYouDied.SetActive(true);
                vidaTxt.SetText("0");
                Time.timeScale = 0f;
            }
        }

        if (collision.gameObject.tag == "Nivell")
        {
            transform.parent = collision.transform;
        }

        if (collision.gameObject.tag == "cor")
        {
            audioData.Play(0);

            vida = vida + 1;
            vidaTxt.SetText("" + vida);
            Debug.Log(vida);
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))

        {
            material.SetColor("_ToColor", Color.red);
            audioData2.Play(0);

            uiImage.sprite = Resources.Load<Sprite>("df");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))

        {
            material.SetColor("_ToColor", Color.green);
            audioData2.Play(0);

            uiImage.sprite = Resources.Load<Sprite>("dp");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))

        {
            material.SetColor("_ToColor", Color.blue);
            audioData2.Play(0);

            uiImage.sprite = Resources.Load<Sprite>("da");
        }
    }
}