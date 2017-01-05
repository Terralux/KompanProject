// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.27 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.27;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-2662-OUT,custl-5160-OUT,clip-498-A,voffset-7978-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32029,y:32729,ptovrint:False,ptlb:ColorTint,ptin:_ColorTint,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:498,x:32061,y:32555,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_498,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e127470452cf4714f9e81796087c98a7,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2662,x:32405,y:32645,varname:node_2662,prsc:2|A-498-RGB,B-7241-RGB;n:type:ShaderForge.SFN_TexCoord,id:2936,x:31392,y:33395,varname:node_2936,prsc:2,uv:0;n:type:ShaderForge.SFN_VertexColor,id:2338,x:32230,y:32943,varname:node_2338,prsc:2;n:type:ShaderForge.SFN_Time,id:1468,x:31451,y:33564,varname:node_1468,prsc:2;n:type:ShaderForge.SFN_Cos,id:1350,x:31611,y:33574,varname:node_1350,prsc:2|IN-1468-T;n:type:ShaderForge.SFN_OneMinus,id:6776,x:31576,y:33395,varname:node_6776,prsc:2|IN-2936-V;n:type:ShaderForge.SFN_Multiply,id:8605,x:31968,y:33339,varname:node_8605,prsc:2|A-6485-OUT,B-5573-OUT;n:type:ShaderForge.SFN_Multiply,id:7978,x:32509,y:33063,varname:node_7978,prsc:2|A-2338-R,B-6941-OUT;n:type:ShaderForge.SFN_Slider,id:6485,x:31392,y:33210,ptovrint:False,ptlb:Intensity,ptin:_Intensity,varname:node_6485,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Multiply,id:5573,x:31795,y:33436,varname:node_5573,prsc:2|A-6776-OUT,B-1350-OUT;n:type:ShaderForge.SFN_Append,id:6941,x:32330,y:33216,varname:node_6941,prsc:2|A-5517-OUT,B-1822-OUT;n:type:ShaderForge.SFN_Slider,id:6629,x:32018,y:33592,ptovrint:False,ptlb:VerticalMovement,ptin:_VerticalMovement,varname:node_6629,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.05,max:5;n:type:ShaderForge.SFN_Multiply,id:1822,x:32175,y:33321,varname:node_1822,prsc:2|A-8605-OUT,B-6629-OUT;n:type:ShaderForge.SFN_Slider,id:7822,x:31723,y:33159,ptovrint:False,ptlb:HorizontalMovement,ptin:_HorizontalMovement,varname:_VerticalMovement_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:5;n:type:ShaderForge.SFN_Multiply,id:5517,x:32135,y:33184,varname:node_5517,prsc:2|A-8605-OUT,B-7822-OUT;n:type:ShaderForge.SFN_LightVector,id:4437,x:30941,y:32632,varname:node_4437,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2349,x:30926,y:32764,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:1548,x:31131,y:32697,cmnt:Lambert,varname:node_1548,prsc:2,dt:1|A-4437-OUT,B-2349-OUT;n:type:ShaderForge.SFN_If,id:6098,x:31647,y:32671,varname:node_6098,prsc:2|A-953-OUT,B-5882-OUT,GT-953-OUT,EQ-953-OUT,LT-7831-RGB;n:type:ShaderForge.SFN_ValueProperty,id:5882,x:31259,y:32805,ptovrint:False,ptlb:LightCutoff,ptin:_LightCutoff,varname:node_8366,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.54;n:type:ShaderForge.SFN_Subtract,id:5160,x:31856,y:32699,varname:node_5160,prsc:2|A-6098-OUT,B-3123-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3123,x:31647,y:32853,ptovrint:False,ptlb:LightSubtraction,ptin:_LightSubtraction,varname:node_1877,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.67;n:type:ShaderForge.SFN_LightAttenuation,id:4059,x:30896,y:32485,varname:node_4059,prsc:2;n:type:ShaderForge.SFN_Multiply,id:953,x:31310,y:32631,varname:node_953,prsc:2|A-4392-OUT,B-1548-OUT;n:type:ShaderForge.SFN_LightColor,id:7702,x:30878,y:32369,varname:node_7702,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4392,x:31096,y:32456,varname:node_4392,prsc:2|A-7702-RGB,B-4059-OUT;n:type:ShaderForge.SFN_Color,id:7831,x:31353,y:32965,ptovrint:False,ptlb:ShadowColor,ptin:_ShadowColor,varname:node_4264,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1539792,c2:0.1574306,c3:0.6544118,c4:1;proporder:7241-498-6485-6629-7822-5882-3123-7831;pass:END;sub:END;*/

