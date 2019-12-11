#pragma warning disable 0649    //disables SerializeField + private warning
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ThrownShieldSplatter : MonoBehaviour
{
    [Range(0, 10)]
    public float splatterRadius = 2f;
    [SerializeField]
    private GameObject splatterPrefab_;
    [SerializeField]
    private LayerMask splatterMask_;
    private List<GameObject> splatterObjects_ = new List<GameObject>();
    private SpriteRenderer rend_;

    private void Awake()
    {
        rend_ = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //Testing purposes, remove later
        if (Input.GetButtonDown("AButton"))
            RemoveSplatter();
    }

    public void RemoveSplatter()
    {
        for (int i = 0; i < splatterObjects_.Count; i++)
        {
            Destroy(splatterObjects_[i]);
        }
        splatterObjects_.Clear();
    }

    public void Splatter()
    {
        List<RaycastHit2D> hitsToUse = FindColliders();

        CreateSplatter(hitsToUse);
    }

    private List<RaycastHit2D> FindColliders()
    {
        RaycastHit2D[] nearbyColliders = Physics2D.CircleCastAll(transform.position, splatterRadius, transform.up, 0.1f, splatterMask_);

        List<RaycastHit2D> hitsToUse = new List<RaycastHit2D>();

        for (int i = 0; i < nearbyColliders.Length; i++)
        {
            //Check if anything is inbetween shield object and object to splat on
            var dir = (nearbyColliders[i].point - (Vector2)transform.position).normalized;
            var hit = Physics2D.Raycast(transform.position, dir, splatterRadius, splatterMask_);

            if (hit.collider == nearbyColliders[i].collider)
                hitsToUse.Add(hit);
        }

        return hitsToUse;
    }

    private void CreateSplatter(List<RaycastHit2D> hitsToUse)
    {
        for (int i = 0; i < hitsToUse.Count; i++)
        {
            //Instantiate splatter prefab object
            var splatterObject = Instantiate(splatterPrefab_, hitsToUse[i].transform.position, Quaternion.identity);
            splatterObjects_.Add(splatterObject);
            splatterObject.GetComponent<SortingGroup>().sortingOrder =
            hitsToUse[i].transform.GetComponent<SpriteRenderer>().sortingOrder + 1;

            //Adjust splatter object's sprite settings
            var sprite = splatterObject.transform.GetChild(0);
            sprite.localScale = hitsToUse[i].transform.localScale;
            sprite.rotation = hitsToUse[i].transform.rotation;
            sprite.GetComponent<SpriteRenderer>().sprite = hitsToUse[i].transform.GetComponent<SpriteRenderer>().sprite;
            sprite.GetComponent<SpriteRenderer>().color = rend_.color;

            //Set splatter object's sprite mask position
            var spriteMask = splatterObject.transform.GetChild(1);
            spriteMask.position = transform.position;

            //Set parent of splatter object
            splatterObject.GetComponent<Splatter>().SetParent(hitsToUse[i].transform);
        }
    }
}
