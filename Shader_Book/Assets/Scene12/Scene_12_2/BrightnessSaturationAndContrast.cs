using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessSaturationAndContrast : PostEffectsBase
{
    //声明该效果需要的Shader， 并据此创建相应的材质
    public Shader briSatConShader;

    private Material briSatConMaterial;

    // briSatConShader 是我们指定的Shader， 对应了后面将会实现的Chapter12-BrightnessSaturationAndContrast.
    // briSatConMaterial 是创建的材质，我们提供了名为material的材质来访问它，
    // material的get函数调用了基类的CheckShaderAndCreateMaterial 函数来得到对应的材质
    public Material material
    {
        get
        {
            briSatConMaterial = CheckShaderAndCreateMaterial(briSatConShader, briSatConMaterial);
            return briSatConMaterial;
        }
    }

    // 调整亮度、饱和度和对比度的参数
    [Range(0.0f, 3.0f)] 
    public float brightness = 1.0f;
    [Range(0.0f, 3.0f)] 
    public float saturation = 1.0f;
    [Range(0.0f, 3.0f)] 
    public float contrast = 1.0f;

    // 每当OnRenderImage函数被调用时，它会检查材质是否可用。如果可用，就把参数传递给材质，再调用Graphics.Blit进行处理；否则，直接把原图像显示到屏幕上，不做任何处理
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (material != null)
        {
            material.SetFloat("_Brightness", brightness);
            material.SetFloat("_Saturation", saturation);
            material.SetFloat("_Contrast", contrast);
            // 使用着色器将源纹理复制到目标渲染纹理
            Graphics.Blit(src, dest, material);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }



}
