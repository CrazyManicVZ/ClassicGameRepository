using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private Tweener tweener;
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
    void Update()
    {
        if (Player.transform.position == new Vector3(-13.5f, 3.50f, 0.0f))
        {
            Tweenmovement(new Vector3(-13.5f, 7.50f, 0.0f), 3.0f);

        }

        if (Player.transform.position == new Vector3(-13.5f, 7.50f, 0.0f))
        {
            Tweenmovement(new Vector3(-8.5f, 7.50f, 0.0f), 3.0f);
        }

        if (Player.transform.position == new Vector3(-8.5f, 7.50f, 0.0f))
        {
            Tweenmovement(new Vector3(-8.5f, 3.50f, 0.0f), 3.0f);
        }

        if (Player.transform.position == new Vector3(-8.5f, 3.50f, 0.0f))
        {
            Tweenmovement(new Vector3(-13.5f, 3.50f, 0.0f), 3.0f);
        }

    }
}
