namespace Lesson6;
public interface IMultimediaPlayer : IAudioPlayer, IVideoPlayer
{
    public abstract void PlayVideo(string path);
    public abstract void PlayAudio(string path);
    public abstract void PlayFile();
}