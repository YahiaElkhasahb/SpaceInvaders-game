using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_scroll : MonoBehaviour
{

    public float scroll_Speed = 0.5f;

    private MeshRenderer mesh_Renderer;

    private float y_Scroll;

    void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {

        y_Scroll = Time.time * scroll_Speed;
        Vector2 offset = new Vector2(0f , y_Scroll);
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);

    }

}