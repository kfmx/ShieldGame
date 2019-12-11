#pragma warning disable 0649    //disables SerializeField + private warning
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CopyColor : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer colorToCopy_;
    private SpriteRenderer rend_;

    private void OnEnable()
    {
        Copy();
    }

    public void Copy()
    {
        rend_ = GetComponent<SpriteRenderer>();
        rend_.color = colorToCopy_.color;
    }
}
