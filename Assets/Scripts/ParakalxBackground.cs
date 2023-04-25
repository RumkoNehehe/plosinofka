using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParakalxBackground : MonoBehaviour
{

    private Transform cameraTransform;
    [SerializeField] GameObject cam;
    [SerializeField] float paralaxMultiplier;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    private void Start()
    {
        cameraTransform = cam.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    private void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement * paralaxMultiplier;
        lastCameraPosition = cameraTransform.position;
    
        if(Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
    }
}
    