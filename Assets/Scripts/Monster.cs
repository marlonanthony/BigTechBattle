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
    [SerializeField]
    private GameObject amazonPackage;

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
            // if amazon drone is within 5px of player 
            myBody.transform.position.x < player.position.x + 5 &&
            myBody.transform.position.x > player.position.x - 5 &&
            !anim.GetBool("IsEmpty"))
        {
            // transition to empty animation state and render explosive
            anim.SetBool("IsEmpty", true);
            amazonPackage = Instantiate(amazonPackage);
            amazonPackage.transform.localPosition = new Vector3(myBody.transform.position.x, -2.7f, 1f);
        }
    }

    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }
}
