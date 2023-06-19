using UnityEngine;

public class PlayerRadar : MonoBehaviour
{
    public float radiusRadar;

    [SerializeField]
    private new CircleCollider2D collider;
    [SerializeField]
    private Transform radarBorderSprite;

    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        SetSizeRadarBorder();
    }

    public void SetSizeRadarBorder()
    {
        collider.radius = radiusRadar;
        Vector3 renderScale = new Vector3(radarBorderSprite.localScale.x * radiusRadar, radarBorderSprite.localScale.y * radiusRadar, 1f);
        radarBorderSprite.transform.localScale = renderScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
    }
}
