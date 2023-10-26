﻿using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace SNEngine.Animations
{
    public interface IDissolveable
    {
        UniTask Dissolve(float time, Ease ease);
    }
}
