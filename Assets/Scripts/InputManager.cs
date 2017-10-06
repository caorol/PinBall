using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	private HingeJoint leftHingeJoint;
	private HingeJoint rightHingeJoint;
	private float defaultAngle = 20;
	private float flickAngle = -20;

	void Start () {
		leftHingeJoint = GameObject.Find ("LeftFripper").GetComponent<HingeJoint> ();
		rightHingeJoint = GameObject.Find ("RightFripper").GetComponent<HingeJoint> ();
		SetAngle (leftHingeJoint, this.defaultAngle);
		SetAngle (rightHingeJoint, this.defaultAngle);
	}

	void Update () {
		InputKey ();
		InputMouse ();
		InputTouch ();
	}

	void InputKey() {
		// <- 押下で左フリッパー動作
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			SetAngle (leftHingeJoint, this.flickAngle);
		}
		// -> 押下で右フリッパー動作
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			SetAngle (rightHingeJoint, this.flickAngle);
		}

		// <- UPで左フリッパーを戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			SetAngle (leftHingeJoint, this.defaultAngle);
		}
		// -> UPで右フリッパーを戻す
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			SetAngle (rightHingeJoint, this.defaultAngle);
		}
	}

	void InputMouse() {
		#if UNITY_EDITOR
		if (Input.GetMouseButtonDown(0)) {
			SetAngleFlick (Input.mousePosition.x);
		} else if(Input.GetMouseButtonUp(0)){
			SetAngleDefault (Input.mousePosition.x);
		}
		#endif
	}

	void InputTouch(){
		// 左右のフリッパーの同時操作に対応
		int count = Input.touchCount > 2 ? 2 : Input.touchCount;
		for(int i = 0; i < count; i++){
			Touch touch = Input.GetTouch(i);
			if(touch.phase == TouchPhase.Began) {
				SetAngleFlick (touch.position.x);
			}
			if(touch.phase == TouchPhase.Ended) {
				SetAngleDefault (touch.position.x);
			}
		}
	}
		
	void SetAngleFlick(float positionX) {
		if(positionX < Screen.width / 2) {
			SetAngle (leftHingeJoint, this.flickAngle);
		} else {
			SetAngle (rightHingeJoint, this.flickAngle);
		}
	}

	void SetAngleDefault(float positionX) {
		if(positionX < Screen.width / 2) {
			SetAngle (leftHingeJoint, this.defaultAngle);
		} else {
			SetAngle (rightHingeJoint, this.defaultAngle);
		}
	}

	void SetAngle(HingeJoint hingeJoint, float angle) {
		JointSpring jointSpring = hingeJoint.spring;
		jointSpring.targetPosition = angle;
		hingeJoint.spring = jointSpring;
	}
}
