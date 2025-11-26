using UnityEngine;

public interface IHitable
{
    public GameObject gameObject{get;}
    
    public void TakeDamage(int damage);
}
