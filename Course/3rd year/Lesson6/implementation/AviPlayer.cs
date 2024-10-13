namespace Lesson6;

public class AviPlayer : IVideoPlayer
{
    public void PlayVideo(string path)
    {
        Console.WriteLine($"Видео из файла {path} воспроизводится");
    }
}