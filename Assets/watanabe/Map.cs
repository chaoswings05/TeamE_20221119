using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Map :MonoBehaviour
{
    //�X�e�[�W�̑傫��
    private const int width = 10;
    private const int height = 10;

    //�}�b�v
    public string[,] map = new string[height, width] // z, x���W�Ŏw��
    {
        {"��", "��", "��", "��", "��", "��", "��", "��", "��", "��"},
        {"��", "��", "��", "��", "0", "0", "��", "��", "��", "��"},
        {"��", "��", "0", "0", "0", "0", "0", "0", "��", "��"},
        {"��", "0", "0", "0", "0", "0", "0", "0", "0", "��"},
        {"��", "0", "0", "0", "0", "0", "0", "0", "0", "��"},
        {"0", "0", "0", "0", "0", "0", "0", "0", "0", "0"},
        {"0", "0", "0", "0", "0", "0", "0", "0", "0", "0"},
        {"0", "0", "0", "0", "0", "0", "0", "0", "0", "0"},
        {"��", "0", "0", "0", "��", "��", "0", "0", "0", "��"},
        {"��", "��", "0", "0", "��", "��", "0", "0", "��", "��"}
    };
    //������������Ƃ���
    public readonly string empty = "0";
    //�����Ȃ���
    public readonly string Wall = "��";
    public readonly string character = "1";

    public bool CheckMap()
    {
        int x = 100;
        int y = 100;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (map[j, i] == character)
                {
                    //�z�u�s�\�ȃ}�X�z�u

                }
                else
                {
                    //�z�u�\�ȃ}�X�z�u

                }
                x -= 10;
            }
            y -= 10;
        }
        return true;
    } 
}