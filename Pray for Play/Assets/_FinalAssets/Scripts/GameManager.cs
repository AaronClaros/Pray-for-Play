using UnityEngine;
using System.Collections;

namespace _FinalAssets{
	public class GameManager : MonoBehaviour {

		public static GameManager instance = null;
		public BoardManager boardScript;

		public Font readable_Font;
		public Font weird_Font;

		public GUIManager guiCanvas;
		void Awake()
		{
			if (instance == null)
				instance = this;
			else if (instance != this)
				Destroy(gameObject);	

			DontDestroyOnLoad(gameObject);

			boardScript = GetComponent<BoardManager>();
			InitGame();
		}

		void InitGame()
		{

		}

		void Start(){
			guiCanvas = FindObjectOfType<GUIManager> ();
			guiCanvas.gameObject.SetActive (false);
		}

		void Update(){
			if (Input.GetKey (KeyCode.LeftShift)) 
				guiCanvas.gameObject.SetActive (true);
			else 
				guiCanvas.gameObject.SetActive (false);
			
		}
	}
}
