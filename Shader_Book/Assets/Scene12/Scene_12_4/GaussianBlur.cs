using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussianBlur : PostEffectsBase
{
    public Shader gaussianBlurShader;
    private Material gaussianBlurMaterial = null;

    public Material material
    {
        get
        {
            gaussianBlurMaterial = CheckShaderAndCreateMaterial(gaussianBlurShader, gaussianBlurMaterial);
            return gaussianBlurMaterial;
        }
    }
    
    // Blur iteration - larger number means more blur.
    [Range(0, 4)] public int iterations = 3;
    [Range(0.2f, 3.0f)] public float blurSpread = 0.6f;
    [Range(1, 8)] public int downSample = 2;

    /// 1st edition: just apply blur
    // private void OnRenderImage(RenderTexture src, RenderTexture dest)
    // {
    //     if (material != null)
    //     {
    //         int rtW = src.width;
    //         int rtH = src.height;
    //         // RenderTexture.GetTemporary 分配临时渲染纹理
    //         RenderTexture buffer = RenderTexture.GetTemporary(rtW, rtH, 0);
    //         
    //         // Render the vertical pass
    //         Graphics.Blit(src, buffer,material,0);
    //         // Render the horizontal pass
    //         Graphics.Blit(buffer,dest,material,1);
    //         
    //         RenderTexture.ReleaseTemporary(buffer);
    //     }
    //     else
    //     {
    //         Graphics.Blit(src,dest);
    //     }
    // }

    /// 2nd edition: scale the render texture
    // private void OnRenderImage(RenderTexture src, RenderTexture dest)
    // {
    //     if (material != null)
    //     {
    //         int rtW = src.width/downSample;
    //         int rtH = src.height/downSample;
    //         // RenderTexture.GetTemporary 分配临时渲染纹理
    //         RenderTexture buffer = RenderTexture.GetTemporary(rtW, rtH, 0);
    //         // Bilinear 过滤-对纹理样本求平均值
    //         buffer.filterMode = FilterMode.Bilinear;
    //         
    //         // Render the vertical pass
    //         Graphics.Blit(src, buffer,material,0);
    //         // Render the horizontal pass
    //         Graphics.Blit(buffer,dest,material,1);
    //         
    //         RenderTexture.ReleaseTemporary(buffer);
    //     }
    //     else
    //     {
    //         Graphics.Blit(src,dest);
    //     }
    ///3rd edition: use iteration for lager blur
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (material != null)
        {
            // 对图像进行降采样，对图像进行降采样不仅可以减少需要处理的像素个数，提高性能，而且适当的降采样往往还可以得到更好的模糊效果。
            int rtW = src.width/downSample;
            int rtH = src.height/downSample;
            // RenderTexture.GetTemporary 分配临时渲染纹理
            RenderTexture buffer0 = RenderTexture.GetTemporary(rtW, rtH, 0);
            // Bilinear 过滤-对纹理样本求平均值
            buffer0.filterMode = FilterMode.Bilinear;
            
            Graphics.Blit(src, buffer0);

            for (int i = 0; i < iterations; i++)
            {
                material.SetFloat("_BlurSize", 1.0f + i * blurSpread);

                RenderTexture buffer1 = RenderTexture.GetTemporary(rtW, rtH, 0);
                
                //Render the vertical pass
                Graphics.Blit(buffer0, buffer1, material,0);
                
                RenderTexture.ReleaseTemporary(buffer0);
                buffer0 = buffer1;
                buffer1 = RenderTexture.GetTemporary(rtW, rtH, 0);
                
                //Render the horizontal pass
                Graphics.Blit(buffer0,buffer1,material,1);
                
                RenderTexture.ReleaseTemporary(buffer0);
                buffer0 = buffer1;
            }
            Graphics.Blit(buffer0,dest);
            RenderTexture.ReleaseTemporary(buffer0);
        }
        else
        {
            Graphics.Blit(src,dest);
        }
    }
}
    
    
