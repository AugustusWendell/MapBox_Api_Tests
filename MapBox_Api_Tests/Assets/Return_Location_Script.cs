using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

public class Return_Location_Script : MonoBehaviour {

    public Camera _referenceCamera;
    public AbstractMap _mapManager;


    // Use this for initialization
    void Start () {
        //_referenceCamera = GetComponent<Camera>();
        //_referenceCamera = Camera.main;
        //_mapManager = this.AbstractMap;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
           // Debug.Log("Pressed primary button.");
            Debug.Log(_mapManager.CenterLatitudeLongitude.x);

        var mousePosScreen = Input.mousePosition;
        //assign distance of camera to ground plane to z, otherwise ScreenToWorldPoint() will always return the position of the camera
        //http://answers.unity3d.com/answers/599100/view.html
        mousePosScreen.z = _referenceCamera.transform.localPosition.y;

        var pos = _referenceCamera.ScreenToWorldPoint(mousePosScreen);

        var latlongDelta = _mapManager.WorldToGeoPosition(pos);
        Debug.Log("Latitude: " + latlongDelta.x + " Longitude: " + latlongDelta.y);

        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed secondary button.");

        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");



        //var mousePosScreen = Input.mousePosition;
       
        //var pos = _referenceCamera.ScreenToWorldPoint(mousePosScreen);

       // var latlongDelta = _mapManager.WorldToGeoPosition(pos);
       // Debug.Log("Latitude: " + latlongDelta.x + " Longitude: " + latlongDelta.y);


    }
}
