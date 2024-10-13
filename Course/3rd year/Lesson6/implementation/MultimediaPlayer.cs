namespace Lesson6;
public class MultimediaPlayer : IMultimediaPlayer
{
    public string path {get;set;}


    public MultimediaPlayer() { }
    public MultimediaPlayer(string p) 
    {
        this.path = p;
    }

    public void PlayVideo(string path)
    {
        Console.WriteLine($"Видео из файла {this.path} воспроизводится");
    }
    public void PlayAudio(string path)
    {
        Console.WriteLine($"Звук из файла {this.path} воспроизводится");
    }
    public void PlayFile()
    {
        int position = this.path.IndexOf(".");
        string type = this.path.Substring(position + 1);
        switch(type)
        {
            case("mp4"):
            case("avi"):
                PlayVideo(path);
                break;
            case("mp3"):
            case("aac"):
                PlayAudio(path);
                break;
            default:
                Console.WriteLine("Ошибка воспроизведения: неизвестный тип файла.");
                break;
        }
    }
}