using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {
	//HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	public Vector2 position ;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}

	// Update is called once per frame
	void Update () {

		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		//矢印キー離された時フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}

		//iphone
		// タッチされているとき
		if (Input.touchCount > 0) {
			// タッチされている指の数だけ処理
			for (int i = 0; i < Input.touchCount; i++) {
				// タッチ情報をコピー
				Touch touch = Input.GetTouch (i);
				// タッチしたときかどうか

				//画面の真ん中より左側でタップした時は左フリッパーを動かす
				if ((touch.position.x <= Screen.width / 2) && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);
				}
				//画面の真ん中より右側でタップした時は右フリッパーを動かす
				if ((touch.position.x >= Screen.width / 2) && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);
				}
				//タップが離された時フリッパーを元に戻す
				if (touch.phase == TouchPhase.Ended) {
					SetAngle (this.defaultAngle);
				}
			}
		}
	}

	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}