bool IsStereoEyeLeft(float3 WorldCamPos, float3 WorldCamRight, float force)
{
	if(force >= 0){
		return force == 0;
	}
#if defined(USING_STEREO_MATRICES)
	// Unity 5.4 has this new variable
	return (unity_StereoEyeIndex == 0);
#elif defined (UNITY_DECLARE_MULTIVIEW)
	// OVR_multiview extension
	return (UNITY_VIEWID == 0);
#else
	// NOTE: Bug #1165: _WorldSpaceCameraPos is not correct in multipass VR (when skybox is used) but UNITY_MATRIX_I_V seems to be
	#if defined(UNITY_MATRIX_I_V)
		float3 renderCameraPos = UNITY_MATRIX_I_V._m03_m13_m23;
	#else
		float3 renderCameraPos = _WorldSpaceCameraPos.xyz;
	#endif

	float fL = distance(WorldCamPos - WorldCamRight, renderCameraPos);
	float fR = distance(WorldCamPos + WorldCamRight, renderCameraPos);
	return (fL < fR);
#endif
}

void StereoSwitch_half(float3 WorldCameraPosition, float3 WorldCameraRight, float Force, float4 Left, float4 Right, out float4 Out) {
	Out = Left;
	if (IsStereoEyeLeft(WorldCameraPosition, WorldCameraRight, Force)){
	  Out = Left;
	}
	else {
	  Out = Right;
	}
}
void StereoSwitch_float(float3 WorldCameraPosition, float3 WorldCameraRight, float Force, float4 Left, float4 Right, out float4 Out) {
	Out = Left;
	if (IsStereoEyeLeft(WorldCameraPosition, WorldCameraRight, Force)){
	  Out = Left;
	}
	else {
	  Out = Right;
	}
}