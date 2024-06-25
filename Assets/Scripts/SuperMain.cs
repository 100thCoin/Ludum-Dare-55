﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super{
	public static SuperMain Dataholder;
}
public class S{
	public static SuperMain Main;
}

public class SuperMain : MonoBehaviour {
	public bool DEBUGGING;

	public GameObject TitleScreen;
	public GameObject Game;

	public GameObject LoadedGame;

	public KeyCode[] ReboundInputs;
	public bool InvertMouse;
	public float Volume_Music;
	public float Volume_SFX;
	public float Volume_Voice;

	public float MusicMultiplier;

	public GameObject KeyRebinderPrefab;
	public KeyCode GetReboundKeyCode(KeyCode KC)
	{
		switch (KC) {
		case KeyCode.D:	return ReboundInputs [0];
		case KeyCode.A:	return ReboundInputs [1];
		case KeyCode.S:	return ReboundInputs [2];
		case KeyCode.W:	return ReboundInputs [3];
		case KeyCode.Space:	return ReboundInputs [4];
		case KeyCode.Mouse0:	return ReboundInputs [5];
		case KeyCode.Mouse1:	return ReboundInputs [6];
		case KeyCode.R:	return ReboundInputs [7];
		case KeyCode.Escape:	return ReboundInputs [8];		

		default:
			break;
		}
		return KC;

	}

	public void LoadKeyRebinder()
	{
		Instantiate (KeyRebinderPrefab, transform.position, transform.rotation, transform);
	}

	public bool GetReboundInput(KeyCode KC)
	{
		KeyCode K = GetReboundKeyCode (KC);
		return Input.GetKey (K);		
	}

	public bool GetReboundInputDown(KeyCode KC)
	{
		KeyCode K = GetReboundKeyCode (KC);
		return Input.GetKeyDown (K);

	}

	public bool GetReboundInputUp(KeyCode KC)
	{
		KeyCode K = GetReboundKeyCode (KC);
		return Input.GetKeyUp (K);

	}

	public void StartGame()
	{
		if (LoadedGame != null) {
			Destroy (LoadedGame);
		}
		LoadedGame = Instantiate (Game, Vector3.zero, transform.rotation, transform);

	}


	public void ReturnToTitle()
	{
		if (LoadedGame != null) {
			Destroy (LoadedGame);
		}
		Instantiate (TitleScreen, Vector3.zero,transform.rotation,transform);
		MusicMultiplier = 1;
	}

	// Use this for initialization
	void Start () {
		if (!DEBUGGING) {
			ReturnToTitle ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake()
	{
		Super.Dataholder = this;
		S.Main = this;

	}

	void OnEnable()
	{
		Super.Dataholder = this;
		S.Main = this;

	}






}
