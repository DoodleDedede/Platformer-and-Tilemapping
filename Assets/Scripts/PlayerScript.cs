using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text score;

    public Text lives;

    public GameObject winTextObject;

    public GameObject loseTextObject;

    private int scoreValue = 0;

    private int livesValue = 3;

    public AudioSource musicSource;

    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    // Start is called before the first frame update
    void Start()
    {
      rd2d = GetComponent<Rigidbody2D>();
      score.text = scoreValue.ToString();
      lives.text = livesValue.ToString();
      winTextObject.SetActive(false);
      loseTextObject.SetActive(false);

      musicSource.clip = musicClipOne;
      musicSource.Play();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

        if (Input.GetKey("escape"))
        {
          Application.Quit();
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.collider.tag == "Coin")
      {
        Destroy(collision.collider.gameObject);
        scoreValue += 1;
        score.text = scoreValue.ToString();
      }

      if (collision.collider.tag == "Enemy")
      {
        Destroy(collision.collider.gameObject);
        livesValue -= 1;
        lives.text = livesValue.ToString();
      }

      if (scoreValue == 4)
        {
            transform.position = new Vector2(52.5f, 1.83f);
        }


      if (scoreValue == 8)
      {
        winTextObject.SetActive(true);

        musicSource.clip = musicClipOne;
        musicSource.Stop();

        musicSource.clip = musicClipTwo;
        musicSource.Play();
      }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
      if (collision.collider.tag == "Ground")
      {
        if (Input.GetKey(KeyCode.W))
        {
          rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
        }
      }

    }
}




