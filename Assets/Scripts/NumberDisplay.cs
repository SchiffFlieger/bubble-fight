using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberDisplay : MonoBehaviour {
	public void SetNumber(string number)
	{
		this.GetComponent<TextMesh>().text = number;
	}
}
