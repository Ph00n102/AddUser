using System;
using Microsoft.JSInterop;

namespace HosxpUi.Pages.MusicPad;

public class SoundPlayer : ISoundPlayer
{
    private readonly IJSRuntime _jSRuntime;
    private const string JSFUNCTION = "playaudio";

    public SoundPlayer(IJSRuntime jSRuntime)
    {
        _jSRuntime = jSRuntime;
    }
    public async Task Play(string sound, string pressedPadId)
    {
        if (string.IsNullOrEmpty(sound)) return;
            await _jSRuntime.InvokeVoidAsync(JSFUNCTION, sound, pressedPadId);
    }
}
