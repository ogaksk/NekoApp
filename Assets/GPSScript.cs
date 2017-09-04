using UnityEngine;
using System.Collections;

public class GPSScript : MonoBehaviour {

	// Use this for initialization
	// void Start () {	
	// }
    public string text = "text";
    private GUIStyle m_guiStyle;

    IEnumerator Start() 
    {
        m_guiStyle = new GUIStyle();
        m_guiStyle.fontSize = 30;   // フォントサイズの変更.

        Debug.Log("start");
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            print("no service.");
            text = "no service.";
            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }


        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            text = "Timed out";
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            text = "Unable to determine device location";
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            text  = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI () 
    {
         GUI.Label(new Rect(20, 40, 80, 20), text, m_guiStyle);
    }
}

