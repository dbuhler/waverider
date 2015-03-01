#include "waveio.h"

EXPORT void CALLBACK SendWaveMsg(HWND hwnd, UINT msg, PWAVEINFO pWaveInfo)
{
    SendMessage(hwnd, msg, (WPARAM)pWaveInfo, 0);
}


EXPORT LRESULT CALLBACK WaveProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
    static BOOL         bRecording, bPlaying, bPaused, bEnding, bTerminating;
    static HWAVEIN      hWaveIn;
    static HWAVEOUT     hWaveOut;
    static PBYTE        pBuffer1, pBuffer2, pNewBuffer;
    static PWAVEHDR     pWaveHdr1, pWaveHdr2;
    static WAVEFORMATEX waveform;
    static PWAVEINFO    pWaveInfo;
    static HANDLE       hEvent;


    switch (msg)
    {
        case WAV_INIT:

            // Allocate memory for wave header
            pWaveHdr1 = (PWAVEHDR) malloc(sizeof(WAVEHDR));
            pWaveHdr2 = (PWAVEHDR) malloc(sizeof(WAVEHDR));

            pWaveInfo = (PWAVEINFO) wParam;

            bRecording   = FALSE;
            bPlaying     = FALSE;
            bPaused      = FALSE;
            bEnding      = FALSE;
            bTerminating = FALSE;

            return 0;
        
        case WAV_TERM:

            if (bRecording)
            {
                bTerminating = TRUE;
                bEnding      = TRUE;
                waveInReset(hWaveIn);
                return 0;
            }

            if (bPlaying)
            {
                bTerminating = TRUE;
                bEnding      = TRUE;
                waveOutReset(hWaveOut);
                return 0;
            }

            free(pWaveHdr1);
            free(pWaveHdr2);
            return 0;
        
        case WAV_RECORD_BEG:

            // Allocate buffer memory
            pBuffer1 = (PBYTE) malloc(INP_BUFFER_SIZE);
            pBuffer2 = (PBYTE) malloc(INP_BUFFER_SIZE);

            if (!pBuffer1 || !pBuffer2)
            {
                // Allocating buffer memory failed
                if (pBuffer1) free(pBuffer1);
                if (pBuffer2) free(pBuffer2);
                return 1;
            }

            // Open waveform audio for input
            waveform.wFormatTag      = WAVE_FORMAT_PCM;
            waveform.nChannels       = pWaveInfo->wChannels;
            waveform.nSamplesPerSec  = pWaveInfo->dwSamplingRate;
            waveform.nAvgBytesPerSec = pWaveInfo->wChannels * pWaveInfo->wBytesPerSample * pWaveInfo->dwSamplingRate;
            waveform.nBlockAlign     = pWaveInfo->wChannels * pWaveInfo->wBytesPerSample;
            waveform.wBitsPerSample  = 8 * pWaveInfo->wBytesPerSample;
            waveform.cbSize          = 0;

            hEvent = CreateEvent(NULL, FALSE, FALSE, TEXT("RecordingStopped"));

            if (waveInOpen(&hWaveIn, WAVE_MAPPER, &waveform, (DWORD) hwnd, 0, CALLBACK_WINDOW))
            {
                // Opening waveform audio failed
                free(pBuffer1);
                free(pBuffer2);
                return 1;
            }

            // Set up headers and prepare them
            pWaveHdr1->lpData          = (LPSTR) pBuffer1;
            pWaveHdr1->dwBufferLength  = INP_BUFFER_SIZE;
            pWaveHdr1->dwBytesRecorded = 0;
            pWaveHdr1->dwUser          = 0;
            pWaveHdr1->dwFlags         = 0;
            pWaveHdr1->dwLoops         = 1;
            pWaveHdr1->lpNext          = NULL;
            pWaveHdr1->reserved        = 0;

            waveInPrepareHeader(hWaveIn, pWaveHdr1, sizeof(WAVEHDR));

            pWaveHdr2->lpData          = (LPSTR) pBuffer2;
            pWaveHdr2->dwBufferLength  = INP_BUFFER_SIZE;
            pWaveHdr2->dwBytesRecorded = 0;
            pWaveHdr2->dwUser          = 0;
            pWaveHdr2->dwFlags         = 0;
            pWaveHdr2->dwLoops         = 1;
            pWaveHdr2->lpNext          = NULL;
            pWaveHdr2->reserved        = 0;

            waveInPrepareHeader(hWaveIn, pWaveHdr2, sizeof(WAVEHDR));

            return 0;

        case WAV_RECORD_END:
            
            // Reset input to return last buffer
            bEnding = TRUE;
            waveInReset(hWaveIn);
            return 0;

        case WAV_PLAY_BEG:

            // Open waveform audio for output
            waveform.wFormatTag      = WAVE_FORMAT_PCM;
            waveform.nChannels       = pWaveInfo->wChannels;
            waveform.nSamplesPerSec  = pWaveInfo->dwSamplingRate;
            waveform.nAvgBytesPerSec = pWaveInfo->wChannels * pWaveInfo->wBytesPerSample * pWaveInfo->dwSamplingRate;
            waveform.nBlockAlign     = pWaveInfo->wChannels * pWaveInfo->wBytesPerSample;
            waveform.wBitsPerSample  = 8 * pWaveInfo->wBytesPerSample;
            waveform.cbSize          = 0;

            if (waveOutOpen(&hWaveOut, WAVE_MAPPER, &waveform, (DWORD) hwnd, 0, CALLBACK_WINDOW))
            {
                // Opening waveform audio failed
                return 1;
            }

            return 0;

        case WAV_PLAY_END:
                
            // Reset output for close preparation
            bEnding = TRUE;
            waveOutReset(hWaveOut);
            return 0;

        case WAV_PLAY_PAUSE:

            // Pause or restart output
            if (!bPaused)
            {
                waveOutPause(hWaveOut);
                bPaused = TRUE;
            }
            else
            {
                waveOutRestart(hWaveOut) ;
                bPaused = FALSE;
            }

            return 0;

        case MM_WIM_OPEN:

            // Shrink down the save buffer
            pWaveInfo->pSaveBuffer = (PBYTE) realloc(
                pWaveInfo->pSaveBuffer,
                pWaveInfo->wBytesPerSample * sizeof(BYTE));

            // Add the buffers
            waveInAddBuffer(hWaveIn, pWaveHdr1, sizeof(WAVEHDR));
            waveInAddBuffer(hWaveIn, pWaveHdr2, sizeof(WAVEHDR));

            // Begin sampling
            bRecording = TRUE;
            bEnding    = FALSE;
            pWaveInfo->dwDataLength = 0;
            waveInStart(hWaveIn);
            return 0;

        case MM_WIM_DATA:

            // Reallocate save buffer memory
            pNewBuffer = (PBYTE) realloc(
                pWaveInfo->pSaveBuffer,
                (pWaveInfo->dwDataLength + ((PWAVEHDR) lParam)->dwBytesRecorded) * sizeof(BYTE));
            

            if (pNewBuffer == NULL)
            {
                // Reallocating save buffer memory failed
                waveInClose(hWaveIn);
                return 1;
            }

            pWaveInfo->pSaveBuffer = pNewBuffer;
            CopyMemory(pWaveInfo->pSaveBuffer + pWaveInfo->dwDataLength,
                ((PWAVEHDR) lParam)->lpData,
                ((PWAVEHDR) lParam)->dwBytesRecorded);

            pWaveInfo->dwDataLength += ((PWAVEHDR) lParam)->dwBytesRecorded;

            if (bEnding)
            {
                waveInClose(hWaveIn);
                return 0;
            }

            // Send out a new buffer
            waveInAddBuffer(hWaveIn, (PWAVEHDR) lParam, sizeof(WAVEHDR));
            return 0;

        case MM_WIM_CLOSE:

            // Free the buffer memory
            waveInUnprepareHeader(hWaveIn, pWaveHdr1, sizeof(WAVEHDR));
            waveInUnprepareHeader(hWaveIn, pWaveHdr2, sizeof(WAVEHDR));

            free(pBuffer1);
            free(pBuffer2);

            bRecording = FALSE;
            SetEvent(hEvent);

            if (bTerminating)
            {
                SendMessage(hwnd, WAV_TERM, 0, 0);
            }

            return 0;

        case MM_WOM_OPEN:

            // Set up header
            pWaveHdr1->lpData          = (LPSTR) pWaveInfo->pSaveBuffer;
            pWaveHdr1->dwBufferLength  = pWaveInfo->dwDataLength;
            pWaveHdr1->dwBytesRecorded = 0;
            pWaveHdr1->dwUser          = 0;
            pWaveHdr1->dwFlags         = WHDR_BEGINLOOP | WHDR_ENDLOOP;
            pWaveHdr1->dwLoops         = 1;
            pWaveHdr1->lpNext          = NULL;
            pWaveHdr1->reserved        = 0;

            // Prepare and write
            waveOutPrepareHeader(hWaveOut, pWaveHdr1, sizeof(WAVEHDR));
            waveOutWrite(hWaveOut, pWaveHdr1, sizeof(WAVEHDR));

            bEnding  = FALSE;
            bPlaying = TRUE;
            return 0;

        case MM_WOM_DONE:

            waveOutUnprepareHeader(hWaveOut, pWaveHdr1, sizeof(WAVEHDR));
            waveOutClose(hWaveOut);
            return 0;

        case MM_WOM_CLOSE:

            bPlaying = FALSE;

            if (bTerminating)
            {
                SendMessage(hwnd, WAV_TERM, 0, 0);
            }

            return 0;
    }

    return 0;
}