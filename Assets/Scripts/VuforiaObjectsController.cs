using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VuforiaObjectsController : MonoBehaviour
{
    public static List<VuforiaObjectsController> controllers = new List<VuforiaObjectsController>();

    public bool OnTracking
    {
        get{ return _onTracking; }
    }

    public Vector3 ScreenPosition
    {
        get{ return Camera.main.ScreenToViewportPoint(this.transform.position); }
    }

    public VuforiaObjectsController()
    {
        controllers.Add(this);
    }

    ~VuforiaObjectsController() //Destructor
    {
        if (controllers != null && controllers.Contains(this))
        {
            controllers.Remove(this);
        }
    }

    protected virtual void OnTrackingFoundMessage()
    {
        _onTracking = true;
    }

    protected virtual void OnTrackingLostMessage()
    {
        _onTracking = false;
    }

    private bool _onTracking = false;

}
