using UnityEngine;
using System.Collections;


public class AssociateTextNPC : MonoBehaviour {

	public TextAsset bontext; //= Resources.Load("..\\Text\\BonText.txt");
	public TextAsset badtext; //= Resources.Load("..\\Text\\TextMauvais.txt");

	public string[] bontab;
	public string[] badtab;

	public int indexBonText;
	public int indexBadText;
	private int i;


	// Use this for initialization
	void Start () {
	}

	public string[] GenerateDial(int type)
	{
		bontab = (bontext.text.Split('\n'));
		badtab = (badtext.text.Split('\n'));
		indexBonText = bontab.Length - 1;
		indexBadText = badtab.Length - 1;

		string[] tabreturn = new string[3];
		int sentence;
		string[] tab;
		i = 0;

		if (type == 1) {  // On fait un personnage bon
			for (i = 0; i < 3; i++) {
				sentence = Random.Range (0, indexBonText);
				tabreturn [i] = bontab [sentence];
			}

		} else if (type == 2) {  // On fait un personnage moyen bon
			for (i = 0; i < 2; i++) {
				sentence = Random.Range (0, indexBonText);
				tabreturn [i] = bontab [sentence];
			}
			sentence = Random.Range (0, indexBadText);
			tabreturn [i] = badtab [sentence];

		} else if (type == 3) {   // On fait un personnage mauvais
			for (i = 0; i < 3; i++) {
				sentence = Random.Range (0, indexBadText);
				tabreturn [i] = badtab [sentence];
			}
		} else if (type == 4) {   // On fait un personnage moyen mauvais
			for (i = 0; i < 2; i++) {
				sentence = Random.Range (0, indexBadText);
				tabreturn [i] = badtab [sentence];
			}
			sentence = Random.Range (0, indexBonText);
			tabreturn [i] = bontab [sentence];
		} else {
			tabreturn = null;
		}
		return tabreturn;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
