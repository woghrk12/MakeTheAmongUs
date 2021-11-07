using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnClickBackground()
    {
        StartCoroutine(CloseSettingUI());
    }

    private IEnumerator CloseSettingUI()
    {
        animator.SetTrigger("Close");

        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }
}