Shader "Nima/GrassShader" {
    Properties {
        _ColorTint ("ColorTint", Color) = (1,1,1,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _Intensity ("Intensity", Range(0, 5)) = 1
        _VerticalMovement ("VerticalMovement", Range(0, 5)) = 0.05
        _HorizontalMovement ("HorizontalMovement", Range(0, 5)) = 0.5
        _LightCutoff ("LightCutoff", Float ) = 0.54
        _LightSubtraction ("LightSubtraction", Float ) = 0.67
        _ShadowColor ("ShadowColor", Color) = (0.1539792,0.1574306,0.6544118,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _ColorTint;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Intensity;
            uniform float _VerticalMovement;
            uniform float _HorizontalMovement;
            uniform float _LightCutoff;
            uniform float _LightSubtraction;
            uniform float4 _ShadowColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_1468 = _Time + _TimeEditor;
                float node_8605 = (_Intensity*((1.0 - o.uv0.g)*cos(node_1468.g)));
                v.vertex.xyz += float3((o.vertexColor.r*float2((node_8605*_HorizontalMovement),(node_8605*_VerticalMovement))),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(_MainTex_var.a - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float3 emissive = (_MainTex_var.rgb*_ColorTint.rgb);
                float3 node_953 = ((_LightColor0.rgb*attenuation)*max(0,dot(lightDirection,normalDirection)));
                float node_6098_if_leA = step(node_953,_LightCutoff);
                float node_6098_if_leB = step(_LightCutoff,node_953);
                float3 finalColor = emissive + (lerp((node_6098_if_leA*_ShadowColor.rgb)+(node_6098_if_leB*node_953),node_953,node_6098_if_leA*node_6098_if_leB)-_LightSubtraction);
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _ColorTint;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Intensity;
            uniform float _VerticalMovement;
            uniform float _HorizontalMovement;
            uniform float _LightCutoff;
            uniform float _LightSubtraction;
            uniform float4 _ShadowColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_1468 = _Time + _TimeEditor;
                float node_8605 = (_Intensity*((1.0 - o.uv0.g)*cos(node_1468.g)));
                v.vertex.xyz += float3((o.vertexColor.r*float2((node_8605*_HorizontalMovement),(node_8605*_VerticalMovement))),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(_MainTex_var.a - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 node_953 = ((_LightColor0.rgb*attenuation)*max(0,dot(lightDirection,normalDirection)));
                float node_6098_if_leA = step(node_953,_LightCutoff);
                float node_6098_if_leB = step(_LightCutoff,node_953);
                float3 finalColor = (lerp((node_6098_if_leA*_ShadowColor.rgb)+(node_6098_if_leB*node_953),node_953,node_6098_if_leA*node_6098_if_leB)-_LightSubtraction);
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Intensity;
            uniform float _VerticalMovement;
            uniform float _HorizontalMovement;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                float4 node_1468 = _Time + _TimeEditor;
                float node_8605 = (_Intensity*((1.0 - o.uv0.g)*cos(node_1468.g)));
                v.vertex.xyz += float3((o.vertexColor.r*float2((node_8605*_HorizontalMovement),(node_8605*_VerticalMovement))),0.0);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(_MainTex_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
