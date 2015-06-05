using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace audio
{
    public class audio
    {
        public static WAVEHDR whdr;
        public static WAVEFORMAT format_wave;
        public static WAVEHDR outHdr;
        public static int bufferIn;
        public static int numSamples;
        public static int hWaveOut;
        public const short MMIO_READ = 0x0;
        public const int CALLBACK_FUNCTION = 0x30000;
        public const short WAVE_MAPPED = 0x4;
        public const short MMIO_FINDCHUNK = 0x10;
        public const short MMIO_FINDRIFF = 0x20;
        public const short MM_WOM_DONE = 0x3BD;
        public struct MMCKINFO
        {
            public int ckid;
            public int ckSize;
            public int fccType;
            public int dwDataOffset;
            public int dwFlags;
        }
        public struct mmioinfo
        {
            public int dwFlags;
            public int fccIOProc;
            public int pIOProc;
            public int wErrorRet;
            public int htask;
            public int cchBuffer;
            public string pchBuffer;
            public string pchNext;
            public string pchEndRead;
            public string pchEndWrite;
            public int lBufOffset;
            public int lDiskOffset;
            public string adwInfo;
            public int dwReserved1;
            public int dwReserved2;
            public int hmmio;
        }
        public struct WAVEFORMAT
        {
            public short wFormatTag;
            public short nChannels;
            public int nSamplesPerSec;
            public int nAvgBytesPerSec;
            public short nBlockAlign;
            public short wBitsPerSample;
            public short cbSize;
        }
        public struct WAVEHDR
        {
            public int lpData;
            public int dwBufferLength;
            public int dwBytesRecorded;
            public int dwUser;
            public int dwFlags;
            public int dwLoops;
            public int lpNext;
            public int Reserved;
        }
        public delegate void waveOutProcCallBack(int hwo, int uMsg, int dwInstance, int dwParam1, int dwParam2);
        public static void waveOutProc(int hwo, int uMsg, int dwInstance, int dwParam1, int dwParam2)
        {
            switch (uMsg)
            {
                case MM_WOM_DONE:
                    
                    WaveOutOpen_1.Form1.showMsg("Play Stopped");
                    Free();
                    break;
                default:
                   // WaveOutOpen_1.Form1.showMsg("Play");
                    break;

            }
        }
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int waveOutPause(int hwo);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int waveOutRestart(int hwo);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int waveOutReset(int hwo);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int waveOutUnprepareHeader(int hWaveIn,
        ref WAVEHDR lpWaveInHdr, int uSize);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int waveOutClose(int hwo);

        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int waveOutWrite(int hWaveOut,
        ref WAVEHDR lpWaveOutHdr, int uSize);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int waveOutPrepareHeader(int hWaveIn,
        ref WAVEHDR lpWaveInHdr, int uSize);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int mmioRead(int hmmio,
        int pch, int cch);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int waveOutOpen(ref int lphWaveIn,
            int uDeviceID, ref WAVEFORMAT lpFormat,
            waveOutProcCallBack dwCallback,int dwInstance,
            int dwFlags);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GlobalAlloc(int wFlags, int
        dwBytes);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GlobalLock(int hmem);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int mmioAscend(int hmmio, ref MMCKINFO
        lpck, int uFlags);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GlobalFree(int hmem);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int mmioOpenA(string szFileName, ref
mmioinfo lpmmioinfo, int dwOpenFlags);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int mmioDescend(int hmmio, ref MMCKINFO
        lpck, int x, int uFlags);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int mmioRead(int hmmio, ref WAVEFORMAT
        pch, int cch);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int mmioClose(int hmmio, int uFlags);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int mmioStringToFOURCCA(string sz, int
        uFlags);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int mmioDescend(int hmmio, ref MMCKINFO
        lpck, ref MMCKINFO lpckParent, int uFlags);

        public static void LoadFile(ref string inFile)
        {
            int hmem = 0;
            MMCKINFO mmckinfoParentIn = new MMCKINFO();
            MMCKINFO mmckinfoSubchunkIn = new MMCKINFO();
            int hmmioIn = 0;
            mmioinfo mmioinf = new mmioinfo();
            mmioinf.adwInfo =
            (new StringBuilder()).Append(' ', 4).ToString();
            hmmioIn = mmioOpenA(inFile, ref mmioinf, MMIO_READ);
            if (hmmioIn == 0) return;
            mmioDescend(hmmioIn, ref mmckinfoParentIn, 0,
            MMIO_FINDRIFF);
            mmckinfoSubchunkIn.ckid = mmioStringToFOURCCA("fmt", 0);
            mmioDescend(hmmioIn, ref mmckinfoSubchunkIn,
            ref mmckinfoParentIn, MMIO_FINDCHUNK);
            mmioRead(hmmioIn, ref format_wave,
            Marshal.SizeOf(format_wave));
            mmioAscend(hmmioIn, ref mmckinfoSubchunkIn, 0);
            mmckinfoSubchunkIn.ckid = mmioStringToFOURCCA("data", 0);
            mmioDescend(hmmioIn, ref mmckinfoSubchunkIn,
            ref mmckinfoParentIn,
            MMIO_FINDCHUNK);
            GlobalFree(hmem);
            hmem = GlobalAlloc(0x40, mmckinfoSubchunkIn.ckSize);
            bufferIn = GlobalLock(hmem);
            mmioRead(hmmioIn, bufferIn, mmckinfoSubchunkIn.ckSize);
            numSamples =mmckinfoSubchunkIn.ckSize / format_wave.nBlockAlign;
            mmioClose(hmmioIn, 0);
        }
        public static void Play(short soundcard)
        {
            waveOutProcCallBack call = new waveOutProcCallBack(waveOutProc);

            int rc = 0;
            int lFlags = 0;
            lFlags = CALLBACK_FUNCTION;
            if (soundcard != -1) lFlags = lFlags | WAVE_MAPPED;
            rc = waveOutOpen(ref hWaveOut, soundcard,
            ref format_wave, call, 0, lFlags);
            if (rc != 0) return;
            outHdr.lpData = bufferIn;
            outHdr.dwBufferLength =
            numSamples * format_wave.nBlockAlign;
            outHdr.dwFlags = 0;
            outHdr.dwLoops = 0;
            waveOutPrepareHeader(hWaveOut, ref outHdr,
            Marshal.SizeOf(outHdr));
            waveOutWrite(hWaveOut, ref outHdr, Marshal.SizeOf(outHdr));
        }
       /* public static void Play(short soundcard,IntPtr handle)
        {
            int rc = 0;
            int lFlags = 0;
            lFlags = CALLBACK_FUNCTION;
            if (soundcard != -1) lFlags = lFlags | WAVE_MAPPED;
            rc = waveOutOpen(ref hWaveOut, soundcard,
            ref format_wave, handle, 0, lFlags);
            if (rc != 0) return;
            outHdr.lpData = bufferIn;
            outHdr.dwBufferLength =
            numSamples * format_wave.nBlockAlign;
            outHdr.dwFlags = 0;
            outHdr.dwLoops = 0;
            waveOutPrepareHeader(hWaveOut, ref outHdr,
            Marshal.SizeOf(outHdr));
            waveOutWrite(hWaveOut, ref outHdr, Marshal.SizeOf(outHdr));
        }*/
        public static void Pause()
        {
            waveOutPause(hWaveOut);
        }
        public static void Resume()
        {
            waveOutRestart(hWaveOut);
        }
        public static void Stop()
        {
            waveOutReset(hWaveOut);
        }
        public static void Free()
        {
            waveOutUnprepareHeader(hWaveOut, ref outHdr,
            Marshal.SizeOf(outHdr));
            waveOutClose(hWaveOut);
        }
    }
}