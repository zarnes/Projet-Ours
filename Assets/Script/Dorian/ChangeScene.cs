using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    /// Quand appelé, la méthode charge la scene voulue (fournir le nom de la scène au script)
	/*public void LoadScene (string Scene)
	{
		SceneManager.LoadScene(Scene);
		Debug.Log ("Load");
	}*/
    public void Play()
    {
        SceneManager.LoadScene("level1");
        
    }
    public void Credit()
    {
        //SceneManager.LoadScene(Scene);
        
    }
    public void Quit()
    {
        //SceneManager.LoadScene(Scene);
        
    }
}