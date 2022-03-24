using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;

public class AddressableSpriteLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public AssetReference newSprite;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
