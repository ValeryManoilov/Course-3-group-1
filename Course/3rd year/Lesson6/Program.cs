// See https://aka.ms/new-console-template for more information
namespace Lesson6;
public class Program
{
    static void Main(string[] args)
    {
        string VideoPath = "monkeyjump.mp4";
        string AudioPath = "asmrcoding.mp3";
        string RandomPath1 = "bulldogsdance.avi";
        string RandomPath2 = "minecraftscarynoise.aac";
        string RandomPath3 = "Курсовая.doc";

        // Тест 1
        IVideoPlayer Videoplayer = new AviPlayer();
        Videoplayer.PlayVideo(VideoPath);

        // Тест 2
        IAudioPlayer Audioplayer = new Mp3Player();
        Audioplayer.PlayAudio(AudioPath);

        // Тест 3
        string path = "monkey.mp4";

        IMultimediaPlayer player1 = new MultimediaPlayer(RandomPath1);
        player1.PlayFile();

        IMultimediaPlayer player2 = new MultimediaPlayer(RandomPath2);
        player2.PlayFile();

        IMultimediaPlayer player3 = new MultimediaPlayer(RandomPath3);
        player3.PlayFile();
    }
}