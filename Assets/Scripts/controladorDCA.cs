using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorDCA : VuforiaObjectsController
{
    protected override void OnTrackingFoundMessage()
    {
        base.OnTrackingFoundMessage();
        Debug.Log("controladorSiquiero.OnButtonPressed(): " + this.name);
    }

    protected override void OnTrackingLostMessage()
    {
        base.OnTrackingLostMessage();
        Debug.Log("controladorSiquiero.OnButtonReleased(): " + this.name);
    }
}
