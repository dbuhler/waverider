#ifndef WAVEIO_H
#define WAVEIO_H

#include <windows.h>

#ifdef __cplusplus
#define EXPORT extern "C" __declspec (dllexport)
#else
#define EXPORT __declspec (dllexport)
#endif

#define INP_BUFFER_SIZE 32768

#define WAV_INIT        WM_USER + 0
#define WAV_TERM        WM_USER + 1
#define WAV_RECORD_BEG  WM_USER + 2
#define WAV_RECORD_END  WM_USER + 3
#define WAV_PLAY_BEG    WM_USER + 4
#define WAV_PLAY_END    WM_USER + 5
#define WAV_PLAY_PAUSE  WM_USER + 6

typedef struct WaveInfo
{
    DWORD dwSamplingRate;
    WORD  wBytesPerSample;
    WORD  wChannels;
    DWORD dwDataLength;
    PBYTE pSaveBuffer;
} WAVEINFO, *PWAVEINFO;

EXPORT LRESULT CALLBACK WaveProc(HWND, UINT, WPARAM, LPARAM);
EXPORT void CALLBACK SendWaveMsg(HWND, UINT, PWAVEINFO);

#endif