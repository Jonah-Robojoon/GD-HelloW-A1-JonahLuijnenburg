using UnityEngine;

public class CollectCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void OnEnable() => Collect.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collect.OnCollected += OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        text.text = (++count).ToString();
    }
}
