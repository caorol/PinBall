using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour {
	Material material;

	private float minEmission = 0.3f;
	private float magEmission = 2.0f;
	private int degree = 0;
	private int speed = 10;
	Color defaultColor = Color.white;

	// Use this for initialization
	void Start () {
		// change bright color by tag
		if (tag == "SmallStarTag") {
			this.defaultColor = Color.white;
		} else if (tag == "LargeStarTag") {
			this.defaultColor = Color.yellow;
		} else if (tag == "SmallCloudTag" || tag == "LargeCloudTag") {
			this.defaultColor = Color.blue;
		}

		// get attached material at object
		this.material = GetComponent<Renderer> ().material;

		// set first color for object
		// Materialクラスの「SetColor」関数は、マテリアルの色を設定します。第一引数に変更したい色のパラメータを指定し、第二引数に変更する色の値を指定します。
		// ここでは発光する色の強さを変更したいので、第一引数にEmissionのパラメータ名である_EmissionColorを指定し、第二引数にはTagで個々に設定した色を最小限に光らせた値を指定しています。
		material.SetColor("_EmissionColor", this.defaultColor * minEmission);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.degree >= 0) {
			// bright speed
			// 度数法：半回転ぶんが 180∘180∘ となるように測った角度
			// 弧度法：半回転ぶんが ππ ラジアンとなるように測った角度
			// 180° = π[rad]
//			Debug.Log ("degree: " + this.degree + "(" + this.degree * Mathf.Deg2Rad+ "[rad]),  Sin: " + Mathf.Round(Mathf.Sin(this.degree * Mathf.Deg2Rad) * 1000) / 1000 + ",   color: " + this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmission));
			Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmission);

			// set color at emission
			material.SetColor ("_EmissionColor", emissionColor);

			// set small angle
			this.degree -= this.speed;
		}
	}

	// called at collision
	// 自分のColliderが他のオブジェクトのColliderと接触した時に呼ばれる関数
	// 引数には接触した相手のCollisionが渡されます。「Collision」は、衝突したオブジェクトの情報が取得できるクラスです。
	void OnCollisionEnter(Collision other) {
		// degree変数に180を代入したことにより、Update関数が呼ばれる
		this.degree = 180;
	}
}
