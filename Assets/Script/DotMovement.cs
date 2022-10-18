using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMovement : MonoBehaviour
{
    
    private Tweener tweener;
    public bool dot1active = false;
    public bool dot2active = false;
    public bool dot3active = false;
    public bool dot4active = false;
    public float timeScale = 1.0f;
    [SerializeField] private GameObject dot1;
    [SerializeField] private GameObject dot2;
    [SerializeField] private GameObject dot3;
    [SerializeField] private GameObject dot4;
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }


    public void Tweenmovement(Vector3 position, float duration)
    {
        if (dot1active)
        {
            tweener.AddTween(dot1.transform, dot1.transform.position, position, duration);
            dot1active = false;
        }
        if (dot2active)
        {
            tweener.AddTween(dot2.transform, dot2.transform.position, position, duration);
            dot2active = false;
        }
        if (dot3active)
        {
            tweener.AddTween(dot3.transform, dot3.transform.position, position, duration);
            dot3active = false;
        }
        if (dot4active)
        {
            tweener.AddTween(dot4.transform, dot4.transform.position, position, duration);
            dot4active = false;
        }
    }

    // Update is called once per frame

    void Tweening()
    {

        //I made it slow so you got time to see the animation
        if (dot1.transform.position == new Vector3(-3.3f, 2.1f, 0.0f))
        {
            dot1active = true;
            Tweenmovement(new Vector3(-3.3f, 4.7f, 0.0f), 1f);
        }

        if (dot1.transform.position == new Vector3(-3.3f, 4.7f, 0.0f))
        {
            dot1active = true;
            Tweenmovement(new Vector3(3.42f, 4.7f, 0.0f), 1f);
        }

        if (dot1.transform.position == new Vector3(3.42f, 4.7f, 0.0f))
        {
            dot1active = true;
            Tweenmovement(new Vector3(3.42f, 2.1f, 0.0f), 1f);
        }

        if (dot1.transform.position == new Vector3(3.42f, 2.1f, 0.0f))
        {
            dot1active = true;
            Tweenmovement(new Vector3(-3.3f, 2.1f, 0.0f), 1f);
        }

        if (dot2.transform.position == new Vector3(-3.3f, 2.1f, 0.0f))
        {
            dot2active = true;
            Tweenmovement(new Vector3(-3.3f, 4.7f, 0.0f), 1f);
        }

        if (dot2.transform.position == new Vector3(-3.3f, 4.7f, 0.0f))
        {
            dot2active = true;
            Tweenmovement(new Vector3(3.42f, 4.7f, 0.0f), 1f);
        }

        if (dot2.transform.position == new Vector3(3.42f, 4.7f, 0.0f))
        {
            dot2active = true;
            Tweenmovement(new Vector3(3.42f, 2.1f, 0.0f), 1f);
        }

        if (dot2.transform.position == new Vector3(3.42f, 2.1f, 0.0f))
        {
            dot2active = true;
            Tweenmovement(new Vector3(-3.3f, 2.1f, 0.0f), 1f);
        }

        if (dot3.transform.position == new Vector3(-3.3f, 2.1f, 0.0f))
        {
            dot3active = true;
            Tweenmovement(new Vector3(-3.3f, 4.7f, 0.0f), 1f);
        }

        if (dot3.transform.position == new Vector3(-3.3f, 4.7f, 0.0f))
        {
            dot3active = true;
            Tweenmovement(new Vector3(3.42f, 4.7f, 0.0f), 1f);
        }

        if (dot3.transform.position == new Vector3(3.42f, 4.7f, 0.0f))
        {
            dot3active = true;
            Tweenmovement(new Vector3(3.42f, 2.1f, 0.0f), 1f);
        }

        if (dot3.transform.position == new Vector3(3.42f, 2.1f, 0.0f))
        {
            dot3active = true;
            Tweenmovement(new Vector3(-3.3f, 2.1f, 0.0f), 1f);
        }

        if (dot4.transform.position == new Vector3(-3.3f, 2.1f, 0.0f))
        {
            dot4active = true;
            Tweenmovement(new Vector3(-3.3f, 4.7f, 0.0f), 1f);
        }

        if (dot4.transform.position == new Vector3(-3.3f, 4.7f, 0.0f))
        {
            dot4active = true;
            Tweenmovement(new Vector3(3.42f, 4.7f, 0.0f), 1f);
        }

        if (dot4.transform.position == new Vector3(3.42f, 4.7f, 0.0f))
        {
            dot4active = true;
            Tweenmovement(new Vector3(3.42f, 2.1f, 0.0f), 1f);
        }

        if (dot4.transform.position == new Vector3(3.42f, 2.1f, 0.0f))
        {
            dot4active = true;
            Tweenmovement(new Vector3(-3.3f, 2.1f, 0.0f), 1f);
        }

    }





    void Update()
    {
        Tweening();
    }

}
