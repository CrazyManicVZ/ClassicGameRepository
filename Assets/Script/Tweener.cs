using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private List<Tween> activeTweens;
    //I just like having this here 
    private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        activeTweens = new List<Tween>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < activeTweens.Count; i++)
        {
            if (activeTweens[i] != null)
            {
                if (Vector3.Distance(activeTweens[i].Target.position, activeTweens[i].EndPos) > 0.1f)
                {
                    float timeCovered = (Time.time - activeTweens[i].StartTime) * speed;
                    float fractionDistance = timeCovered / activeTweens[i].Duration;

                    activeTweens[i].Target.position = Vector3.Lerp(activeTweens[i].StartPos, activeTweens[i].EndPos, Mathf.Pow(fractionDistance, 3.0f));
                }
                else if (Vector3.Distance(activeTweens[i].Target.position, activeTweens[i].EndPos) <= 0.1f)
                {
                    activeTweens[i].Target.position = activeTweens[i].EndPos;
                    activeTweens.Remove(activeTweens[i]);
                }
            }
        }
    }

    public bool TweenExists(Transform target)
    {

        foreach (Tween currentTween in activeTweens)
        {
            if (currentTween.Target == target)
            {
                return true;
            }
        }

        return false;

    }

    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        TweenExists(targetObject);

        if (TweenExists(targetObject) == false)
        {
            activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
            return true;
        }
        return false;
    }
}


