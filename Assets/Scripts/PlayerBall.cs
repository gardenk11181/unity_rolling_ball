using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower = 10;
    public int itemCount = 0;
    Rigidbody rigid;
    private bool isJump;
    AudioSource audioSource;
    public GameManager gameManager;


    void Awake() {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame

    void Update() {
        if(Input.GetButtonDown("Jump") && !isJump) { // prevent double jump
        isJump = true;
        rigid.AddForce(new Vector3(0,jumpPower,0),ForceMode.Impulse);
        }
    }

     void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h,0,v),ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Floor") {
            isJump = false;
        } else if(collision.gameObject.tag == "Finish")
        {
            if(itemCount == gameManager.totalItemCount)
            {
                // Game Clear!!
                SceneManager.LoadScene("Example1_1");
            } else
            {
                // Restart !!
                SceneManager.LoadScene("Example1_0");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audioSource.Play();
            other.gameObject.SetActive(false);
        }
    }
}
