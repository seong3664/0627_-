using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Change_Wp : MonoBehaviour
{
    public Animation CombatSG;
    public SkinnedMeshRenderer Spas12;
    public MeshRenderer[] AK47;
    public MeshRenderer[] M4A1;
    void Start()
    {
        
    }

    void Update()
    {
        //Alpha1 = ���� 1
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponChange1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponChange2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponChange3();
        }

    }

    private void WeaponChange3()
    {
        CombatSG.Play("draw");
        foreach (MeshRenderer Wp in AK47)
        {
            Wp.enabled = false;     //�Ž� ������ Ȱ��ȭ
        }
        Spas12.enabled = true;     //��Ű�� �Ž� ������ ��Ȱ��ȭ

        foreach(MeshRenderer M4 in M4A1)
        {
            M4.enabled = false;
        }
    }

    private void WeaponChange2()
    {
        CombatSG.Play("draw");
        foreach (MeshRenderer Wp in AK47)
        {
            Wp.enabled = false;     //�Ž� ������ Ȱ��ȭ
        }
        Spas12.enabled = false;     //��Ű�� �Ž� ������ ��Ȱ��ȭ

        foreach (MeshRenderer M4 in M4A1)
        {
            M4.enabled = true;
        }
    }

    private void WeaponChange1()
    {
        CombatSG.Play("draw");
        foreach (MeshRenderer Wp in AK47)
        {
            Wp.enabled = true;     //�Ž� ������ Ȱ��ȭ
        }
        Spas12.enabled = false;     //��Ű�� �Ž� ������ ��Ȱ��ȭ

        foreach (MeshRenderer M4 in M4A1)
        {
            M4.enabled = false;
        }
    }
}
