using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointRock : MonoBehaviour
{
    [Range(0, 5)]
    public float speed;

    [Range(0, 2)]
    public float waitDuration;

    Vector3 targetPos;
    public GameObject Ways;
    public Transform[] wayPoint;

    int pointIndex;
    int pointCount;
    int direction = 1;
    
    int speedMultiplier = 1;

    private void Awake()
    {
        wayPoint = new Transform[Ways.transform.childCount];
        for (int i = 0; i < Ways.gameObject.transform.childCount; i++)
        {
            wayPoint[i] = Ways.transform.GetChild(i).gameObject.transform;
        }
    }
    private void Start()
    {
        pointCount = wayPoint.Length;
        pointIndex = 1;
        targetPos = wayPoint[pointIndex].transform.position;
    }

    private void Update()
    {
        var step = speedMultiplier * speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        if ( transform.position == targetPos)
        {
            NextPoint();
        }
    }
    void NextPoint()
    {
        if ( pointIndex == pointCount - 1)
        {
            direction = -1;
        }

        if (pointIndex == 0)
        {
            direction = 1;
        }
        pointIndex += direction;
        targetPos = wayPoint[pointIndex].transform.position;
        StartCoroutine(WaitNextPoint());
    }
    IEnumerator WaitNextPoint()
    {
        speedMultiplier = 0;
        yield return new WaitForSeconds(waitDuration);
        speedMultiplier = 1;
    }
}
