using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter : MonoBehaviour {

    public void SetIsVisible(bool isVisible) {
        gameObject.SetActive(isVisible);
    }
}
