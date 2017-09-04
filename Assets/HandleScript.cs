using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HandleScript : MonoBehaviour {
  public Text MousePos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
     if (Input.GetMouseButton(0))
    {
      Vector3 screenPos = Input.mousePosition;
      Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward * 1);
      transform.position = worldPos;

      MousePos.text = screenPos.ToString();
    }
	}

}
