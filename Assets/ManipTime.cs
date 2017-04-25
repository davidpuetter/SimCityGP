using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManipTime : MonoBehaviour {

	//Make time a range, may not be needed.
	//[Range(0,5)]
	//Make fast time 6 and keep 1 as normal time. Can change fast time if needed.
	public float Fast = 6f;
	public float Norm = 1f;
	bool IsOn = true;
	// Use this for initialization
	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(Clicked);

	}

	// Use bool to toggle speed on and of. 
	public void  Clicked () {
		if (IsOn == true) {
			Time.timeScale = Fast; 
			IsOn = false;
		} else if (IsOn == false) {
			Time.timeScale = Norm;
			IsOn = true;
		}
	}
}
