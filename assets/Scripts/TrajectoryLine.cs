using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour
{
	Vector3 startPos;
	Vector3 endPos;
	Vector3 mousePos;
	Vector3 mouseDir;
	public float max = 5f;
	Camera cam;
	LineRenderer lr;
		void Start()
	{
		lr = GetComponent<LineRenderer>();
		cam = Camera.main;
	}
	private void Update()
	{
		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		mouseDir = mousePos - gameObject.transform.position;
		mouseDir.z = 15f;
		mouseDir = mouseDir.normalized;
		if (Input.GetMouseButtonDown(0))
		{
			lr.enabled = true;
		}
		if (Input.GetMouseButton(0))
		{
			startPos = gameObject.transform.position;
			startPos.z = 15f;
			lr.SetPosition(0, startPos);
			endPos = mousePos;
			endPos.z = 15f;
			float capLength = Mathf.Clamp(Vector2.Distance(startPos, endPos), 0, max);
			endPos = startPos + (mouseDir * capLength);
			lr.SetPosition(1, endPos);
		}
		if (Input.GetMouseButtonUp(0))
		{
			lr.enabled = false;
		}
	}
	
}

