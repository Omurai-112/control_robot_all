using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// PC�łŃE�B���h�E�T�C�Y�������Œ�������N���X
/// </summary>
public class windowsize : MonoBehaviour
{

    //�^�[�Q�b�g�̃A�X�䗦
    private static readonly float SCREEN_RATE = 16f / 9f;

    //�X�N���[���T�C�Y
    private int _width, _height;

    //�X�V�Ԋu
    private static readonly float UPDATE_SPAN = 1f;
    private float _updateSpan = UPDATE_SPAN;

    //=================================================================================
    //������
    //=================================================================================

    private void Start()
    {
        _width = Screen.width;
        _height = Screen.height;
    }

    //=================================================================================
    //�X�V
    //=================================================================================

    private void Update()
    {
        #if !UNITY_EDITOR //�G�f�B�^��ł͒������Ȃ��悤��
        _updateSpan -= Time.fixedDeltaTime;
        if (_updateSpan > 0) {
          return;
        }
        _updateSpan = UPDATE_SPAN;
    
        //���݂̃A�X��`�F�b�N
        int width = Screen.width, height = Screen.height;
        var rate = width / (float)height;
        if(Mathf.Abs(SCREEN_RATE - rate) <= 0.1f) {
          _width  = width;
          _height = height;
          return;
        }
    
        //�����������ɍ��킹�Ē���
        if (Mathf.Abs(_width - width) > Mathf.Abs(_height - height)) {
          Screen.SetResolution(width, Mathf.RoundToInt(width / SCREEN_RATE), false);
        }
        else {
          Screen.SetResolution(Mathf.RoundToInt(height * SCREEN_RATE), height, false);
        }
    
        _width  = width;
        _height = height;

        #endif
    }

}