using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public float xPosition;
    public float yPosition;
    private Vector3 CenterPosition = new Vector3(-1.0f, -7.0f, 0.0f);
    public int randomchance;

    public float timeScale = 1.0f;
    private float timer = 0;

    public bool notLerping = true;

  [SerializeField]
    private GameObject Cherry;
    private Tweener tweener;

    public GameObject SpawnedCherry;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();

        randomchance = Random.Range(1, 3);
        
        if (randomchance == 1)
        {
            xPosition = Random.Range(-27f, 25f);
            yPosition = 9.4f;
        }

        if (randomchance == 2)
        {
            xPosition = -27f;
            yPosition = Random.Range(9.4f, -21.0f);
        }
        
        SpawnedCherry = Instantiate(Cherry, new Vector3(xPosition, yPosition, 0.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
        timer += Time.deltaTime;
        SpawningCherry();
    }

    void SpawningCherry()
    {
        if (SpawnedCherry != null)
        {
            if (randomchance == 1)
            {
                Vector3 Offsetpositions = new Vector3(0.0f, -5.5f, 0.0f);
                Vector3 EndPosition = -SpawnedCherry.transform.position + CenterPosition + Offsetpositions;
                if (notLerping == true)
                {
                    Tweenmovement(EndPosition, 50.0f);
                    notLerping = false;
                }
                if (SpawnedCherry.transform.position.y <= -21.0f)
                {
                    if (timer > 30)
                    {
                        Destroy(SpawnedCherry);
                        notLerping = true;
                        timer = 0;
                    }
                }

            }
            if (randomchance == 2)
            {
                Vector3 EndPosition = -SpawnedCherry.transform.position + CenterPosition;
                if (notLerping == true)
                {
                    Tweenmovement(EndPosition, 50.0f);
                    notLerping = false;
                }
                if (SpawnedCherry.transform.position.x >= 26.0f)
                {
                    if (timer > 30)
                    {
                        Destroy(SpawnedCherry);
                        notLerping = true;
                        timer = 0;
                    }
                }
            }
        }

        if (SpawnedCherry == null)
        {
            randomchance = Random.Range(1, 3);
            if (randomchance == 1)
            {
                xPosition = Random.Range(-27f, 25f);
                yPosition = 9.4f;
            }

            if (randomchance == 2)
            {
                xPosition = -27f;
                yPosition = Random.Range(9.4f, -21.0f);
            }
            SpawnedCherry = Instantiate(Cherry, new Vector3(xPosition, yPosition, 0.0f), Quaternion.identity);
        }
    }

    public void Tweenmovement(Vector3 position, float duration)
    {
        if (SpawnedCherry != null)
        {
            tweener.AddTween(SpawnedCherry.transform, SpawnedCherry.transform.position, position, duration);
        }
    }
}
