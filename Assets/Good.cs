using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Good : MonoBehaviour {
	float timer= 9;
	SpriteRenderer sR;
	public Sprite neutre;
	public Sprite main1;
	public Sprite main2;
	public Sprite OtherSprite;
	// Use this for initialization


	// Use this for initialization
	void Start() 
	{
		sR = GetComponent<SpriteRenderer>();

	}
	// Update is called once per frame
	void Update () {
		if (timer > 0)
		{
			timer -= Time.deltaTime; // I need timer which from a particular time goes to zero
		}
		Debug.Log(timer);
		if (timer <= 6)
		{
			sR.sprite = neutre;

		} 
		if (timer <= 5)
		{
			sR.sprite = main1;

		} 
		if (timer <= 4)
		{
			sR.sprite = main2;

		} 
		if (timer <= 2)
		{
			sR.sprite = OtherSprite;

		} 
	} 
}
