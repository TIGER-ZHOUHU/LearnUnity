using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionBlur : PostEffectsBase
{
    public Shader motionBlurShader;
    private Material motionBlurMaterial = null;

    public Material material
    {
        get
        {
            motionBlurMaterial = CheckShaderAndCreateMaterial(motionBlurShader, motionBlurMaterial);
            return motionBlurMaterial;
        }
    }

    // blurAmount 的值越大，运动拖尾的效果就越明显，为了防止拖尾效果完全代替当前帧的渲染结果，我们把它的值截取在0.0-0.9范围内
    [Range(0.0f, 0.9f)] public float blurAmount = 0.5f;

    // 定义一个RenderTexture 类型的变量，保存之前图像叠加的结果
    private RenderTexture accumulationTexture;

    // 在该脚本不运行时，即调用OnDisable函数时，立即销毁accumulationTexture。
    // 这是因为我们希望在下一次开始应用运动模糊时重新叠加图像
    private void OnDisable()
    {
        DestroyImmediate(accumulationTexture);
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (material != null)
        {
            // Crete the accumulation texture
            if (accumulationTexture == null || accumulationTexture.width != src.width || accumulationTexture.height != src.height)
            {
                DestroyImmediate(accumulationTexture);
                accumulationTexture = new RenderTexture(src.width, src.height, 0);
                accumulationTexture.hideFlags = HideFlags.HideAndDontSave;
                Graphics.Blit(src, accumulationTexture);
            }
            
            // We are accumulating motion over frames without clear/discard 
            // by design, so silence any performance warnings from Unity
            accumulationTexture.MarkRestoreExpected();
            
            material.SetFloat("_BlurAmount", 1.0f - blurAmount);
            
            Graphics.Blit(src, accumulationTexture, material);
            Graphics.Blit(accumulationTexture, dest);
        }
        else
        {
            Graphics.Blit(src,dest);
        }
    }
}
