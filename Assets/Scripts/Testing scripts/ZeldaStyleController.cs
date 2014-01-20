using UnityEngine;
using System.Collections;

public class ZeldaStyleController : MonoBehaviour {

	public float RunSpeed = 9;
	// public float JumpSpeed = 9;
	public float TurnSpeed = 25f;
	
	public float ThumbStickDeadZone = 0.15f;
	
	[HideInInspector]
	public float CurSpeed = 0;
	
	private Vector3 _moveDirection = Vector3.zero;
	private float _angle;
	private Transform _transform;
	private CharacterController _controller;
	
	private void Awake()
	{
		_controller = GetComponent<CharacterController>();
		_transform = transform;
	}
	
	public void Update()
	{
		var x = Input.GetAxis("Horizontal");
		var y = Input.GetAxis("Vertical");
		
		CurSpeed = 0;
		
		_moveDirection.y -= 0 * Time.deltaTime;
		
		if (Mathf.Abs(y) > ThumbStickDeadZone || (Mathf.Abs(x) > ThumbStickDeadZone))
		{
			_angle = Mathf.Atan2(x, y) * (180 / Mathf.PI);
			CurSpeed = RunSpeed;
		}
		
		if (_controller.isGrounded)
		{
			_moveDirection = _transform.TransformDirection(Vector3.forward) * CurSpeed;
			//_moveDirection *= CurSpeed;
			//if (Input.GetButton("Fire1"))
			//      MoveDirection.y = JumpSpeed;
		}
		
		_controller.Move(_moveDirection * Time.deltaTime);
		_transform.rotation = Quaternion.Lerp(_transform.rotation, Quaternion.Euler(new Vector3(0, _angle, 0)), Time.deltaTime * TurnSpeed);
	}
}
