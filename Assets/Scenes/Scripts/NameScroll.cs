using UnityEngine;
using UnityEngine.UI;

public class ContributorsLoop : MonoBehaviour
{
    public RectTransform[] contributors; // Array of UI elements containing contributors' names
    public float scrollSpeed = 50f; // Speed at which the names scroll

    void Update()
    {
        // Loop through each contributor
        foreach (RectTransform contributor in contributors)
        {
            // Move the contributor's RectTransform
            contributor.anchoredPosition += Vector2.right * scrollSpeed * Time.deltaTime;

            // If the contributor's RectTransform has moved beyond the screen, reset its position to the left side
            if (contributor.anchoredPosition.x > (contributor.rect.width + Screen.width) / 2)
            {
                contributor.anchoredPosition = new Vector2(-(contributor.rect.width + Screen.width)/2, contributor.anchoredPosition.y);
            }
        }
    }
}