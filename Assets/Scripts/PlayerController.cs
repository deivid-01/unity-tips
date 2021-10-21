using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
   
    
    
    #region bar features
    [Space]
    [Header("UI Max height")]
    private float _startPositionY;
    private float _maxHeight;
    [SerializeField] private Text txtHeight;
    [SerializeField] private Transform  trVerticalBar;
    
#endregion

   
    void Start()
    {
        #region bar features
        _startPositionY = transform.position.y;
        _maxHeight = 0;
        #endregion 
        
    }

    private void FixedUpdate()
    {
       SetMaxHeight();
       

    }
    
    #region bar features
    private void SetMaxHeight()
    {
        float actualHeight = (transform.position.y - _startPositionY);
        
        SetBarHeight(actualHeight);
        
        if (actualHeight > _maxHeight)
        {
            _maxHeight = actualHeight;
            
            txtHeight.text = _maxHeight.ToString("F")+"m";
        }
    }

    private void SetBarHeight(float height)
    {
        Vector3 newScale = trVerticalBar.localScale;
        newScale.y = height;
        trVerticalBar.localScale = newScale;
    }


#endregion

}
