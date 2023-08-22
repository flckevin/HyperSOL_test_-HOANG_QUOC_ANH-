using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollingBackground : MonoBehaviour
{
    [Range(-1f,1f)]public float scrollSpeed;
    private float _offSet;
    private Material _mat;
    // Start is called before the first frame update
    void Start()
    {
        _mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        _offSet += (Time.deltaTime * scrollSpeed) / 10f;
        _mat.SetTextureOffset("_MainTex", new Vector2(0, _offSet));
    }
}
