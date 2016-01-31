using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace _FinalAssets{
	public class EnemyScript : MonoBehaviour {
		public PlayerActions player;
		public string eName;

		public bool being_spelling;
		public GameObject invokeCircle;
		private SpriteRenderer spriteCircle;

		private Animator anim;
		public Text enemyText;

		public bool dead_flag;

		private GUIManager guiRef;

		public Color sprRefColor;
		// Use this for initialization
		void Start () {
			player = FindObjectOfType<PlayerActions>();
			name = gameObject.name;
			invokeCircle = transform.FindChild("Invoke Circle").gameObject;

			//spriteCircle = invokeCircle.GetComponent<SpriteRenderer>();
			invokeCircle.SetActive (false);
			anim = GetComponent<Animator> ();
			enemyText = transform.FindChild ("Canvas Enemy").GetComponentInChildren<Text> ();
			enemyText.text = eName.ToLower ();
			enemyText.font = GameManager.instance.weird_Font;

			sprRefColor = GetComponent<SpriteRenderer>().color;

		}
		
		// Update is called once per frame
		void Update () {
			if (being_spelling) {
				//Debug.Log ("hOI, am "+name+" you touch me?");
				invokeCircle.SetActive(true);
			} else {
				//Debug.Log("Were you go??");
				invokeCircle.SetActive(false);
			}

			//Move to Player

		}

		void OnMouseDown(){
			being_spelling = true;
			player.actualTarget = gameObject; 
		}

		void OnMouseUp(){
			being_spelling = false;
			player.actualTarget = null;
		}

		public IEnumerator DeadOnce()
		{
			anim.SetTrigger ("dead");
			enemyText.font = GameManager.instance.readable_Font;
			enemyText.text = eName.ToUpper ();
			while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.95f)
			{	
				yield return null;
			}
			dead_flag = true;
			yield return new WaitForSeconds (1f);
			Debug.Log (eName + ": I am dead");
			gameObject.SetActive (false);
		}

	}
}