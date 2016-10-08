using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void Update()
    {
        if (Input.GetKeyDown("space"))
            SceneManager.LoadScene(1);
    }
}
