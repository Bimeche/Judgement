using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public Image img;
	public Image bg;
	public Text pressToContinue;
	public Image meteorbg;
	void Start()
	{
		pressToContinue.text = "Appuyez sur espace pour continuer";
		pressToContinue.canvasRenderer.SetAlpha(0);
		meteorbg.canvasRenderer.SetAlpha(0);
		bg.canvasRenderer.SetAlpha(0);
		img.canvasRenderer.SetAlpha(0);
		StartCoroutine(DisplayTitle());
	}


	IEnumerator DisplayTitle()
	{
		float i = 1;
		yield return new WaitForSeconds(1F);
		bg.canvasRenderer.SetAlpha(1);

		while (bg.canvasRenderer.GetAlpha() > 0)
		{
			bg.canvasRenderer.SetAlpha(i);
			i -= 0.03f;
			yield return new WaitForSeconds(0.05F);
		}

		yield return new WaitForSeconds(1.5F);
		bg.canvasRenderer.SetAlpha(1);
		i = 1;
		while (bg.canvasRenderer.GetAlpha() > 0)
		{
			bg.canvasRenderer.SetAlpha(i);
			i -= 0.03f;
			yield return new WaitForSeconds(0.05F);
		}
		i = 0;
		while (i<1)
		{
			meteorbg.canvasRenderer.SetAlpha(i);
			i = i+0.01f;
			yield return new WaitForSeconds(0.05F);
		}

		img.canvasRenderer.SetAlpha(1);
		yield return new WaitForSeconds(1.5F);
		pressToContinue.canvasRenderer.SetAlpha(1);

	}

    public void Update()
    {
		if (Input.GetKeyDown("space"))
            SceneManager.LoadScene(1);
    }
}
