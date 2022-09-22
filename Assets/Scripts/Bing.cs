using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bing : MonoBehaviour
{
    public GameObject bing;
    public GameObject player;
    public float positionX;
    private Animator anim;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        positionX = player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        SetBingDirection();
    }

    void SetBingDirection()
    {
        if (positionX < transform.position.x) transform.position += new Vector3(3f, 0f, 0f) * Time.deltaTime * 6f;
        else transform.position -= new Vector3(3f, 0f, 0f) * Time.deltaTime * 6f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool("Binged", true);
            Destroy(other.gameObject);
        }
    }
}
