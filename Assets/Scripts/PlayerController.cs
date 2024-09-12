using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool isFalling;
    [SerializeField] private float rotationSpeed = 10f; 
    private Rigidbody2D rb;
    private AudioSource jumpSound;
    private Animator animator;
    public GameManager gameManager;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0){
            animator.ResetTrigger("isFlapping");
        }

        if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && isGameOver == false){
            rb.velocity = Vector2.up * jumpForce;
            jumpSound.Play();
            animator.SetTrigger("isFlapping");

        }

        transform.rotation = Quaternion.Euler(0,0,rb.velocity.y * rotationSpeed);
    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        isGameOver = true;
        gameManager.GetComponent<GameManager>().GameOver();
        
    }

    }


