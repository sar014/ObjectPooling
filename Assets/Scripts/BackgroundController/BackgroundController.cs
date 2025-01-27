using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] RawImage img;
    [SerializeField] float x,y;

    private void Update() {
        // Calculate new UV offset
        Vector2 offset = img.uvRect.position + new Vector2(x, y) * Time.deltaTime;

        // Apply modulus to keep UV coordinates within 0 to 1
        offset.x %= 1f;
        offset.y %= 1f;

        // Update the RawImage's UV rect
        img.uvRect = new Rect(offset, img.uvRect.size);
    }
}
