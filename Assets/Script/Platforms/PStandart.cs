using System;
using System.Collections;
using UnityEngine;

public class PStandart : MonoBehaviour
{
    public Jump Jump;
    public float speed;
    Vector3 targetPos;

    Moove movementController;

    //Rigidbody2D rb;
    Vector3 moveDirection;

    public Rigidbody2D heroRB;
    public GameObject ways;
    public Transform[] wayPoints;
    int pointIndex; // порядковый номер
    int pointCount; // кол-во платформ
    int direction = 1;

    public float waitDuration;

    private void Awake()
    {

        wayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }

    private void Start()
    {
        pointIndex = 0;
        pointCount = wayPoints.Length;
        targetPos = wayPoints[0].transform.position;
        DirectionCalculate();
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (transform.position == targetPos)
        {
            NextPoint();
        }
    }


    private void NextPoint()
    {
        transform.position = targetPos;
        moveDirection = Vector3.zero;
        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }

        if (pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        targetPos = wayPoints[pointIndex].transform.position;

        StartCoroutine(WaitNextPoint());
    }

    IEnumerator WaitNextPoint()
    {
        yield return new WaitForSeconds(waitDuration);
        DirectionCalculate();
    }
    private void DirectionCalculate()
    {
        moveDirection = (targetPos - transform.position).normalized;
    }


}

