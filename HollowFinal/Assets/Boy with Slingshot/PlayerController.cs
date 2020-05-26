using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float moveVelocity = 1f;
    public float jumpHeight = 20;

    public float horizontal = 0;
    public bool facingRight;
    private bool isWalking;
    private bool isJumping;
    private float currentY;

    public Transform firePoint;
    public GameObject bulletPrefab;


    private Rigidbody2D MyRigidbody;
    private Animator anim;
    private AudioSource audioSource;

    private void Awake()
    {
        MyRigidbody = GetComponent<Rigidbody2D>();
        MyRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = true;
        isJumping = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical);
        Debug.Log(horizontal);

        isWalking = false;
        moveVelocity = 0;

        Flip(horizontal);
        if (direction.x > 0 && isJumping == false)
        {
            moveVelocity = moveSpeed;
            isWalking = true;
            MyRigidbody.velocity = new Vector2(moveVelocity, 0);
        }
        if (direction.x < 0 && isJumping == false)
        {
            moveVelocity = -1 * moveSpeed;
            isWalking = true;
            MyRigidbody.velocity = new Vector2(moveVelocity, 0);
        }

        if (direction.y > 0 && isJumping == false)
        {
            isWalking = false;
            MyRigidbody.velocity = new Vector2(moveVelocity, jumpHeight);
            audioSource = GetComponents<AudioSource>()[0];
            audioSource.Play();
            isJumping = true;
        }

        if (MyRigidbody.velocity.y == 0)
        {
            isJumping = false;
        }

        if (isWalking == false && isJumping == false)
        {
            MyRigidbody.velocity = new Vector2(0, MyRigidbody.velocity.y);
        } 

        if ( Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Shoot");
            Shoot();
        }

        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isJumping", isJumping);
        
        //anim.SetFloat("x", direction.x);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "coin")
        {
            Coin.numCoins++;
            audioSource = GetComponents<AudioSource>()[1];
            audioSource.Play();
            Destroy(col.gameObject);

            if (Coin.numCoins == 8)
            {
                SceneManager.LoadScene("Victory");
            }

        }

        if (col.gameObject.tag == "ground")
        {
            isJumping = false;
        }
    }
    private void Flip(float horizontal)
    {
        if (horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }
        else if (horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    void Shoot ()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}