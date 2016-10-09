using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public Image judgement;
	public Image day;
	public Image bg;
	public Text pressToContinue;
	public Image meteorbg;
	public AudioSource jud;
	public AudioSource dday;
	public AudioSource boom1;
	public AudioSource boom2;
	public GameObject music;

	void Start()
	{
		music = GameObject.Find("bgmusic");
		DontDestroyOnLoad(music);
		boom1.Stop();
		boom2.Stop();
		jud.Stop();
		dday.Stop();
		pressToContinue.text = "Appuyez sur espace pour continuer";
		pressToContinue.canvasRenderer.SetAlpha(0);
		meteorbg.canvasRenderer.SetAlpha(0);
		bg.canvasRenderer.SetAlpha(0);
		judgement.canvasRenderer.SetAlpha(0);
		day.canvasRenderer.SetAlpha(0);
		
		StartCoroutine(DisplayTitle());
	}


	IEnumerator DisplayTitle()
	{
		float i = 1;
		yield return new WaitForSeconds(0.5F);
		bg.canvasRenderer.SetAlpha(1);

		while (bg.canvasRenderer.GetAlpha() > 0)
		{
			bg.canvasRenderer.SetAlpha(i);
			i -= 0.03f;
			yield return new WaitForSeconds(0.05F);
		}

		yield return new WaitForSeconds(1F);
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
			i = i+0.02f;
			yield return new WaitForSeconds(0.05F);
		}

		judgement.canvasRenderer.SetAlpha(1);
		boom1.Play();
		yield return new WaitForSeconds(1F);
		day.canvasRenderer.SetAlpha(1);
		boom2.Play();
		yield return new WaitForSeconds(1F);
		jud.Play();
		yield return new WaitForSeconds(1F);
		dday.Play();
		yield return new WaitForSeconds(2F);
		pressToContinue.canvasRenderer.SetAlpha(1);

	}

    public void Update()
    {
		if (Input.GetKeyDown("space"))
            SceneManager.LoadScene(4);
    }
}
