using System;
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
 
            Console.WriteLine(contributor.name);

            // Move the contributor's RectTransform
            contributor.anchoredPosition += Vector2.right * scrollSpeed * Time.deltaTime;

            // If the contributor's RectTransform has moved beyond the screen, reset its position to the left side

            //  if (contributor.anchoredPosition.x > (contributor.rect.width + Screen.width) / 2)
           // {
            //    contributor.anchoredPosition = new Vector2(-(contributor.rect.width + Screen.width) / 2, contributor.anchoredPosition.y);
           // }
        }

        // Last contributor looping 

        RectTransform lastcontributor = contributors[contributors.Length - 1];

        if (lastcontributor.anchoredPosition.x > (lastcontributor.rect.width + Screen.width) / 2)
        {
            lastcontributor.anchoredPosition = new Vector2(-(lastcontributor.rect.width + Screen.width) / 2, lastcontributor.anchoredPosition.y);
        }

        // Check if next name has looped, then loop yourself

        for (int i = 0; i < 6;  i++)
        {
            RectTransform nextcontributor = contributors[i + 1];

            RectTransform currcontributor = contributors[i];

            if (nextcontributor.anchoredPosition.x > nextcontributor.rect.width / 2 + 5f && currcontributor.anchoredPosition.x > (Screen.width + currcontributor.rect.width) / 2)
            {
                currcontributor.anchoredPosition = new Vector2(-(currcontributor.rect.width + Screen.width) / 2, currcontributor.anchoredPosition.y);
            }
        }
    }
}