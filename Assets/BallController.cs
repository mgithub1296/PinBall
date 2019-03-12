using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;
	//得点を表示するテキスト
	private GameObject pointText;
	//得点用の変数
	private int point = 0;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		//シーン中のPointTextオブジェクトを取得
		this.pointText = GameObject.Find("PointText");
		//得点を表示させる
		this.pointText.GetComponent<Text> ().text = point.ToString();
	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		// タグによって点数を変える
		if (other.gameObject.tag == "SmallStarTag") {
			this.point += 10;
		} else if (other.gameObject.tag == "LargeStarTag") {
			this.point += 20;
		} else if (other.gameObject.tag == "SmallCloudTag") {
			this.point += 20;
		} else if (other.gameObject.tag == "LargeCloudTag") {
			this.point += 100;
		}

		//pointTextに//得点を表示
		this.pointText.GetComponent<Text> ().text = point.ToString();
	}
}