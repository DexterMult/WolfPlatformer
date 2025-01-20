using System;
using System.Collections;
using UnityEngine;

public class PStandart : MonoBehaviour
{
	public Jump Jump;
	public float speed;
	Vector3 targetPos;


	public Rigidbody2D heroRB;
	public GameObject ways;
	public Transform[] wayPoints;
	int pointIndex;
	int pointCount;
	int direction = 1;
	private bool isTargetPosition = false;

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
	}
	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
		if (transform.position == targetPos && isTargetPosition == false)
		{
			isTargetPosition = true;
			StartCoroutine(MoveWait(waitDuration));
		}
	}


	private void NextPoint()
	{
		transform.position = targetPos;
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
	}

	IEnumerator MoveWait(float delay) //Задержка перед отправлением в след. точку
	{
		yield return new WaitForSeconds(delay);
		isTargetPosition = false;
		NextPoint();
	}
}

