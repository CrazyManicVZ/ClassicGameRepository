using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private Tweener tweener;
    public Animator playerAnimator;
    public AudioSource walkingSource;
    public AudioSource backgroundSource;
    public bool movingUp = false;
    public bool movingDown = false;
    public bool movingLeft = false;
    public bool movingRight = false; 
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }


    public void Tweenmovement(Vector3 position, float duration)
    {
        tweener.AddTween(Player.transform, Player.transform.position, position, duration); 
    }

    // Update is called once per frame

    void Tweening()
    {
        if (Player.transform.position == new Vector3(-13.5f, 3.50f, 0.0f))
        {
            Tweenmovement(new Vector3(-13.5f, 7.50f, 0.0f), 6.0f);
            movingUp = true;
            movingDown = false;
            movingRight = false;
            movingLeft = false; 
        }

        if (Player.transform.position == new Vector3(-13.5f, 7.50f, 0.0f))
        {
            movingUp = false;
            movingDown = false;
            movingRight = true;
            movingLeft = false;
            Tweenmovement(new Vector3(-8.5f, 7.50f, 0.0f), 6.0f);
        }

        if (Player.transform.position == new Vector3(-8.5f, 7.50f, 0.0f))
        {
            movingUp = false;
            movingDown = true;
            movingRight = false;
            movingLeft = false;
            Tweenmovement(new Vector3(-8.5f, 3.50f, 0.0f), 6.0f);
        }

        if (Player.transform.position == new Vector3(-8.5f, 3.50f, 0.0f))
        {
            movingUp = false;
            movingDown = false;
            movingRight = false;
            movingLeft = true;
            Tweenmovement(new Vector3(-13.5f, 3.50f, 0.0f), 6.0f);
        }

    }

    void soundEffects()
    {
        if (movingUp == true || movingDown == true || movingLeft == true || movingRight == true)
        {
            backgroundSource.volume = 0.5f;
            walkingSource.PlayDelayed(0.5f);
        }
        else
        {
            backgroundSource.volume = 1.0f;
            walkingSource.Stop();
        }
    }

    void playAnimation()
    {
        if (movingUp == true)
        {
            playerAnimator.SetBool("movingUp", true);
            playerAnimator.SetBool("movingDown", false);
            playerAnimator.SetBool("movingRight", false);
            playerAnimator.SetBool("movingLeft", false);

        }

        if (movingDown == true)
        {
            playerAnimator.SetBool("movingUp", false);
            playerAnimator.SetBool("movingDown", true);
            playerAnimator.SetBool("movingRight", false);
            playerAnimator.SetBool("movingLeft", false);
        }

        if (movingLeft == true)
        {
            playerAnimator.SetBool("movingUp", false);
            playerAnimator.SetBool("movingDown", false);
            playerAnimator.SetBool("movingRight", false);
            playerAnimator.SetBool("movingLeft", true);
        }

        if (movingRight == true)
        {
            playerAnimator.SetBool("movingUp", false);
            playerAnimator.SetBool("movingDown", false);
            playerAnimator.SetBool("movingRight", true);
            playerAnimator.SetBool("movingLeft", false);
        }
    }

    void Update()
    {
        Tweening();
        soundEffects();
        playAnimation();
    }

}
