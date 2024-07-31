using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public float scrollSpeed = 0.1f; // Speed at which the texture scrolls
    public Vector2 scrollDirection = Vector2.right; // Direction in which the texture scrolls

    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        offset = rend.material.mainTextureOffset;
    }

    void Update()
    {
        offset += scrollDirection * scrollSpeed * Time.deltaTime;
        rend.material.SetTextureOffset("_MainTex", offset);
    }
}
