using UnityEngine;

public interface IGrabber
{
    public Transform GetGrabTarget();
    public void UnGrab();
}
