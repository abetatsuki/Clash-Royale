using UnityEngine;

public class CreateGround : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefabA;
    [SerializeField] private GameObject groundPrefabB;
    [SerializeField] private int width = 10;     // ‰¡
    [SerializeField] private int height = 8;     // c
    [SerializeField] private float spacing = 1f; // ƒ^ƒCƒ‹ŠÔ‚Ì‹——£

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject prefab;

                // A ‚Æ B ‚ğŒğŒİ‚É’u‚­
                if ((x + y) % 2 == 0)
                {
                    prefab = groundPrefabA;
                }
                else
                {
                    prefab = groundPrefabB;
                }

                Vector3 pos = new Vector3(x * spacing, 0f, y * spacing);
                Instantiate(prefab, pos, Quaternion.identity,transform);
            }
        }
    }
}
