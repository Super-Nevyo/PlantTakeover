using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    public void OnClick(UnityEngine.InputSystem.InputValue value)
    {
        if (value.Get<float>() == 1) EventManager.ClickAction?.Invoke();
        else if (value.Get<float>() == 0) EventManager.UnClickAction?.Invoke();
    }
}
