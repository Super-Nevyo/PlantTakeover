using UnityEngine;

public class Orphan : MonoBehaviour, IBombable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBomb()
    {
        Die();
    }
    public void Die()
    {

    }
}
