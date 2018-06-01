using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberDisplay : MonoBehaviour {

	private TextMesh mesh;

	void Start () {
		this.mesh = this.GetComponent<TextMesh>();
	}

	public void SetNumber(int number)
	{
		this.mesh.text = "" + number;
	}
}
