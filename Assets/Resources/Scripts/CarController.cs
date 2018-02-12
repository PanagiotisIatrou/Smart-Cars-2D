using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

	public LayerMask ignoreCarsMask;

	public static bool started = false;

	public Transform RaycastersGO;
	private GameObject ForwardRayGO0;
	private GameObject ForwardRayGO1;

	private GameObject LeftRayGO;
	private GameObject RightRayGO;

	private GameObject LeftUpRayGO;
	private GameObject RightUpRayGO;
	private float maxSpeed = 6f;
	private float speed = 0f;
	private float turnSpeed = 2f;
	private float turn = 0f;

	void Start()
	{
		ForwardRayGO0 = RaycastersGO.GetChild(0).gameObject;
		ForwardRayGO1 = RaycastersGO.GetChild(1).gameObject;
		LeftRayGO = RaycastersGO.GetChild(2).gameObject;
		RightRayGO = RaycastersGO.GetChild(3).gameObject;
		LeftUpRayGO = RaycastersGO.GetChild(4).gameObject;
		RightUpRayGO = RaycastersGO.GetChild(5).gameObject;
	}

	void Update()
	{
		if (!started)
			return;

		RaycastHit2D forwardRay0 = Physics2D.Raycast(ForwardRayGO0.transform.position, ForwardRayGO0.transform.right, Mathf.Infinity, ignoreCarsMask);
		RaycastHit2D forwardRay1 = Physics2D.Raycast(ForwardRayGO1.transform.position, ForwardRayGO1.transform.right, Mathf.Infinity, ignoreCarsMask);
		RaycastHit2D leftRay = Physics2D.Raycast(LeftRayGO.transform.position, LeftRayGO.transform.right, Mathf.Infinity, ignoreCarsMask);
		RaycastHit2D rightRay = Physics2D.Raycast(RightRayGO.transform.position, RightRayGO.transform.right, Mathf.Infinity, ignoreCarsMask);

		RaycastHit2D leftUpRay = Physics2D.Raycast(LeftUpRayGO.transform.position, LeftUpRayGO.transform.right, Mathf.Infinity, ignoreCarsMask);
		RaycastHit2D rightUpRay = Physics2D.Raycast(RightUpRayGO.transform.position, RightUpRayGO.transform.right, Mathf.Infinity, ignoreCarsMask);

		float forwardDist0 = (forwardRay0.point - (Vector2)transform.position).magnitude;
		float forwardDist1 = (forwardRay1.point - (Vector2)transform.position).magnitude;
		float leftDist = (leftRay.point - (Vector2)transform.position).magnitude;
		float rightDist = (rightRay.point - (Vector2)transform.position).magnitude;

		float leftUpDist = (leftUpRay.point - (Vector2)transform.position).magnitude;
		float rightUpDist = (rightUpRay.point - (Vector2)transform.position).magnitude;

		// LEFT vs RIGHT
		if (Mathf.Abs(leftDist - rightDist) > 0.1f)
			turn += leftDist > rightDist ? turnSpeed : -turnSpeed;

		if (Mathf.Abs(leftUpDist - rightUpDist) > 0.1f)
			turn += leftUpDist > rightUpDist ? turnSpeed * 2f : -turnSpeed * 2f;

		if ((forwardDist0 + forwardDist1) / 2f < 2.5f)
		{
			Vector3 forwardsDir;
			if (forwardDist0 > forwardDist1)
			{
				forwardsDir = (forwardRay0.point - forwardRay1.point).normalized;
				turn += turnSpeed;
			}
			else
			{
				forwardsDir = (forwardRay1.point - forwardRay0.point).normalized;
				turn += -turnSpeed;
			}
			Debug.Log(forwardsDir);
		}

		float forwDist = (forwardDist0 + forwardDist1) / 2f;
		float _speed = Mathf.Clamp(forwDist, 0, maxSpeed);
		float diff = Mathf.Abs(speed - _speed);
		if (_speed < speed)
			speed -= diff / 5f;
		else
			speed += diff / 100f;

		speed = Mathf.Clamp(speed, 0, maxSpeed);
		transform.position += transform.right * speed * Time.deltaTime;

		turn = Mathf.Clamp(turn, -1.5f, 1.5f);
		transform.Rotate(new Vector3(0f, 0f, turn));
		turn = 0f;
	}
}
