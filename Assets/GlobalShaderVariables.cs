using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GlobalShaderVariables : MonoBehaviour 
{
    public GameObject deathStar;

    private void OnPreRender()
    {
        //The camera positions we need to determines the global position of the shader
        Shader.SetGlobalVector("_CamPos",     this.transform.position);
        Shader.SetGlobalVector("_CamRight",   this.transform.right);
        Shader.SetGlobalVector("_CamUp",      this.transform.up);
        Shader.SetGlobalVector("_CamForward", this.transform.forward);

        //The position of the death star
        Shader.SetGlobalVector("_StarPos", deathStar.transform.position);
    }
}

