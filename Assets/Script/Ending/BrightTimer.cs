using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BrightTimer : MonoBehaviour
{
    public BrightofStar bright;
    public Material originMaterial;

    #region chageMaterialObj
    public GameObject shadow;
    public SpriteShapeRenderer ground1;
    public SpriteShapeRenderer ground2;
    public SpriteRenderer background1;
    public SpriteRenderer background2;
    public SpriteRenderer player;
    #endregion
    public GameObject ground3;
    public GameObject wall;
    public GameObject playerlight;
    public GameObject fade;
    public GameObject ToEnd;

    public GameObject EndStartUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightON()
    {
        fade.SetActive(true);
        ToEnd.SetActive(true);
        shadow.SetActive(false);
        ground3.SetActive(true);
        wall.SetActive(false);
        playerlight.SetActive(false);

        background1.material = originMaterial;
        background2.material = originMaterial;
        player.material = originMaterial;

        Material[] materials = ground1.materials;
        materials[0] = originMaterial; materials[1] = originMaterial;
        ground1.materials = materials;
        ground2.materials = materials;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bright.isEnding = true;
            EndStartUI.SetActive(true);
            Invoke(nameof(UIOFF), 3f);
            bright.StartCoroutine(bright.DimLight());
        }
    }

    void UIOFF()
    {
        EndStartUI.SetActive(false);
    }
}
