using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Intro : MonoBehaviour {

	public TextAsset intro;
	private string all;
	public Text toDisplay1;
	public Image blackbg;

	void Start () {
		blackbg.canvasRenderer.SetAlpha(0.5f);
		all = intro.text;
		toDisplay1.text = "";
		StartCoroutine(DisplayIntroText());
	}

	IEnumerator DisplayIntroText()
	{

		int i = 0;
		while (i < all.Length)
		{
			toDisplay1.text += all[i++];
			yield return new WaitForSeconds(0.01F);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Destroy(GameObject.Find("bgmusic"));
			SceneManager.LoadScene(1);
		}
	}
}
