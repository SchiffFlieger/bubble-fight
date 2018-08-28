using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentMusic : MonoBehaviour {
	void Start () {
		
		DontDestroyOnLoad(this.gameObject);
	}
}
