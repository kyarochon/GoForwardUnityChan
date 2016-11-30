using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	// キューブの移動速度
	private float speed = -0.2f;

	// 消滅位置
	private float deadLine = -10;

	// 効果音
	private AudioSource soundEffect;

	// Use this for initialization
	void Start(){
		soundEffect = GetComponent<AudioSource>();
	}


	// Update is called once per frame
	void Update () {
		// キューブを移動させる
		transform.Translate (this.speed, 0, 0);

		// 画面外に出たら破棄する
		if (transform.position.x < this.deadLine){
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.transform.tag == "GroundTag" || other.transform.tag == "CubeTag")
			soundEffect.PlayOneShot (soundEffect.clip);
	}

}