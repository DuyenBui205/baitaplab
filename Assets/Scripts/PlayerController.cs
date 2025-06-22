using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;

    bool walking, jumped, jumping, grounded = false;
    float speed = 40f, height = 40f, jumpTime, walkTime;
    int moveState;
    public GameObject gameOverText;
    
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (gameOverText != null)
            gameOverText.SetActive(false);

    }
    void Move(Vector3 dir)
    {
        walking = true;
        speed = Mathf.Clamp(speed, speed, 10f);
        walkTime = Time.time;

        transform.Translate(dir * speed * Time.fixedDeltaTime);
        if (walkTime<3f && walking)
        {
            speed += .025f;
        }
        else if (walkTime > 3f)
        {
            speed = 5f;
        }
    }
    void Jump()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if (grounded)
            {
                rbody.linearVelocity = new Vector2(rbody.linearVelocity.x, height);

            }
        }
        if(jumping && jumped)
        {
            rbody.gravityScale -= (0.1f * Time.fixedDeltaTime);
            FindObjectOfType<SoundManager>().PlayJump();
        }
        if (jumpTime > 1f)
            jumping = false;
        if (!jumping && jumped)
            rbody.gravityScale += .2f;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false); // Ẩn nhân vật
            Time.timeScale = 0;          // Dừng thời gian game

            //if (gameOverText != null)
            //    gameOverText.SetActive(true); // Hiện chữ GAME OVER

            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumped = false;
            jumping = false;

            anim.SetBool("Jump", false);
            jumpTime = 0;
            rbody.gravityScale = 5;
        }
    }

    void State()
    {
        switch (moveState)
        {
            case 1:
                anim.SetBool("Run", true);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), 
                    transform.localScale.y, transform.localScale.z);
                Move(Vector3.right);
                break;
            case 2:
                anim.SetBool("Run", true);
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x),
                    transform.localScale.y, transform.localScale.z);
                Move(Vector3.left);
                break;
            default:
                walking = false;
                walkTime = 0;
                speed = 5f;
                anim.SetBool("Run", false);
                break;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            jumped = true; jumping = true;
            jumpTime += Time.fixedDeltaTime;
        }
        else jumping = false;
    }
    void Update()
    {
        State();
    }
    private void FixedUpdate()
    {
        if(!Input.GetKey(KeyCode.RightArrow)||!Input.GetKey(KeyCode.UpArrow)
            || Input.GetKey(KeyCode.LeftArrow))
        {
            moveState = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow))
            moveState = 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveState = 2;
        Jump();
    }
}
