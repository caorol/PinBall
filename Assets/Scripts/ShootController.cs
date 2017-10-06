using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {
	private Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDrag() {
		Vector3 objectPointInScreen = Camera.main.WorldToScreenPoint (this.transform.position);
		Vector3 mousePointInScreen = new Vector3 (objectPointInScreen.x, Input.mousePosition.y, objectPointInScreen.z);
		Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint (mousePointInScreen);
//		mousePointInWorld.z = this.transform.position.z;
		this.transform.position = mousePointInWorld;

		// ドラッグ中は物理演算を無効にする（じゃないとドラッグ中に接触しているボールが跳ね飛んでいく）
		_rigidbody.isKinematic = true;
	}

	void OnMouseUp () {
		_rigidbody.isKinematic = false;
	}
		
}
