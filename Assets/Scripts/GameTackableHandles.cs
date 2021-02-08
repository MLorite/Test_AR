using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTackableHandles : DefaultTrackableEventHandler
{
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        BroadcastMessage("OnTrackingFoundMessage");
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        BroadcastMessage("OnTrackingLostMessage");
    }
}
