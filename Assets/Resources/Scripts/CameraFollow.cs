using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public GameObject TargetObj;

	void Update()
	{
		transform.position = new Vector3(TargetObj.transform.position.x, TargetObj.transform.position.y, -10f);
	}

}
