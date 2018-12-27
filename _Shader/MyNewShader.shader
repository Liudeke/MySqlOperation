// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "MyNewShader"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_TextureSample2("Texture Sample 2", 2D) = "bump" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "Amplify" = "True"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.5
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _TextureSample2;
		uniform float4 _TextureSample2_ST;
		uniform sampler2D _TextureSample0;
		uniform float4 _TextureSample0_ST;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_TextureSample2 = i.uv_texcoord * _TextureSample2_ST.xy + _TextureSample2_ST.zw;
			o.Normal = UnpackNormal( tex2D( _TextureSample2,uv_TextureSample2) );
			float2 uv_TextureSample0 = i.uv_texcoord * _TextureSample0_ST.xy + _TextureSample0_ST.zw;
			o.Albedo = tex2D( _TextureSample0,uv_TextureSample0).xyz;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=5105
272;160;993;692;504;319;1;False;False
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;72,-245;Float;False;True;3;Float;ASEMaterialInspector;Standard;MyNewShader;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;Opaque;0.5;True;True;0;False;Opaque;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;13;OBJECT;0.0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False
Node;AmplifyShaderEditor.TextureArrayNode;3;-127,209;Float;False;Property;_TextureArray0;Texture Array 0;1;0;None;0;Object;-1;Auto;0;FLOAT2;0,0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False
Node;AmplifyShaderEditor.TexturePropertyNode;4;-501,32;Float;True;Property;_Texture0;Texture 0;2;0;Assets/AmplifyShaderEditor/Examples/Assets/Textures/Rock/rock_d.tif;False;white;Auto
Node;AmplifyShaderEditor.SamplerNode;1;-339,-199;Float;True;Property;_TextureSample0;Texture Sample 0;0;0;Assets/AmplifyShaderEditor/Examples/Assets/Textures/Rock/rock_d.tif;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False
Node;AmplifyShaderEditor.SamplerNode;7;-349,14;Float;True;Property;_TextureSample2;Texture Sample 2;3;0;Assets/AmplifyShaderEditor/Examples/Assets/Textures/Rock/rock_n.jpg;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False
WireConnection;0;0;1;0
WireConnection;0;1;7;0
ASEEND*/
//CHKSM=D805C8EBAC8706C0FAA32A91097EB03B163B8A53