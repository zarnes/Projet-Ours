﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void LoadScene (string Scene)
	{
		SceneManager.LoadScene(Scene);
		Debug.Log ("Load");
	}
}