using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private GameObject _currentPreview;
    private CardSO _currentCard;
    private bool _isValidPlacement;

    [Header("陣地設定")]
    [SerializeField] private float _playerTerritoryMaxZ = 0f; // プレイヤー陣地のZ座標上限

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
        _isValidPlacement = false;
    }

    private void FollowMouseByRay()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        
        // 地面のコライダーに当てる
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("Ground")))
        {
            // ヒットした面の法線が上向き（Y軸正方向）かチェック
            if (Vector3.Dot(hit.normal, Vector3.up) > 0.9f)
            {
                // 自分の陣地内かチェック（Z座標が_playerTerritoryMaxZ以下）
                if (hit.point.z <= _playerTerritoryMaxZ)
                {
                    _currentPreview.transform.position = hit.point;
                    _isValidPlacement = true;
                }
                else
                {
                    _currentPreview.transform.position = hit.point;
                    _isValidPlacement = false;
                }
            }
            else
            {
                _isValidPlacement = false;
            }
        }
        else
        {
            _isValidPlacement = false;
        }
    }

    private void CheckPlace()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && _isValidPlacement)
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