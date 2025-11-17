using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private GameObject _currentPreview;
    private CardSO _currentCard;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (_currentPreview == null) return;

        FollowMouseByRay();
        CheckPlace();
    }

    public void StartPlacing(CardSO card)
    {
        _currentCard = card;
        _currentPreview = Instantiate(card.UnitGhostPrefab);
    }

    private void FollowMouseByRay()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Debug.Log(mousePos);
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        
        // 地面のコライダーに当てる
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("Ground")))
        {
            _currentPreview.transform.position = hit.point;
        }
    }

    private void CheckPlace()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Instantiate(_currentCard.UnitPrefab,
                _currentPreview.transform.position,
                Quaternion.identity);

            Destroy(_currentPreview);
            _currentPreview = null;
            _currentCard = null;
        }
    }
}
