using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    [SerializeField]
    private GameObject Bing;
    private Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer sr;
    private bool isGrounded;
    private float movementX;
    private const string WALK_ANIMATION = "Walk";
    private const string GROUND_TAG = "Ground";
    private const string ENEMY_TAG = "Enemy";
    private int ammo = 10;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        PlayerJump();
        AnimatePlayer();
        PlayerFire();
    }

    void PlayerMoveKeyboard()
    {
        // -1, 0, or 1
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    void PlayerFire()
    {
        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            ammo--;
            movementX = Input.GetAxisRaw("Horizontal");
            if (movementX > 0) Instantiate(Bing, new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z), transform.rotation);
            else Instantiate(Bing, new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z), transform.rotation);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
