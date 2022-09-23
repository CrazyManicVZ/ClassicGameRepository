using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween 
{
    public Transform Target { get; private set; }
    public Vector3 StartPos { get; private set; }
    public Vector3 EndPos { get; private set; }
    public float StartTime { get; private set; }
    public float Duration { get; private set; }

    public Tween(Transform TargetTrans, Vector3 firstPos, Vector3 lastPos, float Time, float timePassed)
    {
        Target = TargetTrans;
        StartPos = firstPos;
        EndPos = lastPos;
        StartTime = Time;
        Duration = timePassed;
    }
}
