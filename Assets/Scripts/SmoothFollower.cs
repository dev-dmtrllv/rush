using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class SmoothFollower : MonoBehaviour
{
	[SerializeField] public Transform target;
	[SerializeField] float dampTime = 0.15f;

	Vector3 velocity = Vector3.zero;

	void LateUpdate()
	{
		if (target)
		{
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
}
