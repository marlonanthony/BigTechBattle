using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    private Rigidbody2D myBody;
    private Transform player;
    private Animator anim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        speed = 5;

        player = GameObject.FindWithTag("Player").transform;

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player &&
            myBody.transform.position.x < player.position.x + 5 &&
            myBody.transform.position.x > player.position.x - 5
            ) anim.SetBool("IsEmpty", true);
    }

    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }
}
