using System;

namespace HosxpUi.Pages.MusicPad;

public interface ISoundPlayer
{
    Task Play(string sound, string pressedPadId);
}
