using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float force = 0;

    public float jumpForce = 0;

    public float velocitiy = 0;

    Rigidbody rb;

    public float score = 0;
    public Text scoreText;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();

    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && Time.timeScale > 0.0f)
            Jump();

        if (scoreText)
            scoreText.text = "Score: " + score.ToString();
    }

    private void FixedUpdate()
    {
        rb.AddForce(Input.GetAxis("Horizontal") * force, 0, Input.GetAxis("Vertical") * force);
    }

    private void Jump()
    {
        if (rb)
            if (Mathf.Abs(rb.velocity.y)<0.05f)
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (score < 5)            
            if (collision.gameObject.CompareTag("Destruccion"))
                Destroy(gameObject);
                    
    }
}
