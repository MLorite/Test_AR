using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class controladorSiquiero : VuforiaObjectsController, IVirtualButtonEventHandler
{

    public VirtualButtonBehaviour _VirtualButtonBehaviour;
    public CambioColor _virtualButtonController;
   // public Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _VirtualButtonBehaviour.RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("controladorSiquiero.OnButtonPressed(): " + vb.VirtualButtonName);
        _virtualButtonController.PressedButton();
        //_animator.SetTrigger("Cut");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("controladorSiquiero.OnButtonReleased(): " + vb.VirtualButtonName);
        _virtualButtonController.ReleasedButton();
    }

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
