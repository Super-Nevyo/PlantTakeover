using UnityEngine;

public class GrabbyVines
{
    private Vector2 _currentLocation;
    private Vector2 _locationToGetTo;
    private GameObject _controlledArm;
    private SpriteRenderer _sprite;
    private Player _player;
    private float _spriteWidth = 0.2f;

    public GrabbyVines(Player player, GameObject controlledArm)
    {
        _player = player;
        _controlledArm = controlledArm;
        _sprite = controlledArm.GetComponent<SpriteRenderer>();
    }
    
    public void Update()
    {
        _currentLocation = _player.transform.position;
        _locationToGetTo = _player.ArmPosition;
        _sprite.size = new Vector2((_locationToGetTo - _currentLocation).magnitude, _spriteWidth);
        _controlledArm.transform.localPosition = new Vector2(0.5f * (_locationToGetTo - _currentLocation).magnitude,0);
    }

    public void Enable()
    {
        _controlledArm.SetActive(true);
    }
    public void Disable()
    {
        _controlledArm.SetActive(false);
    }
}
