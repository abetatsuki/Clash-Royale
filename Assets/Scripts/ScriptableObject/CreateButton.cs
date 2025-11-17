using UnityEngine;
using UnityEngine.UI;

public class CreateButton : MonoBehaviour
{
    public  CardSO Card;
    
    private void Start()
    {
       var image = GetComponent<Image>();
        image.sprite = Card.Icon;
    }

    public void CreateGhostCharactor()
    {
      SpawnManager.Instance.StartPlacing(Card);
    }
}
