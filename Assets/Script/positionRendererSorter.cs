using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionRendererSorter : MonoBehaviour
{
    [SerializeField] Renderer spriteCharacter;
    [SerializeField] int sortingOrderBase =5;
    [SerializeField] int offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        settingOrder();
    }

    void settingOrder()
    {
        spriteCharacter.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
    }
}
