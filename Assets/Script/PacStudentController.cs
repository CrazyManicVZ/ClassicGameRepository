using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{

    public LayerMask wallCollusion;

    public float playerSpeed = 0.1f;

    public Vector3 lastInputtedDirection;

    public Vector3 currentInputtedDirection;

    public Vector3 startPosition;

    public Vector3 originalposition;

    public ParticleSystem walkDust;
    public ParticleSystem crash;

    public bool movingUp = false;
    public bool movingDown = false;
    public bool movingLeft = false;
    public bool movingRight = false;

    public bool eating = false;
    public bool blocked = false;

    public float timeScale = 1.0f;
    private int lastTime = 0;
    private float timer = 0;

    [SerializeField]
    private GameObject Player;
    private Tweener tweener;
    public Animator playerAnimator;
    public AudioSource walkingSource;
    public AudioSource eatingSource;
    public AudioSource backgroundSource;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        startPosition = Player.transform.position;
       
    }

    public void Tweenmovement(Vector3 position, float duration)
    {
        tweener.AddTween(Player.transform, Player.transform.position, position, duration);
    }


    void Tweening()
    {
        //I made it slow so you got time to see the animation
        if (Input.GetKeyDown(KeyCode.W))
        {
            blocked = false;
            spawnDust();
            setInput(new Vector3(0, 1, 0));
            movingUp = true;
            movingDown = false;
            movingRight = false;
            movingLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            blocked = false;
            spawnDust();
            setInput(new Vector3(-1, 0, 0));
            movingUp = false;
            movingDown = false;
            movingRight = false;
            movingLeft = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            blocked = false;
            spawnDust();
            setInput(new Vector3(0, -1, 0));
            movingUp = false;
            movingDown = true;
            movingRight = false;
            movingLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            blocked = false;
            spawnDust();
            setInput(new Vector3(1, 0, 0));
            movingUp = false;
            movingDown = false;
            movingRight = true;
            movingLeft = false;

        }
    }

    public void setInput (Vector3 direction)
    {
        if (!Blocked(direction))
        {
            lastInputtedDirection = direction;
            currentInputtedDirection = new Vector3(0, 0, 0);
        }
        else
        {
            currentInputtedDirection = direction;
        }
    }

    void spawnDust()
    {
        walkDust.Play();
    }

    void spawnCrash()
    {
        crash.Play();
    }

    public bool Blocked (Vector3 direction)
    {
        RaycastHit2D Block = Physics2D.BoxCast(Player.transform.position, new Vector3(1, 1, 1) * 0.75f, 0.0f, direction, 2.0f, wallCollusion);

        return Block.collider != null;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        spawnCrash();
        lastInputtedDirection = -lastInputtedDirection;
        StartCoroutine(Delaytime(1f));
        blocked = true;
    }


    IEnumerator Delaytime (float time)
        {
            yield return new WaitForSeconds(time);
        }

    void soundEffects()
    {
        if (movingUp == true || movingDown == true || movingLeft == true || movingRight == true)
        {
            if (timer > lastTime + 1)
            {
                if (eating == true)
                {
                    backgroundSource.volume = 0.5f;
                    eatingSource.Play();
                    lastTime++;
                }
                else
                {
                    backgroundSource.volume = 0.5f;
                    walkingSource.Play();
                    lastTime++;
                }
            }
        }
        else
        {
            backgroundSource.volume = 1.0f;
            walkingSource.Stop();
        }
    }

    void Teleport()
    {
        if (Player.transform.position.x <= -14.5f)
        {
            blocked = true;
            Player.transform.position = new Vector3(13.0f, Player.transform.position.y, Player.transform.position.z);
            blocked = false;
        }

        if (Player.transform.position.x >= 13.5f)
        {
            blocked = true;
            Player.transform.position = new Vector3(-12.5f, Player.transform.position.y, Player.transform.position.z);
            blocked = false;
        }
    }

    void playAnimation()
    {
        if (movingUp == true && lastInputtedDirection == new Vector3(0, 1, 0))
        {
            playerAnimator.SetBool("movingUp", true);
            playerAnimator.SetBool("movingDown", false);
            playerAnimator.SetBool("movingRight", false);
            playerAnimator.SetBool("movingLeft", false);

        }

        if (movingDown == true && lastInputtedDirection == new Vector3(0, -1, 0))
        {
            playerAnimator.SetBool("movingUp", false);
            playerAnimator.SetBool("movingDown", true);
            playerAnimator.SetBool("movingRight", false);
            playerAnimator.SetBool("movingLeft", false);
        }

        if (movingLeft == true && lastInputtedDirection == new Vector3(-1, 0, 0))
        {
            playerAnimator.SetBool("movingUp", false);
            playerAnimator.SetBool("movingDown", false);
            playerAnimator.SetBool("movingRight", false);
            playerAnimator.SetBool("movingLeft", true);
        }

        if (movingRight == true && lastInputtedDirection == new Vector3(1, 0, 0))
        {
            playerAnimator.SetBool("movingUp", false);
            playerAnimator.SetBool("movingDown", false);
            playerAnimator.SetBool("movingRight", true);
            playerAnimator.SetBool("movingLeft", false);
        }
    }



    // Update is called once per frame
    void Update()
    {
        Tweening();
        soundEffects();
        playAnimation();
        Time.timeScale = timeScale;
        timer += Time.deltaTime;

        if (currentInputtedDirection != new Vector3(0, 0, 0))
        {
            setInput(currentInputtedDirection);
        }

    }

    private void FixedUpdate()
    {
        Teleport();
        if (blocked == false)
        {
            Vector3 playerTranslation = lastInputtedDirection * Time.fixedDeltaTime;
            Tweenmovement((Player.transform.position + playerTranslation), playerSpeed);
        }
    }

}
