using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterFunction : MonoBehaviour
{
    public Transform linkedposition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Working");
        Vector3 position = collision.transform.position;
        position.x = this.linkedposition.position.x;
        position.y = this.linkedposition.position.y;
        collision.transform.position = position;
    }
}
