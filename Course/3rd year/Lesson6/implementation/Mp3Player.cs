namespace Lesson6;

public class Mp3Player : IAudioPlayer
{
    public void PlayAudio(string path)
    {
        Console.WriteLine($"Аудио из файла {path} воспроизводится");
    }
}