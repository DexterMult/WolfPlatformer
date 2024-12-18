using System;
using System.Collections;
using UnityEngine;

public class PStandart : MonoBehaviour
{

    public float speed;
    Vector3 targetPos;

    Moove movementController;

    //Rigidbody2D rb;
    Vector3 moveDirection;

    public Rigidbody2D heroRB;
    public GameObject ways;
    public Transform[] wayPoints;
    int pointIndex; // ���������� �����
    int pointCount; // ���-�� ��������
    int direction = 1;

    public float waitDuration;

    private void Awake()
    {
        movementController = GameObject.FindGameObjectWithTag("HeroeTag").GetComponent<Moove>();

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
        movementController.pDirection = moveDirection;
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
    public Vector3 GetVelicity()
    {
        return moveDirection * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HeroeTag"))
        {
            collision.transform.parent = this.transform;
            movementController.isOnPlatform = true;
            movementController.platform = this;
            movementController.jumpCounter = 0;
            movementController.pSpeed = speed;
            heroRB.gravityScale = 30f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HeroeTag"))
        {
            collision.transform.parent = null;
            movementController.isOnPlatform = false;
            movementController.maxVelocityX = 8;
            heroRB.gravityScale = 5f;
        }
    }
}

