using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    private AudioSource audioSource;
    public GameObject player;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "coin")
        {
            Coin.numCoins++;
            audioSource = GetComponents<AudioSource>()[0];
            audioSource.Play();
            Destroy(col.gameObject);
            Destroy(gameObject);

            if (Coin.numCoins == 8)
            {
                SceneManager.LoadScene("Victory");
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1.0F * Time.deltaTime;
        if (timer >= 4)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
