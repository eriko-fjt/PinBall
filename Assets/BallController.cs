using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {


	// ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;


	// ゲームオーバーを表示するテキスト
	private GameObject gameoverText;


	// 得点表示のための変数設定
	private GameObject scoreText;

	private int totalScorePoint = 0;




	// Use this for initialization
	void Start () {

		// シーンの中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		// 得点表示のオブジェクトを取得、表示
		this.scoreText = GameObject.Find("ScoreText");
		this.scoreText.GetComponent<Text>().text = "Score : " + totalScorePoint;
	}
	
	// Update is called once per frame
	void Update () {

		// ボールが画面の外に出た場合
		if (this.transform.position.z < this.visiblePosZ)
        {

			// GameOverTextにゲームオーバーを表示
			this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
		
	}

    private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag == "SmallStarTag")
		{
			totalScorePoint += 20;
		}
		else if (collision.gameObject.tag == "LargeStarTag")
		{
			totalScorePoint += 40;
		}
		else if (collision.gameObject.tag == "SmallCloudTag")
        {
			totalScorePoint += 80;
        }
		else if (collision.gameObject.tag == "LargeCloudTag")
        {
			totalScorePoint += 100;
        }

		this.scoreText.GetComponent<Text>().text = "Score : " + totalScorePoint;
	}
}
