using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private Transform player;
    private Vector2 initScale;
    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        initScale = player.localScale;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.localScale = new Vector2(initScale.x * -1, initScale.y);
            anim.SetTrigger("keyPress");

        }
        if(Input.GetKeyUp(KeyCode.A))
        {

            anim.SetTrigger("keyRelease");

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            player.localScale = new Vector2(initScale.x * 1, initScale.y);
            anim.SetTrigger("keyPress");

        }
        if (Input.GetKeyUp(KeyCode.D))
        {

            anim.SetTrigger("keyRelease");

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            anim.SetTrigger("keyPressJ");

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {

            anim.SetTrigger("keyReleaseJ");

        }



    }
}
