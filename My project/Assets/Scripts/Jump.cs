using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{

    Rigidbody2D rb;
    public bool ReadyJump;
    public bool ReadyGround;
    public int ForceJump;

    public int score;
    public Text scoreT;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreT.text = score.ToString();
    }
    void FixedUpdate()
    {
        if (ReadyJump && ReadyGround)
        {
            rb.AddForce(new Vector2(0, ForceJump));
            ReadyJump = false;
            ReadyGround = false;
        }
    }

    public void JumpPlayer()
    {
        ReadyJump = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            ReadyGround = true;
        }
        else
        {
            ReadyGround = false;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "Score")
        {
            score++;
            scoreT.text = score.ToString();
        }
    }
}
