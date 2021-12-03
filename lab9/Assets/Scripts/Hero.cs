using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private AudioSource getCoin;
    [SerializeField] private AudioSource toStart;
    public string sceneName;
    private bool isGrounded = false;
    public int score = 0;
    public GameObject text;
    private Vector3 startPos;


    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        text.SetActive(false);
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded) State = States.idle;
        if(Input.GetButton("Horizontal")) Run();
        if(isGrounded && Input.GetButtonDown("Jump")) Jump();
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if(score==14)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private States State{
        get{return (States)animator.GetInteger("State");}
        set{animator.SetInteger("State", (int)value);}
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Run()
    {
        if(isGrounded) State = States.run;
        Vector3 dir = transform.right* Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length>1;
        if(!isGrounded) State = States.jump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            getCoin.Play();
            Destroy(collision.gameObject);
            score++;
            text.SetActive(true);
            text.GetComponent<Text>().text = "Score: " + score.ToString();
        }
        if(collision.gameObject.tag == "Skull")
        {
            toStart.Play();
            Destroy(collision.gameObject);
            transform.position=startPos;
        }
    }
}

public enum States
{
    idle,
    run,
    jump
}
