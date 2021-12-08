using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public AudioSource keySound;
    void Start()
    {
        keySound = GetComponent<AudioSource>();
    }
    
    private void OnMouseDown()
    {
        keySound.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            keySound.Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 0.6f);
        }

    }
}



