﻿using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameTool
{
    public class TransistionFX : SingletonMonoBehaviour<TransistionFX>
    {
        [SerializeField] private Image dim;
        public IEnumerator OnLoadScene()
        {
            dim.DOFade(1, 0.5f).SetUpdate(true);
            yield return new WaitForSecondsRealtime(1.5f);
        }

        public void EndLoadScene()
        {
            dim.DOFade(0, 0.25f).SetUpdate(true);
        }
    }
}