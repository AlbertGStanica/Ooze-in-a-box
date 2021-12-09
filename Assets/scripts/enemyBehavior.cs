using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{

    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [SerializeField] private Transform enemy;

    [SerializeField] private float speed;

    private Vector2 initScale;

    private bool movingLeft;

    private void Awake()
    {

        initScale = enemy.localScale;


    }
    private void Update()
    {

        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {

                move(-1);

            }
            else
            {

                changeDirection();
            }
            

        }
        else
        {

            if (enemy.position.x <= rightEdge.position.x)
            {
                move(1);

            }
            else
            {

                changeDirection();

            }

                

        }
        


    }

    private void changeDirection()
    {

        movingLeft = !movingLeft;

    }
    private void move(int _direction)
    {

        enemy.localScale = new Vector2(initScale.x * _direction, initScale.y);

        enemy.position = new Vector2(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y);

    }

}
