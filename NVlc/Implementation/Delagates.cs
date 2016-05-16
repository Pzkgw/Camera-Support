﻿
using System;
using System.Runtime.InteropServices;
using LibVlcWrapper;

namespace Implementation
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void VlcEventHandlerDelegate(ref libvlc_event_t libvlc_event, IntPtr userData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate void* LockEventHandler(void* opaque, void** plane);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate void UnlockEventHandler(void* opaque, void* picture, void** plane);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate void DisplayEventHandler(void* opaque, void* picture);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate void* CallbackEventHandler(void* data);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate int VideoFormatCallback(void** opaque, char* chroma, int* width, int* height, int* pitches, int* lines);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate void CleanupCallback(void* opaque);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate void PlayCallbackEventHandler(void* data, void* samples, uint count, long pts);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate void VolumeCallbackEventHandler(void* data, float volume, bool mute);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate int SetupCallbackEventHandler(void** data, char* format, int* rate, int* channels);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate void AudioCallbackEventHandler(void* data, long pts);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate void AudioDrainCallbackEventHandler(void* data);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate int ImemGet(void* data, char* cookie, long* dts, long* pts, int* flags, uint* dataSize, void** ppData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate void ImemRelease(void* data, char* cookie, uint dataSize, void* pData); 

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate void LogCallback(void* data, libvlc_log_level level, void* ctx, char* fmt, char* args);
}
